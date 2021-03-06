﻿using QRCodeBaseLib.DataBlocks.SymbolCodes;
using QRCodeBaseLib.DataBlocks.Symbols;
using QRCodeBaseLib.MetaInfo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QRCodeBaseLib.ECCDecoding
{
    internal class DeInterleaver
    {
        public static List<ECCBlock> DeInterleave(CodeSymbolCode<RawCodeByte> interleavedCode,
                                                  ErrorCorrectionLevel        eccLevel)
        {
            // a block consists of data and ecc codewords for that block
            // blocks are in groups of blocks with the same amount of data codewords (max 2 groups)
            // blocks for all groups have the same amount of ecc codewords
            // the number of data codewords can differ between groups but not between blocks of a group
            var eccGroups = eccLevel.GetECCGroups();
            int numberOfGroups = eccGroups.Length;
            uint numberOfBlocks = 0;
            uint numberOfRawCodeBytes = 0;

            foreach(ECCGroupInfo g in eccGroups)
            {
                numberOfBlocks += g.NumberOfBlocks;
                numberOfRawCodeBytes += g.NumberOfBlocks * (g.DataBytesPerBlock + eccLevel.ECCBytesPerBlock);
            }

            if (interleavedCode.SymbolCount != numberOfRawCodeBytes)
                throw new ArgumentException("Invalid number of symbols in interleaved code.");

            uint largestBlockLength = 0;
            foreach(ECCGroupInfo g in eccGroups)
            {
                largestBlockLength = Math.Max(largestBlockLength, g.DataBytesPerBlock);
            }
            var dataCodewords = new RawCodeByte[numberOfBlocks, largestBlockLength];
            var eccCodewords  = new RawCodeByte[numberOfBlocks, eccLevel.ECCBytesPerBlock];
            int pos = 0; // position in interleavedCode

            // generate data block code
            for (int j = 0; j < largestBlockLength; j++)            // for each symbol in block
            {
                for (int i = 0; i < numberOfBlocks; i++)            // for each block
                {
                    if (j < DeInterleaver.GetBlockLength(i, eccGroups)) // skip block if it is already full
                    {
                        dataCodewords[i, j] = interleavedCode.GetSymbolAt(pos++);
                        System.Diagnostics.Debug.Assert(dataCodewords[i, j] != null);
                    }
                }
            }
            // generate ecc block code
            for (int j = 0; j < eccLevel.ECCBytesPerBlock; j++)     // for each symbol in block
            {
                for (int i = 0; i < numberOfBlocks; i++)            // for each block
                {
                    eccCodewords[i, j] = interleavedCode.GetSymbolAt(pos++);
                }
            }

            var eccBlockList = new List<ECCBlock>();
            int absBlockNo = 0;

            for (int g = 0; g < eccGroups.Length; g++)                       // group
            {
                for (int b = 0; b < eccGroups[g].NumberOfBlocks; b++)        // block
                {
                    var blockData = new List<RawCodeByte>();
                    var blockECC = new List<RawCodeByte>();
                    for (int s = 0; s < eccGroups[g].DataBytesPerBlock; s++) // data symbol
                    {
                        blockData.Add(dataCodewords[absBlockNo, s]);
                    }
                    for (int e = 0; e < eccLevel.ECCBytesPerBlock; e++)      // ecc symbol
                    {
                        blockECC.Add(eccCodewords[absBlockNo, e]);
                    }
                    eccBlockList.Add(new ECCBlock(new CodeSymbolCode<RawCodeByte>(blockData),
                                                  new CodeSymbolCode<RawCodeByte>(blockECC)));
                    absBlockNo++;
                }
            }
            return eccBlockList;
        }

        private static uint GetBlockLength(int absoluteBlockNumber, ECCGroupInfo[] eccGroups)
        {
            for(int i = 0; i < eccGroups.Length; i++)
            {
                if (absoluteBlockNumber < eccGroups[i].NumberOfBlocks)
                    return eccGroups[i].DataBytesPerBlock;
                else
                    absoluteBlockNumber -= (int) eccGroups[i].NumberOfBlocks;
            }
            throw new ArgumentException("absoluteBlockNumber is larger than the total number of blocks in eccGroups.");
        }
    }
}
