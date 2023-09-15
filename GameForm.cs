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
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
        }

        public GameForm(String playerUsernameParam)
        {
            InitializeComponent();
            playerUsername = playerUsernameParam; 
        }

        public String playerUsername { get; }
        public static int rowSize = 10;
        public static int colSize = 10;
        public int playerTries=0;
        public Point startPoint = new Point(60, 90);
        public Point enemyStartPoint = new Point(480, 90);
        public Random rand = new Random();
        public Battlefield friendlyBattlefield = new Battlefield(false,10,10);
        public Battlefield enemyBattlefield = new Battlefield(true,10,10);
        public string[] letters = { "A", "B", "C", "D", "E", "F", "G" ,"H","I","J"};
        private int gameTimeSecs=0;
        //List<ButtonPoint> pointsLeftToHit = new List<ButtonPoint>();      Maybe will be implemented!!!
        private void Form1_Load(object sender, EventArgs e)
        {
            friendlyBattlefield.upperForm = this;
            enemyBattlefield.upperForm = this;
            setBattlefield(startPoint,ref  friendlyBattlefield);
            setBattlefield(enemyStartPoint,ref enemyBattlefield);
            /*for (int i=0; i<rowSize; i++)     GO TO ComputerMove function for info!!!!!
            {
                for (int j=0; j<colSize; j++)
                {
                    pointsLeftToHit.Add(friendlyBattlefield.battlefieldPoints[i, j]);
                }
            }
            */
            friendlyBattlefield.setWarship(5);  //Name is set based on size given
            friendlyBattlefield.setWarship(4);
            friendlyBattlefield.setWarship(3);
            friendlyBattlefield.setWarship(2);
            enemyBattlefield.setWarship(5);
            enemyBattlefield.setWarship(4);
            enemyBattlefield.setWarship(3);
            enemyBattlefield.setWarship(2);
            GameTimer.Enabled = true;

        }

        private void setBattlefield(Point startPoint,ref Battlefield newBattlefield)
        {
            Point paddingPoint = new Point(startPoint.X, startPoint.Y);
            ButtonPoint tempButton = new ButtonPoint();
            
            for (int i=0; i<colSize; i++)       //MAYBE NEEDS IMPROVEMENT!!!!!
            {
                Label tempLabel = new Label();
                tempLabel.Font = new Font("Calibri", 14);
                tempLabel.ForeColor = Color.Black;
                //tempLabel.BackColor = Color.Transparent;
                tempLabel.Size = new Size(30, 25);
                tempLabel.Location = new Point(paddingPoint.X +i*30+3, paddingPoint.Y - 30);
                tempLabel.Text = (i+1).ToString();
                this.Controls.Add(tempLabel);
            }
            for (int i = 0; i < newBattlefield.rowSize; i++)
            {
                Label tempLabel = new Label();
                tempLabel.Font = new Font("Calibri", 14);
                tempLabel.ForeColor = Color.Black;
                //tempLabel.BackColor = Color.Transparent;
                tempLabel.Size = new Size(25, 25);
                tempLabel.Location = new Point(paddingPoint.X-30,paddingPoint.Y+5);
                tempLabel.Text = letters[i];
                this.Controls.Add(tempLabel);
                for (int j = 0; j < newBattlefield.colSize; j++)
                {
                    tempButton = new ButtonPoint();
                    tempButton.Location = new Point(paddingPoint.X + 30 * j, paddingPoint.Y);
                    tempButton.battlefieldUpper = newBattlefield;
                    tempButton.Enabled = newBattlefield.isEnemyBatt;    //Only the enemy battlefield's buttons can be clicked.
                    newBattlefield.battlefieldPoints[i, j] = tempButton;
                    this.Controls.Add(newBattlefield.battlefieldPoints[i, j]);
                }
                paddingPoint.Y += 30;
            }
        }
        public void GameEnd(bool calledByEnemy)
        {
            GameTimer.Enabled = false;
            string gameTimeFormatted = TimeSpan.FromSeconds(gameTimeSecs).ToString(@"hh\:mm\:ss");
            String connectionString = "Data Source=NavalBattleDB.db;Version=3;";
            SQLiteConnection connectionObj = new SQLiteConnection(connectionString);
            connectionObj.Open();
            string queryString = @"INSERT INTO ResultData(username,tries,time,result) values($username,$tries,$time,$result)";
            SQLiteCommand command = new SQLiteCommand(queryString, connectionObj);
            command.Parameters.Add("$username", DbType.String).Value = playerUsername;
            command.Parameters.Add("$tries", DbType.String).Value = playerTries.ToString();
            command.Parameters.Add("$time", DbType.String).Value = gameTimeFormatted;
            if (calledByEnemy)  //If the function is called by the enemy battlefield class , that means all of it's ships were destroyed first
            {
                command.Parameters.Add("$result", DbType.String).Value = "Won";
                command.ExecuteNonQuery();
                connectionObj.Close();
                MessageBox.Show($"You won!Moves: {playerTries.ToString()},Time: {gameTimeFormatted}");
                this.Close();
            }
            else 
            {
                command.Parameters.Add("$result", DbType.String).Value = "Lost";
                command.ExecuteNonQuery();
                connectionObj.Close();
                MessageBox.Show($"You Lost!Moves: {playerTries.ToString()},Time: {gameTimeFormatted}");
                this.Close();
            }

        }

        public void ComputerMove()
        {
            int rowToAttack = rand.Next(10);
            int colToAttack = rand.Next(10);
            //MessageBox.Show(rowToAttack.ToString() + "," + colToAttack.ToString());
            while(true)
            {
                if (friendlyBattlefield.battlefieldPoints[rowToAttack,colToAttack].isHit)
                {
                    rowToAttack = rand.Next(10);
                    colToAttack = rand.Next(10);
                    continue;   //Continue makes sure we get to the next iteration and 
                }

                break;
            }
            
            
            friendlyBattlefield.battlefieldPoints[rowToAttack, colToAttack].ComputerButtonPick();
            this.Enabled = true;

            /*int randomIndex = rand.Next(pointsLeftToHit.Count);           !!!ATTENTION!!!!Maybe could be implemented this way!
            pointsLeftToHit[randomIndex].ComputerButtonPick();
            pointsLeftToHit.RemoveAt(randomIndex);
            */

        }

        public void SunkMessage(String message,bool isEnemyShip)
        {
            if (isEnemyShip)
            {
                MessageBox.Show($"Enemy {message} has been sunk!");
            }
            else
            {
                MessageBox.Show($"Your {message} has been sunk!");
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            gameTimeSecs++;
        }
    }
}
