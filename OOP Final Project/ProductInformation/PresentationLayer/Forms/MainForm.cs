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
    public partial class MainFrom : Form
    {
        public MainFrom()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {    
        }
        private void btnProduct_Click(object sender, EventArgs e)
        {
            ProductUser prodUser = new ProductUser();
            prodUser.Show();
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

        private void btnSiparisVer_Click(object sender, EventArgs e)
        {
            ProductOrderForm pOrder = new ProductOrderForm();
            pOrder.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm reg = new RegisterForm();
            reg.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
