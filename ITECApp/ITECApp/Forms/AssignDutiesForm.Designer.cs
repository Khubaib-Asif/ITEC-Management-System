namespace ITECApp.Forms
{
    partial class AssignDutiesForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvDuties;
        private ComboBox cmbAssignee;
        private Button btnAssign;

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
            this.dgvDuties = new DataGridView();
            this.cmbAssignee = new ComboBox();
            this.btnAssign = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuties)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDuties
            // 
            this.dgvDuties.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDuties.Location = new System.Drawing.Point(12, 12);
            this.dgvDuties.Name = "dgvDuties";
            this.dgvDuties.Size = new System.Drawing.Size(776, 300);
            this.dgvDuties.TabIndex = 0;
            // 
            // cmbAssignee
            // 
            this.cmbAssignee.FormattingEnabled = true;
            this.cmbAssignee.Location = new System.Drawing.Point(12, 330);
            this.cmbAssignee.Name = "cmbAssignee";
            this.cmbAssignee.Size = new System.Drawing.Size(200, 21);
            this.cmbAssignee.TabIndex = 1;
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(230, 330);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(75, 23);
            this.btnAssign.TabIndex = 2;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // AssignDutiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.cmbAssignee);
            this.Controls.Add(this.dgvDuties);
            this.Name = "AssignDutiesForm";
            this.Text = "Assign Duties";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuties)).EndInit();
            this.ResumeLayout(false);
        }
    }
}


