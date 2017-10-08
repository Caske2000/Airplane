using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotPlanes
{
    public partial class Form1 : Form
    {
        // Variabelen bovenaan
        private List<PlanePic> picPool = new List<PlanePic>();

        public Form1()
        {
            InitializeComponent();

            Setup();
        }

        /// <summary>
        /// Is run when the project loads, sets everything up
        /// </summary>
        private void Setup()
        {
            Console.WriteLine("STARTING");
            string path = "";

            // Ask the user which folder to use
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = false;
            folderDlg.Description = "Choose your image folder";
            // Show the FolderBrowserDialog
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = folderDlg.SelectedPath;
            } else
            {
                MessageBox.Show("Something went wrong in selection the folder", "Folder error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }


            // SGet all the files in the selected folder and add them to the active pool
            foreach (string pic in Directory.GetFiles(path))
            {
                picPool.Add(new PlanePic(pic, 0));
            }

            // Load the first pair of pictures
            LoadPictures();
        }

        private void LoadPictures()
        {
            // Order the list based on the pictures score
            picPool = picPool.OrderBy(p => p.Score).ToList();

            // Load the first two pictures
            pictureBox1.Load(picPool[0].Path);
            pictureBox2.Load(picPool[1].Path);

            // Reload the top 3
            top1.Load(picPool[picPool.Count - 1].Path);
            top2.Load(picPool[picPool.Count - 2].Path);
            top3.Load(picPool[picPool.Count - 3].Path);

            // Also add their scores
            textBox1.Text = picPool[picPool.Count - 1].Score.ToString();
            textBox2.Text = picPool[picPool.Count - 2].Score.ToString();
            textBox3.Text = picPool[picPool.Count - 3].Score.ToString();
        }

        /// <summary>
        /// When the user presses the left image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // If there are not enough pictures, the program should terminate
            if (picPool.Count < 4)
            {
                MessageBox.Show("We have reached a top 3!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Increase the score of the winning image by 1, we do this first to avoid deletion problems
            picPool[0].Score++;

            // Removes the losing image from the active pool
            picPool.RemoveAt(1);

            // Load the next set of pictures
            LoadPictures();
        }

        /// <summary>
        /// When the user presses the right image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // If there are not enough pictures, the program should terminate
            if (picPool.Count < 4)
            {
                MessageBox.Show("We have reached a top 3!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Increase the score of the winning image by 1, we do this first to avoid deletion problems
            picPool[1].Score++;

            // Removes the losing image from the active pool
            picPool.RemoveAt(0);

            // Load the next set of pictures
            LoadPictures();
        }
    }
}
