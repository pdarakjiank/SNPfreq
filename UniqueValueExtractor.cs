using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SNPfreq
{
    class UniqueValueExtractor
    {
        string rF;
        string oF;
        string gF;
        string rFOrdered;

        public UniqueValueExtractor(string outFolder)
        {
            oF = outFolder;
            rF = oF + "\\SeqWindows.txt";
            rFOrdered = oF + "\\SeqWindowsOrdered.txt";
            gF = oF + "\\Genes_with_snps.txt";
        }

        public void extractGenes()
        {
            File.WriteAllLines(rFOrdered, File.ReadLines(rF).OrderBy(s => s));
            using (StreamReader resultFile = File.OpenText(rFOrdered))
            {
                string line;
                Stream stream = null;
                string prevEnsemblID = "";
                try
                {
                    stream = new FileStream(gF, FileMode.Append, FileAccess.Write);
                    using (StreamWriter sw = new StreamWriter(stream))
                    {
                        StringBuilder ids = new StringBuilder();
                        while ((line = resultFile.ReadLine()) != null)
                        {
                            string[] items = line.Split('\t');
                            string geneSym = items[0];
                            string ensemblID = items[1];
                            if (prevEnsemblID != ensemblID)
                            {
                                ids = ids.Append(geneSym).Append("\t").Append(ensemblID).AppendLine();
                                sw.Write(ids);
                                prevEnsemblID = ensemblID;
                                ids.Clear();
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
