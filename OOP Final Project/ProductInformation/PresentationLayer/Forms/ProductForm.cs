using BusinessLayer;
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
using BusinessLayer.UnitOfWork.Business;
using System.IO;
using BusinessLayer.Bridge;
using PresentationLayer.Forms;

namespace PresentationLayer
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }
        ProductInformationEntities db = new ProductInformationEntities();
        BusinessProduct prodBusi = new BusinessProduct();
        BusinessCategory catBus = new BusinessCategory();
        BusinessProductType typeBus = new BusinessProductType();
        BusinessBrand brandBus = new BusinessBrand();
        BusinessModel modBus = new BusinessModel();

        ProductBase _productBase = new ProductBase
        {
            DataObject = new ProductDatabaseObject()
        };

        private void ProductForm_Load(object sender, EventArgs e)
        {
            cmbCategory.SetDataSource<Category>(catBus.ListForComboBox(), "CategoryName", "CategoryId");
            cmbProductType.SetDataSource<ProductTypes>(typeBus.ListForComboBox(), "ProductType", "TypeId");
            cmbBrand.SetDataSource<Brands>(brandBus.ListForComboBox(), "Brand", "BrandID");
            cmbModel.SetDataSource<Models>(modBus.ListForComboBox(), "Model", "ModelID");
        }

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

        private void btnPrior_Click(object sender, EventArgs e)
        {
            Product p = _productBase.Prior;

            txtProductID.Text = p.ProductID.ToString();
            cmbCategory.Text = p.CategoryID.ToString();
            cmbProductType.Text = p.ProductTypeID.ToString();
            cmbBrand.Text = p.BrandID.ToString();
            cmbModel.Text = p.ModelID.ToString();
            txtPrice.Text = p.Price.ToString();
            txtOutputYear.Text = txtOutputYear.Text;
            txtStock.Text = p.Stock.ToString();
            txtColor.Text = p.Color;
            txtOutputYear.Text = p.OutputYear;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Product p = _productBase.Next;

            txtProductID.Text = p.ProductID.ToString();
            cmbCategory.Text = p.CategoryID.ToString();
            cmbProductType.Text = p.ProductTypeID.ToString();
            cmbBrand.Text = p.BrandID.ToString();
            cmbModel.Text = p.ModelID.ToString();
            txtPrice.Text = p.Price.ToString();
            txtOutputYear.Text = txtOutputYear.Text;
            txtStock.Text = p.Stock.ToString();
            txtColor.Text = p.Color;
            txtOutputYear.Text = p.OutputYear;
        }

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbProductType.Text) || string.IsNullOrEmpty(cmbCategory.Text) || string.IsNullOrEmpty(cmbBrand.Text) || string.IsNullOrEmpty(cmbModel.Text) || string.IsNullOrEmpty(txtPrice.Text) || string.IsNullOrEmpty(txtOutputYear.Text) || string.IsNullOrEmpty(txtColor.Text) || string.IsNullOrEmpty(txtStock.Text) || string.IsNullOrEmpty(txtWarrantyPeriod.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                prodBusi.Add(new Product
                {
                    ProductTypeID = Convert.ToInt32(cmbProductType.SelectedValue),
                    CategoryID = Convert.ToInt32(cmbCategory.SelectedValue),
                    BrandID = Convert.ToInt32(cmbBrand.SelectedValue),
                    ModelID = Convert.ToInt32(cmbModel.SelectedValue),
                    Price = Convert.ToDecimal(txtPrice.Text),
                    OutputYear = txtOutputYear.Text,
                    Color = txtColor.Text,
                    Stock = Convert.ToInt32(txtStock.Text),
                    WarrantyPeriod = txtWarrantyPeriod.Text,
                    Photo1 = txtPhoto1.Text,
                    Photo2 = txtPhoto2.Text
                });
                ListProduct();
                MessageBox.Show("Kayıt Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComeBack_Click(object sender, EventArgs e)
        {
            Forms.MainFromAdmin mfa = new Forms.MainFromAdmin();
            mfa.Show();
            this.Hide(); ;
        }

        private void dgvProduct_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtProductID.Text = dgvProduct.CurrentRow.Cells["ProductID"].Value.ToString();
            cmbCategory.Text = dgvProduct.CurrentRow.Cells["ProductTypeID"].Value.ToString();
            cmbProductType.Text = dgvProduct.CurrentRow.Cells["CategoryID"].Value.ToString();
            cmbBrand.Text = dgvProduct.CurrentRow.Cells["BrandID"].Value.ToString();
            cmbModel.Text = dgvProduct.CurrentRow.Cells["ModelID"].Value.ToString();
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

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbProductType.Text) || string.IsNullOrEmpty(cmbCategory.Text) || string.IsNullOrEmpty(cmbBrand.Text) || string.IsNullOrEmpty(cmbModel.Text) || string.IsNullOrEmpty(txtPrice.Text) || string.IsNullOrEmpty(txtOutputYear.Text) || string.IsNullOrEmpty(txtColor.Text) || string.IsNullOrEmpty(txtStock.Text) || string.IsNullOrEmpty(txtWarrantyPeriod.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                prodBusi.Edit(new Product
                {
                    ProductID = Convert.ToInt32(txtProductID.Text),
                    CategoryID = Convert.ToInt32(cmbCategory.SelectedValue),
                    ProductTypeID = Convert.ToInt32(cmbProductType.SelectedValue),
                    BrandID = Convert.ToInt32(cmbBrand.SelectedValue),
                    ModelID = Convert.ToInt32(cmbModel.SelectedValue),
                    Price = Convert.ToDecimal(txtPrice.Text),
                    OutputYear = txtOutputYear.Text,
                    Color = txtColor.Text,
                    Stock = Convert.ToInt32(txtStock.Text),
                    WarrantyPeriod = txtWarrantyPeriod.Text,
                    Photo1 = txtPhoto1.Text.ToString(),
                    Photo2 = txtPhoto2.Text.ToString()
                });
                ListProduct();
                MessageBox.Show("Güncelleme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbProductType.Text) || string.IsNullOrEmpty(cmbCategory.Text) || string.IsNullOrEmpty(cmbBrand.Text) || string.IsNullOrEmpty(cmbModel.Text) || string.IsNullOrEmpty(txtPrice.Text) || string.IsNullOrEmpty(txtOutputYear.Text) || string.IsNullOrEmpty(txtColor.Text) || string.IsNullOrEmpty(txtStock.Text) || string.IsNullOrEmpty(txtWarrantyPeriod.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                prodBusi.Remove(Convert.ToInt32(txtProductID.Text));
                dgvProduct.DataSource = prodBusi.GetProducts();
                MessageBox.Show("Silme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            Clear c = new Clear();
            c.ClearAll(this);
        }

        private void btnList_Click_1(object sender, EventArgs e)
        {
            ListProduct();
        }

        private void btnSelectedImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pct1.ImageLocation = openFileDialog1.FileName;
            txtPhoto1.Text = openFileDialog1.FileName;
        }

        private void btnSelectedImage2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pct2.ImageLocation = openFileDialog1.FileName;
            txtPhoto2.Text = openFileDialog1.FileName;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear clear = new Clear();
            clear.ClearAll(this);
        }
    }
}
