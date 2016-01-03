namespace Lab5
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
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Outline = new System.Windows.Forms.CheckBox();
            this.Fill = new System.Windows.Forms.CheckBox();
            this.penWidth = new System.Windows.Forms.ListBox();
            this.fillColour = new System.Windows.Forms.ListBox();
            this.penColour = new System.Windows.Forms.ListBox();
            this.Draw = new System.Windows.Forms.GroupBox();
            this.inputText = new System.Windows.Forms.TextBox();
            this.text = new System.Windows.Forms.RadioButton();
            this.Ellipse = new System.Windows.Forms.RadioButton();
            this.Rectangle = new System.Windows.Forms.RadioButton();
            this.Line = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawings = new System.Windows.Forms.Panel();
            this.drawingPanel.SuspendLayout();
            this.Draw.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawingPanel
            // 
            this.drawingPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.drawingPanel.Controls.Add(this.label3);
            this.drawingPanel.Controls.Add(this.label2);
            this.drawingPanel.Controls.Add(this.label1);
            this.drawingPanel.Controls.Add(this.Outline);
            this.drawingPanel.Controls.Add(this.Fill);
            this.drawingPanel.Controls.Add(this.penWidth);
            this.drawingPanel.Controls.Add(this.fillColour);
            this.drawingPanel.Controls.Add(this.penColour);
            this.drawingPanel.Controls.Add(this.Draw);
            this.drawingPanel.Controls.Add(this.menuStrip1);
            this.drawingPanel.Location = new System.Drawing.Point(0, -2);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(755, 261);
            this.drawingPanel.TabIndex = 0;
            this.drawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingPanel_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(602, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Pen Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(442, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fill Colour";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Pen Colour";
            // 
            // Outline
            // 
            this.Outline.AutoSize = true;
            this.Outline.Location = new System.Drawing.Point(406, 219);
            this.Outline.Name = "Outline";
            this.Outline.Size = new System.Drawing.Size(59, 17);
            this.Outline.TabIndex = 5;
            this.Outline.Text = "Outline";
            this.Outline.UseVisualStyleBackColor = true;
            // 
            // Fill
            // 
            this.Fill.AutoSize = true;
            this.Fill.Location = new System.Drawing.Point(406, 196);
            this.Fill.Name = "Fill";
            this.Fill.Size = new System.Drawing.Size(38, 17);
            this.Fill.TabIndex = 4;
            this.Fill.Text = "Fill";
            this.Fill.UseVisualStyleBackColor = true;
            // 
            // penWidth
            // 
            this.penWidth.FormattingEnabled = true;
            this.penWidth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.penWidth.Location = new System.Drawing.Point(602, 70);
            this.penWidth.Name = "penWidth";
            this.penWidth.Size = new System.Drawing.Size(120, 134);
            this.penWidth.TabIndex = 3;
            // 
            // fillColour
            // 
            this.fillColour.FormattingEnabled = true;
            this.fillColour.Items.AddRange(new object[] {
            "White",
            "Black",
            "Red",
            "Blue",
            "Green"});
            this.fillColour.Location = new System.Drawing.Point(442, 70);
            this.fillColour.Name = "fillColour";
            this.fillColour.Size = new System.Drawing.Size(120, 95);
            this.fillColour.TabIndex = 2;
            // 
            // penColour
            // 
            this.penColour.FormattingEnabled = true;
            this.penColour.Items.AddRange(new object[] {
            "Black",
            "Red",
            "Blue",
            "Green"});
            this.penColour.Location = new System.Drawing.Point(283, 70);
            this.penColour.Name = "penColour";
            this.penColour.Size = new System.Drawing.Size(120, 95);
            this.penColour.TabIndex = 1;
            // 
            // Draw
            // 
            this.Draw.Controls.Add(this.inputText);
            this.Draw.Controls.Add(this.text);
            this.Draw.Controls.Add(this.Ellipse);
            this.Draw.Controls.Add(this.Rectangle);
            this.Draw.Controls.Add(this.Line);
            this.Draw.Location = new System.Drawing.Point(33, 56);
            this.Draw.Name = "Draw";
            this.Draw.Size = new System.Drawing.Size(228, 186);
            this.Draw.TabIndex = 0;
            this.Draw.TabStop = false;
            this.Draw.Text = "Draw";
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(7, 116);
            this.inputText.Multiline = true;
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(215, 64);
            this.inputText.TabIndex = 4;
            // 
            // text
            // 
            this.text.AutoSize = true;
            this.text.Location = new System.Drawing.Point(7, 92);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(49, 17);
            this.text.TabIndex = 3;
            this.text.TabStop = true;
            this.text.Text = "Text ";
            this.text.UseVisualStyleBackColor = true;
            // 
            // Ellipse
            // 
            this.Ellipse.AutoSize = true;
            this.Ellipse.Location = new System.Drawing.Point(7, 68);
            this.Ellipse.Name = "Ellipse";
            this.Ellipse.Size = new System.Drawing.Size(55, 17);
            this.Ellipse.TabIndex = 2;
            this.Ellipse.TabStop = true;
            this.Ellipse.Text = "Ellipse";
            this.Ellipse.UseVisualStyleBackColor = true;
            // 
            // Rectangle
            // 
            this.Rectangle.AutoSize = true;
            this.Rectangle.Location = new System.Drawing.Point(7, 44);
            this.Rectangle.Name = "Rectangle";
            this.Rectangle.Size = new System.Drawing.Size(74, 17);
            this.Rectangle.TabIndex = 1;
            this.Rectangle.TabStop = true;
            this.Rectangle.Text = "Rectangle";
            this.Rectangle.UseVisualStyleBackColor = true;
            // 
            // Line
            // 
            this.Line.AutoSize = true;
            this.Line.Location = new System.Drawing.Point(7, 20);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(45, 17);
            this.Line.TabIndex = 0;
            this.Line.TabStop = true;
            this.Line.Text = "Line";
            this.Line.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(755, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // drawings
            // 
            this.drawings.Location = new System.Drawing.Point(0, 258);
            this.drawings.Name = "drawings";
            this.drawings.Size = new System.Drawing.Size(755, 253);
            this.drawings.TabIndex = 0;
            this.drawings.Paint += new System.Windows.Forms.PaintEventHandler(this.drawings_Paint);
            this.drawings.MouseClick += new System.Windows.Forms.MouseEventHandler(this.drawings_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 512);
            this.Controls.Add(this.drawings);
            this.Controls.Add(this.drawingPanel);
            this.Name = "Form1";
            this.Text = "Lab 5 - Anish Asthana";
            this.drawingPanel.ResumeLayout(false);
            this.drawingPanel.PerformLayout();
            this.Draw.ResumeLayout(false);
            this.Draw.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.Panel drawings;
        private System.Windows.Forms.GroupBox Draw;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.RadioButton text;
        private System.Windows.Forms.RadioButton Ellipse;
        private System.Windows.Forms.RadioButton Rectangle;
        private System.Windows.Forms.RadioButton Line;
        private System.Windows.Forms.ListBox penColour;
        private System.Windows.Forms.ListBox penWidth;
        private System.Windows.Forms.ListBox fillColour;
        private System.Windows.Forms.CheckBox Outline;
        private System.Windows.Forms.CheckBox Fill;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
    }
}

