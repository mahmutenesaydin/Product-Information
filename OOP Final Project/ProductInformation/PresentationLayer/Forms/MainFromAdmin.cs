using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Forms
{
    public partial class MainFromAdmin : Form
    {
        public MainFromAdmin()
        {
            InitializeComponent();
        }

        private void btnSiparisTakip_Click(object sender, EventArgs e)
        {
            CategoryForm ctgForm = new CategoryForm();
            ctgForm.Show();
            this.Hide();
        }

        private void btnProductType_Click(object sender, EventArgs e)
        {
            ProductTypeForm pType = new ProductTypeForm();
            pType.Show();
            this.Hide();
        }

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            ProductForm pForm = new ProductForm();
            pForm.Show();
            this.Hide();
        }

        private void btnBrandAdd_Click(object sender, EventArgs e)
        {
            BrandForm brandForm = new BrandForm();
            brandForm.Show();
            this.Hide();
        }

        private void btnModel_Click(object sender, EventArgs e)
        {
            ModelForm modelForm = new ModelForm();
            modelForm.Show();
            this.Hide();
        }

        private void btnEmployeeAdd_Click(object sender, EventArgs e)
        {
            EmployeeForm empForm = new EmployeeForm();
            empForm.Show();
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

        private void btnProduct_Click(object sender, EventArgs e)
        {
            CountryForm cf = new CountryForm();
            cf.Show();
            this.Hide();
        }

        private void btnSiparisVer_Click(object sender, EventArgs e)
        {
            CityForm cf = new CityForm();
            cf.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReportForm report = new ReportForm();
            report.Show();
            this.Hide();
        }
    }
}
