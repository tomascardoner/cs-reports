using PdfSharp;
using static CardonerSistemas.Reports.Net.Model.Report;

namespace CardonerSistemas.Reports.Net.WinformsEditor
{
    public partial class FormReportEditor : Form
    {

        #region Declarations

        private const string ReportKey = "Report";
        private const string DatasourceKey = "Datasource";
        private const string DatasourceParameterKey = "DatasourceParameter";
        private const string FontsKey = "Fonts";
        private const string FontKey = "Font";
        private const string BrushesKey = "Brushes";
        private const string BrushKey = "Brush";
        private const string SectionsKey = "Sections";
        private const string SectionKey = "Section";
        private const string LinesKey = "Lines";
        private const string LineKey = "Line";
        private const string RectanglesKey = "Rectangles";
        private const string RectangleKey = "Rectangle";
        private const string TextsKey = "Texts";
        private const string TextKey = "Text";

        private readonly Model.Report mReport;
        private string mFilePath;

        #endregion Declarations

        #region Form stuff

        public FormReportEditor(Model.Report report, string filePath)
        {
            InitializeComponent();
            mReport = report;
            mFilePath = filePath;
            InitializeForm();
        }

        private void InitializeForm()
        {
            this.Text = string.IsNullOrWhiteSpace(mReport.Name) ? Properties.Resources.StringReportNew : $"{mReport.Name} ({mFilePath})";
            TreeViewReport.ImageList = ImageListMain;
            ShowReport();

            FillPageSizes();
            FillPageOrientations();
        }

        private void FillPageSizes()
        {
            comboBoxPageSize.Items.Clear();
            foreach (Model.Report.PageSizes pageSize in Enum.GetValues<Model.Report.PageSizes>())
            {
                comboBoxPageSize.Items.Add(PageSizeFriendlyName(pageSize));
            }
        }

        private void FillPageOrientations()
        {
            comboBoxPageOrientation.Items.Clear();
            foreach (Model.Report.PageOrientations pageOrientation in Enum.GetValues<Model.Report.PageOrientations>())
            {
                comboBoxPageOrientation.Items.Add(pageOrientation);
            }
        }

        public bool SaveReport(string fileName)
        {
            return Storage.FileSystem.Save(mReport, fileName);
        }

        #endregion Form stuff

        #region Display report elements

        private void ShowReport()
        {
            this.Cursor = Cursors.WaitCursor;

            TreeViewReport.SuspendLayout();
            TreeViewReport.Nodes.Clear();
            if (mReport.Sections is not null)
            {
                // Root node for the report
                TreeNode treeNodeReport = new()
                {
                    Text = string.IsNullOrWhiteSpace(mReport.Name) ? Properties.Resources.StringReportNew : mReport.Name,
                    Tag = ReportKey + "@",
                    ImageKey = ReportKey,
                    SelectedImageKey = ReportKey
                };
                TreeViewReport.Nodes.Add(treeNodeReport);
                treeNodeReport.Expand();

                ShowDatasource(treeNodeReport);
                ShowFonts(treeNodeReport);
                ShowBrushes(treeNodeReport);
                ShowSections(treeNodeReport);
            }
            TreeViewReport.ResumeLayout();

            this.Cursor = Cursors.Default;
        }

        private void ShowDatasource(TreeNode treeNodeParent)
        {
            TreeNode treeNodeDatasource = new()
            {
                Tag = DatasourceKey + "@",
                ImageKey = DatasourceKey,
                SelectedImageKey = DatasourceKey
            };
            treeNodeParent.Nodes.Add(treeNodeDatasource);
            if (mReport.Datasource is null)
            {
                treeNodeDatasource.Text = Properties.Resources.StringDatasource;
            }
            else
            {
                treeNodeDatasource.Text = mReport.Datasource.TypeFriendlyName + (mReport.Datasource.Type != System.Data.CommandType.Text ? " => " + mReport.Datasource.Text : string.Empty);
                foreach (string parameterName in mReport.Datasource.Parameters.OrderBy(p => p.Name).Select(p => p.Name))
                {
                    treeNodeDatasource.Nodes.Add(new TreeNode()
                    {
                        Text = parameterName,
                        Tag = DatasourceParameterKey + "@" + parameterName,
                        ImageKey = DatasourceParameterKey,
                        SelectedImageKey = DatasourceParameterKey
                    });
                }
            }
        }

