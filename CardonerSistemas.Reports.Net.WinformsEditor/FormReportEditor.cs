using System.Data.Common;

namespace CardonerSistemas.Reports.Net.WinformsEditor
{
    public partial class FormReportEditor : Form
    {

        #region Declarations

        private const string ReportKey = "Report";
        private const string DatasourceKey = "Datasource";
        private const string DatasourceParameterKey = "DatasourceParameter";
        private const string DatasourceFieldKey = "DatasourceField";
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

        private readonly string mApplicationTitle;
        private readonly Model.Report mReport;
        private string mFilePath;

        private ReportEditorPanels.PanelReport? mPanelReport;
        private ReportEditorPanels.PanelDatasource? mPanelDatasource;
        private ReportEditorPanels.PanelDatasourceParameter? mPanelDatasourceParameter;

        public string FilePath => mFilePath;

        #endregion Declarations

        #region Form stuff

        public FormReportEditor(string applicationTitle, Model.Report report, string filePath)
        {
            InitializeComponent();
            mApplicationTitle = applicationTitle;
            mReport = report;
            mFilePath = filePath;
            InitializeForm();
        }

        private void InitializeForm()
        {
            this.Text = string.IsNullOrWhiteSpace(mReport.Name) ? Properties.Resources.StringReportNew : $"{mReport.Name} ({mFilePath})";
            treeViewReport.ImageList = imageListMain;
            CreateReportNode();
        }

        private void FormReportEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mReport.IsModified && MessageBox.Show(Properties.Resources.StringReportModifiedConfirmation, mApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                SaveReport();
            }
        }

        #endregion Form stuff

        #region Methods

        public bool SaveReport()
        {
            if (string.IsNullOrEmpty(mFilePath))
            {
                return SaveReportAs();
            }
            else
            {
                return Storage.FileSystem.Save(mReport, mFilePath);
            }
        }

        public bool SaveReportAs()
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = Properties.Resources.StringFileDialogFilter,
                FilterIndex = 1,
                RestoreDirectory = true,
                CheckWriteAccess = true,
                ValidateNames = true
            };
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK && Storage.FileSystem.Save(mReport, saveFileDialog.FileName))
            {
                mFilePath = saveFileDialog.FileName;
                this.Text = string.IsNullOrWhiteSpace(mReport.Name) ? Properties.Resources.StringReportNew : $"{mReport.Name} ({mFilePath})";
                return true;
            }
            return false;
        }

        #endregion Methods

        #region Events

        private void TreeViewReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is null || e.Node.Tag is null)
            {
                return;
            }
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            string nodeTag = e.Node.Tag.ToString();
            string nodeType = nodeTag[..nodeTag.IndexOf('@')];
            string nodeId = nodeTag[(nodeType.Length + 1)..];
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            PanelControlsHide();

            switch (nodeType)
            {
                case ReportKey:
                    PanelReportShow();
                    break;
                case DatasourceKey:
                    PanelDatasourceShow();
                    break;
                case DatasourceParameterKey:
                    PanelDatasourceParameterShow(nodeId);
                    break;
            }
        }

        #endregion Events

        #region Panel controls

        private void PanelControlsHide()
        {
            mPanelReport?.Hide();
            mPanelDatasource?.Hide();
            mPanelDatasourceParameter?.Hide();
        }

        #endregion Panel controls

        #region Report

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

        private void PanelReportShow()
        {
            if (mPanelReport is null)
            {
                mPanelReport = new(mReport, mApplicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(mPanelReport);
            }
            else
            {
                mPanelReport.SetReport(mReport);
            }
            mPanelReport.Show();
        }

        #endregion Report

        #region Datasource

        private void CreateDatasourceNode(TreeNode treeNodeParent)
        {
            TreeNode treeNodeDatasource = new()
            {
                Tag = DatasourceKey + "@",
                ImageKey = DatasourceKey,
                SelectedImageKey = DatasourceKey
            };
            if (mReport.Datasource is null)
            {
                treeNodeDatasource.Text = Properties.Resources.StringDatasource;
            }
            else
            {
                treeNodeDatasource.Text = FriendlyNames.GetDatasourceType(mReport.Datasource.Type) + (mReport.Datasource.Type != System.Data.CommandType.Text ? " => " + mReport.Datasource.Text : string.Empty);
            }
            treeNodeParent.Nodes.Add(treeNodeDatasource);

            CreateDatasourceParametersNodes(treeNodeDatasource);
            CreateDatasourceFieldsNodes(treeNodeDatasource);
        }

        private void PanelDatasourceShow()
        {
            if (mPanelDatasource is null)
            {
                mPanelDatasource = new(mReport.Datasource, mApplicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(mPanelDatasource);
            }
            else
            {
                mPanelDatasource.SetDatasource(mReport.Datasource);
            }
            mPanelDatasource.Show();
        }

        #endregion Datasource

        #region Datasource parameters

        private void CreateDatasourceParametersNodes(TreeNode treeNodeParent)
        {
            if (mReport.Datasource is null)
            {
                return;
            }
            foreach (string parameterName in mReport.Datasource.Parameters.Select(p => p.Name))
            {
                treeNodeParent.Nodes.Add(new TreeNode()
                {
                    Text = parameterName,
                    Tag = DatasourceParameterKey + "@" + parameterName,
                    ImageKey = DatasourceParameterKey,
                    SelectedImageKey = DatasourceParameterKey
                });
            }
        }

        private void PanelDatasourceParameterShow(string parameterName)
        {
            Model.DatasourceParameter? parameter = mReport.Datasource?.Parameters.FirstOrDefault(p => p.Name == parameterName);
            if (parameter is null)
            {
                return;
            }
            if (mPanelDatasourceParameter is null)
            {
                mPanelDatasourceParameter = new(parameter, mApplicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(mPanelDatasourceParameter);
            }
            else
            {
                mPanelDatasourceParameter.SetDatasourceParameter(parameter);
            }
            mPanelDatasourceParameter.Show();
        }

        #endregion Datasource parameters

        #region Datasource fields

        private void CreateDatasourceFieldsNodes(TreeNode treeNodeParent)
        {
            if (mReport.Datasource is null)
            {
                return;
            }
            foreach (string fieldName in mReport.Datasource.Fields.Select(f => f.Name))
            {
                treeNodeParent.Nodes.Add(new TreeNode()
                {
                    Text = fieldName,
                    Tag = DatasourceFieldKey + "@" + fieldName,
                    ImageKey = DatasourceFieldKey,
                    SelectedImageKey = DatasourceFieldKey
                });
            }
        }

        private void PanelDatasourceFieldShow(string fieldName)
        {
            Model.DatasourceField? field = mReport.Datasource?.Fields.FirstOrDefault(p => p.Name == fieldName);
            if (field is null)
            {
                return;
            }
            //if (mPanelDatasourceField is null)
            //{
            //    mPanelDatasourceField = new(field, mApplicationTitle)
            //    {
            //        Dock = DockStyle.Fill
            //    };
            //    splitContainerMain.Panel2.Controls.Add(mPanelDatasourceField);
            //}
            //else
            //{
            //    mPanelDatasourceField.SetDatasourceField(field);
            //}
            //mPanelDatasourceField.Show();
        }

        #endregion Datasource fields

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