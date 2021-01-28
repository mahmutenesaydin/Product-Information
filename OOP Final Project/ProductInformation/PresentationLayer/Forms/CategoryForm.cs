using BusinessLayer;
using BusinessLayer.Bridge;
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
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        ProductInformationEntities db = new ProductInformationEntities();
        BusinessCategory ctgBus = new BusinessCategory();


        private void ListCategory()
        {
            var category = (from c in db.Categories
                            select new
                            {
                                c.CategoryID,
                                c.CategoryName
                            }).ToList();
            dgvCategory.DataSource = category;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoryName.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                ctgBus.Add(new Category
                {
                    CategoryName = txtCategoryName.Text
                });
                ListCategory();
                MessageBox.Show("Kayıt Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtCategoryName.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                ctgBus.Edit(new Category
                {
                    CategoryID = Convert.ToInt32(txtID.Text),
                    CategoryName = txtCategoryName.Text
                });
                ListCategory();
                MessageBox.Show("Güncelleme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoryName.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                ctgBus.Remove(Convert.ToInt16(txtID.Text));
                ListCategory();
                MessageBox.Show("Silme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            ListCategory();
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComeBack_Click(object sender, EventArgs e)
        {
            Forms.MainFromAdmin mainForm = new Forms.MainFromAdmin();
            mainForm.Show();
            this.Hide();
        }

        private void btnOff_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComeBack_Click_1(object sender, EventArgs e)
        {
            Forms.MainFromAdmin adminForm = new Forms.MainFromAdmin();
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
