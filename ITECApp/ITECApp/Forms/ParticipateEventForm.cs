using System;
using System.Windows.Forms;

namespace ITECApp.Forms
{
    public partial class ParticipateEventForm : Form
    {
        public ParticipateEventForm()
        {
            InitializeComponent();
            LoadEvents();
        }

        private void LoadEvents()
        {
            // Load events from the database
        }

        private void btnParticipate_Click(object sender, EventArgs e)
        {
            // Participate in selected event
        }
    }
}
