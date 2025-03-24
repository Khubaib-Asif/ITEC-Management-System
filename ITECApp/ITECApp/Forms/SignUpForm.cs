using ITECApp.BusinessLayer;
using ITECApp.DataAccess;
using ITECApp.Entities;
using ITECApp.Utilities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ITECApp.Forms
{
    public partial class SignUpForm : Form
    {
        private ComboBox cmbRoles = new ComboBox();
        private TextBox txtUsername = new TextBox();
        private TextBox txtEmail = new TextBox();
        private TextBox txtPassword = new TextBox();
        private TextBox txtConfirmPassword = new TextBox();
        private Button btnSignUp = new Button();
        private LinkLabel lnkSignIn = new LinkLabel();
        private Label lblError = new Label();

        public SignUpForm()
        {
            InitializeComponent();
            LoadRoles();
            InitializePlaceholders();
            ApplyStyling();
            AttachEventHandlers();
        }

        private void LoadRoles()
        {
            try
            {
                var roles = new RoleDAL().GetAllRoles();
                cmbRoles.DataSource = roles;
                cmbRoles.DisplayMember = "RoleName";
                cmbRoles.ValueMember = "RoleId";
                cmbRoles.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading roles: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializePlaceholders()
        {
            AddPlaceholder(txtUsername, "Enter username");
            AddPlaceholder(txtEmail, "Enter email");
            AddPlaceholder(txtPassword, "Enter password", true);
            AddPlaceholder(txtConfirmPassword, "Confirm password", true);
        }

        private void AddPlaceholder(TextBox textBox, string placeholder, bool isPassword = false)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;
            if (isPassword) textBox.PasswordChar = '\0';

            textBox.Enter += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.White;
                    if (isPassword) textBox.PasswordChar = '*';
                }
            };

            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                    if (isPassword) textBox.PasswordChar = '\0';
                }
            };
        }

        private void ApplyStyling()
        {
            // Form Styling
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ForeColor = Color.White;
            this.ClientSize = new Size(400, 500);
            this.Text = "ITEC Sign Up";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Control Positioning
            txtUsername.Location = new Point(50, 50);
            txtUsername.Size = new Size(300, 25);

            txtEmail.Location = new Point(50, 100);
            txtEmail.Size = new Size(300, 25);

            txtPassword.Location = new Point(50, 150);
            txtPassword.Size = new Size(300, 25);

            txtConfirmPassword.Location = new Point(50, 200);
            txtConfirmPassword.Size = new Size(300, 25);

            cmbRoles.Location = new Point(50, 250);
            cmbRoles.Size = new Size(300, 25);

            btnSignUp.Location = new Point(50, 300);
            btnSignUp.Size = new Size(300, 35);
            btnSignUp.Text = "Sign Up";
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.BackColor = Color.FromArgb(0, 150, 136);
            btnSignUp.ForeColor = Color.White;

            lnkSignIn.Location = new Point(50, 350);
            lnkSignIn.Size = new Size(200, 20);
            lnkSignIn.Text = "Already have an account? Sign In";
            lnkSignIn.LinkColor = Color.FromArgb(0, 150, 136);

            lblError.Location = new Point(50, 400);
            lblError.Size = new Size(300, 20);
            lblError.ForeColor = Color.OrangeRed;

            this.Controls.AddRange(new Control[] {
                txtUsername, txtEmail, txtPassword, txtConfirmPassword,
                cmbRoles, btnSignUp, lnkSignIn, lblError
            });
        }

        private void AttachEventHandlers()
        {
            btnSignUp.Click += btnSignUp_Click;
            lnkSignIn.LinkClicked += lnkSignIn_LinkClicked;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Visible = false;

                string username = txtUsername.Text == "Enter username" ? "" : txtUsername.Text.Trim();
                string email = txtEmail.Text == "Enter email" ? "" : txtEmail.Text.Trim();
                string password = txtPassword.Text == "Enter password" ? "" : txtPassword.Text;
                string confirmPassword = txtConfirmPassword.Text == "Confirm password" ? "" : txtConfirmPassword.Text;

                if (cmbRoles.SelectedItem == null)
                {
                    ShowError("Select a role!");
                    return;
                }

                var user = new User
                {
                    Username = username,
                    Email = email,
                    PasswordHash = password,
                    RoleId = ((Role)cmbRoles.SelectedItem).RoleId
                };

                var response = new UserBLL().ValidateAndRegister(user, confirmPassword);
                HandleRegistrationResponse(response);
            }
            catch (Exception ex)
            {
                ShowError($"Registration Error: {ex.Message}");
            }
        }

        private void HandleRegistrationResponse(Response<User> response)
        {
            if (response.IsSuccess)
            {
                MessageBox.Show("Registration successful! Please sign in.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                new SignInForm().Show();
            }
            else
            {
                ShowError(response.Message);
            }
        }

        private void lnkSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new SignInForm().Show();
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }
    }
}
