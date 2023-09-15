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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        public UserForm(String playerNameParam)
        {
            playerName = playerNameParam;
            InitializeComponent();
        }

        public String playerName { get; }

        private void UserForm_Load(object sender, EventArgs e)
        {
            WelcomeLabel.Text = "Welcome " + playerName;
        }

        private void PersonalResultsButton_Click(object sender, EventArgs e)
        {
            ResultTextbox.Text = "";
            String connectionString = "Data Source=NavalBattleDB.db;Version=3;";
            SQLiteConnection connectionObj = new SQLiteConnection(connectionString);
            connectionObj.Open();
            String queryString = "Select * from ResultData where username=@username";
            SQLiteCommand command = new SQLiteCommand(queryString, connectionObj);
            command.Parameters.AddWithValue("@username", playerName);
            SQLiteDataReader reader = command.ExecuteReader();
            String result="";
            if (!reader.HasRows)
            {
                reader.Close();
                connectionObj.Close();
                MessageBox.Show("No games played yet!");
                return;
            }
            ResultTextbox.Text += playerName + " results:\n\n";
            while (reader.Read())
            {
                result +="Tries: "+reader[2].ToString();
                result += ", Time: "+reader[3].ToString();
                result += ", " + reader[4].ToString();
                ResultTextbox.Text += result+"\n";
                result = "";
            }
            reader.Close();
            connectionObj.Close();
        }

        private void SeeResultsSearch_Click(object sender, EventArgs e)
        {
            ResultTextbox.Text = "";
            if (UsernameTextbox.Text=="")
            {
                MessageBox.Show("Username must not be null.");
                return;
            }
            String connectionString = "Data Source=NavalBattleDB.db;Version=3;";
            SQLiteConnection connectionObj = new SQLiteConnection(connectionString);
            connectionObj.Open();
            String queryString = "Select * from ResultData where username=@username";
            SQLiteCommand command = new SQLiteCommand(queryString, connectionObj);
            command.Parameters.AddWithValue("@username", UsernameTextbox.Text);
            SQLiteDataReader reader = command.ExecuteReader();
            String result = "";
            if(!reader.HasRows)
            {
                reader.Close();
                connectionObj.Close();
                MessageBox.Show("Username not found or user hasn't played any games yet.");
                return;
            }
            ResultTextbox.Text += UsernameTextbox.Text + " results:\n\n";
            while (reader.Read())
            {
                result += "Tries: " + reader[2].ToString();
                result += ", Time: " + reader[3].ToString();
                result += ", " + reader[4].ToString();
                ResultTextbox.Text += result + "\n";
                result = "";
            }
            reader.Close();
            connectionObj.Close();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            new GameForm(playerName).Show();
        }
    }
}
