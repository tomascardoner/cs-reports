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

        internal string FilePath => mFilePath;

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
            treeViewReport.ImageList = imageListMain;
            CreateReportNode();

            // Report combo boxes
            FillReportPageSizes();
            FillReportPageOrientations();

            // Datasource combo boxes
            FillDatasourceProviders();
            FillDatasourceTypes();
        }

        #endregion Form stuff

        #region Methods

        public bool SaveReport()
        {
            if (!string.IsNullOrEmpty(mFilePath))
            {
                return Storage.FileSystem.Save(mReport, mFilePath);
            }
            return false;
        }

        public bool SaveReport(string fileName)
        {
            if (Storage.FileSystem.Save(mReport, fileName))
            {
                mFilePath = fileName;
                this.Text = string.IsNullOrWhiteSpace(mReport.Name) ? Properties.Resources.StringReportNew : $"{mReport.Name} ({mFilePath})";
                return true;
            }
            return false;
        }

        #endregion Methods

        #region Events

        private void TreeViewReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            string nodeType = e.Node.Tag.ToString()[..e.Node.Tag.ToString().IndexOf('@')];
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            tableLayoutPanelReport.Visible = false;
            tableLayoutPanelDatasource.Visible = false;

            switch (nodeType)
            {
                case ReportKey:
                    ShowReportProperties();
                    break;
                case DatasourceKey:
                    ShowDatasourceProperties();
                    break;
            }
        }

        private void TextBoxs_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }

        #endregion Events

        #region Report

        private void FillReportPageSizes()
        {
            comboBoxReportPageSize.ValueMember = "Key";
            comboBoxReportPageSize.DisplayMember = "Value";
            ICollection<KeyValuePair<byte, string>> reportPageSizes = [];
            foreach (Model.Report.PageSizes pageSize in Enum.GetValues<Model.Report.PageSizes>())
            {
                reportPageSizes.Add(new KeyValuePair<byte, string>((byte)pageSize, FriendlyNames.GetPageSize(pageSize)));
            }
            comboBoxReportPageSize.DataSource = reportPageSizes;
        }

        private void FillReportPageOrientations()
        {
            comboBoxReportPageOrientation.ValueMember = "Key";
            comboBoxReportPageOrientation.DisplayMember = "Value";
            ICollection<KeyValuePair<byte, string>> reportPageOrientations = [];
            foreach (Model.Report.PageOrientations pageOrientation in Enum.GetValues<Model.Report.PageOrientations>())
            {
                reportPageOrientations.Add(new KeyValuePair<byte, string>((byte)pageOrientation, FriendlyNames.GetPageOrientation(pageOrientation)));
            }
            comboBoxReportPageOrientation.DataSource = reportPageOrientations;
        }

        private void CreateReportNode()
        {
            this.Cursor = Cursors.WaitCursor;

            treeViewReport.SuspendLayout();
            treeViewReport.Nodes.Clear();
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
                treeViewReport.Nodes.Add(treeNodeReport);
                treeNodeReport.Expand();

                CreateDatasourceNode(treeNodeReport);
                CreateFontsNode(treeNodeReport);
                CreateBrushesNode(treeNodeReport);
                CreateSectionsNode(treeNodeReport);
            }
            treeViewReport.ResumeLayout();

            this.Cursor = Cursors.Default;
        }

        private void ShowReportProperties()
        {
            textBoxReportId.Text = mReport.ReportId.ToString();
            textBoxReportName.Text = mReport.Name;
            textBoxReportTemplateFileName.Text = mReport.TemplateFileName;
            comboBoxReportPageSize.SelectedIndex = (byte)mReport.PageSize;
            comboBoxReportPageOrientation.SelectedItem = mReport.PageOrientation;
            numericUpDownReportPageMarginTop.Value = mReport.PageMarginTop;
            numericUpDownReportPageMarginLeft.Value = mReport.PageMarginLeft;
            numericUpDownReportPageMarginRight.Value = mReport.PageMarginRight;
            numericUpDownReportPageMarginBottom.Value = mReport.PageMarginBottom;
            numericUpDownReportDetailSectionMaxRowCount.Value = mReport.DetailSectionMaxRowCount;

            tableLayoutPanelReport.Visible = true;
        }

        private void ReportApplyChanges(object sender, EventArgs e)
        {
            mReport.Name = textBoxReportName.Text;
            mReport.TemplateFileName = textBoxReportTemplateFileName.Text;
            mReport.PageSize = (Model.Report.PageSizes)comboBoxReportPageSize.SelectedIndex;
            mReport.PageOrientation = (Model.Report.PageOrientations)comboBoxReportPageOrientation.SelectedIndex;
            mReport.PageMarginTop = numericUpDownReportPageMarginTop.Value;
            mReport.PageMarginLeft = numericUpDownReportPageMarginLeft.Value;
            mReport.PageMarginRight = numericUpDownReportPageMarginRight.Value;
            mReport.PageMarginBottom = numericUpDownReportPageMarginBottom.Value;
            mReport.DetailSectionMaxRowCount = (short)numericUpDownReportDetailSectionMaxRowCount.Value;
        }

        private void ReportResetChanges(object sender, EventArgs e)
        {
            ShowReportProperties();
        }

        #endregion Report

        #region Datasource

        private void FillDatasourceProviders()
        {
            comboBoxDatasourceProvider.ValueMember = "Key";
            comboBoxDatasourceProvider.DisplayMember = "Value";
            ICollection<KeyValuePair<byte, string>> datasourceProviders = [];
            foreach (Model.Datasource.Providers provider in Enum.GetValues<Model.Datasource.Providers>())
            {
                datasourceProviders.Add(new KeyValuePair<byte, string>((byte)provider, FriendlyNames.GetDatasourceProvider(provider)));
            }
            comboBoxDatasourceProvider.DataSource = datasourceProviders;
        }

        private void FillDatasourceTypes()
        {
            comboBoxDatasourceType.ValueMember = "Key";
            comboBoxDatasourceType.DisplayMember = "Value";
            ICollection<KeyValuePair<short, string>> datasourceTypes = [];
            foreach (System.Data.CommandType datasourceType in Enum.GetValues<System.Data.CommandType>())
            {
                datasourceTypes.Add(new KeyValuePair<short, string>((short)datasourceType, FriendlyNames.GetDatasourceType(datasourceType)));
            }
            comboBoxDatasourceType.DataSource = datasourceTypes;
        }

        private void CreateDatasourceNode(TreeNode treeNodeParent)
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
                treeNodeDatasource.Text = FriendlyNames.GetDatasourceType(mReport.Datasource.Type) + (mReport.Datasource.Type != System.Data.CommandType.Text ? " => " + mReport.Datasource.Text : string.Empty);
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

        private void ShowDatasourceProperties()
        {
            tableLayoutPanelDatasource.SuspendLayout();
            if (mReport.Datasource is null)
            {
                comboBoxDatasourceProvider.SelectedIndex = -1;
                textBoxDatasourceConnectionString.Text = string.Empty;
                comboBoxDatasourceType.SelectedIndex = -1;
                textBoxDatasourceText.Text = string.Empty;
            }
            else
            {
                comboBoxDatasourceProvider.SelectedValue = (byte)mReport.Datasource.Provider;
                textBoxDatasourceConnectionString.Text = mReport.Datasource.ConnectionString;
                comboBoxDatasourceType.SelectedValue = (short)mReport.Datasource.Type;
                textBoxDatasourceText.Text = mReport.Datasource.Text;
            }
            tableLayoutPanelDatasource.ResumeLayout();
            tableLayoutPanelDatasource.Visible = true;
        }

        private void DatasourceApplyChanges(object sender, EventArgs e)
        {
            mReport.Datasource ??= new();
            mReport.Datasource.Provider = (Model.Datasource.Providers)comboBoxDatasourceProvider.SelectedIndex;
            mReport.Datasource.ConnectionString = textBoxDatasourceConnectionString.Text;
            mReport.Datasource.Type = (System.Data.CommandType)comboBoxDatasourceType.SelectedIndex;
            mReport.Datasource.Text = textBoxDatasourceText.Text;
        }

        private void DatasourceResetChanges(object sender, EventArgs e)
        {
            ShowDatasourceProperties();
        }

        #endregion Datasource

        #region Fonts

        private void CreateFontsNode(TreeNode treeNodeParent)
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

        #endregion Fonts

        #region Brushes

        private void CreateBrushesNode(TreeNode treeNodeParent)
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

        #endregion Brushes

        #region Sections

        private void CreateSectionsNode(TreeNode treeNodeParent)
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

                CreateLinesOfSectionNode(section, treeNodeSection);
                CreateRectanglesOfSectionNode(section, treeNodeSection);
                CreateTextsOfSectionNode(section, treeNodeSection);
            }
        }

        #endregion Sections

        #region Lines

        private void CreateLinesOfSectionNode(Model.Section section, TreeNode treeNodeParent)
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

        #endregion Lines

        #region Rectangles

        private void CreateRectanglesOfSectionNode(Model.Section section, TreeNode treeNodeParent)
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

        #endregion Rectangles

        #region Texts

        private void CreateTextsOfSectionNode(Model.Section section, TreeNode treeNodeParent)
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

        #endregion Texts

    }
}