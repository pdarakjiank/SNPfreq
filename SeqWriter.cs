using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.IO;
using SNPfreq;


namespace SNPfreq
{
    class SeqWriter
    {

        // This method writes the "x" sequences to a file
        public void writeTaggedSeqToFile(StringBuilder seq, string oF)
        {
            string outputFile = oF + "\\snpTaggedSeqs.txt";
            Stream stream = null;
            try
            {
                stream = new FileStream(outputFile, FileMode.Append, FileAccess.Write);
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    stream = null;
                    sw.Write(seq.ToString());
                }
            }
            finally
            {
                if(stream != null) stream.Dispose();
            }
        }
    }
}

