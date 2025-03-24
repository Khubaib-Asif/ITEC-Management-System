namespace ITECApp.Forms
{
    partial class ManageCommitteesForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvCommittees;
        private Button btnAddCommittee;
        private Button btnEditCommittee;
        private Button btnDeleteCommittee;

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
            this.dgvCommittees = new DataGridView();
            this.btnAddCommittee = new Button();
            this.btnEditCommittee = new Button();
            this.btnDeleteCommittee = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommittees)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCommittees
            // 
            this.dgvCommittees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommittees.Location = new System.Drawing.Point(12, 12);
            this.dgvCommittees.Name = "dgvCommittees";
            this.dgvCommittees.Size = new System.Drawing.Size(776, 300);
            this.dgvCommittees.TabIndex = 0;
            // 
            // btnAddCommittee
            // 
            this.btnAddCommittee.Location = new System.Drawing.Point(12, 330);
            this.btnAddCommittee.Name = "btnAddCommittee";
            this.btnAddCommittee.Size = new System.Drawing.Size(75, 23);
            this.btnAddCommittee.TabIndex = 1;
            this.btnAddCommittee.Text = "Add Committee";
            this.btnAddCommittee.UseVisualStyleBackColor = true;
            this.btnAddCommittee.Click += new System.EventHandler(this.btnAddCommittee_Click);
            // 
            // btnEditCommittee
            // 
            this.btnEditCommittee.Location = new System.Drawing.Point(100, 330);
            this.btnEditCommittee.Name = "btnEditCommittee";
            this.btnEditCommittee.Size = new System.Drawing.Size(75, 23);
            this.btnEditCommittee.TabIndex = 2;
            this.btnEditCommittee.Text = "Edit Committee";
            this.btnEditCommittee.UseVisualStyleBackColor = true;
            this.btnEditCommittee.Click += new System.EventHandler(this.btnEditCommittee_Click);
            // 
            // btnDeleteCommittee
            // 
            this.btnDeleteCommittee.Location = new System.Drawing.Point(190, 330);
            this.btnDeleteCommittee.Name = "btnDeleteCommittee";
            this.btnDeleteCommittee.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteCommittee.TabIndex = 3;
            this.btnDeleteCommittee.Text = "Delete Committee";
            this.btnDeleteCommittee.UseVisualStyleBackColor = true;
            this.btnDeleteCommittee.Click += new System.EventHandler(this.btnDeleteCommittee_Click);
            // 
            // ManageCommitteesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDeleteCommittee);
            this.Controls.Add(this.btnEditCommittee);
            this.Controls.Add(this.btnAddCommittee);
            this.Controls.Add(this.dgvCommittees);
            this.Name = "ManageCommitteesForm";
            this.Text = "Manage Committees";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommittees)).EndInit();
            this.ResumeLayout(false);
        }
    }
}




