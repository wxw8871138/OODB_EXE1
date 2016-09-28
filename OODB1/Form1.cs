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

namespace OODB1
{
    public partial class Form1 : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommandBuilder cmb;
        int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//Load Button
        {
            string conS = "Data Source=(local);Integrated Security=SSPI;Initial Catalog=Dafesty";
            cn = new SqlConnection(conS);
            cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandText = "select VideoCode,MovieTitle,Rating from Movies";
            da = new SqlDataAdapter(cm);
            cmb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "Movies");
            i = 0;
            textBox1.Text = ds.Tables[0].Rows[i][0].ToString();
            textBox2.Text = ds.Tables[0].Rows[i][1].ToString();
            textBox3.Text = ds.Tables[0].Rows[i][2].ToString();
            
        }

        private void button6_Click(object sender, EventArgs e)//> Button
        {
            if (i < ds.Tables[0].Rows.Count-1)
            {
                i++;
                textBox1.Text = ds.Tables[0].Rows[i][0].ToString();
                textBox2.Text = ds.Tables[0].Rows[i][1].ToString();
                textBox3.Text = ds.Tables[0].Rows[i][2].ToString();
            }
            
        }

        private void button5_Click(object sender, EventArgs e)//< button
        {
            if (i > 0)
            {
                i--;
                textBox1.Text = ds.Tables[0].Rows[i][0].ToString();
                textBox2.Text = ds.Tables[0].Rows[i][1].ToString();
                textBox3.Text = ds.Tables[0].Rows[i][2].ToString();
            }
            
        }

        private void button7_Click(object sender, EventArgs e)//<< Button
        {
            i = 0;
            textBox1.Text = ds.Tables[0].Rows[i][0].ToString();
            textBox2.Text = ds.Tables[0].Rows[i][1].ToString();
            textBox3.Text = ds.Tables[0].Rows[i][2].ToString();
        }

        private void button8_Click(object sender, EventArgs e)//>> Button
        {
            i = ds.Tables[0].Rows.Count-1;
            textBox1.Text = ds.Tables[0].Rows[i][0].ToString();
            textBox2.Text = ds.Tables[0].Rows[i][1].ToString();
            textBox3.Text = ds.Tables[0].Rows[i][2].ToString();
        }

        private void button9_Click(object sender, EventArgs e)//Find Button
        {
            string code = textBox4.Text.ToString();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i][0].ToString() == code)
                {
                    textBox1.Text = ds.Tables[0].Rows[i][0].ToString();
                    textBox2.Text = ds.Tables[0].Rows[i][1].ToString();
                    textBox3.Text = ds.Tables[0].Rows[i][2].ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//Update Button
        {
            ds.Tables[0].Rows[i][0] = textBox1.Text;
            ds.Tables[0].Rows[i][1] = textBox2.Text;
            ds.Tables[0].Rows[i][2] = textBox3.Text;
            int isSuccessful = da.Update(ds, "Movies");
            if(isSuccessful == 1)
            {
                MessageBox.Show("successful!");
            }
        }

        private void button3_Click(object sender, EventArgs e)//Insert Button
        {
            DataRow dr = ds.Tables[0].NewRow();
            textBox1.Text = null;
            textBox2.Text = "";
            textBox3.Text = "";
            dr[0] = 0;
            dr[1] = "";
            dr[2] = "";
            ds.Tables[0].Rows.Add(dr);
            i = ds.Tables[0].Rows.Count-1;
            textBox1.Text = null;
            textBox2.Text = "";
            textBox3.Text = "";
            
        }

        private void button4_Click(object sender, EventArgs e)//Delete Button
        {
            ds.Tables[0].Rows[i].Delete();
            int isSuccessful = da.Update(ds, "Movies");
            if(isSuccessful == 1)
            {
                MessageBox.Show("Successful!");
            }
        }
    }
}
