namespace CardonerSistemas.Reports.Net.WinformsEditor
{
    public partial class FormReportEditor : Form
    {
        private readonly Model.Report mReport;

        public FormReportEditor(Model.Report report)
        {
            InitializeComponent();
            mReport = report;
            TreeViewReport.ImageList = ImageListMain;
            ShowReport();
        }

        public bool SaveReport(string fileName)
        {
            return Storage.FileSystem.Save(mReport, fileName);
        }

        #region Display report elements

        private void ShowReport()
        {
            this.Cursor = Cursors.WaitCursor;
            this.Text = $"{Properties.Resources.StringEditorTitle} - {mReport.Name}";

            TreeViewReport.SuspendLayout();
            TreeViewReport.Nodes.Clear();
            if (mReport is not null && mReport.Sections is not null)
            {
                // Root node for the report
                TreeNode treeNodeReport = new(mReport.Name)
                {
                    ImageKey = "Report",
                    SelectedImageKey = "Report"
                };
                TreeViewReport.Nodes.Add(treeNodeReport);
                treeNodeReport.Expand();

                ShowDatasource(treeNodeReport);
                ShowFonts(treeNodeReport);
                ShowBrushes(treeNodeReport);
                ShowSections(treeNodeReport);
            }
            TreeViewReport.ResumeLayout();

            PanelSection.SuspendLayout();
            PanelSection.Controls.Clear();
            PanelSection.ResumeLayout();

            this.Cursor = Cursors.Default;
        }

        private void ShowDatasource(TreeNode treeNodeParent)
        {
            TreeNode treeNodeDatasource = new()
            {
                ImageKey = "Datasource",
                SelectedImageKey = "Datasource"
            };
            treeNodeParent.Nodes.Add(treeNodeDatasource);
            if (mReport.Datasource is null)
            {
                treeNodeDatasource.Text = Properties.Resources.StringDatasource;
            }
            else
            {
                treeNodeDatasource.Text = mReport.Datasource.TypeFriendlyName + (mReport.Datasource.Type != System.Data.CommandType.Text ? " => " + mReport.Datasource.Text : string.Empty);
                foreach (Model.DatasourceParameter parameter in mReport.Datasource.Parameters)
                {
                    treeNodeDatasource.Nodes.Add(new TreeNode(parameter.Name)
                    {
                        ImageKey = "DatasourceParameter",
                        SelectedImageKey = "DatasourceParameter"
                    });
                }
            }
        }

        private void ShowFonts(TreeNode treeNodeParent)
        {
            TreeNode treeNodeFonts = new(Properties.Resources.StringFonts)
            {
                ImageKey = "FontsFolder",
                SelectedImageKey = "FontsFolder"
            };
            treeNodeParent.Nodes.Add(treeNodeFonts);
            foreach (Model.Font font in mReport.Fonts)
            {
                treeNodeFonts.Nodes.Add(new TreeNode($"#{font.FontId:00} - {font.Description}")
                {
                    ImageKey = "Font",
                    SelectedImageKey = "Font"
                });
            }
        }

        private void ShowBrushes(TreeNode treeNodeParent)
        {
            TreeNode treeNodeBrushes = new(Properties.Resources.StringBrushes)
            {
                ImageKey = "BrushesFolder",
                SelectedImageKey = "BrushesFolder"
            };
            treeNodeParent.Nodes.Add(treeNodeBrushes);
            foreach (Model.Brush brush in mReport.Brushes)
            {
                treeNodeBrushes.Nodes.Add(new TreeNode($"#{brush.BrushId:00} {brush.Type} - {Properties.Resources.StringColor}: {brush.Color1Hex}")
                {
                    ImageKey = "Brush",
                    SelectedImageKey = "Brush"
                });
            }
        }

        private void ShowSections(TreeNode treeNodeParent)
        {
            TreeNode treeNodeSections = new(Properties.Resources.StringSections)
            {
                ImageKey = "SectionsFolder",
                SelectedImageKey = "SectionsFolder"
            };
            treeNodeParent.Nodes.Add(treeNodeSections);
            foreach (Model.Section section in mReport.Sections.OrderBy(s => s.Type).ThenBy(s => s.Order))
            {
                TreeNode treeNodeSection = new($"{section.Type} - #{section.SectionId:00}")
                {
                    Tag = section
                };
                treeNodeSections.Nodes.Add(treeNodeSection);

                ShowLinesOfSection(section, treeNodeSection);
                ShowRectanglesOfSection(section, treeNodeSection);
                ShowTextsOfSection(section, treeNodeSection);
            }
        }

        private void ShowLinesOfSection(Model.Section section, TreeNode treeNodeParent)
        {
            TreeNode treeNodeSectionLines = new(Properties.Resources.StringLines);
            treeNodeParent.Nodes.Add(treeNodeSectionLines);
            foreach (Model.Line line in mReport.Lines.Where(l => l.SectionId1 == section.SectionId))
            {
                treeNodeSectionLines.Nodes.Add(line.LineId.ToString());
            }
        }

        private void ShowRectanglesOfSection(Model.Section section, TreeNode treeNodeParent)
        {
            TreeNode treeNodeSectionRectangles = new(Properties.Resources.StringRectangles);
            treeNodeParent.Nodes.Add(treeNodeSectionRectangles);
            foreach (Model.Rectangle rectangle in mReport.Rectangles.Where(r => r.SectionId1 == section.SectionId))
            {
                treeNodeSectionRectangles.Nodes.Add(rectangle.RectangleId.ToString());
            }
        }

        private void ShowTextsOfSection(Model.Section section, TreeNode treeNodeParent)
        {
            TreeNode treeNodeSectionTexts = new(Properties.Resources.StringTexts);
            treeNodeParent.Nodes.Add(treeNodeSectionTexts);
            foreach (Model.Text text in mReport.Texts.Where(t => t.SectionId == section.SectionId))
            {
                treeNodeSectionTexts.Nodes.Add($"{text.TextType} => {text.Value}");
            }
        }

        #endregion Display report elements

    }
}
