using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavmaxiaGame
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            String connectionString = "Data Source=NavalBattleDB.db;Version=3;";
            SQLiteConnection connectionObj = new SQLiteConnection(connectionString);
            connectionObj.Open();
            String selectQuery = "Select * from UserData where username=@username and password=@password";
            SQLiteCommand loginCommand = new SQLiteCommand(selectQuery,connectionObj);
            loginCommand.Parameters.AddWithValue("@username", UsernameTextbox.Text);
            loginCommand.Parameters.AddWithValue("@password", PasswordTextbox.Text);
            SQLiteDataReader reader = loginCommand.ExecuteReader();
            if (reader.Read())
            {
                //new GameForm(UsernameTextbox.Text).Show();
                connectionObj.Close();
                new UserForm(UsernameTextbox.Text).Show();
                this.Close();
            }
            else
            {
                connectionObj.Close();
                MessageBox.Show("Invalid login.");
            }
            connectionObj.Close();

        }
    }
}
