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
using System.Windows.Forms.VisualStyles;

namespace PictureSlideShow
{
    public partial class Form1 : Form
    {
        //TODO: keyboard shortcuts still work in FS mode.

        //Variable declaration
        private fFullScreen formFS;                                             //For full screen functionality.        

        //Variables initialized
        private readonly int delay = 5;                                         //TODO Make delay dynamic.
        private int currentFolderIndex = 0;                                     //This will be adjusted based on user interaction and the slideshow functions.        
        private List<Folder> folders = new List<Folder>();                      //List of folder objects that will hold image file pathways by folder.        
        private BackgroundWorker bckgrndLoader = new BackgroundWorker();        //Background worker to load image list so the UI is still interactive during longer load times.
        private BackgroundWorker bckgrndTimer = new BackgroundWorker();         //Background worker to enable timer while keeping the UI interactive.
        private bool paused = false;                                            //Pause status.
        private bool skip = false;                                              //To prevent image increment on timer completion if folder or image has been manually incremented.
        
        //Computable properties
        private Folder CurrentFolder => folders[currentFolderIndex];            //This is computable so as to always return the current folder object.
        private bool IsFinalFolder => currentFolderIndex + 1 >= folders.Count;  //This is computable so as to always return the current status.      
      
        //Initialize the form.
        public Form1()
        {
            InitializeComponent();
            InitializeBackgroundWorkers();
            KeyPreview = true;                                                  //HACK: replace with ProcessCmdKey as presented here https://stackoverflow.com/questions/3172731/forms-not-responding-to-keydown-events
        }

        //Initialize background workers.
        private void InitializeBackgroundWorkers()
        {
            //Loader
            bckgrndLoader.DoWork += new DoWorkEventHandler(bckgrndLoader_DoWork);
            bckgrndLoader.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bckgrndLoader_RunWorkerCompleted);
            bckgrndLoader.WorkerSupportsCancellation = true;                                                            //TODO: Loader cancellation still needs implementation.

