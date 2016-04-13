Copyright 2016, OHSU-SOM-BNS Priscila Darakjian, All rights reserved.

SNPfreq - V.1.0
Developer - Priscila Darakjian

RNASeq short reads alignment tools need to be calibrated through various parameters, one of them consisting of the number of base mismatches that one is willing to allow for matching a short read sequence to a specific locus in a genome. This threshold depends on multiple factors. 

SNPfreq addresses one of those factors, i.e. the Single Nucleotide Polymorphism (SNP) frequency within an interval of "n" bases (n being the number of bases in a short read) in genes of interest. It does that by scanning a gene  through moving windows and providing the counts of snps found in each of these windows. It also provides the maximum number of snps found at those windows for each genomic feature. 

The user must provide 2 files: 
- SNPs list file - tab separated text file containing two columns: chromosome and snp location
- File with intervals of the genomic features of interest: tab separated text file containing 4 columns: chromosome, start, end, feature id), 
    

