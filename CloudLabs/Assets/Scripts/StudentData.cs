using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StudentData : MonoBehaviour
{
    public string nombre;
    public string apellido;
    public string codigo;
    public string correo;
    public float notaFinal;
    public bool esAprobado = false;

    [SerializeField] private TMP_Text txt_nombre;
    [SerializeField] private TMP_Text txt_apellido;
    [SerializeField] private TMP_Text txt_codigo;
    [SerializeField] private TMP_Text txt_correo;
    [SerializeField] private TMP_Text txt_notaFinal;
    public Toggle tog_esAprobado;
    [SerializeField] private TMP_Text txt_esAprobado;
    [SerializeField] private Image img_background;

    public void CreateStudentData(Student student, Color m_color)
    {
        nombre = student.nombre;
        apellido = student.apellido;
        codigo = student.codigo;
        correo = student.correo;
        notaFinal = student.notaFinal;

        txt_nombre.text = nombre;
        txt_apellido.text = apellido;
        txt_codigo.text = codigo;
        txt_correo.text = correo;
        txt_notaFinal.text = notaFinal.ToString();

        img_background.color = m_color;
        SetCalification();
    }

    public void SetCalification()
    {
        if (tog_esAprobado.isOn)
        {
            esAprobado = true;
            txt_esAprobado.text = "Aprobado";
            txt_esAprobado.color = Color.green;
        }
        else
        {
            esAprobado = false;
            txt_esAprobado.text = "NO aprobado";
            txt_esAprobado.color = Color.red;
        }
    }
}
