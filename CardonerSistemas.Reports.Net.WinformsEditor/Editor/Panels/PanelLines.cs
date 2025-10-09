using System.Globalization;

namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels;

public partial class PanelLines : UserControl
{

    #region Declarations

#pragma warning disable S4487 // Unread "private" fields should be removed
    private readonly string _applicationTitle;
#pragma warning restore S4487 // Unread "private" fields should be removed
    private readonly Model.Report _report;
    private readonly short _sectionId;

    public event EventHandler<EventHandlers.LineEventArgs>? LineAdded;

    #endregion Declarations

    #region Initialization

    public PanelLines(Model.Report report, short sectionId, string applicationTitle)
    {
        InitializeComponent();
        _report = report;
        _sectionId = sectionId;
        _applicationTitle = applicationTitle;
        InitializeForm();
    }

    private void InitializeForm()
    {
        buttonAdd.Text = Properties.Resources.StringLinesAdd;
    }

    #endregion Initialization

    #region Methods

    public void ShowProperties(int count)
    {
        labelCounter.Text = count switch
        {
            0 => Properties.Resources.StringLinesCounterEmpty,
            1 => Properties.Resources.StringLinesCounterOne,
            _ => string.Format(CultureInfo.InvariantCulture, Properties.Resources.StringLinesCounter, count)
        };
    }

    private void Add(object sender, EventArgs e)
    {
        Model.Line? line = new(_report) { SectionId1 = _sectionId, SectionId2 = _sectionId };
        _report.Lines.Add(line);
        if (LineAdded is not null)
        {
            LineAdded(this, new EventHandlers.LineEventArgs(line.LineId, line.SectionId1));
        }
    }

    #endregion Methods

}
