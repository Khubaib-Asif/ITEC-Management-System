using System;
using System.Windows.Forms;
using ITECApp.DataAccess;
using ITECApp.Entities;

namespace ITECApp.Forms
{
    public partial class ManageEventsForm : Form
    {
        public ManageEventsForm()
        {
            InitializeComponent();
            LoadEvents();
        }

        private void LoadEvents()
        {
            var events = new EventDAL().GetAllEvents();
            dgvEvents.DataSource = events;
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            // Add new event
        }

        private void btnEditEvent_Click(object sender, EventArgs e)
        {
            // Edit selected event
        }

        private void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            // Delete selected event
        }
    }
}