            //Timer
            bckgrndTimer.DoWork += new DoWorkEventHandler(bckgrndTimer_DoWork);
            bckgrndTimer.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bckgrndTimer_RunWorkerCompleted);
            bckgrndTimer.WorkerSupportsCancellation = true;
        }

        //Start the slide show.
        private void BtnStartSlide_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please select a parent directory. The program will pull image files from this directory and from all subdirectories that contain .jpg files. Images will be grouped based on their containing folder.");
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                //Start background loader
                bckgrndLoader.RunWorkerAsync();
            }
        }

        //Stop the slide show and clear the picturebox.
        private void BtnStopSlide_Click(object sender, EventArgs e)
        {
            //Cancel the background timer, clear the image, and clear the list of folders.
            bckgrndTimer.CancelAsync();
            pictureBox1.Image = null;
            folders.Clear();
        }

        //Pause the slides how.
        private void BtnPauseShow_Click(object sender, EventArgs e)
        {
            //If currently paused. Restart the timer.
            if (paused)
            {
                paused = false;
                bckgrndTimer.RunWorkerAsync();
                BtnPauseShow.Text = "| |";
            }
            //If not curently paused, stop the timer.
            else
            {
                paused = true;
                bckgrndTimer.CancelAsync();
                BtnPauseShow.Text = ">";
            }
        }

        //Prevous folder button, increment backwards one folder.
        private void BtnPreviousFolder_Click(object sender, EventArgs e)
        {
            //Skip
            Skip(-1, "folder");
        }

        //Previous image button, increment backwards 1 image.
        private void PreviousImage_Click(object sender, EventArgs e)
        {
            //Skip
            Skip(-1, "file");
        }

        //Next image button, increment foward 1 image.
        private void NextImage_Click(object sender, EventArgs e)
        {
            //Skip
            Skip(1, "file");
        }

        //Next folder button, increment forwards one folder.
        private void NextFolder_Click(object sender, EventArgs e)
        {
            //Skip
            Skip(1, "folder");    
        }

        //Navigation functions for Ctrl + arrows.
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && e.Control)
            {
                Skip(-1, "file");
            }
            else if (e.KeyCode == Keys.Right && e.Control)
            {
                Skip(1, "file");
            }
            else if (e.KeyCode == Keys.Up && e.Control)
            {
                Skip(1, "folder");
            }
            else if (e.KeyCode == Keys.Down && e.Control)
            {
                Skip(-1, "folder");
            }
            else if (e.KeyCode == Keys.F4 && e.Control)
            {
               Application.Exit();
            }
            else if (e.KeyCode == Keys.F && e.Control)
            {
                FSMode();
            }
        }

        /// <summary>
        /// Skip image manually and restart the timer.
        /// </summary>
        /// <param name="increment">Integer representation of the skip. 1 progresses the associated index forward 1 place. All other entries result in moving the associated index back 1.</param>
        /// <param name="type">String representation of the type. "file" for file. All other entries result in folder.</param>
        public void Skip(int increment, string type)
        {
            if (!(folders.Count == 0)) //Only proceed if folders list is filled.
            {
                //Set skip variable
                skip = true;

                //Cancel timer
                bckgrndTimer.CancelAsync();

                //Increment according to type.
                if (type == "file")
                {
                    FileIncrement(increment);
                }
                else //increment the folder            
                {
                    FolderIncrement(increment);
                }

                //Fill the picturebox.
                FillPB(); 
            }
        }

        //Start FS mode on selection of FSMode button.
        private void BtnFullScreen_Click(object sender, EventArgs e)
        {
            FSMode();
        }

        //Start FS mode on double click of image.
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            FSMode();
        }

        //Launch FS.
        public void FSMode()
        {
            //Create an instance of the full screen form and feed it the current image.
            formFS = new fFullScreen(this);
            formFS.Slide = pictureBox1.Image;
            formFS.Show();
        }

        //Fill picturebox(es)
        private void FillPB()
        {
            //Load the picturebox with the return of the GetFileName method.
            try
            {
                pictureBox1.Load(CurrentFolder.GetFileName());
            }
            catch (Exception)
            {
                return;
            }

            //If there exists an instace of the full screen form, then push the image to that form as well.
            if (!(formFS is null))
            {
                formFS.Slide = pictureBox1.Image;
            }
        }

        //Increment the file. Adjust for file file or first file as necessary.
        private void FileIncrement(int increment)
        {
            //TODO Look into making this more readable.

            if (increment == 1) //If a positive increment
            {
                if (CurrentFolder.IsFinalImage) //If no more images in this folder
                {
                    if (IsFinalFolder) //If no more folders, inform the user but don't remove the image.
                    {
                        MessageBox.Show("No more images!");
                        return;
                    }
                    else
                    {
                        currentFolderIndex++; //Otherwise, migrate up a folder.
                        folders[currentFolderIndex].CurrentFileIndex = 0; //Want to insure that the first image in the next folder is pulled.
                    }
                }
                else //If not last image, migrate up an image.
                {
                    CurrentFolder.CurrentFileIndex++;
                }
            }
            else //If a negative increment
            {
                if (!CurrentFolder.IsFirstImage) //If not the first image in the folder.
                {
                    CurrentFolder.CurrentFileIndex--; //increment back an image.
                }
                else
                {
                    if (currentFolderIndex == 0) //Else, if this is the first image in the first folder, then warn the user but don't remove the image.
                    {
                        MessageBox.Show("At the begining of images.");
                    }
                    else //Else increment back one image.
                    {
                        currentFolderIndex--;
                        folders[currentFolderIndex].CurrentFileIndex = folders[currentFolderIndex].Length - 1; //When navigating back a folder by image, want to start with the last image in the prior folder.
                    }
                }
            }
        }

        //Increment the folder. Adjust for first or last folder.
        private void FolderIncrement(int increment)
        {
            //TODO See about making this more readable.
            if (increment == 1)
            {
                if (IsFinalFolder)
                {
                    MessageBox.Show("This is the final image folder.");
                    return;
                }
                else
                {
                    currentFolderIndex++;
                    CurrentFolder.CurrentFileIndex = 0; //Want to start with the first image when navigating whole folders.
                    FillPB();
                }
            }
            else
            {
                if (currentFolderIndex == 0)
                {
                    MessageBox.Show("This is the first folder.");
                    return;
                }
                else
                {
                    currentFolderIndex--;
                    CurrentFolder.CurrentFileIndex = 0; //Want to start with the first image when navigating whole folders.
                    FillPB();
                }
            }
        }

        //Locate and order files into a list of folder objects.
        private void bckgrndLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            //Generate list of folder objects, each with a list of image pathways.
            SourceImages();

            //TODO: include an option to cancel the load.
        }

        //Upon completion, start the slide show.
        private void bckgrndLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //TODO: include handling of errors or a cancel order.

            //Fill the picturebox with the first image (folder index 0 filename index 0).
            FillPB();

            //Start the backgroundworker (timer).
            bckgrndTimer.RunWorkerAsync();
        }

        //Count time in the background until set delay is met.
        private void bckgrndTimer_DoWork(object sender, DoWorkEventArgs e)
        {
            //Convert sender object to background worker
            BackgroundWorker worker = sender as BackgroundWorker;

            //Determine timeToChange
            DateTime timeToChange = DateTime.Now.AddSeconds(delay);

            //Wait until timeToChange is met.
            while (DateTime.Now < timeToChange)
            {
                //If cancellation order is sent, set cancel to true and break out of the wait.
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
            }
        }

        //When delay is met, call the FileIncrement and FillPB methods. Then restart the timer.
        private void bckgrndTimer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //If error.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            //If cancelled.
            else if (e.Cancelled)
            {
                //If the image/folder was manually incremented
                if (skip)
                {
                    //Reset skip variable, fill the PB, and restart the timer.
                    skip = false;
                    bckgrndTimer.RunWorkerAsync();
                }
                //If cancelation was not the result of a manual skip, do nothing else.
            }
            //Otherwise
            else
            {
                //Increment image index
                FileIncrement(1);

                //Fill PB
                FillPB();

                //Restart the timer
                bckgrndTimer.RunWorkerAsync();
            }
        }

        //Source image files
        private void SourceImages()
        {
            // Using wild card so all folders are pulled.
            string[] initialFolders = Directory.GetDirectories(folderBrowserDialog1.SelectedPath, "*", SearchOption.AllDirectories);

            //Suffle the list by assiging GUIDs to the array elements and ordering them in a new list.
            var shuffled = initialFolders.OrderBy(x => Guid.NewGuid()).ToList();

            //Loop through the list and build a folder object if jpg fils are found. Add the object to the folders list.
            foreach (string pathway in shuffled)
            {
                string[] files = Directory.GetFiles(pathway, "*.jpg");
                if (files.Length > 0)
                {
                    files.OrderBy(f => f); //TODO Confirm that this orderby is necessary. If so, determine if it should be made dynamic.
                    Folder folder = new Folder(files);
                    folders.Add(folder);
                }
            }
        }
    }
}
