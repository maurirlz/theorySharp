namespace SimonMemoryGame
{
    partial class SimoneForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimoneForm));
            this.Blue = new System.Windows.Forms.Button();
            this.Green = new System.Windows.Forms.Button();
            this.Yellow = new System.Windows.Forms.Button();
            this.Red = new System.Windows.Forms.Button();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Blue
            // 
            this.Blue.BackColor = System.Drawing.SystemColors.Desktop;
            this.Blue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Blue.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Blue.FlatAppearance.BorderSize = 3;
            this.Blue.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Blue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Blue.Location = new System.Drawing.Point(489, 294);
            this.Blue.Name = "Blue";
            this.Blue.Size = new System.Drawing.Size(315, 200);
            this.Blue.TabIndex = 1;
            this.Blue.Text = "Blue";
            this.Blue.UseVisualStyleBackColor = false;
            this.Blue.Click += new System.EventHandler(this.Blue_Click);
            // 
            // Green
            // 
            this.Green.BackColor = System.Drawing.SystemColors.Desktop;
            this.Green.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Green.FlatAppearance.BorderSize = 3;
            this.Green.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Green.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Green.Location = new System.Drawing.Point(63, 41);
            this.Green.Name = "Green";
            this.Green.Size = new System.Drawing.Size(315, 198);
            this.Green.TabIndex = 3;
            this.Green.Text = "Green";
            this.Green.UseVisualStyleBackColor = false;
            this.Green.Click += new System.EventHandler(this.Green_Click);
            // 
            // Yellow
            // 
            this.Yellow.BackColor = System.Drawing.SystemColors.Desktop;
            this.Yellow.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Yellow.FlatAppearance.BorderSize = 3;
            this.Yellow.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Yellow.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Yellow.Location = new System.Drawing.Point(63, 294);
            this.Yellow.Name = "Yellow";
            this.Yellow.Size = new System.Drawing.Size(315, 198);
            this.Yellow.TabIndex = 5;
            this.Yellow.Text = "Yellow";
            this.Yellow.UseVisualStyleBackColor = false;
            this.Yellow.Click += new System.EventHandler(this.Yellow_Click);
            // 
            // Red
            // 
            this.Red.BackColor = System.Drawing.SystemColors.Desktop;
            this.Red.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Red.FlatAppearance.BorderSize = 3;
            this.Red.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Red.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Red.Location = new System.Drawing.Point(489, 39);
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(315, 200);
            this.Red.TabIndex = 4;
            this.Red.Text = "Red";
            this.Red.UseVisualStyleBackColor = false;
            this.Red.Click += new System.EventHandler(this.Red_Click);
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.BackColor = System.Drawing.SystemColors.WindowText;
            this.ScoreLabel.Font = new System.Drawing.Font("Lucida Console", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ScoreLabel.Location = new System.Drawing.Point(370, 506);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(130, 24);
            this.ScoreLabel.TabIndex = 6;
            this.ScoreLabel.Text = "Score: 0";
            // 
            // SimoneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(894, 539);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.Yellow);
            this.Controls.Add(this.Red);
            this.Controls.Add(this.Green);
            this.Controls.Add(this.Blue);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Name = "SimoneForm";
            this.Text = "Simon Memory Game - Mauricio Ezequiel Benitez, Frias Lucas, Garavaglia Mauricio, " +
    "Bruzzo Fernando";
            this.Load += new System.EventHandler(this.SimoneForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Blue;
        private System.Windows.Forms.Button Green;
        private System.Windows.Forms.Button Yellow;
        private System.Windows.Forms.Button Red;
        private System.Windows.Forms.Label ScoreLabel;
    }
}