        private void ShowFonts(TreeNode treeNodeParent)
        {
            TreeNode treeNodeFonts = new(Properties.Resources.StringFonts)
            {
                Tag = FontsKey + "@",
                ImageKey = FontsKey,
                SelectedImageKey = FontsKey
            };
            treeNodeParent.Nodes.Add(treeNodeFonts);
            foreach (Model.Font font in mReport.Fonts)
            {
                treeNodeFonts.Nodes.Add(new TreeNode()
                {
                    Text = $"#{font.FontId:00} - {font.Description}",
                    Tag = FontKey + "@" + font.FontId,
                    ImageKey = "Font",
                    SelectedImageKey = "Font"
                });
            }
        }

        private void ShowBrushes(TreeNode treeNodeParent)
        {
            TreeNode treeNodeBrushes = new()
            {
                Text = Properties.Resources.StringBrushes,
                Tag = BrushesKey + "@",
                ImageKey = BrushesKey,
                SelectedImageKey = BrushesKey
            };
            treeNodeParent.Nodes.Add(treeNodeBrushes);
            foreach (Model.Brush brush in mReport.Brushes)
            {
                treeNodeBrushes.Nodes.Add(new TreeNode()
                {
                    Text = $"#{brush.BrushId:00} {brush.Type} - {Properties.Resources.StringColor}: {brush.Color1Hex}",
                    Tag = BrushKey + "@" + brush.BrushId,
                    ImageKey = BrushKey,
                    SelectedImageKey = BrushKey
                });
            }
        }

        private void ShowSections(TreeNode treeNodeParent)
        {
            TreeNode treeNodeSections = new()
            {
                Text = Properties.Resources.StringSections,
                Tag = SectionsKey + "@",
                ImageKey = SectionsKey,
                SelectedImageKey = SectionsKey
            };
            treeNodeParent.Nodes.Add(treeNodeSections);
            foreach (Model.Section section in mReport.Sections.OrderBy(s => s.Type).ThenBy(s => s.Order))
            {
                TreeNode treeNodeSection = new()
                {
                    Text = $"{section.Type} - #{section.SectionId:00}",
                    Tag = SectionKey + "@" + section.SectionId,
                    ImageKey = SectionKey,
                    SelectedImageKey = SectionKey
                };
                treeNodeSections.Nodes.Add(treeNodeSection);

                ShowLinesOfSection(section, treeNodeSection);
                ShowRectanglesOfSection(section, treeNodeSection);
                ShowTextsOfSection(section, treeNodeSection);
            }
        }

        private void ShowLinesOfSection(Model.Section section, TreeNode treeNodeParent)
        {
            TreeNode treeNodeSectionLines = new()
            {
                Text = Properties.Resources.StringLines,
                Tag = LinesKey + "@",
                ImageKey = LinesKey,
                SelectedImageKey = LinesKey
            };
            treeNodeParent.Nodes.Add(treeNodeSectionLines);
            foreach (short lineId in mReport.Lines.Where(l => l.SectionId1 == section.SectionId).OrderBy(l => l.LineId).Select(l => l.LineId))
            {
                treeNodeSectionLines.Nodes.Add(new TreeNode()
                {
                    Text = $"#{lineId:00}",
                    Tag = LineKey + "@" + lineId,
                    ImageKey = LineKey,
                    SelectedImageKey = LineKey
                });
            }
        }

        private void ShowRectanglesOfSection(Model.Section section, TreeNode treeNodeParent)
        {
            TreeNode treeNodeSectionRectangles = new()
            {
                Text = Properties.Resources.StringRectangles,
                Tag = RectanglesKey + "@",
                ImageKey = RectanglesKey,
                SelectedImageKey = RectanglesKey
            };
            treeNodeParent.Nodes.Add(treeNodeSectionRectangles);
            foreach (short rectangleId in mReport.Rectangles.Where(r => r.SectionId1 == section.SectionId).OrderBy(r => r.RectangleId).Select(r => r.RectangleId))
            {
                treeNodeSectionRectangles.Nodes.Add(new TreeNode()
                {
                    Text = $"#{rectangleId:00}",
                    Tag = RectangleKey + "@" + rectangleId,
                    ImageKey = RectangleKey,
                    SelectedImageKey = RectangleKey
                });
            }
        }

