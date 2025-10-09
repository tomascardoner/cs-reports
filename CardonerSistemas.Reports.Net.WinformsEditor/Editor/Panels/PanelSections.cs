using System.Globalization;

namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels;

public partial class PanelSections : UserControl
{

    #region Declarations

#pragma warning disable S4487 // Unread "private" fields should be removed
    private readonly string _applicationTitle;
#pragma warning restore S4487 // Unread "private" fields should be removed
    private readonly Model.Report _report;

    public event EventHandler<EventHandlers.SectionEventArgs>? SectionAdded;

    #endregion Declarations

    #region Initialization

    public PanelSections(Model.Report report, string applicationTitle)
    {
        InitializeComponent();
        _report = report;
        _applicationTitle = applicationTitle;
        InitializeForm();
    }

    private void InitializeForm()
    {
        buttonAdd.Text = Properties.Resources.StringSectionsAdd;
    }

    #endregion Initialization

    #region Methods

    public void ShowProperties()
    {
        labelCounter.Text = _report.Sections.Count switch
        {
            0 => Properties.Resources.StringSectionsCounterEmpty,
            1 => Properties.Resources.StringSectionsCounterOne,
            _ => string.Format(CultureInfo.InvariantCulture, Properties.Resources.StringSectionsCounter, _report.Sections.Count)
        };
    }

    private void Add(object sender, EventArgs e)
    {
        Model.Section section = new(_report);
        _report.Sections.Add(section);
        if (SectionAdded is not null)
        {
            SectionAdded(this, new EventHandlers.SectionEventArgs(section.SectionId));
        }
    }

    #endregion Methods

}
