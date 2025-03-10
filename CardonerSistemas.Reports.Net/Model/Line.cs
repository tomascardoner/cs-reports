﻿using System.Text.Json.Serialization;
using PdfSharp.Drawing;

namespace CardonerSistemas.Reports.Net.Model
{
    public class Line
    {

        public Line(Report report)
        {
            if (report.Lines.Count == 0)
            {
                LineId = 1;
            }
            else
            {
                LineId = (short)(report.Lines.Max(l => l.LineId) + 1);
            }
        }

        [JsonConstructor]
        public Line(short lineId)
        {
            LineId = lineId;
        }

        public short LineId { get; }

        public byte ColorRed { get; set; }

        public byte ColorGreen { get; set; }

        public byte ColorBlue { get; set; }

        [JsonIgnore]
        public string ColorHex => $"#{ColorRed:X2}{ColorGreen:X2}{ColorBlue:X2}";

        [JsonIgnore]
        public XColor Color => XColor.FromArgb(ColorRed, ColorGreen, ColorBlue);

        public decimal Thickness { get; set; }

        public short SectionId1 { get; set; }

        public decimal PositionX1 { get; set; }

        public decimal PositionY1 { get; set; }

        public short SectionId2 { get; set; }

        public decimal PositionX2 { get; set; }

        public decimal PositionY2 { get; set; }

        [JsonIgnore]
        public string DisplayName => $"#{LineId:00}";
    }
}
