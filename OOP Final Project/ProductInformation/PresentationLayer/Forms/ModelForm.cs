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
    public partial class ModelForm : Form
    {
        public ModelForm()
        {
            InitializeComponent();
        }

        BusinessModel modelBus = new BusinessModel();
        BusinessBrand brandBus = new BusinessBrand();
        ProductInformationEntities db = new ProductInformationEntities();

        private void ModelForm_Load(object sender, EventArgs e)
        {
            cmbBrand.SetDataSource<Brands>(brandBus.ListForComboBox(), "Brand", "BrandID");
        }

        private void ListModel()
        {
            var model = (from m in db.Models1
                         select new
                         {
                             m.ModelID,
                             m.BrandID,
                             m.Model
                         }).ToList();
            dgvModel.DataSource = model;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbBrand.Text) || string.IsNullOrEmpty(txtModel.Text))
            {
                MessageBox.Show("Lütfen bilgileri doldurun!", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                modelBus.Add(new DataLayer.Models
                {
                    BrandID = Convert.ToInt32(cmbBrand.SelectedValue),
                    Model = txtModel.Text
                });
                ListModel();
                MessageBox.Show("Kayıt Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbBrand.Text) || string.IsNullOrEmpty(txtModel.Text))
            {
                MessageBox.Show("Lütfen bilgileri doldurun!", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                modelBus.Edit(new Models
                {
                    ModelID = Convert.ToInt32(txtID.Text),
                    BrandID = Convert.ToInt32(cmbBrand.Text),
                    Model = txtModel.Text
                });
                ListModel();
                MessageBox.Show("Günelleme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbBrand.Text) || string.IsNullOrEmpty(txtModel.Text))
            {
                MessageBox.Show("Lütfen bilgileri doldurun!", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                modelBus.Remove(Convert.ToInt32(txtID.Text));
                ListModel();
                MessageBox.Show("Silme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            ListModel();
        }

        private void dgvModel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvModel.CurrentRow.Cells["ModelID"].Value.ToString();
            cmbBrand.Text = dgvModel.CurrentRow.Cells["BrandID"].Value.ToString();
            txtModel.Text = dgvModel.CurrentRow.Cells["Model"].Value.ToString();
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComeBack_Click(object sender, EventArgs e)
        {
            Forms.MainFromAdmin mfAdmin = new Forms.MainFromAdmin();
            mfAdmin.Show();
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear c = new Clear();
            c.ClearAll(this);
        }
    }
}
