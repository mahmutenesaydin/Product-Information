using BusinessLayer.UnitOfWork.Business;
using DataLayer;
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
    public partial class ForgotYourPassword : Form
    {
        public ForgotYourPassword()
        {
            InitializeComponent();
        }

        ProductInformationEntities db = new ProductInformationEntities();
        BusinessUser userBus = new BusinessUser();

        private void btnChangeMyPassword_Click(object sender, EventArgs e)
        {  
            userBus.Edit(new User
            {
                Password = txtNewPassword.Text
            });
        }

        private void btnComeBack_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
