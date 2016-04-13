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
using System.Diagnostics;


namespace SNPfreq
{
    /// <summary>
    /// SNPfreq_form class: provides a graphical interface for the user to be able to enter
    /// the path to a snps list file (tab separated text file containing two columns:
    /// chromosome and snp location), a file with genomic locations of interest (also
    /// tab separated; it should contain 4 columns: chromosome, start, end, feature id), 
    /// the path to the output directory (where the user would like result files to be written 
    /// to), the size of the window (in base-pair) where the tool will search for snps,
    /// and the minimum number of snps to look for in each window.
    /// </summary>
    public partial class SNPfreq_form : Form
    {
        /// <summary>
        /// SNPfreq_form constructor
        /// </summary>
        public SNPfreq_form()
        {
            InitializeComponent();
        }

        
        /// <summary>
        /// Open dialog to select file with sequences loci 
        /// The file should be tab separated text file containing
        /// four columns: chromosome, start, end, and feature id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void seqFolderPathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Search for Sequence Locations File";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                this.seqFileTextBox.Text = fdlg.FileName;
            }
        }

        
        /// <summary>
        /// Open dialog to select file with snps loci.
        /// It should be a tab separated text file containing two columns:
        /// chromosome and snp location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void snpFolderPathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Search for SNP Locations File";
            //fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                this.snpFileTextBox.Text = fdlg.FileName;
            }
        }

  
        /// <summary>
        /// Open dialog to select folder where output files will be placed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectOuputpuFolderButton_Click(object sender, EventArgs e)
        {
            DialogResult folderBrowser = folderBrowserDialog.ShowDialog();
            if (folderBrowser == DialogResult.OK)
            {
                outputFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }


        string outF;
        int snpMin;

        /*****************************************************
        * Event handler for calculating snp frequencies
        *****************************************************/
        /// <summary>
        /// Event-handler that generates a snp-tagged sequence,
        /// i.e., a sequence of "x" and "s" characters, where
        /// "s" represents the presence of a snp at a specific 
        /// index in the "x" string
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createTaggedSeqButton_Click(object sender, EventArgs e)
        {
            // First do some validation (no field can be empty)
            foreach (Control control in ActiveForm.Controls)
            {
                string controlType = control.GetType().ToString();
                if (controlType == "System.Windows.Forms.TextBox")
                {
                    TextBox txtBox = (TextBox)control;
                    if (string.IsNullOrEmpty(txtBox.Text))
                    {
                        MessageBox.Show("All fields must be filled.");
                        txtBox.Focus();
                        return;
                    }
                }
            }

            
            // Add the contents of the snps loci file to an array
            /****************************************************/
            try
            {
                outF = this.outputFolderTextBox.Text;
                string pathResultFile = outF + "\\snpTaggedSeqs.txt";
                FileVerifier fv = new FileVerifier();
                int verified = fv.verifyFileExistence(pathResultFile, " masked sequence file ", outF, this);

                if (verified == 1)
                {
                    try
                    {
                        int[][] snps = (from line in File.ReadAllLines(snpFileTextBox.Text)
                                        select (from item in line.Split('\t')
                                                select int.Parse(item)).ToArray()).ToArray();
                        // Call method that will mark snps in seqs
                        string seqF = this.seqFileTextBox.Text;

                        SeqMasker sm = new SeqMasker(seqF, outF);
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        Cursor.Current = Cursors.WaitCursor;
                        sm.tagSnpsOnSeqs(snps);
                        Cursor.Current = Cursors.Default;
                        sw.Stop();
                        MessageBox.Show("Finished Creating Masked Sequences! It took " + sw.Elapsed + Environment.NewLine + "Now filtering ...", "Completed Phase 1");

                    }
                    catch
                    {
                        MessageBox.Show("Please, make sure that your snp file includes only integers as chromosome names.\n" +
                    "In case you have chromosome names with strings, replace those with integers.\n" +
                    "This includes chromosomes X and Y.", "Error reading snp file", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }
                }
            }
            catch
            {
                MessageBox.Show("Possible issue with the path to output folder; please verify that you have entered the complete plath.",
                    "Error reading snp file", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }

        /// <summary>
        /// Event-handler calls a method to extract the masked sequences that contain
        /// number of snps equal or greater than the value entered by the user.
        /// This way we can run moving windows on a smaller file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filterButton_Click(object sender, EventArgs e)
        {
            try
            {
                outF = this.outputFolderTextBox.Text;
                snpMin = int.Parse(this.snpMinTextBox.Text); 
                FilterSeqs fs = new FilterSeqs(outF, snpMin, this);
                Cursor.Current = Cursors.WaitCursor;
                fs.filterTaggedSeqFile();
                Cursor.Current = Cursors.Default;
            }
            catch
            {
                MessageBox.Show("It seems you have not generated a snp tagged sequence file yet; or all fields are not filled out. Please, do so.");
            }
            
        }

        /// <summary>
        /// Event-handler that calls a method to look for and count the number of 
        /// snps in each x bp window within each interval
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runMovingWinButton_Click(object sender, EventArgs e)
        {
            try
            {
                outF = this.outputFolderTextBox.Text;
                snpMin = int.Parse(this.snpMinTextBox.Text);
                int winSize = int.Parse(this.windowSizeTextBox.Text);
                SeqCrawler sc = new SeqCrawler(outF,snpMin,winSize);
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Cursor.Current = Cursors.WaitCursor;
                sc.crawlSeqFile();
                Cursor.Current = Cursors.Default; 
                sw.Stop();
                MessageBox.Show("Finished Crawler! It took " + sw.Elapsed,"Completed Phase 3");


            }
            catch
            {

            }
        }

        /// <summary>
        /// Event-Handler that will call a method to extract the (unique) gene symbol and Ensembl ID
        /// from the results file and write those to output. This list can be interpreted as the list
        /// of genes the contain x bp windows with n or more snps.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void extractGenesButton_Click(object sender, EventArgs e)
        {
            UniqueValueExtractor uve = new UniqueValueExtractor(outF);
            Cursor.Current = Cursors.WaitCursor;
            uve.extractGenes();
            Cursor.Current = Cursors.Default;

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
