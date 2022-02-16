using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JsonConfiguration : MonoBehaviour
{
    [SerializeField] private JsonManager jsonManager;
    
    public TMP_InputField input_nombre;
    public TMP_InputField input_apellido;
    public TMP_InputField input_correo;
    public TMP_InputField input_numEstudiantes;
    public TMP_InputField input_jsonNombre;

    [SerializeField]private List<string> nombresCreados;
    [SerializeField]private List<string> apellidosCreados;

    public void AgregarNombre()
    {
        if (string.IsNullOrEmpty(input_nombre.text))
        {
            return;
        }

        if (nombresCreados == null)
        {
            nombresCreados = new List<string>();
        }

        nombresCreados.Add(input_nombre.text);
        input_nombre.text = "";
    }

    public void AgregarApellido()
    {
        if (string.IsNullOrEmpty(input_apellido.text))
        {
            return;
        }

        if (apellidosCreados == null)
        {
            apellidosCreados = new List<string>();
        }
        
        apellidosCreados.Add(input_apellido.text);
        input_apellido.text = "";
    }

    public void ActualizarDominio()
    {
        if (string.IsNullOrEmpty(input_correo.text))
        {
            return;
        }

        jsonManager.m_correoForm = input_correo.text;
        input_correo.text = "";
    }

    public void ActualizarGrupoCantidad()
    {
        if (string.IsNullOrEmpty(input_numEstudiantes.text))
        {
            return;
        }

        jsonManager.m_numberOfStudents = System.Convert.ToInt32(input_numEstudiantes.text);
        input_numEstudiantes.text = "";
    }

    public void ActualizarJsonNombre()
    {
        if (string.IsNullOrEmpty(input_jsonNombre.text))
        {
            return;
        }

        jsonManager.m_filenameJson = input_jsonNombre.text;
        input_jsonNombre.text = "";
    }

    public void BorrarNombres()
    {
        nombresCreados.Clear();
        nombresCreados = new List<string>();
        input_nombre.text = "";
    }
    
    public void BorrarApellidos()
    {
        apellidosCreados.Clear();
        apellidosCreados = new List<string>();
        input_apellido.text = "";
    }

    public void CrearJson()
    {
        if (nombresCreados == null || nombresCreados.Count == 0 || apellidosCreados == null ||
            apellidosCreados.Count == 0)
        {
            return;
        }

        jsonManager.m_apellidos = apellidosCreados;
        jsonManager.m_nombres = nombresCreados;
        jsonManager.CreateJson();
        LaunchApp();
    }

    public void CargarJson()
    {
        jsonManager.LoadJson();
        LaunchApp();
    }

    void LaunchApp()
    {
        GameManager.Instance.CreateStudents();
        GameManager.Instance.ScreenSelection(1);
    }
}
