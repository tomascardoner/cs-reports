using System.Globalization;

namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels;

public partial class PanelRectangles : UserControl
{

    #region Declarations

#pragma warning disable S4487 // Unread "private" fields should be removed
    private readonly string _applicationTitle;
#pragma warning restore S4487 // Unread "private" fields should be removed
    private readonly Model.Report _report;
    private readonly short _sectionId;

    public event EventHandler<EventHandlers.RectangleEventArgs>? RectangleAdded;

    #endregion Declarations

    #region Initialization

    public PanelRectangles(Model.Report report, short sectionId, string applicationTitle)
    {
        InitializeComponent();
        _report = report;
        _sectionId = sectionId;
        _applicationTitle = applicationTitle;
        InitializeForm();
    }

    private void InitializeForm()
    {
        buttonAdd.Text = Properties.Resources.StringRectanglesAdd;
    }

    #endregion Initialization

    #region Methods

    public void ShowProperties(int count)
    {
        labelCounter.Text = count switch
        {
            0 => Properties.Resources.StringRectanglesCounterEmpty,
            1 => Properties.Resources.StringRectanglesCounterOne,
            _ => string.Format(CultureInfo.InvariantCulture, Properties.Resources.StringRectanglesCounter, count)
        };
    }

    private void Add(object sender, EventArgs e)
    {
        Model.Rectangle? rectangle = new(_report) { SectionId1 = _sectionId, SectionId2 = _sectionId };
        _report.Rectangles.Add(rectangle);
        if (RectangleAdded is not null)
        {
            RectangleAdded(this, new EventHandlers.RectangleEventArgs(rectangle.RectangleId, rectangle.SectionId1));
        }
    }

    #endregion Methods

}
