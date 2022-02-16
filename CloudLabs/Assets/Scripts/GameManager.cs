using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public JsonManager jsonMnager;

    public GameObject pref_student;
    [SerializeField] private Transform go_parentList;
    [SerializeField] private Color m_color, m_colorVariation;
    [SerializeField] private GameObject btn_calificar;
    [SerializeField] private GameObject btn_volver;
        
        
    [SerializeField] private GameObject scrn_alerta;
    [SerializeField] private TMP_Text txt_alerta;
    public List<StudentData> students;
    private int errorCalification;


    [SerializeField] private GameObject pref_dragStudent;
    public Transform dragParent;
    public Transform drgaNeutralZone;
    public List<StudentDrag> dragStudents;
    [SerializeField] private GameObject finalScreen;

    [SerializeField] private GameObject[] screens;
    [SerializeField] private Scrollbar _scrollbar;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        btn_volver.SetActive(false);
        btn_calificar.SetActive(false);
        scrn_alerta.SetActive(false);
        finalScreen.SetActive(false);
        ScreenSelection(0);
    }

    public void CreateStudents()
    {
        students = new List<StudentData>();
        for (int i = 0; i < jsonMnager.m_students.Count; i++)
        {
            GameObject go = Instantiate(pref_student, go_parentList);
            StudentData studentData = go.GetComponent<StudentData>();
            studentData.CreateStudentData(jsonMnager.m_students[i], i % 2 == 0 ? m_color : m_colorVariation);
            go.gameObject.name = $"Student_{studentData.nombre}";
            students.Add(studentData);
        }

        btn_calificar.SetActive(true);
    }

    public void ComprobarCalificaciones()
    {
        errorCalification = 0;
        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].notaFinal < 3f && students[i].esAprobado ||
                students[i].notaFinal >= 3f && !students[i].esAprobado)
            {
                errorCalification++;
            }
        }

        if (errorCalification > 0)
        {
            ShowWarning();
        }
        else
        {
            for (int i = 0; i < students.Count; i++)
            {
                students[i].tog_esAprobado.enabled = false;
            }

            CreateDragStudents();
        }
    }

    void ShowWarning()
    {
        txt_alerta.text = $"Se han encontrado {errorCalification} irregularidades, corrigelas para continuar.";
        scrn_alerta.SetActive(true);
    }

    void CreateDragStudents()
    {
        dragStudents = new List<StudentDrag>();
        for (int i = 0; i < students.Count; i++)
        {
            GameObject go = Instantiate(pref_dragStudent, drgaNeutralZone);
            StudentDrag studentDrag = go.GetComponent<StudentDrag>();
            studentDrag.CreateStudentDrag(students[i].nombre, students[i].apellido);
            go.gameObject.name = $"StudentDrag_{students[i].nombre}";
            dragStudents.Add(studentDrag);
        }
        
        ScreenSelection(2);
        btn_volver.SetActive(true);
        btn_calificar.SetActive(false);
    }

    public void RevisarDragStudents()
    {
        if (drgaNeutralZone.childCount == 0)
        {
            errorCalification = 0;
            for (int i = 0; i < dragStudents.Count; i++)
            {
                if (dragStudents[i].actualState == StudentState.Aprobado && !students[i].esAprobado ||
                    dragStudents[i].actualState == StudentState.Reprobado && students[i].esAprobado)
                {
                    errorCalification++;
                }
            }
            
            if (errorCalification > 0)
            {
                ShowWarning();
            }
            else
            {
                finalScreen.SetActive(true);
            }
        }
    }
    
    public void ScreenSelection(int index)
    {
        for (int i = 0; i < screens.Length; i++)
        {
            if (i == index)
            {
                screens[index].SetActive(true);
                _scrollbar.value = 1;
            }
            else
            {
                screens[i].SetActive(false);
            }
        }
    }

    public void IrComienzo()
    {
        for (int i = 0; i < students.Count; i++)
        {
            Destroy(students[i].gameObject);
        }
        students.Clear();
        students = new List<StudentData>();

        for (int i = 0; i < dragStudents.Count; i++)
        {
            Destroy(dragStudents[i].gameObject);
        }
        dragStudents.Clear();
        dragStudents = new List<StudentDrag>();
        btn_volver.SetActive(false);
        ScreenSelection(0);
    }

    public void Salir()
    {
        Application.Quit();
    }
}

public enum StudentState
{
    Aprobado,
    Reprobado,
    Neutro
}