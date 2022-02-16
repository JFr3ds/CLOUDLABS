using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHotZone : MonoBehaviour, IDropHandler
{
    public Transform content;
    public StudentState sendState;
    
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<StudentDrag>() != null)
        {
            eventData.pointerDrag.transform.parent = content;
            eventData.pointerDrag.GetComponent<StudentDrag>().actualState = sendState;
            GameManager.Instance.RevisarDragStudents();
        }
    }
}
