using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class JsonManager : MonoBehaviour
{
    public string m_correoForm;
    public List<string> m_nombres;
    public List<string> m_apellidos;
    public int m_numberOfStudents;
    public string m_filenameJson;

    [SerializeField] public List<Student> m_students;


    public void LoadJson()
    {
        m_students = new List<Student>();
        m_students = FileHandler.ReadFromJson<Student>(m_filenameJson);
    }

    public void CreateJson()
    {
        m_students = new List<Student>();
        m_students = CreateStudents();
        FileHandler.SaveToJson<Student>(m_students, m_filenameJson);
    }

    private List<Student> CreateStudents()
    {
        var listStudents = from mNombre in m_nombres
            from mApellido in m_apellidos
            select new Student
            {
                nombre = mNombre, apellido = mApellido, correo = $"{mNombre}{mApellido}{m_correoForm}",
                codigo = Guid.NewGuid().ToString().Substring(25),
                notaFinal = (float) Math.Round(Random.Range(0.0f, 5.0f), 1)
            };
        return listStudents.OrderBy((st) => st.codigo).Take(m_numberOfStudents).ToList();
    }
}

[System.Serializable]
public class Student
{
    public string nombre;
    public string apellido;
    public string codigo;
    public string correo;
    public float notaFinal;
}