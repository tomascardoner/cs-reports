namespace CardonerSistemas.Reports.Net.WinformsEditor
{
    public partial class FormReportEditor : Form
    {
        private readonly Model.Report mReport;

        public FormReportEditor(Model.Report report)
        {
            InitializeComponent();
            mReport = report;
            ShowReport();
        }

        private void ShowReport()
        {
            this.Cursor = Cursors.WaitCursor;

            TreeViewReport.SuspendLayout();
            TreeViewReport.Nodes.Clear();
            if (mReport is not null && mReport.Sections is not null)
            {
                // Root node for the report
                TreeNode treeNodeReport = new(mReport.Name);
                TreeViewReport.Nodes.Add(treeNodeReport);

                // First child node for the datasource if present
                if (mReport.Datasource is not null)
                {
                    TreeNode treeNodeDatasource = new(mReport.Datasource.Type.ToString() + (mReport.Datasource.Type != System.Data.CommandType.Text ? " => " + mReport.Datasource.Text : string.Empty));
                    treeNodeReport.Nodes.Add(treeNodeDatasource);
                    foreach (Model.DatasourceParameter parameter in mReport.Datasource.Parameters)
                    {
                        treeNodeDatasource.Nodes.Add(new TreeNode(parameter.Name));
                    }
                }

                // Nodes for fonts
                TreeNode treeNodeFonts = new("Fonts");
                treeNodeReport.Nodes.Add(treeNodeFonts);
                foreach (Model.Font font in mReport.Fonts)
                {
                    treeNodeFonts.Nodes.Add(new TreeNode(font.Description));
                }

                // Nodes for brushes
                TreeNode treeNodeBrushes = new("Brushes");
                treeNodeReport.Nodes.Add(treeNodeBrushes);
                foreach (Model.Brush brush in mReport.Brushes)
                {
                    treeNodeBrushes.Nodes.Add(new TreeNode($"{brush.Type} - Color: {brush.Color1Hex}"));
                }

                // Nexts nodes for the sections
                TreeNode treeNodeSections = new("Sections");
                treeNodeReport.Nodes.Add(treeNodeSections);
                foreach (Model.Section section in mReport.Sections.OrderBy(s => s.Type).ThenBy(s => s.Order))
                {
                    TreeNode treeNodeSection = new(section.Type.ToString())
                    {
                        Tag = section
                    };
                    treeNodeSections.Nodes.Add(treeNodeSection);

                    // Lines for the section
                    TreeNode treeNodeSectionLines = new("Lines");
                    treeNodeSection.Nodes.Add(treeNodeSectionLines);
                    foreach (Model.Line line in mReport.Lines.Where(l => l.SectionId1 == section.SectionId))
                    {
                        treeNodeSectionLines.Nodes.Add(line.LineId.ToString());
                    }

                    // Rectangles for the section
                    TreeNode treeNodeSectionRectangles = new("Rectangles");
                    treeNodeSection.Nodes.Add(treeNodeSectionRectangles);
                    foreach (Model.Rectangle rectangle in mReport.Rectangles.Where(r => r.SectionId1 == section.SectionId))
                    {
                        treeNodeSectionRectangles.Nodes.Add(rectangle.RectangleId.ToString());
                    }

                    // Texts for the section
                    TreeNode treeNodeSectionTexts = new("Texts");
                    treeNodeSection.Nodes.Add(treeNodeSectionTexts);
                    foreach (Model.Text text in mReport.Texts.Where(t => t.SectionId == section.SectionId))
                    {
                        treeNodeSectionTexts.Nodes.Add($"{text.TextType} => {text.Value}");
                    }
                }
            }
            TreeViewReport.ResumeLayout();

            PanelSection.SuspendLayout();
            PanelSection.Controls.Clear();
            PanelSection.ResumeLayout();

            this.Cursor = Cursors.Default;
        }

    }
}
