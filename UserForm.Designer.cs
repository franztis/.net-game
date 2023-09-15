
namespace NavmaxiaGame
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.ResultTextbox = new System.Windows.Forms.RichTextBox();
            this.PersonalResultsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SeeResultsSearch = new System.Windows.Forms.Button();
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeLabel.Location = new System.Drawing.Point(92, 22);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(0, 25);
            this.WelcomeLabel.TabIndex = 0;
            // 
            // ResultTextbox
            // 
            this.ResultTextbox.Enabled = false;
            this.ResultTextbox.Location = new System.Drawing.Point(39, 289);
            this.ResultTextbox.Name = "ResultTextbox";
            this.ResultTextbox.Size = new System.Drawing.Size(313, 364);
            this.ResultTextbox.TabIndex = 1;
            this.ResultTextbox.Text = "";
            // 
            // PersonalResultsButton
            // 
            this.PersonalResultsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PersonalResultsButton.Location = new System.Drawing.Point(63, 133);
            this.PersonalResultsButton.Name = "PersonalResultsButton";
            this.PersonalResultsButton.Size = new System.Drawing.Size(258, 39);
            this.PersonalResultsButton.TabIndex = 2;
            this.PersonalResultsButton.Text = "View personal results";
            this.PersonalResultsButton.UseVisualStyleBackColor = true;
            this.PersonalResultsButton.Click += new System.EventHandler(this.PersonalResultsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(172, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "or";
            // 
            // SeeResultsSearch
            // 
            this.SeeResultsSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeeResultsSearch.Location = new System.Drawing.Point(63, 203);
            this.SeeResultsSearch.Name = "SeeResultsSearch";
            this.SeeResultsSearch.Size = new System.Drawing.Size(258, 39);
            this.SeeResultsSearch.TabIndex = 4;
            this.SeeResultsSearch.Text = "View results by username search ";
            this.SeeResultsSearch.UseVisualStyleBackColor = true;
            this.SeeResultsSearch.Click += new System.EventHandler(this.SeeResultsSearch_Click);
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Location = new System.Drawing.Point(161, 248);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(144, 20);
            this.UsernameTextbox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(59, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Username:";
            // 
            // NewGameButton
            // 
            this.NewGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewGameButton.Location = new System.Drawing.Point(140, 66);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(115, 45);
            this.NewGameButton.TabIndex = 7;
            this.NewGameButton.Text = "New Game";
            this.NewGameButton.UseVisualStyleBackColor = true;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(400, 665);
            this.Controls.Add(this.NewGameButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UsernameTextbox);
            this.Controls.Add(this.SeeResultsSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PersonalResultsButton);
            this.Controls.Add(this.ResultTextbox);
            this.Controls.Add(this.WelcomeLabel);
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserForm";
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.RichTextBox ResultTextbox;
        private System.Windows.Forms.Button PersonalResultsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SeeResultsSearch;
        private System.Windows.Forms.TextBox UsernameTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button NewGameButton;
    }
}