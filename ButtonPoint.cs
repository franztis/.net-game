using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavmaxiaGame
{
    public class ButtonPoint : Button
    {
        public Boolean isTaken { get; set; }        //Is set to true when a ButtonPoint belongs to a Warship
        public Boolean isHit = false;
        public Warship warshipUpper { get; set; }
        public Battlefield battlefieldUpper{get; set;}
        public ButtonPoint()
        {
            this.Click += new EventHandler(ButtonClick);
            this.Width = 30;
            this.Height = 30;
            this.BackColor = Color.LightGray;
            this.Font = new Font("Calibri", 16);
            this.ForeColor = Color.Black;
        }

        public void ButtonClick(object sender, EventArgs e)     //This method is an event of clicking an enemy battlefield button
        {                                                       //Because those buttonPoints are the ones we can click
            ButtonPoint currentButton = ((ButtonPoint)sender);
            
            if (this.isTaken)
            {
                //currentButton.BackColor = Color.Green;
                currentButton.Text = "X";
                currentButton.ForeColor = Color.Red;
                currentButton.isHit = true;
                currentButton.Enabled = false;
                currentButton.battlefieldUpper.upperForm.playerTries++;
                warshipUpper.AttemptRemoval(currentButton);     //If the ButtonPoint is taken attempt to remove it from the ship it belongs to.
                currentButton.battlefieldUpper.upperForm.Enabled = false;
                currentButton.battlefieldUpper.upperForm.ComputerMove();
                return;
            }
            currentButton.Text = "-";
            currentButton.ForeColor = Color.Green;
            currentButton.battlefieldUpper.upperForm.Enabled = false;
            currentButton.isHit = true;
            currentButton.battlefieldUpper.upperForm.playerTries++;
            //currentButton.BackColor = Color.Red;
            currentButton.Enabled = false;
            currentButton.battlefieldUpper.upperForm.ComputerMove();
        }

        public void ComputerButtonPick()    //The buttonPoints of our battlefield are disabled so we cant click them
        {                                   //The code will 'pick' a buttonPoint of ours by changing its isHit value
            if (this.isTaken)               //And its appearance.It will also remove it from the warship it belongs to.
            {
                //this.BackColor = Color.Green;
                this.Text = "X";
                this.ForeColor = Color.Red;
                this.Enabled = false;
                this.isHit = true;
                warshipUpper.AttemptRemoval(this);
                return;
            }
            //this.BackColor = Color.Red;
            this.Text = "-";
            this.ForeColor = Color.Green;
            this.isHit = true;
            this.Enabled = false;
        }


    }
}
