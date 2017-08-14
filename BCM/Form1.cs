using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;// Recuerden agregar la referencia "Microsoft.VisualBasic".
using System.Diagnostics; 

namespace c_sahrp
{
    public partial class Form1 : Form
    {
        Computer mycomputer = new Computer(); // Así accederemos al "FileSystem".
        string tipo = "carpeta"; // Para esta aplicación, para saber si copiar/mover un archivo a una carpeta.
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true)
            {
                tipo = "carpeta"; // El tipo se cambiará a archivo.
                button1.Enabled = true;
                button2.Enabled = false; //Para poder seleccionar un archivo y no una carpeta.
            }
            else // Si el radiobutton de la carpeta no esta seleccionado (significa lo contrario de la condición que antes hemos puesto).
            {
                tipo = "archivo"; // El tipo se cambiará a carpeta.
                button1.Enabled = false;
                button2.Enabled = true; //Para poder seleccionar una carpeta y no un archivo.
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // El siguiente código servirá para que si hacemos un click en Ok con el selector de carpeta, el texto del TextBox1 sea la ruta seleccionada.
            var resultado = fbd1.ShowDialog();
            if (resultado == DialogResult.OK) { textBox1.Text = fbd1.SelectedPath; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // El siguiente código servirá para que el texto del textbox2 sea igual a la ruta seleccionada + desde el último índice de "\", para copiar el nombre de la carpeta.
            var resultado = fbd1.ShowDialog();
            if (resultado == DialogResult.OK) { textBox2.Text = fbd1.SelectedPath + textBox1.Text.Substring(textBox1.Text.LastIndexOf(@"\")); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // El siguiente código servirá para que si hacemos un click en Ok con el selector de archivos, el texto del TextBox1 sea el archivo seleccionado.
            var resultado = ofd1.ShowDialog();
            if (resultado == DialogResult.OK) { textBox1.Text = ofd1.FileName; }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tipo == "carpeta") { mycomputer.FileSystem.CopyDirectory(textBox1.Text, textBox2.Text); } // Copiamos la carpeta.
            if (tipo == "archivo") { mycomputer.FileSystem.CopyFile(textBox1.Text, textBox2.Text); } // Copiamos el archivo.
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tipo == "carpeta") { mycomputer.FileSystem.MoveDirectory(textBox1.Text, textBox2.Text); } // Movemos la carpeta.
            if (tipo == "archivo") { mycomputer.FileSystem.MoveFile(textBox1.Text, textBox2.Text); } // Movemos el archivo.
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process.Start(textBox3.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscar = new OpenFileDialog();

            if (buscar.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = buscar.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // Para copiar:
        // mycomputer.FileSystem.CopyDirectory / CopyFile(ruta 1 as string, ruta 2 as string);
        //
        // Para mover:
        // mycomputer.FileSystem.MoveDirectory / MoveFile(ruta 1 as string, ruta 2 as string);
    }
}


