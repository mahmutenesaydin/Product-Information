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
    public partial class ProductOrderForm : Form
    {
        public ProductOrderForm()
        {
            InitializeComponent();
        }

        ProductInformationEntities db = new ProductInformationEntities();
        BusinessOrder orderBus = new BusinessOrder();
        BusinessCategory catBus = new BusinessCategory();
        BusinessProductType typeBus = new BusinessProductType();
        BusinessBrand brandBus = new BusinessBrand();
        BusinessModel modBus = new BusinessModel();

        private void ProductOrder_Load(object sender, EventArgs e)
        {
            cmbCategory.SetDataSource<Category>(catBus.ListForComboBox(), "CategoryName", "CategoryId");
            cmbType.SetDataSource<ProductTypes>(typeBus.ListForComboBox(), "ProductType", "TypeId");
            cmbBrand.SetDataSource<Brands>(brandBus.ListForComboBox(), "Brand", "BrandID");
            cmbModel.SetDataSource<Models>(modBus.ListForComboBox(), "Model", "ModelID");
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbCategory.Text) || string.IsNullOrEmpty(cmbType.Text) || string.IsNullOrEmpty(cmbBrand.Text) || string.IsNullOrEmpty(cmbModel.Text) || string.IsNullOrEmpty(mskProductCode.Text))
            {
                MessageBox.Show("Lütfen bilgileri doldurun!", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {

                DialogResult r = MessageBox.Show("Bilgiler kaydedilecek. Emin misiniz?", "KAYIT ONAY", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                switch (r)
                {
                    case DialogResult.Yes:
                        orderBus.Add(new Order
                        {
                            CategoryID = Convert.ToInt32(cmbCategory.SelectedValue),
                            TypeID = Convert.ToInt32(cmbType.SelectedValue),
                            BrandID = Convert.ToInt32(cmbBrand.SelectedValue),
                            ModelID = Convert.ToInt32(cmbModel.SelectedValue),
                            ProductCode = Convert.ToInt32(mskProductCode.Text)
                        });
                        ComplateOrderForm complateOrder = new ComplateOrderForm();
                        complateOrder.Show();
                        this.Hide();
                        break;
                }
            }
        }

        private void btnCode_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int code = rnd.Next(100, 999);

            mskProductCode.Text = code.ToString();
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            Clear c = new Clear();
            c.ClearAll(this);
        }

        private void btnProductReview_Click(object sender, EventArgs e)
        {
            ProductUser prodUser = new ProductUser();
            prodUser.Show();
            this.Hide();
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnComeBack_Click(object sender, EventArgs e)
        {
            MainFrom mfrom = new MainFrom();
            mfrom.Show();
            this.Hide();
        }
    }
}
