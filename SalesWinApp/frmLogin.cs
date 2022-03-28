using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using DataAccess.Repository;
using BusinessObject;
using Microsoft.Extensions.Configuration;


namespace SalesWinApp
{
    public partial class frmLogin : Form
    {
        IMemberRepository memberRepository = new MemberRepository();
        public frmLogin()
        {
            InitializeComponent();
        }

        static IConfiguration GetConfiguration()
            => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            IConfiguration config = GetConfiguration();
            if (email.Equals(config["login:email"])
                && password.Equals(config["login:password"]))
            {
                this.Hide();
                frmMain frmMain = new frmMain { IsAdmin = true };
                frmMain.ShowDialog();
            }
            else if (memberRepository.LogIn(email, password) != null)
            {
                this.Hide();
                MemberObject account = memberRepository.LogIn(email, password);
                frmMain frmMain = new frmMain { IsAdmin = false, AccountID = account.MemberID };
                frmMain.ShowDialog();
            }
            else
            {
                lbMessage.ForeColor = Color.Red;
                lbMessage.Text = "Email or password is incorrect, try again!";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private void txtEmail_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLogin.Text = "Please enter your email.";
        }

        private void txtEmail_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLogin.Text = "";
        }

        private void txtPassword_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLogin.Text = "Please enter your password.";
        }

        private void txtPassword_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLogin.Text = "";
        }
    }
}
