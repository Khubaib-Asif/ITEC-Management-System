using System;
using System.Windows.Forms;
using ITECApp.DataAccess;
using ITECApp.Entities;

namespace ITECApp.Forms
{
    public partial class ManageVendorsForm : Form
    {
        public ManageVendorsForm()
        {
            InitializeComponent();
            LoadVendors();
        }

        private void LoadVendors()
        {
            var vendors = new VendorDAL().GetAllVendors();
            dgvVendors.DataSource = vendors;
        }

        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            // Add new vendor
            var vendor = new Vendor
            {
                VendorName = "New Vendor",
                VendorType = "Type"
            };
            new VendorDAL().AddVendor(vendor);
            LoadVendors();
        }

        private void btnEditVendor_Click(object sender, EventArgs e)
        {
            // Edit selected vendor
            if (dgvVendors.SelectedRows.Count > 0)
            {
                var selectedVendor = (Vendor)dgvVendors.SelectedRows[0].DataBoundItem;
                selectedVendor.VendorName = "Edited Vendor";
                selectedVendor.VendorType = "Edited Type";
                new VendorDAL().UpdateVendor(selectedVendor);
                LoadVendors();
            }
            else
            {
                MessageBox.Show("Please select a vendor to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteVendor_Click(object sender, EventArgs e)
        {
            // Delete selected vendor
            if (dgvVendors.SelectedRows.Count > 0)
            {
                var selectedVendor = (Vendor)dgvVendors.SelectedRows[0].DataBoundItem;
                new VendorDAL().DeleteVendor(selectedVendor.VendorId);
                LoadVendors();
            }
            else
            {
                MessageBox.Show("Please select a vendor to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

