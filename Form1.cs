using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio8
{
    public partial class Form1 : Form
    {
        List<int> notasTemporales = new List<int>();
        List <NotasAlumno> listaNotas = new List<NotasAlumno>();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonNota_Click(object sender, EventArgs e)
        {
            int nota = Convert.ToInt16(textBoxNota.Text);
            notasTemporales.Add(nota);
        }


        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            //Guarda a un alumno con sus notas
            NotasAlumno notasAlumno = new NotasAlumno();
            notasAlumno.Nombre = textBoxNombre.Text;
            notasAlumno.Notas = notasTemporales.GetRange(0,notasTemporales.Count);

            // Guarda a ese alumno en el listado de notas de alumnos.
            listaNotas.Add(notasAlumno);
            Grabar();

            //Borrar las notas temporales para el proximo alumno
            notasTemporales.Clear();
        }

        private void Grabar()
        {
            string json = JsonConvert.SerializeObject(listaNotas);
            string archivo = "Datos.json";
            System.IO.File.WriteAllText(archivo, json);
        }
    }
}
