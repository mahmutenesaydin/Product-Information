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
    public partial class CreditCartForm : Form
    {
        public CreditCartForm()
        {
            InitializeComponent();
        }

        BusinessCreditCart creditBus = new BusinessCreditCart();
        ProductInformationEntities db = new ProductInformationEntities();

        private void btnCompleteOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCartOwner.Text) || string.IsNullOrEmpty(mskCartNumber.Text) || string.IsNullOrEmpty(mskPassword.Text) || string.IsNullOrEmpty(mskSecurityCode.Text))
            {
                MessageBox.Show("Lütfen bilgileri doldurun!", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                creditBus.Add(new CreditCart
                {
                    CartOwner = txtCartOwner.Text,
                    CardNumber = mskCartNumber.Text,
                    Password = mskPassword.Text,
                    SecurityCode = mskSecurityCode.Text
                });
                MessageBox.Show("Satış İşleminiz Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            } 
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear c = new Clear();
            c.ClearAll(this);
        }
    }
}
