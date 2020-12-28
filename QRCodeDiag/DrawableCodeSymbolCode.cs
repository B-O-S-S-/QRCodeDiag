﻿using QRCodeBaseLib.DataBlocks.SymbolCodes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeDiag
{
    public class DrawableCodeSymbolCode : IDrawableCodeSymbolCode
    {
        public ICodeSymbolCode CodeSymbolCode { get; set; }
        public Color SymbolIndexColor { get; set; }
        public SymbolColors SymbolColoring { get; private set; }
        public bool DrawSymbolCode { get; set; }
        public bool DrawSymbolValues { get; set; }
        public bool DrawSymbolIndices { get; set; }
        public bool DrawBitIndices { get; set; }
        public DrawableCodeSymbolCode(ICodeSymbolCode codeSymbolCode, SymbolColors symbolColors, Color symbolIndexColor)
        {
            this.CodeSymbolCode = codeSymbolCode;
            this.SymbolColoring = symbolColors;
            this.SymbolIndexColor = symbolIndexColor;

            this.DrawSymbolCode = false;
            this.DrawSymbolValues = false;
            this.DrawSymbolIndices = false;
            this.DrawBitIndices = false;
        }
    }
}
