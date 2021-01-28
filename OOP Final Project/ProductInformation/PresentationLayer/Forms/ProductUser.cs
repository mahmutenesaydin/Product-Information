using BusinessLayer;
using BusinessLayer.Bridge;
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
    public partial class ProductUser : Form
    {
        public ProductUser()
        {
            InitializeComponent();
        }

        ProductInformationEntities db = new ProductInformationEntities();
        BusinessProduct prodBus = new BusinessProduct();

        ProductBase _productBase = new ProductBase
        {
            DataObject = new ProductDatabaseObject()
        };

        private void ListProduct()
        {
            var prod = (from p in db.Products
                        select new
                        {
                            p.ProductID,
                            p.CategoryID,
                            p.ProductTypeID,
                            p.BrandID,
                            p.ModelID,
                            p.Price,
                            p.OutputYear,
                            p.Color,
                            p.Stock,
                            p.WarrantyPeriod,
                            p.Photo1,
                            p.Photo2
                        }).ToList();
            dgvProduct.DataSource = prod;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            ListProduct();
        }

        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProductID.Text = dgvProduct.CurrentRow.Cells["ProductID"].Value.ToString();
            txtCategory.Text = dgvProduct.CurrentRow.Cells["ProductTypeID"].Value.ToString();
            txtProductType.Text = dgvProduct.CurrentRow.Cells["CategoryID"].Value.ToString();
            txtBrand.Text = dgvProduct.CurrentRow.Cells["BrandID"].Value.ToString();
            txtModel.Text = dgvProduct.CurrentRow.Cells["ModelID"].Value.ToString();
            txtPrice.Text = dgvProduct.CurrentRow.Cells["Price"].Value.ToString();
            txtOutputYear.Text = dgvProduct.CurrentRow.Cells["OutputYear"].Value.ToString();
            txtColor.Text = dgvProduct.CurrentRow.Cells["Color"].Value.ToString();
            txtStock.Text = dgvProduct.CurrentRow.Cells["Stock"].Value.ToString();
            txtWarrantyPeriod.Text = dgvProduct.CurrentRow.Cells["WarrantyPeriod"].Value.ToString();
            txtPhoto1.Text = dgvProduct.CurrentRow.Cells["Photo1"].Value.ToString();
            txtPhoto2.Text = dgvProduct.CurrentRow.Cells["Photo2"].Value.ToString();

            pct1.ImageLocation = dgvProduct.CurrentRow.Cells["Photo1"].Value.ToString();
            pct2.ImageLocation = dgvProduct.CurrentRow.Cells["Photo2"].Value.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Product p = _productBase.Next;

            txtProductID.Text = p.ProductID.ToString();
            txtCategory.Text = p.CategoryID.ToString();
            txtProductType.Text = p.ProductTypeID.ToString();
            txtBrand.Text = p.BrandID.ToString();
            txtModel.Text = p.ModelID.ToString();
            txtPrice.Text = p.Price.ToString();
            txtOutputYear.Text = txtOutputYear.Text;
            txtStock.Text = p.Stock.ToString();
            txtColor.Text = p.Color;
            txtOutputYear.Text = p.OutputYear;
            txtPhoto1.Text = p.Photo1;
            txtPhoto2.Text = p.Photo2;
        }

        private void btnPrior_Click(object sender, EventArgs e)
        {
            Product p = _productBase.Prior;

            txtProductID.Text = p.ProductID.ToString();
            txtCategory.Text = p.CategoryID.ToString();
            txtProductType.Text = p.ProductTypeID.ToString();
            txtBrand.Text = p.BrandID.ToString();
            txtModel.Text = p.ModelID.ToString();
            txtPrice.Text = p.Price.ToString();
            txtOutputYear.Text = txtOutputYear.Text;
            txtStock.Text = p.Stock.ToString();
            txtColor.Text = p.Color;
            txtOutputYear.Text = p.OutputYear;
            txtPhoto1.Text = p.Photo1;
            txtPhoto2.Text = p.Photo2;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            ProductOrderForm order = new ProductOrderForm();
            order.Show();
            this.Hide();
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Programdan çıkmak istiyor musunuz?", "UYARI!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnComeBack_Click(object sender, EventArgs e)
        {
            MainFrom mf = new MainFrom();
            mf.Show();
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear c = new Clear();
            c.ClearAll(this);
        }
    }
}

