using System.Text.Json.Serialization;
using PdfSharp.Drawing;

namespace CardonerSistemas.Reports.Net.Model;

public class Rectangle
{
    private readonly Report _report;

    public Rectangle(Report report)
    {
        _report = report;
        if (report.Rectangles.Count == 0)
        {
            RectangleId = 1;
        }
        else
        {
            RectangleId = (short)(report.Rectangles.Max(r => r.RectangleId) + 1);
        }
    }

    public Rectangle(Report report, short rectangleId)
    {
        _report = report;
        RectangleId = rectangleId;
    }

    [JsonConstructor]
    public Rectangle(short rectangleId)
    {
        _report = new();
        RectangleId = rectangleId;
    }

    public short RectangleId { get; }

    public byte BorderColorRed { get; set; }

    public byte BorderColorGreen { get; set; }

    public byte BorderColorBlue { get; set; }

    [JsonIgnore]
    public string BorderColorHex => $"#{BorderColorRed:X2}{BorderColorGreen:X2}{BorderColorBlue:X2}";

    [JsonIgnore]
    public XColor BorderColor => XColor.FromArgb(BorderColorRed, BorderColorGreen, BorderColorBlue);

    public decimal BorderThickness { get; set; }

    public short? BrushId { get; set; }

    public short SectionId1 { get; set; }

    public decimal PositionX1 { get; set; }

    public decimal PositionY1 { get; set; }

    public short SectionId2 { get; set; }

    public decimal PositionX2 { get; set; }

    public decimal PositionY2 { get; set; }

    [JsonIgnore]
    public Brush? Brush => _report.Brushes.FirstOrDefault(b => b.BrushId == BrushId);

    [JsonIgnore]
    public Section? Section1 => _report.Sections.FirstOrDefault(s => s.SectionId == SectionId1);

    [JsonIgnore]
    public Section? Section2 => _report.Sections.FirstOrDefault(s => s.SectionId == SectionId2);

    [JsonIgnore]
    public string DisplayName => $"#{RectangleId:00}";
}
