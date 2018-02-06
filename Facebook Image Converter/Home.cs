using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook_Image_Converter
{
    public partial class Home : Form
    {
        String[] selected_files;
        public Home()
        {
            InitializeComponent();
        }

        private void openFilesClick(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                            selected_files = openFileDialog1.FileNames;
                            labelTotalImages.Text = selected_files.Length.ToString() 
                                + " item"+(selected_files.Length>1?"s":"")+" selected.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void openFolderClick(object sender, EventArgs e)
        {
            FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (openFileDialog1)
                    {
                        // Insert code to read the stream here.
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read folder from disk. Original error: " + ex.Message);
                }
            }
        }

        private void closeApp(object sender, EventArgs e)
        {
            //do something before closing app

            Application.Exit();
        }

        private void Convert(object sender, EventArgs e)
        {
            for (var i = 0; i < selected_files.Length; i++)
            {
                var png = Image.FromFile(selected_files[i]);
                
                png.Save("ouput"+i.ToString()+".png", ImageFormat.Png);
            }
        }
    }
}
