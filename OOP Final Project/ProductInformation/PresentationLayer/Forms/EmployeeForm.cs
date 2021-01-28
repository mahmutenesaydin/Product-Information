using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using BusinessLayer;
using BusinessLayer.UnitOfWork.Business;
using System.IO;
using PresentationLayer.Forms;

namespace PresentationLayer
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        ProductInformationEntities db = new ProductInformationEntities();
        BusinessEmployee empBusi = new BusinessEmployee();
         
        private void ListEmployee()
        {

            var emp = (from e in db.Employees
                       select new
                       {
                           e.EmployeeID,
                           e.FirstName,
                           e.LastName,
                           e.RoleOf,
                           e.PhoneNumber,
                           e.DateOfBirth,
                           e.DateOfStart,
                           e.Address,
                           e.Photo
                       }).ToList();
            dgvEmployee.DataSource = emp;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text) || string.IsNullOrEmpty(txtRoleOf.Text) || string.IsNullOrEmpty(mskPhoneNumber.Text) || string.IsNullOrEmpty(mskDateOfBirth.Text)||string.IsNullOrEmpty(mskDateOfStart.Text)||string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Lütfen bilgileri doldurun!", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                empBusi.Add(new Employee
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    RoleOf = txtRoleOf.Text,
                    PhoneNumber = mskPhoneNumber.Text,
                    DateOfBirth = Convert.ToDateTime(mskDateOfBirth.Text),
                    DateOfStart = Convert.ToDateTime(mskDateOfStart.Text),
                    Address = txtAddress.Text,
                    Photo = txtPhoto1.Text
                });
                ListEmployee();
                MessageBox.Show("Kayıt Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }   
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text) || string.IsNullOrEmpty(txtRoleOf.Text) || string.IsNullOrEmpty(mskPhoneNumber.Text) || string.IsNullOrEmpty(mskDateOfBirth.Text) || string.IsNullOrEmpty(mskDateOfStart.Text) || string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Lütfen bilgileri doldurun!", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                empBusi.Edit(new Employee
                {
                    EmployeeID = Convert.ToInt32(txtID.Text),
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    RoleOf = txtRoleOf.Text,
                    PhoneNumber = mskPhoneNumber.Text,
                    DateOfBirth = Convert.ToDateTime(mskDateOfBirth.Text),
                    DateOfStart = Convert.ToDateTime(mskDateOfStart.Text),
                    Address = txtAddress.Text,
                    Photo = txtPhoto1.Text
                });
                ListEmployee();
                MessageBox.Show("Güncelleme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text) || string.IsNullOrEmpty(txtRoleOf.Text) || string.IsNullOrEmpty(mskPhoneNumber.Text) || string.IsNullOrEmpty(mskDateOfBirth.Text) || string.IsNullOrEmpty(mskDateOfStart.Text) || string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Lütfen bilgileri doldurun!", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                empBusi.Remove(Convert.ToInt32(txtID.Text));
                dgvEmployee.DataSource = empBusi.GetEmployees();
                MessageBox.Show("Silme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }       
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            ListEmployee();
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComeBack_Click(object sender, EventArgs e)
        {
            Forms.MainFromAdmin adminForm = new Forms.MainFromAdmin();
            adminForm.Show();
            this.Hide();
        }

        private void btnSelectedImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            picturePhoto.ImageLocation = openFileDialog1.FileName;
            txtPhoto1.Text = openFileDialog1.FileName;
        }

        private void dgvEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvEmployee.CurrentRow.Cells["EmployeeID"].Value.ToString();
            txtFirstName.Text = dgvEmployee.CurrentRow.Cells["FirstName"].Value.ToString();
            txtLastName.Text = dgvEmployee.CurrentRow.Cells["LastName"].Value.ToString();
            txtRoleOf.Text=dgvEmployee.CurrentRow.Cells["RoleOf"].Value.ToString();
            mskPhoneNumber.Text = dgvEmployee.CurrentRow.Cells["PhoneNumber"].Value.ToString();
            mskDateOfBirth.Text = dgvEmployee.CurrentRow.Cells["DateOfBirth"].Value.ToString();
            mskDateOfStart.Text = dgvEmployee.CurrentRow.Cells["DateOfStart"].Value.ToString();
            txtAddress.Text = dgvEmployee.CurrentRow.Cells["Address"].Value.ToString();
            txtPhoto1.Text = dgvEmployee.CurrentRow.Cells["Photo"].Value.ToString();

            picturePhoto.ImageLocation = dgvEmployee.CurrentRow.Cells["Photo"].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear c = new Clear();
            c.ClearAll(this);
        }
    }
}
