using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SNPfreq
{
    class FilterSeqs
    {
        string filePath;
        string folderPath;
        int snpMin;
        SNPfreq_form formObj;

        public FilterSeqs(string fpath,int sMin,SNPfreq_form formObject)
        {
            folderPath = fpath;
            filePath = fpath + "\\snpTaggedSeqs.txt";
            snpMin = sMin;
            formObj = formObject;
        }

        public void filterTaggedSeqFile()
        {
            using (StreamReader snpTagReader = File.OpenText(filePath))
            {
                string line;
                    
                string outputFile = folderPath + "\\filteredSnpTaggedSeqs.txt";
                FileVerifier fv = new FileVerifier();
                int verified = fv.verifyFileExistence(outputFile, " filtered sequence file ", folderPath, formObj);
                if (verified == 1)
                {
                    Stream stream = null;
                    try
                    {
                        stream = new FileStream(outputFile, FileMode.Append, FileAccess.Write);
                        using (StreamWriter sw = new StreamWriter(stream))
                        {
                            while ((line = snpTagReader.ReadLine()) != null)
                            {
                                string[] items = line.Split('\t');
                                int snpCnt = int.Parse(items[1]); // Total snps in transcript
                                if (snpCnt >= snpMin)
                                {
                                    stream = null;
                                    sw.WriteLine(line);
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null) stream.Dispose();
                    }
                }
            }
        }
    }
}

