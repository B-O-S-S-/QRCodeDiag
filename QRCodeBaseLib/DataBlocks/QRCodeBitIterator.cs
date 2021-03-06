﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeBaseLib.DataBlocks
{
    class QRCodeBitIterator : IBitIterator
    {
        private const int TIMINGPATTERNCOLUMN = 6;      // number of the column in which the vertical timing pattern is located
        private readonly QRCode qrCode;
        private int xPos, yPos;
        private bool directionUp;
        private bool rightCell;
        private int XPos
        {
            get { return this.xPos; }
            set
            {
                if (value < 0)
                    this.EndReached = true;
                else
                    this.xPos = value;
            }
        }
        private int YPos
        {
            get { return this.yPos; }
            set
            {
                if (value < 0)
                    this.EndReached = true;
                else
                    this.yPos = value;
            }
        }
        public Vector2D Position => new Vector2D(this.xPos, this.yPos);
        public bool EndReached { get; private set; }
        public char CurrentChar => this.qrCode.GetBit((uint)this.XPos, (uint)this.YPos, true);
        public uint BitsConsumed { get; private set; }

        public QRCodeBitIterator(QRCode code)
        {
            this.qrCode = code;
            this.XPos = this.qrCode.GetEdgeLength() - 1;
            this.YPos = this.qrCode.GetEdgeLength() - 1;
            this.directionUp = true;
            this.rightCell = true;
            this.EndReached = false;
            this.BitsConsumed = 0;
        }
        
        public char NextBit()
        {
            bool nextFound = false;
            while (!this.EndReached && !nextFound)
            {
                if (this.YPos == 0 && this.directionUp && !this.rightCell) // Top end of a line reached
                {
                    // go to left neighbor lane, right top cell
                    this.directionUp = false;
                    this.rightCell = true;
                    this.XPos--;
                    if (this.XPos == QRCodeBitIterator.TIMINGPATTERNCOLUMN)
                        this.XPos--;
                }
                else if (this.YPos == this.qrCode.GetEdgeLength() - 1 && !this.directionUp && !this.rightCell) // Bottom end of a line reached
                {
                    // go to left neighbor lane, right bottom cell
                    this.directionUp = true;
                    this.rightCell = true;
                    this.XPos--;
                    if (this.XPos == QRCodeBitIterator.TIMINGPATTERNCOLUMN)
                        this.XPos--;
                }
                else // Somewhere in the line
                {
                    if (this.rightCell)
                    {
                        this.XPos--;
                        this.rightCell = false;
                    }
                    else
                    {
                        this.XPos++;
                        this.rightCell = true;
                        if (this.directionUp)
                        {
                            this.YPos--;
                        }
                        else
                        {
                            this.YPos++;
                        }
                    }
                }
                if (this.qrCode.IsDataCell((uint)this.XPos, (uint)this.YPos))
                {
                    nextFound = true;
                }
            }

            if (nextFound)
            {
                this.BitsConsumed++;
                return this.qrCode.GetBit((uint)this.XPos, (uint)this.YPos, true);
            }
            else
            {
                return 'e';
            }
        }
    }
}
