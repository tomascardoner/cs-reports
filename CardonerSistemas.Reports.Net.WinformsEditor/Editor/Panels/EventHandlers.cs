namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels;
public static class EventHandlers
{
    public class BrushEventArgs : EventArgs
    {
        public short BrushId { get; }

        public BrushEventArgs(short brushId)
        {
            BrushId = brushId;
        }
    }

    public class DatasourceFieldEventArgs : EventArgs
    {
        public short FieldId { get; }

        public DatasourceFieldEventArgs(short fieldId)
        {
            FieldId = fieldId;
        }
    }

    public class DatasourceParameterEventArgs : EventArgs
    {
        public short ParameterId { get; }

        public DatasourceParameterEventArgs(short parameterId)
        {
            ParameterId = parameterId;
        }
    }

    public class FontEventArgs : EventArgs
    {
        public short FontId { get; }
        public FontEventArgs(short fontId)
        {
            FontId = fontId;
        }
    }

    public class LineEventArgs : EventArgs
    {
        public short LineId { get; }
        public short SectionId1 { get; }
        public LineEventArgs(short lineId, short sectionId1)
        {
            LineId = lineId;
            SectionId1 = sectionId1;
        }
    }

    public class RectangleEventArgs : EventArgs
    {
        public short RectangleId { get; }
        public short SectionId1 { get; }
        public RectangleEventArgs(short lineId, short sectionId1)
        {
            RectangleId = lineId;
            SectionId1 = sectionId1;
        }
    }

    public class SectionEventArgs : EventArgs
    {
        public short SectionId { get; }
        public SectionEventArgs(short sectionId)
        {
            SectionId = sectionId;
        }
    }

    public class TextEventArgs : EventArgs
    {
        public short TextId { get; }
        public short SectionId { get; }
        public TextEventArgs(short textId, short sectionId)
        {
            TextId = textId;
            SectionId = sectionId;
        }
    }
}
