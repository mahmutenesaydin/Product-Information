using BusinessLayer;
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

namespace PresentationLayer.Forms
{
    public partial class BrandForm : Form
    {
        public BrandForm()
        {
            InitializeComponent();
        }

        BusinessBrand brandBus = new BusinessBrand();

        private void ListBrand()
        {
            ProductInformationEntities db = new ProductInformationEntities();
            var brand = (from b in db.Brands1
                         select new
                         {
                             b.BrandID,
                             b.Brand
                         }).ToList();
            dgvBrand.DataSource = brand;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBrand.Text))
            {
                MessageBox.Show("Lütfen bilgileri doldurun!", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                brandBus.Add(new DataLayer.Brands
                {
                    Brand = txtBrand.Text
                });
                ListBrand();
                MessageBox.Show("Kayıt Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBrand.Text))
            {
                MessageBox.Show("Lütfen bilgileri doldurun!", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                brandBus.Edit(new DataLayer.Brands
                {
                    BrandID = Convert.ToInt16(txtBrandID.Text),
                    Brand = txtBrand.Text
                });
                ListBrand();
                MessageBox.Show("Güncelleme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBrand.Text))
            {
                MessageBox.Show("Lütfen bilgileri doldurun!", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                brandBus.Remove(Convert.ToInt32(txtBrandID.Text));
                ListBrand();
                MessageBox.Show("Silme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            ListBrand();
        }

        private void dgvBrand_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBrandID.Text = dgvBrand.CurrentRow.Cells["BrandID"].Value.ToString();
            txtBrand.Text = dgvBrand.CurrentRow.Cells["Brand"].Value.ToString();
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComeBack_Click(object sender, EventArgs e)
        {
            MainFromAdmin adminForm = new MainFromAdmin();
            adminForm.Show();
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear c = new Clear();
            c.ClearAll(this);
        }
    }
}