        private void ShowTextsOfSection(Model.Section section, TreeNode treeNodeParent)
        {
            TreeNode treeNodeSectionTexts = new()
            {
                Text = Properties.Resources.StringTexts,
                Tag = TextsKey + "@",
                ImageKey = TextsKey,
                SelectedImageKey = TextsKey
            };
            treeNodeParent.Nodes.Add(treeNodeSectionTexts);
            foreach (Model.Text text in mReport.Texts.Where(t => t.SectionId == section.SectionId).OrderBy(t => t.TextId))
            {
                treeNodeSectionTexts.Nodes.Add(new TreeNode()
                {
                    Text = $"#{text.TextId:00} - {text.TextType} => {text.Value}",
                    Tag = TextKey + "@" + text.TextId,
                    ImageKey = TextKey,
                    SelectedImageKey = TextKey
                });
            }
        }

        #endregion Display report elements

        #region Events

        private void TreeViewReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            string nodeType = e.Node.Tag.ToString().Substring(0, e.Node.Tag.ToString().IndexOf("@"));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            switch (nodeType)
            {
                case ReportKey:
                    ShowReportProperties();
                    break;
            }
        }

        #endregion Events

        #region Display report element properties

        private void ShowReportProperties()
        {
            TableLayoutPanelReport.SuspendLayout();

            textBoxReportId.Text = mReport.ReportId.ToString();
            textBoxName.Text = mReport.Name;
            comboBoxPageSize.SelectedItem = mReport.PageSize;
            comboBoxPageOrientation.SelectedItem = mReport.PageOrientation;

            TableLayoutPanelReport.ResumeLayout();
            TableLayoutPanelReport.Visible = true;
        }

        #endregion Display report element properties

        #region Extra stuff

        private static string PageSizeFriendlyName(PageSizes pageSize)
        {
            return pageSize switch
            {
                PageSizes.A0 => "A0",
                PageSizes.A1 => "A1",
                PageSizes.A2 => "A2",
                PageSizes.A3 => "A3",
                PageSizes.A4 => "A4",
                PageSizes.A5 => "A5",
                PageSizes.RA0 => "RA0",
                PageSizes.RA1 => "RA1",
                PageSizes.RA2 => "RA2",
                PageSizes.RA3 => "RA3",
                PageSizes.RA4 => "RA4",
                PageSizes.RA5 => "RA5",
                PageSizes.B0 => "B0",
                PageSizes.B1 => "B1",
                PageSizes.B2 => "B2",
                PageSizes.B3 => "B3",
                PageSizes.B4 => "B4",
                PageSizes.B5 => "B5",
                PageSizes.Quarto => "Quarto",
                PageSizes.Foolscap => "Foolscap",
                PageSizes.Executive => "Executive",
                PageSizes.GovernmentLetter => "Government Letter",
                PageSizes.Letter => "Letter",
                PageSizes.Legal => "Legal",
                PageSizes.Ledger => "Ledger",
                PageSizes.Tabloid => "Tabloid",
                PageSizes.Post => "Post",
                PageSizes.Crown => "Crown",
                PageSizes.LargePost => "Large Post",
                PageSizes.Demy => "Demy",
                PageSizes.Medium => "Medium",
                PageSizes.Royal => "Royal",
                PageSizes.Elephant => "Elephant",
                PageSizes.DoubleDemy => "Double Demy",
                PageSizes.QuadDemy => "Quad Demy",
                PageSizes.STMT => "STMT",
                PageSizes.Folio => "Folio",
                PageSizes.Statement => "Statement",
                PageSizes.Size10x14 => "10x14",
                _ => "Undefined"
            };
        }

        #endregion Extra stuff

    }
}