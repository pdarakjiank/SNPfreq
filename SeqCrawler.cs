using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SNPfreq
{
    class SeqCrawler
    {
        string oF;
        int wS;
        int sM;
        string inputFile;
        string outputFile;
        
        public SeqCrawler(string outF, int snpMin, int winSize)
        {
            oF = outF;
            wS = winSize;
            sM = snpMin;
            inputFile = oF + "\\filteredSnpTaggedSeqs.txt";
            outputFile = oF + "\\SeqWindows.txt";
        }

        public void crawlSeqFile()
        {
            using (StreamReader snpTagReader = File.OpenText(inputFile))
            {
                string line;
                Stream stream = null;

                try
                {
                    stream = new FileStream(outputFile, FileMode.Append, FileAccess.Write);
                    using (StreamWriter sw = new StreamWriter(stream))
                    {
                        while ((line = snpTagReader.ReadLine()) != null)
                        {
                            string[] items = line.Split('\t');
                            string seq = items[0];
                            int numIterations = seq.Length - wS + 1;
                            string[] id  = items[2].Split('_');
                            string ensemblGeneID = id[0];
                            string geneSymbol = id[1];
                            string transcript = id[2];
                            StringBuilder winLine = new StringBuilder();

                            for (int i = 0; i < numIterations; i++)
                            {
                                string win = seq.Substring(i, wS);
                                int winStart = int.Parse(items[4]) + i;
                                int winEnd = int.Parse(items[4]) + i + wS;
                                int snpCnt = 0;
                                for (int s=0; s < win.Length; s++)
                                {
                                    if(win.Substring(s,1)=="s")
                                    {
                                        snpCnt = snpCnt +1;
                                    }
                                }
                                
                                if (snpCnt >= sM)
                                {
                                    stream = null;
                                    winLine = winLine.Append(geneSymbol).
                                        Append("\t").
                                        Append(ensemblGeneID).
                                        Append("\t").
                                        Append(transcript).
                                        Append("\t").
                                        Append(items[3]).
                                        Append("\t").
                                        Append(items[4]).
                                        Append("\t").
                                        Append(items[5]).
                                        Append("\t").
                                        Append(winStart.ToString()).
                                        Append("\t").
                                        Append(winEnd.ToString()).
                                        Append("\t").Append(snpCnt).
                                        AppendLine();
                                    sw.Write(winLine.ToString());
                                    winLine.Clear();
                                }

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
