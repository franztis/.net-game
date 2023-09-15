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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            String connectionString = "Data Source=NavalBattleDB.db;Version=3;";
            SQLiteConnection connectionObj = new SQLiteConnection(connectionString);
            connectionObj.Open();
            String queryString = "Select * from UserData where username=@username";
            SQLiteCommand command = new SQLiteCommand(queryString, connectionObj);
            command.Parameters.AddWithValue("@username", UsernameTextbox.Text);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                connectionObj.Close();
                MessageBox.Show("Username already in use!Try another one!");
            }
            else
            {
                queryString = @"INSERT INTO UserData(username, password) values($username, $password)";
                command = new SQLiteCommand(queryString, connectionObj);
                command.Parameters.Add("$username", DbType.String).Value=UsernameTextbox.Text;
                command.Parameters.Add("$password", DbType.String).Value=PasswordTextbox.Text;
                command.ExecuteNonQuery();
                connectionObj.Close();
                new UserForm(UsernameTextbox.Text).Show();
                this.Close();
            }
            connectionObj.Close();
            
        }
    }
}
