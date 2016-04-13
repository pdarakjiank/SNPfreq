using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace SNPfreq
{
    /// <summary>
    /// This class is used to verify if a file exists or not
    /// </summary>
    class FileVerifier
    {
        /// <summary>
        /// This method verifies if a file exists already. If it does, it asks the user
        /// if it should be overwritten. If not, it gives the user an opportunity to  rename the old file.
        /// </summary>
        /// <param name="pathToFile">Path to the file</param>
        /// <param name="fileDescriptor">The type of file (masked sequence, filtered, result, gene list)</param>
        /// <param name="outputFolder">Output folder path</param>
        /// <param name="formObject">Form object</param>
        public int verifyFileExistence(string pathToFile, string fileDescriptor, string outputFolder, SNPfreq_form formObject)
        {
            if (File.Exists(pathToFile))
            {
                DialogResult result;
                result = MessageBox.Show("The " + fileDescriptor + " " +
                    pathToFile + " already exists. Would you like to overwrite it?"
                    + " If not, please click 'No', rename the file, and run this step again",
                    "Warning - " + fileDescriptor + " Exists", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    File.Delete(pathToFile);
                    return 1;
                }
                else
                {
                    formObject.outputFolderTextBox.Focus();
                    return 2;
                }
            }
            else
            {
                return 1;
            }
        }
    }
}
