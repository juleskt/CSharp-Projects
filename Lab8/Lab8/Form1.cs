using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab8
{
    public partial class Form1 : Form
    {
        List<string> myFiles = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void openCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openCollectionsDialog.ShowDialog() == DialogResult.OK)
            {
                string reading;
                fileList.Items.Clear();
                myFiles.Clear();

                try
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(openCollectionsDialog.OpenFile());
                    while ((reading = file.ReadLine()) != null)
                    {
                        fileList.Items.Add(reading);
                        myFiles.Add(reading);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading in file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] newFiles = openFileDialog.FileNames;

                if (newFiles.Length > 0)
                {
                    foreach (string file in newFiles)
                    {
                        fileList.Items.Add(file);
                        myFiles.Add(file);
                    }
                }
                else
                    return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string toRemove;
            while (fileList.SelectedItems.Count != 0)
            {
                toRemove = fileList.SelectedItems[0].ToString();
                fileList.Items.Remove(fileList.SelectedItems[0]);
                myFiles.Remove(toRemove);
            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (myFiles.Count > 0 && Int32.Parse(textBox1.Text.ToString()) > 0)
                {
                    Slides slideShow = new Slides(myFiles, Int32.Parse((textBox1.Text.ToString())));
                }
                else if (myFiles.Count <= 0)
                {
                    MessageBox.Show("No images to show", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Int32.Parse(textBox1.Text.ToString()) <= 0)
                {
                    MessageBox.Show("Please enter an integer time interval > 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please enter an integer time interval > 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fileList.Items.Count > 0)
            {
                saveFileDialog.ShowDialog();
                StreamWriter writetext = new StreamWriter(saveFileDialog.OpenFile());
                {
                    foreach (string fileName in myFiles)
                    { 
                        writetext.WriteLine(fileName);
                    }
                }

                writetext.Close();
            }
            else
            {
                MessageBox.Show("No filenames to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
