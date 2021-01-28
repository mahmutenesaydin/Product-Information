using BusinessLayer;
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
    public partial class ComplateOrderForm : Form
    {
        public ComplateOrderForm()
        {
            InitializeComponent();
        }

        BusinessCustomer customerBus = new BusinessCustomer();
        ProductInformationEntities db = new ProductInformationEntities();
        BusinessCountry countryBus = new BusinessCountry();
        BusinessCity cityBus = new BusinessCity();

        private void btnCompleteOrder_Click(object sender, EventArgs e)
        {
            customerBus.Add(new Customer
            {
                FirstName = txtCustomerName.Text,
                LastName = txtLastName.Text,
                PhoneNumber = mskPhoneNumber.Text,
                CountryID = Convert.ToInt32(cmbCountry.SelectedValue),
                CityID = Convert.ToInt32(cmbCity.SelectedValue),
                Address = txtAddress.Text
            });
            CreditCartForm ccForm = new CreditCartForm();
            ccForm.Show();
            this.Hide();
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComeBack_Click(object sender, EventArgs e)
        {
            ProductOrderForm pOrder = new ProductOrderForm();
            pOrder.Show();
            this.Close();
        }

        private void ComplateOrderForm_Load(object sender, EventArgs e)
        {
            cmbCountry.SetDataSource<Country>(countryBus.ListForComboBox(), "CountryName", "CountryID");
            cmbCity.SetDataSource<City>(cityBus.ListForComboBox(), "CityName", "CountryID");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear c = new Clear();
            c.ClearAll(this);
        }
    }
}
