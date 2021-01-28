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
    public partial class CityForm : Form
    {
        public CityForm()
        {
            InitializeComponent();
        }

        ProductInformationEntities db = new ProductInformationEntities();
        BusinessCity cityBus = new BusinessCity();
        BusinessCountry countryBus = new BusinessCountry();

        private void ListCity()
        {
            var city = (from c in db.Cities
                        select new
                        {
                            c.CityID,
                            c.CountryID,
                            c.CityName
                        }).ToList();
            dgvCity.DataSource = city;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbCountry.Text) || string.IsNullOrEmpty(txtCity.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                cityBus.Add(new City
                {
                    CountryID= Convert.ToInt32(cmbCountry.SelectedValue),
                    CityName = txtCity.Text
                });
                ListCity();
                MessageBox.Show("Kayıt Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbCountry.Text) || string.IsNullOrEmpty(txtCity.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                cityBus.Edit(new City
                {
                    CityID = Convert.ToInt32(txtCityID.Text),
                    CountryID = Convert.ToInt32(cmbCountry.SelectedValue),
                    CityName = txtCity.Text
                });
                ListCity();
                MessageBox.Show("Güncelleme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbCountry.Text) || string.IsNullOrEmpty(txtCity.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                cityBus.Remove(Convert.ToInt32(txtCityID.Text));
                ListCity();
                MessageBox.Show("Silme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComeBack_Click(object sender, EventArgs e)
        {
            MainFromAdmin mfa = new Forms.MainFromAdmin();
            mfa.Show();
            this.Hide();
        }

        private void CityForm_Load(object sender, EventArgs e)
        {
            cmbCountry.SetDataSource<Country>(countryBus.ListForComboBox(), "CountryName", "CountryID");
        }

        private void cmbCountry_Click(object sender, EventArgs e)
        {
            cmbCountry.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear c = new Clear();
            c.ClearAll(this);
        }
    }
}
