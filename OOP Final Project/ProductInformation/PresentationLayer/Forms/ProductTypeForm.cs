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
    public partial class ProductTypeForm : Form
    {
        public ProductTypeForm()
        {
            InitializeComponent();
        }

        BusinessProductType typeBus = new BusinessProductType();
        BusinessCategory catBus = new BusinessCategory();
        ProductInformationEntities db = new ProductInformationEntities();

        private void ProductTypeList()
        {
            var type = (from t in db.ProductTypes1
                        select new
                        {
                            t.TypeID,
                            t.CategoryID,
                            t.ProductType
                        }).ToList();
            dgvProductType.DataSource = type;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbCategory.Text) || string.IsNullOrEmpty(txtType.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                typeBus.Add(new DataLayer.ProductTypes
                {
                    CategoryID = Convert.ToInt32(cmbCategory.SelectedValue),
                    ProductType = txtType.Text
                });
                ProductTypeList();
                MessageBox.Show("Kayıt Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbCategory.Text) || string.IsNullOrEmpty(txtType.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                typeBus.Edit(new DataLayer.ProductTypes
                {
                    TypeID = Convert.ToInt32(txtID.Text),
                    CategoryID = Convert.ToInt32(cmbCategory.SelectedValue),
                    ProductType = txtType.Text
                });
                ProductTypeList();
                MessageBox.Show("Güncelleme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbCategory.Text) || string.IsNullOrEmpty(txtType.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                typeBus.Remove(Convert.ToInt32(txtID.Text));
                ProductTypeList();
                MessageBox.Show("Silme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }
        }

        private void ProductTypeForm_Load(object sender, EventArgs e)
        {
            cmbCategory.SetDataSource<Category>(catBus.ListForComboBox(), "CategoryName", "CategoryId");
        }

        private void dgvProductType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvProductType.CurrentRow.Selected = true;

            txtID.Text = dgvProductType.Rows[e.RowIndex].Cells["TypeID"].Value.ToString();
            cmbCategory.Text = dgvProductType.Rows[e.RowIndex].Cells["CategoryId"].Value.ToString();
            txtType.Text = dgvProductType.Rows[e.RowIndex].Cells["ProductType1"].Value.ToString();
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComeBack_Click(object sender, EventArgs e)
        {
            MainFromAdmin mfa = new MainFromAdmin();
            mfa.Show();
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear c = new Clear();
            c.ClearAll(this);
        }
    }
}
