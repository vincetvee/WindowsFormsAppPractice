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

namespace WindowsFormsAppPractice
{
    public partial class Form1 : Form
    {
        string constring = "Data Source=ESL;Initial Catalog=UserRegisterDb;Integrated Security=True"; 

        public Form1()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
          if(txtFirstName.Text == "" || txtMiddelName.Text == "" || txtLastName.Text == "" || txtCountry.Text == "" || txtMaritalStatus.Text =="" )

           
            using (SqlConnection sqlCon = new SqlConnection(constring))
            {
                sqlCon.Open();
                SqlCommand sqlCmd= new SqlCommand("UserAdd", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@MiddelName", txtMiddelName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Country", txtCountry.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@MaritalStatus", txtMaritalStatus.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Registration is successful");

                Clear();
            } 
            
        }
        void Clear()
        {
            txtFirstName.Text = txtMiddelName.Text = txtLastName.Text = txtCountry.Text = txtMaritalStatus.Text = "";
        }

    }
}
