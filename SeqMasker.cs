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
    /// <summary>
    ///  SeqMasker class: generates sequences of "x" and "s", where 
    ///     * x is a base that is not a snp, and s is a base with a snp.
    ///     * So, for instance, a specific interval of 5 bases would be 
    ///     * represented by "xxxxx". If a snp is found in the 3rd base, 
    ///     * the sequence would become "xxsxx".*/
    /// </summary>
    
    class SeqMasker
    {
        

        private string seqFile;
        private string outFolder;

        public SeqMasker()
        {
            seqFile = "";
            outFolder = "";
        }

        public SeqMasker(string sf, string of)
        {
            seqFile = sf;
            outFolder = of;
        }

                SeqWriter sr = new SeqWriter();
        
        
        /***************************************************
        * This is where the masked sequences are generated
        ****************************************************/
        public void tagSnpsOnSeqs(int[][] snps)
        {
            // Open sequences intervals file for reading
            int seqFileLineCount = File.ReadLines(seqFile).Count();
            
            //StringBuilder seq = new StringBuilder();
            StringBuilder seqBatch = new StringBuilder();

            using (StreamReader seqReader = File.OpenText(seqFile))
            {
                string line;
                int l = 1;
                int s = 0; // snp counter
                int i = 0;
                int x = 0;
                int prevChrom = 1;
                seqBatch = seqBatch.Clear();

                while ((line = seqReader.ReadLine()) != null)
                {
                    string[] items = line.Split('\t');
                    int chrom = int.Parse(items[0]); // Chromosome number
                    if (chrom != prevChrom)
                    {
                        prevChrom = chrom;
                        x = i;
                    }
                    int start = int.Parse(items[1]); // Start Location
                    int end = int.Parse(items[2]);   // End Location
                    string featureName = items[3];   // Gene, Transcript, or other name
                    int interval = end - start + 1;  // Get interval width
                    
                    // Initialize "x" sequence
                    string mySeq = string.Concat(Enumerable.Repeat("x", interval));
                    char[] mySeqArray = mySeq.ToCharArray();

                    // Given the sequence interval (above) loop through snp file
                    // to see if there are snps in it.
                    for (i = x; i < snps.Length; i++)
                    {
                        if (snps[i][0] > chrom)
                        {
                            
                            break;
                        }                    
                        int snpLoc = snps[i][1]; // get snp location

                        if ((snpLoc <= end) && (snpLoc >= start)) //&& (i < snps.Length - 1)) // snp within interval, but is not the last in the snp list
                        {
                            int snp_index = snpLoc - start;
                            mySeqArray[snp_index] = 's';
                            
                            s++;
                        }
                        else if (snpLoc > end)  // snp is not within interval but is also not the last snp in the list
                        {
                            break;
                        }
                      
                        else continue; // if snp location is before the interval's start location go to next snp in the list 
                    }

                    l++;

                    if (s != 0)
                    {
                        seqBatch = seqBatch.
                            Append(string.Join("", mySeqArray)).
                            Append("\t").
                            Append(s).
                            Append("\t").
                            Append(featureName).
                            Append("\t").
                            Append(chrom).
                            Append("\t").
                            Append(start).
                            Append("\t").
                            Append(end).
                            AppendLine();
                        s = 0;
                    }
                    else
                    {
                        seqBatch = seqBatch.
                            Append("\t").
                            Append(s).
                            Append("\t").
                            Append(featureName).
                            Append("\t").
                            Append(chrom).
                            Append("\t").
                            Append(start).
                            Append("\t").
                            Append(end).
                            AppendLine();
                    }
                    
                    // Write output in batch of 2000 lines to avoid opening and closing file too many times
                    if ((l%2000== 0) || (seqFileLineCount < 2000) || (seqFileLineCount - l < 2000))
                    {
                        sr.writeTaggedSeqToFile(seqBatch, outFolder); // call method to write sequences to file
                        seqBatch = seqBatch.Clear();
                    }

                    mySeq = string.Empty;
                }
            }
        }

        
    }
}
