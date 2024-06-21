using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cotidiana
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("Server= DESKTOP-TFNBFUK; database= Cotidiana; integrated security= true");
            conexion.Open();
            string Tarea= textBox3.Text;
            string Descripcion= textBox4.Text;
            string cadena = "insert into Pendiente (Tarea, descripción) values ('"+Tarea+"', '"+Descripcion+"')";
            SqlCommand comando = new SqlCommand(cadena,conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Los datos se han guardado correctamente");
            textBox3.Text = "";
            textBox4.Text = "";
            conexion.Close();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox7.Text) && int.TryParse(textBox7.Text, out int result))
            {
                button2.Enabled = true;  
                button7.Enabled = true;
            }
            else 
            {
                button2.Enabled = false;
                button7.Enabled = false; 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("Server= DESKTOP-TFNBFUK; database= Cotidiana; integrated security= true");
            conexion.Open();
            string ID = textBox7.Text;
            string cadena = "delete from Pendiente where ID="+ID;
            SqlCommand comando = new SqlCommand(cadena, conexion);
            int cant;
            cant= comando.ExecuteNonQuery();
            if (cant == 1)
            {
                textBox7.Text = "";
                MessageBox.Show("Tarea eliminada");
            }
            else
                MessageBox.Show("Tarea no encontrada");
            
            conexion.Close();
            button2.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            SqlConnection conexion = new SqlConnection("Server= DESKTOP-TFNBFUK; database= Cotidiana; integrated security= true");
            conexion.Open();
            string cadena = "Select ID, Tarea, Descripción from Pendiente";
            SqlCommand comando= new SqlCommand(cadena, conexion);
            SqlDataReader registros= comando.ExecuteReader();
            while( registros.Read()) 
            {
                textBox1.AppendText(registros["ID"].ToString());
                textBox1.AppendText("  -  ");
                textBox1.AppendText(registros["Tarea"].ToString());
                textBox1.AppendText("  -  ");
                textBox1.AppendText(registros["Descripción"].ToString());
                textBox1.AppendText(Environment.NewLine);
            }
            conexion.Close();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            SqlConnection conexion = new SqlConnection("Server= DESKTOP-TFNBFUK; database= Cotidiana; integrated security= true");
            conexion.Open();
            string cadena = "Select ID, Tarea, Descripción from Completada";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                textBox2.AppendText(registros["ID"].ToString());
                textBox2.AppendText("  -  ");
                textBox2.AppendText(registros["Tarea"].ToString());
                textBox2.AppendText("  -  ");
                textBox2.AppendText(registros["Descripción"].ToString());
                textBox2.AppendText(Environment.NewLine);
            }
            conexion.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("Server= DESKTOP-TFNBFUK; database= Cotidiana; integrated security= true");
            conexion.Open();
            string ID = textBox7.Text;
            string cadena1 = "insert into Completada (Tarea, descripción) select Tarea, descripción from Pendiente where ID=" + ID;
            string cadena2 = "delete from Pendiente WHERE ID=" + ID;
            SqlCommand comando1 = new SqlCommand(cadena1, conexion);
            SqlCommand comando2 = new SqlCommand(cadena2, conexion);

            int cant1 = comando1.ExecuteNonQuery();
            int cant2 = comando2.ExecuteNonQuery();

            if (cant1 == 1 && cant2 == 1)
            {
                textBox7.Text = "";
                MessageBox.Show("Tarea completada");
            }
            else
            {
                MessageBox.Show("Tarea no encontrada");
            }

            conexion.Close();
            button7.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("Server= DESKTOP-TFNBFUK; database= Cotidiana; integrated security= true");
            conexion.Open();
            string ID = textBox8.Text;
            string cadena = "delete from Completada where ID=" + ID;
            SqlCommand comando = new SqlCommand(cadena, conexion);
            int cant;
            cant = comando.ExecuteNonQuery();
            if (cant == 1)
            {
                textBox7.Text = "";
                MessageBox.Show("Tarea eliminada");
            }
            else
                MessageBox.Show("Tarea no encontrada");

            conexion.Close();
            button4.Enabled = false;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox8.Text) && int.TryParse(textBox8.Text, out int result))
            {
                button4.Enabled = true;
            }
            else
            {
                button4.Enabled = false;
            }
        }

      
    }
}
