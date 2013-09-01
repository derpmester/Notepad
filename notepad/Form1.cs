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

namespace notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Do you want to save the document before closing?",
                "Confirm",
                MessageBoxButtons.YesNoCancel
                );

            switch (result)
            {

                case DialogResult.Cancel:
                    break;
                case DialogResult.No:
                    textBox1.Clear();
                    break;
                case DialogResult.Yes:
                    saveFileDialog1.ShowDialog();
                    textBox1.Clear();
                    break;
                default:
                    textBox1.Clear();
                    break;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Shows the openFileDialog
            openFileDialog1.ShowDialog();
            //Reads the text file
            StreamReader OpenFile = new StreamReader(openFileDialog1.FileName);
            //Displays the text file in the textBox
            textBox1.Text = OpenFile.ReadToEnd();
            //Closes the proccess
            OpenFile.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Determines the file to save
            StreamWriter SaveFile = new StreamWriter(openFileDialog1.FileName);
            //Write file to text
            SaveFile.WriteLine(textBox1.Text);
            //Close shit
            SaveFile.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open dialog
            saveFileDialog1.ShowDialog();
            //Determines the text to save
            StreamWriter Savefile = new StreamWriter(saveFileDialog1.FileName);
            //Write text to file
            Savefile.WriteLine(textBox1.Text);
            //Close stuff
            Savefile.Close();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Declare prntDoc as a new PrintDocument
            System.Drawing.Printing.PrintDocument prntDoc = new System.Drawing.Printing.PrintDocument();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.WordWrap = wordWrapToolStripMenuItem.Checked;
        }

    }
}
