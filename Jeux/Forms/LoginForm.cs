using Jeux.Data;
using Jeux.Models;
using Jeux.Utils;
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Jeux.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            using (var connection = new DatabaseConnection().GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM users WHERE username = @username", connection);
                command.Parameters.AddWithValue("@username", username);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string hashedPassword = reader.GetString("password");
                        bool isAdmin = reader.GetBoolean("is_admin");

                        if (SecurityHelper.VerifyPassword(password, hashedPassword))
                        {
                            if (isAdmin)
                            {
                                // Ouvrir le dashboard admin
                                AdminDashboard adminDashboard = new AdminDashboard();
                                adminDashboard.Show();
                            }
                            else
                            {
                                // Ouvrir le dashboard utilisateur
                                UserDashboard userDashboard = new UserDashboard();
                                userDashboard.Show();
                            }
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Mot de passe incorrect.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Utilisateur non trouvé.");
                    }
                }
            }
        }
    }
}