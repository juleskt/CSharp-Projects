namespace EightQueens
{
    partial class Form1
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
            this.HintBox = new System.Windows.Forms.CheckBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HintBox
            // 
            this.HintBox.AutoSize = true;
            this.HintBox.Location = new System.Drawing.Point(25, 25);
            this.HintBox.Name = "HintBox";
            this.HintBox.Size = new System.Drawing.Size(50, 17);
            this.HintBox.TabIndex = 1;
            this.HintBox.Text = "Hints";
            this.HintBox.UseVisualStyleBackColor = true;
            this.HintBox.CheckedChanged += new System.EventHandler(this.HintBox_CheckedChanged);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(100, 25);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 2;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 601);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.HintBox);
            this.Name = "Form1";
            this.Text = "Eight Queens by julest";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Board_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox HintBox;
        private System.Windows.Forms.Button ClearButton;
    }
}

