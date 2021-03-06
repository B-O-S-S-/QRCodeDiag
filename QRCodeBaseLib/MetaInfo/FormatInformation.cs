﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QRCodeBaseLib.MetaInfo
{
    internal class FormatInformation
    {
        public enum FormatInfoLocation
        {
            TopLeft,
            SplitBottomLeftTopRight
        }

        public ErrorCorrectionLevel.ECCLevel ECCLevel { get; set; }
        public XORMask.MaskType Mask { get; set; }

        public FormatInformation(ErrorCorrectionLevel.ECCLevel eccLevel, XORMask.MaskType mask)
        {
            this.ECCLevel = eccLevel;
            this.Mask = mask;
        }

        public FormatInformation(string formatInfoString)
        {
            switch(formatInfoString)
            {
                case "111011111000100":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Low;
                    this.Mask = XORMask.MaskType.Mask000;
                    break;

                case "111001011110011":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Low;
                    this.Mask = XORMask.MaskType.Mask001;
                    break;

                case "111110110101010":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Low;
                    this.Mask = XORMask.MaskType.Mask010;
                    break;

                case "111100010011101":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Low;
                    this.Mask = XORMask.MaskType.Mask011;
                    break;

                case "110011000101111":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Low;
                    this.Mask = XORMask.MaskType.Mask100;
                    break;

                case "110001100011000":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Low;
                    this.Mask = XORMask.MaskType.Mask101;
                    break;

                case "110110001000001":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Low;
                    this.Mask = XORMask.MaskType.Mask110;
                    break;

                case "110100101110110":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Low;
                    this.Mask = XORMask.MaskType.Mask111;
                    break;

                case "101010000010010":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Medium;
                    this.Mask = XORMask.MaskType.Mask000;
                    break;

                case "101000100100101":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Medium;
                    this.Mask = XORMask.MaskType.Mask001;
                    break;

                case "101111001111100":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Medium;
                    this.Mask = XORMask.MaskType.Mask010;
                    break;

                case "101101101001011":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Medium;
                    this.Mask = XORMask.MaskType.Mask011;
                    break;

                case "100010111111001":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Medium;
                    this.Mask = XORMask.MaskType.Mask100;
                    break;

                case "100000011001110":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Medium;
                    this.Mask = XORMask.MaskType.Mask101;
                    break;

                case "100111110010111":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Medium;
                    this.Mask = XORMask.MaskType.Mask110;
                    break;

                case "100101010100000":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Medium;
                    this.Mask = XORMask.MaskType.Mask111;
                    break;

                case "011010101011111":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Quartile;
                    this.Mask = XORMask.MaskType.Mask000;
                    break;

                case "011000001101000":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Quartile;
                    this.Mask = XORMask.MaskType.Mask001;
                    break;

                case "011111100110001":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Quartile;
                    this.Mask = XORMask.MaskType.Mask010;
                    break;

                case "011101000000110":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Quartile;
                    this.Mask = XORMask.MaskType.Mask011;
                    break;

                case "010010010110100":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Quartile;
                    this.Mask = XORMask.MaskType.Mask100;
                    break;

                case "010000110000011":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Quartile;
                    this.Mask = XORMask.MaskType.Mask101;
                    break;

                case "010111011011010":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Quartile;
                    this.Mask = XORMask.MaskType.Mask110;
                    break;

                case "010101111101101":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.Quartile;
                    this.Mask = XORMask.MaskType.Mask111;
                    break;

                case "001011010001001":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.High;
                    this.Mask = XORMask.MaskType.Mask000;
                    break;

                case "001001110111110":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.High;
                    this.Mask = XORMask.MaskType.Mask001;
                    break;

                case "001110011100111":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.High;
                    this.Mask = XORMask.MaskType.Mask010;
                    break;

                case "001100111010000":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.High;
                    this.Mask = XORMask.MaskType.Mask011;
                    break;

                case "000011101100010":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.High;
                    this.Mask = XORMask.MaskType.Mask100;
                    break;

                case "000001001010101":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.High;
                    this.Mask = XORMask.MaskType.Mask101;
                    break;

                case "000110100001100":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.High;
                    this.Mask = XORMask.MaskType.Mask110;
                    break;

                case "000100000111011":
                    this.ECCLevel = ErrorCorrectionLevel.ECCLevel.High;
                    this.Mask = XORMask.MaskType.Mask111;
                    break;

                default:
                    throw new InvalidFormatInformationException($"{0} is not a valid format information string.");
            }
        }

        public static List<Vector2D> GetFormatInformationLocations(QRCodeVersion version, FormatInfoLocation loc)
        {
            var retList = new List<Vector2D>();
            int edgeLen = (int)version.GetEdgeSizeFromVersion();

            switch (loc)
            {
                case FormatInfoLocation.TopLeft:
                    for (int x = 0; x < 9; x++) // left to right (including corner 7th bit)
                    {
                        if (x != 6)
                        {
                            retList.Add(new Vector2D(x, 8));
                        }
                    }
                    for (int y = 7; y >= 0; y--) // towards top (excluding corner, bits 8-14)
                    {
                        if (y != 6)
                        {
                            retList.Add(new Vector2D(8, y));
                        }
                    }
                    break;

                case FormatInfoLocation.SplitBottomLeftTopRight:
                    for (int y = edgeLen - 1; y >= edgeLen - 7; y--) // from bottom up
                    {
                        retList.Add(new Vector2D(8, y));
                    }
                    for (int x = edgeLen - 8; x < edgeLen; x++) // towards right edge
                    {
                        retList.Add(new Vector2D(x, 8));
                    }
                    break;

                default:
                    throw new NotImplementedException(); // TODO version information for version 8+?
            }

            return retList;
        }

        /* TODO proper implementation calculating the bits from information */
        public char[] GetFormatInfoBits()
        {
            switch (this.ECCLevel)
            {
                case ErrorCorrectionLevel.ECCLevel.Low:
                {
                    switch (this.Mask)
                    {
                        case XORMask.MaskType.Mask000:
                            return "111011111000100".ToCharArray();
                        case XORMask.MaskType.Mask001:
                            return "111001011110011".ToCharArray();
                        case XORMask.MaskType.Mask010:
                            return "111110110101010".ToCharArray();
                        case XORMask.MaskType.Mask011:
                            return "111100010011101".ToCharArray();
                        case XORMask.MaskType.Mask100:
                            return "110011000101111".ToCharArray();
                        case XORMask.MaskType.Mask101:
                            return "110001100011000".ToCharArray();
                        case XORMask.MaskType.Mask110:
                            return "110110001000001".ToCharArray();
                        case XORMask.MaskType.Mask111:
                            return "110100101110110".ToCharArray();
                        case XORMask.MaskType.None:
                            return "000000000000000".ToCharArray();
                        default:
                            throw new InvalidOperationException("Invalid Mask Type");
                    }
                }
                case ErrorCorrectionLevel.ECCLevel.Medium:
                {
                    switch (this.Mask)
                    {
                        case XORMask.MaskType.Mask000:
                            return "101010000010010".ToCharArray();
                        case XORMask.MaskType.Mask001:
                            return "101000100100101".ToCharArray();
                        case XORMask.MaskType.Mask010:
                            return "101111001111100".ToCharArray();
                        case XORMask.MaskType.Mask011:
                            return "101101101001011".ToCharArray();
                        case XORMask.MaskType.Mask100:
                            return "100010111111001".ToCharArray();
                        case XORMask.MaskType.Mask101:
                            return "100000011001110".ToCharArray();
                        case XORMask.MaskType.Mask110:
                            return "100111110010111".ToCharArray();
                        case XORMask.MaskType.Mask111:
                            return "100101010100000".ToCharArray();
                        case XORMask.MaskType.None:
                            return "000000000000000".ToCharArray();
                        default:
                            throw new InvalidOperationException("Invalid Mask Type");
                    }
                }

                case ErrorCorrectionLevel.ECCLevel.Quartile:
                {
                    switch (this.Mask)
                    {
                        case XORMask.MaskType.Mask000:
                            return "011010101011111".ToCharArray();
                        case XORMask.MaskType.Mask001:
                            return "011000001101000".ToCharArray();
                        case XORMask.MaskType.Mask010:
                            return "011111100110001".ToCharArray();
                        case XORMask.MaskType.Mask011:
                            return "011101000000110".ToCharArray();
                        case XORMask.MaskType.Mask100:
                            return "010010010110100".ToCharArray();
                        case XORMask.MaskType.Mask101:
                            return "010000110000011".ToCharArray();
                        case XORMask.MaskType.Mask110:
                            return "010111011011010".ToCharArray();
                        case XORMask.MaskType.Mask111:
                            return "010101111101101".ToCharArray();
                        case XORMask.MaskType.None:
                            return "000000000000000".ToCharArray();
                        default:
                            throw new InvalidOperationException("Invalid Mask Type");
                    }
                }

                case ErrorCorrectionLevel.ECCLevel.High:
                {
                    switch (this.Mask)
                    {
                        case XORMask.MaskType.Mask000:
                            return "001011010001001".ToCharArray();
                        case XORMask.MaskType.Mask001:
                            return "001001110111110".ToCharArray();
                        case XORMask.MaskType.Mask010:
                            return "001110011100111".ToCharArray();
                        case XORMask.MaskType.Mask011:
                            return "001100111010000".ToCharArray();
                        case XORMask.MaskType.Mask100:
                            return "000011101100010".ToCharArray();
                        case XORMask.MaskType.Mask101:
                            return "000001001010101".ToCharArray();
                        case XORMask.MaskType.Mask110:
                            return "000110100001100".ToCharArray();
                        case XORMask.MaskType.Mask111:
                            return "000100000111011".ToCharArray();
                        case XORMask.MaskType.None:
                            return "000000000000000".ToCharArray();
                        default:
                            throw new InvalidOperationException("Invalid Mask Type");
                    }
                }

                default:
                    throw new InvalidOperationException("Invalid Mask Type");
            }
        }
    }
}
