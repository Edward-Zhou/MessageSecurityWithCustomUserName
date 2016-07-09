using SecurityMessageUserNameWinForm.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityMessageUserNameWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            Service1Client customclient = new Service1Client("WSHttpBinding_IService1");
            customclient.ClientCredentials.UserName.UserName = txtUserName.Text;
            customclient.ClientCredentials.UserName.Password = txtPassword.Text;
            try
            {
                string result = customclient.GetData(123);
                MessageBox.Show("Certificate Success，result is " + result);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Invalid User Name or Password");
            }

        }
    }
}
