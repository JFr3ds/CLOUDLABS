using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class StudentDrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    public StudentState actualState = StudentState.Reprobado;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    [SerializeField] private TMP_Text txt_nombre;
    [SerializeField] private TMP_Text txt_apellido;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void CreateStudentDrag(string nombre, string apellido)
    {
        txt_nombre.text = nombre;
        txt_apellido.text = apellido;
        actualState = StudentState.Neutro;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        transform.parent = GameManager.Instance.dragParent;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<StudentDrag>() != null)
        {
            eventData.pointerDrag.transform.parent = transform.parent;
            eventData.pointerDrag.GetComponent<StudentDrag>().actualState = transform.GetComponentInParent<DragHotZone>().sendState;
            GameManager.Instance.RevisarDragStudents();
        }
    }
}