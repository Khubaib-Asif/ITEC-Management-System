namespace ITECApp.Forms
{
    partial class ManageVendorsForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvVendors;
        private Button btnAddVendor;
        private Button btnEditVendor;
        private Button btnDeleteVendor;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvVendors = new DataGridView();
            this.btnAddVendor = new Button();
            this.btnEditVendor = new Button();
            this.btnDeleteVendor = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendors)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVendors
            // 
            this.dgvVendors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendors.Location = new System.Drawing.Point(12, 12);
            this.dgvVendors.Name = "dgvVendors";
            this.dgvVendors.Size = new System.Drawing.Size(776, 300);
            this.dgvVendors.TabIndex = 0;
            // 
            // btnAddVendor
            // 
            this.btnAddVendor.Location = new System.Drawing.Point(12, 330);
            this.btnAddVendor.Name = "btnAddVendor";
            this.btnAddVendor.Size = new System.Drawing.Size(75, 23);
            this.btnAddVendor.TabIndex = 1;
            this.btnAddVendor.Text = "Add Vendor";
            this.btnAddVendor.UseVisualStyleBackColor = true;
            this.btnAddVendor.Click += new System.EventHandler(this.btnAddVendor_Click);
            // 
            // btnEditVendor
            // 
            this.btnEditVendor.Location = new System.Drawing.Point(100, 330);
            this.btnEditVendor.Name = "btnEditVendor";
            this.btnEditVendor.Size = new System.Drawing.Size(75, 23);
            this.btnEditVendor.TabIndex = 2;
            this.btnEditVendor.Text = "Edit Vendor";
            this.btnEditVendor.UseVisualStyleBackColor = true;
            this.btnEditVendor.Click += new System.EventHandler(this.btnEditVendor_Click);
            // 
            // btnDeleteVendor
            // 
            this.btnDeleteVendor.Location = new System.Drawing.Point(190, 330);
            this.btnDeleteVendor.Name = "btnDeleteVendor";
            this.btnDeleteVendor.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteVendor.TabIndex = 3;
            this.btnDeleteVendor.Text = "Delete Vendor";
            this.btnDeleteVendor.UseVisualStyleBackColor = true;
            this.btnDeleteVendor.Click += new System.EventHandler(this.btnDeleteVendor_Click);
            // 
            // ManageVendorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDeleteVendor);
            this.Controls.Add(this.btnEditVendor);
            this.Controls.Add(this.btnAddVendor);
            this.Controls.Add(this.dgvVendors);
            this.Name = "ManageVendorsForm";
            this.Text = "Manage Vendors";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendors)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

