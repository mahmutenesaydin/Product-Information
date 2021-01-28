using BusinessLayer.UnitOfWork.Business;
using DataLayer;
using PresentationLayer.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.Show();
            this.Hide();
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Programdan çıkmayı gerçekten istiyor musunuz?", "UYARI!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            };
        }

        ProductInformationEntities db = new ProductInformationEntities();

        private void btnLogin_Click(object sender, EventArgs e)
        {
           if (txtUserName.Text != "" && txtPassword.Text != "")
            {
                foreach (var user in db.Users)
                {
                    if (user.UserName == txtUserName.Text && user.Password == txtPassword.Text)
                    {
                        MessageBox.Show("Kullanıcı Giriş Başarılı.");
                        MainFromAdmin mfa = new MainFromAdmin();
                        mfa.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Böyle bir kullanıcı yok!", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUserName.Text = "";
                        txtPassword.Text = "";
                    }
                    break;
                }
            }
            else
            {
                MessageBox.Show("Lütfen Bilgilerinizi Tekrar Kontrol Edin!", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void chckShowMyPassword_OnChange(object sender, EventArgs e)
        {
            if (chckShowMyPassword.Checked)
            {
               txtPassword.isPassword = false;
            }
            else
            {
                txtPassword.isPassword = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotYourPassword newPas = new ForgotYourPassword();
            newPas.Show();
            this.Hide();
        }
    }
}
