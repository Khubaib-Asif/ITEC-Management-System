using System;
using System.Windows.Forms;
using ITECApp.DataAccess;
using ITECApp.Entities;

namespace ITECApp.Forms
{
    public partial class ManageSponsorsForm : Form
    {
        private DataGridView dgvSponsors;
        private Button btnAddSponsor;
        private Button btnEditSponsor;
        private Button btnDeleteSponsor;

        public ManageSponsorsForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadSponsors();
        }

        private void InitializeCustomComponents()
        {
            dgvSponsors = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 200
            };
            btnAddSponsor = new Button
            {
                Text = "Add Sponsor",
                Dock = DockStyle.Top,
                Height = 30
            };
            btnEditSponsor = new Button
            {
                Text = "Edit Sponsor",
                Dock = DockStyle.Top,
                Height = 30
            };
            btnDeleteSponsor = new Button
            {
                Text = "Delete Sponsor",
                Dock = DockStyle.Top,
                Height = 30
            };

            btnAddSponsor.Click += btnAddSponsor_Click;
            btnEditSponsor.Click += btnEditSponsor_Click;
            btnDeleteSponsor.Click += btnDeleteSponsor_Click;

            // Add dgvSponsors, btnAddSponsor, btnEditSponsor, and btnDeleteSponsor to the form's controls
            this.Controls.Add(btnDeleteSponsor);
            this.Controls.Add(btnEditSponsor);
            this.Controls.Add(btnAddSponsor);
            this.Controls.Add(dgvSponsors);
        }

        private void LoadSponsors()
        {
            var sponsors = new SponsorDAL().GetAllSponsors();
            dgvSponsors.DataSource = sponsors;
        }

        private void btnAddSponsor_Click(object sender, EventArgs e)
        {
            // Add new sponsor
            var sponsor = new Sponsor
            {
                SponsorName = "New Sponsor",
                SponsorType = "Type"
            };
            new SponsorDAL().AddSponsor(sponsor);
            LoadSponsors();
        }

        private void btnEditSponsor_Click(object sender, EventArgs e)
        {
            // Edit selected sponsor
            if (dgvSponsors.SelectedRows.Count > 0)
            {
                var selectedSponsor = (Sponsor)dgvSponsors.SelectedRows[0].DataBoundItem;
                selectedSponsor.SponsorName = "Edited Sponsor";
                selectedSponsor.SponsorType = "Edited Type";
                new SponsorDAL().UpdateSponsor(selectedSponsor);
                LoadSponsors();
            }
            else
            {
                MessageBox.Show("Please select a sponsor to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteSponsor_Click(object sender, EventArgs e)
        {
            // Delete selected sponsor
            if (dgvSponsors.SelectedRows.Count > 0)
            {
                var selectedSponsor = (Sponsor)dgvSponsors.SelectedRows[0].DataBoundItem;
                new SponsorDAL().DeleteSponsor(selectedSponsor.SponsorId);
                LoadSponsors();
            }
            else
            {
                MessageBox.Show("Please select a sponsor to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
