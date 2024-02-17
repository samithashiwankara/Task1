using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Task1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\\Users\Samitha Shiwankara\OneDrive\Documentslogin_new.mdf;Integrated Security=True;Connect Timeout=30");
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            String username, uesr_password;
            username = txt_userName.Text;
            uesr_password = txt_password.Text;

            try
            {
                String querry = "SELECT COUNT (*) FROM login WHERE user_name ='" + txt_userName.Text + "' AND passowrd ='" + txt_password.Text + "' ";
                SqlDataAdapter sda = new SqlDataAdapter(querry, con);

                DataTable dtable = new System.Data.DataTable();
                sda.Fill(dtable);

                if(dtable.Rows.Count == 1)
                {
                    username = txt_userName.Text;
                    uesr_password = txt_password.Text;

                    //page that needed to be load next 
                    this.Hide();

                     MDIParent1 ss = new MDIParent1();
                     ss.Show();
                      
                    
                }
                else
                {
                    MessageBox.Show("Invalid login details");
                    txt_userName.Clear();
                    txt_password.Clear();

                    //to foucs Username
                    txt_userName.Focus();
                }
                    
                   
             }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                con.Close();
            }
         }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_userName.Clear();
            txt_password.Clear();

            txt_userName.Focus();
        }
    }
}
