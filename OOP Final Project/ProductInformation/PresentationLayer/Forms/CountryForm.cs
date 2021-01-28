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
    public partial class CountryForm : Form
    {
        public CountryForm()
        {
            InitializeComponent();
        }

        BusinessCountry countryBus = new BusinessCountry();

        private void ListCountry()
        {
            ProductInformationEntities db = new ProductInformationEntities();
            var country = (from c in db.Countries
                         select new
                         {
                             c.CountryID,
                             c.CountryName
                         }).ToList();
            dgvCountry.DataSource = country;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCountry.Text))
            {
                MessageBox.Show("Lütfen bilgileri doldurun!", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                countryBus.Add(new Country
                {
                    CountryName = txtCountry.Text
                });
                ListCountry();
                MessageBox.Show("Kayıt Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCountry.Text))
            {
                MessageBox.Show("Lütfen bilgileri doldurun!", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                countryBus.Edit(new Country
                {
                    CountryID = Convert.ToInt32(txtCountryID.Text),
                    CountryName = txtCountry.Text
                });
                ListCountry();
                MessageBox.Show("Güncelleme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCountry.Text))
            {
                MessageBox.Show("Lütfen bilgileri doldurun!", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                countryBus.Remove(Convert.ToInt32(txtCountryID.Text));
                ListCountry();
                MessageBox.Show("Silme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            ListCountry();
        }

        private void dgvBrand_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCountryID.Text = dgvCountry.CurrentRow.Cells["CountryID"].Value.ToString();
            txtCountry.Text = dgvCountry.CurrentRow.Cells["CountryName"].Value.ToString();
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
