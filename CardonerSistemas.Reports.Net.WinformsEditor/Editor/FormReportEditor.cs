using System.Collections.ObjectModel;

namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor
{
    public partial class FormReportEditor : Form
    {

        #region Declarations

        private const string ReportKey = "Report";
        private const string DatasourceKey = "Datasource";
        private const string DatasourceParametersKey = "DatasourceParameters";
        private const string DatasourceParameterKey = "DatasourceParameter";
        private const string DatasourceFieldsKey = "DatasourceFields";
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

        // Tree node indexs
        private const int TreeNodeReportIndex = 0;

        private const int TreeNodeDatasourceIndex = 0;
        private const int TreeNodeDatasourceParametersIndex = 0;
        private const int TreeNodeDatasourceFieldsIndex = 1;

        //private const int TreeNodeFontsIndex = 1;
        //private const int TreeNodeBrushesIndex = 2;
        //private const int TreeNodeSectionsIndex = 3;

        private readonly string mApplicationTitle;
        private readonly Model.Report mReport;
        private string mFilePath;

        private Panels.PanelReport? mPanelReport;
        private Panels.PanelDatasource? mPanelDatasource;
        private Panels.PanelDatasourceParameters? mPanelDatasourceParameters;
        private Panels.PanelDatasourceParameter? mPanelDatasourceParameter;
        private Panels.PanelDatasourceFields? mPanelDatasourceFields;
        private Panels.PanelDatasourceField? mPanelDatasourceField;

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
            this.Text = string.IsNullOrWhiteSpace(mReport.Name) ? Properties.Resources.StringReportNameNew : $"{mReport.Name} ({mFilePath})";
            treeViewReport.ImageList = imageListMain;
            ReportCreateNode();
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
                this.Text = string.IsNullOrWhiteSpace(mReport.Name) ? Properties.Resources.StringReportNameNew : $"{mReport.Name} ({mFilePath})";
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

            PanelControlsHide();

            Tuple<string, string> nodeInfo = GetTreeNodeInfoFromTag(e.Node);
            switch (nodeInfo.Item1)
            {
                case ReportKey:
                    ReportPanelShow();
                    break;
                case DatasourceKey:
                    DatasourcePanelShow();
                    break;
                case DatasourceParametersKey:
                    DatasourceParametersPanelShow();
                    break;
                case DatasourceParameterKey:
                    DatasourceParameterPanelShow(nodeInfo.Item2);
                    break;
                case DatasourceFieldsKey:
                    DatasourceFieldsPanelShow();
                    break;
                case DatasourceFieldKey:
                    DatasourceFieldPanelShow(short.Parse(nodeInfo.Item2));
                    break;
            }
        }

        #endregion Events

        #region Extra stuff

        private static string GetTreeNodeTag(string nodeType, string nodeId)
        {
            return nodeType + "@" + nodeId;
        }

        private static TreeNode AddTreeNode(string nodeText, string nodeType, string nodeId)
        {
            TreeNode treeNodeNew = new()
            {
                Text = nodeText,
                Tag = GetTreeNodeTag(nodeType, nodeId),
                ImageKey = nodeType,
                SelectedImageKey = nodeType
            };
            return treeNodeNew;
        }

        private static Tuple<string, string> GetTreeNodeInfoFromTag(TreeNode treeNode)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            string nodeTag = treeNode.Tag.ToString();
            string nodeType = nodeTag[..nodeTag.IndexOf('@')];
            string nodeId = nodeTag[(nodeType.Length + 1)..];
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            return Tuple.Create(nodeType, nodeId);
        }

        private static TreeNode? GetTreeNodeByTag(TreeNode parentTreeNode, string nodeType, string nodeId)
        {
            foreach (TreeNode treeNode in parentTreeNode.Nodes)
            {
                if (treeNode.Tag is not null && treeNode.Tag.ToString() == nodeType + "@" + nodeId)
                {
                    return treeNode;
                }
            }
            return null;
        }

        #endregion Extra stuff

        #region Panel controls

        private void PanelControlsHide()
        {
            mPanelReport?.Hide();
            mPanelDatasource?.Hide();
            mPanelDatasourceParameters?.Hide();
            mPanelDatasourceParameter?.Hide();
            mPanelDatasourceFields?.Hide();
            mPanelDatasourceField?.Hide();
        }

        #endregion Panel controls

        #region Report

        private void ReportCreateNode()
        {
            this.Cursor = Cursors.WaitCursor;

            treeViewReport.SuspendLayout();
            treeViewReport.Nodes.Clear();
            if (mReport.Sections is not null)
            {
                // Root node for the report
                TreeNode treeNodeReport = new()
                {
                    Text = string.IsNullOrWhiteSpace(mReport.Name) ? Properties.Resources.StringReportNameNew : mReport.Name,
                    Tag = ReportKey + "@",
                    ImageKey = ReportKey,
                    SelectedImageKey = ReportKey
                };
                treeViewReport.Nodes.Add(treeNodeReport);
                treeNodeReport.Expand();

                DatasourceCreateNode();
                CreateFontsNode(treeNodeReport);
                CreateBrushesNode(treeNodeReport);
                CreateSectionsNode(treeNodeReport);
            }
            treeViewReport.ResumeLayout();

            this.Cursor = Cursors.Default;
        }

        private void ReportPanelShow()
        {
            if (mPanelReport is null)
            {
                mPanelReport = new(mReport, mApplicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(mPanelReport);
            }
            mPanelReport.ShowProperties();
            mPanelReport.Show();
        }

        #endregion Report

        #region Datasource

        private string DatasourceTreeNodeGetText()
        {
            if (mReport.Datasource is null)
            {
                return Properties.Resources.StringDatasource;
            }
            else
            {
                return FriendlyNames.GetDatasourceType(mReport.Datasource.Type) + (mReport.Datasource.Type != System.Data.CommandType.Text ? " => " + mReport.Datasource.Text : string.Empty);
            }
        }

        private void DatasourceCreateNode()
        {
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes.Add(AddTreeNode(DatasourceTreeNodeGetText(), DatasourceKey, string.Empty));
            DatasourceParametersCreateNodes();
            DatasourceFieldsCreateNodes();
        }

        private void DatasourcePanelShow()
        {
            if (mPanelDatasource is null)
            {
                mPanelDatasource = new(mReport, mApplicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(mPanelDatasource);
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
                mPanelDatasource.DatasourceUpdated += DatasourceUpdated;
                mPanelDatasource.DatasourceDeleted += DatasourceDeleted;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            }
            mPanelDatasource.ShowProperties();
            mPanelDatasource.Show();
        }

        private void DatasourceUpdated(object sender, EventArgs e)
        {
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Text = DatasourceTreeNodeGetText();
            DatasourceParametersCreateNodes();
            DatasourceFieldsCreateNodes();
        }

        private void DatasourceDeleted(object sender, EventArgs e)
        {
            treeViewReport.SuspendLayout();
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Text = DatasourceTreeNodeGetText();
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes.Clear();
            treeViewReport.ResumeLayout();
        }

        #endregion Datasource

        #region Datasource parameters

        private string DatasourceParametersTreeNodeGetText()
        {
            return Properties.Resources.StringDatasourceParameters + string.Format(Properties.Resources.StringNodeItemsCount, mReport.Datasource?.Parameters.Count);
        }

        private void DatasourceParametersCreateNodes()
        {
            if (mReport.Datasource is null)
            {
                return;
            }
            if (GetTreeNodeByTag(treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex], DatasourceParametersKey, string.Empty) is not null)
            {
                return;
            }
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes.Add(AddTreeNode(DatasourceParametersTreeNodeGetText(), DatasourceParametersKey, string.Empty));
            foreach (string parameterName in mReport.Datasource.Parameters.Select(p => p.Name))
            {
                DatasourceParameterCreateNode(parameterName);
            }
        }

        private void DatasourceParametersPanelShow()
        {
            if (mPanelDatasourceParameters is null)
            {
                mPanelDatasourceParameters = new(mReport, mApplicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(mPanelDatasourceParameters);
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
                mPanelDatasourceParameters.ParameterAdded += DatasourceParameterUpdated;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            }
            mPanelDatasourceParameters.ShowProperties();
            mPanelDatasourceParameters.Show();
        }

        #endregion Datasource parameters

        #region Datasource parameter

        private static string DatasourceParameterTreeNodeGetText(string parameterName)
        {
            return parameterName;
        }

        private void DatasourceParameterCreateNode(string parameterName)
        {
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceParametersIndex].Nodes.Add(AddTreeNode(DatasourceParameterTreeNodeGetText(parameterName), DatasourceParameterKey, parameterName));
        }

        private void DatasourceParameterPanelShow(string parameterName)
        {
            Model.DatasourceParameter? parameter = mReport.Datasource?.Parameters.FirstOrDefault(p => p.Name == parameterName);
            if (parameter is null)
            {
                return;
            }
            if (mPanelDatasourceParameter is null)
            {
                mPanelDatasourceParameter = new(mReport, mApplicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(mPanelDatasourceParameter);
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
                mPanelDatasourceParameter.ParameterUpdated += DatasourceParameterUpdated;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            }
            mPanelDatasourceParameter.ShowProperties(parameterName);
            mPanelDatasourceParameter.Show();
        }

        private void DatasourceParameterUpdated(object sender, Panels.PanelDatasourceParameter.ParameterEventArgs e)
        {
            TreeNode treeNodeDatasourceParameters = treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceParametersIndex];
            TreeNode? treeNodeDatasourceParameter = GetTreeNodeByTag(treeNodeDatasourceParameters, DatasourceParameterKey, e.NameOld);
            if (treeNodeDatasourceParameter is null)
            {
                treeNodeDatasourceParameters.Nodes.Add(AddTreeNode(DatasourceParameterTreeNodeGetText(e.NameNew), DatasourceParameterKey, e.NameNew));
                treeNodeDatasourceParameters.Text = DatasourceParametersTreeNodeGetText();
            }
            else
            {
                treeNodeDatasourceParameter.Text = e.NameNew;
                treeNodeDatasourceParameter.Tag = GetTreeNodeTag(DatasourceParameterKey, e.NameNew);
            }
            treeViewReport.SelectedNode = treeNodeDatasourceParameter;
        }

        private void DatasourceParameterDeleted(object sender, Panels.PanelDatasourceParameter.ParameterEventArgs e)
        {
            TreeNode treeNodeDatasourceParameters = treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceParametersIndex];
            TreeNode? treeNodeDatasourceParameter = GetTreeNodeByTag(treeNodeDatasourceParameters, DatasourceParameterKey, e.NameOld);
            if (treeNodeDatasourceParameter is not null)
            {
                treeNodeDatasourceParameters.Nodes.Remove(treeNodeDatasourceParameter);
                treeNodeDatasourceParameters.Text = DatasourceParametersTreeNodeGetText();
            }
        }

        #endregion Datasource parameter

        #region Datasource fields

        private string DatasourceFieldsTreeNodeGetText()
        {
            return Properties.Resources.StringDatasourceFields + string.Format(Properties.Resources.StringNodeItemsCount, mReport.Datasource?.Fields.Count);
        }

        private void DatasourceFieldsCreateNodes()
        {
            if (mReport.Datasource is null)
            {
                return;
            }
            if (GetTreeNodeByTag(treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex], DatasourceFieldsKey, string.Empty) is not null)
            {
                return;
            }
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes.Add(AddTreeNode(DatasourceFieldsTreeNodeGetText(), DatasourceFieldsKey, string.Empty));
            foreach (Model.DatasourceField field in mReport.Datasource.Fields)
            {
                DatasourceFieldCreateNode(field.FieldId, field.Name);
            }
        }

        private void DatasourceFieldsPanelShow()
        {
            if (mPanelDatasourceFields is null)
            {
                mPanelDatasourceFields = new(mReport, mApplicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(mPanelDatasourceFields);
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
                mPanelDatasourceFields.FieldAdded += DatasourceFieldUpdated;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            }
            mPanelDatasourceFields.ShowProperties();
            mPanelDatasourceFields.Show();
        }

        #endregion Datasource fields

        #region Datasource field

        private static string DatasourceFieldTreeNodeGetText(string fieldName)
        {
            return fieldName;
        }

        private void DatasourceFieldCreateNode(short fieldId, string fieldName)
        {
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceFieldsIndex].Nodes.Add(AddTreeNode(DatasourceFieldTreeNodeGetText(fieldName), DatasourceFieldKey, fieldId.ToString()));
        }

        private void DatasourceFieldPanelShow(short fieldId)
        {
            Model.DatasourceField? field = mReport.Datasource?.Fields.FirstOrDefault(f => f.FieldId == fieldId);
            if (field is null)
            {
                return;
            }
            if (mPanelDatasourceField is null)
            {
                mPanelDatasourceField = new(mReport, mApplicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(mPanelDatasourceField);
#pragma warning disable CS8622 // Nullability of reference types in type of field doesn't match the target delegate (possibly because of nullability attributes).
                mPanelDatasourceField.FieldUpdated += DatasourceFieldUpdated;
#pragma warning restore CS8622 // Nullability of reference types in type of field doesn't match the target delegate (possibly because of nullability attributes).
            }
            mPanelDatasourceField.ShowProperties(fieldId);
            mPanelDatasourceField.Show();
        }

        private void DatasourceFieldUpdated(object sender, Panels.PanelDatasourceField.FieldEventArgs e)
        {
            TreeNode treeNodeDatasourceFields = treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceFieldsIndex];
            TreeNode? treeNodeDatasourceField = GetTreeNodeByTag(treeNodeDatasourceFields, DatasourceFieldKey, e.NameOld);
            if (treeNodeDatasourceField is null)
            {
                treeNodeDatasourceFields.Nodes.Add(AddTreeNode(DatasourceFieldTreeNodeGetText(e.NameNew), DatasourceFieldKey, e.NameNew));
                treeNodeDatasourceFields.Text = DatasourceFieldsTreeNodeGetText();
            }
            else
            {
                treeNodeDatasourceField.Text = e.NameNew;
                treeNodeDatasourceField.Tag = GetTreeNodeTag(DatasourceFieldKey, e.NameNew);
            }
            treeViewReport.SelectedNode = treeNodeDatasourceField;
        }

        private void DatasourceFieldDeleted(object sender, Panels.PanelDatasourceField.FieldEventArgs e)
        {
            TreeNode treeNodeDatasourceFields = treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceFieldsIndex];
            TreeNode? treeNodeDatasourceField = GetTreeNodeByTag(treeNodeDatasourceFields, DatasourceFieldKey, e.NameOld);
            if (treeNodeDatasourceField is not null)
            {
                treeNodeDatasourceFields.Nodes.Remove(treeNodeDatasourceField);
                treeNodeDatasourceFields.Text = DatasourceFieldsTreeNodeGetText();
            }
        }

        #endregion Datasource field

        #region Fonts

        private void CreateFontsNode(TreeNode treeNodeParent)
        {
            TreeNode treeNodeFonts = new()
            {
                Text = Properties.Resources.StringFonts + string.Format(Properties.Resources.StringNodeItemsCount, mReport.Fonts.Count),
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
                Text = Properties.Resources.StringBrushes + string.Format(Properties.Resources.StringNodeItemsCount, mReport.Brushes.Count),
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
                Text = Properties.Resources.StringSections + string.Format(Properties.Resources.StringNodeItemsCount, mReport.Sections.Count),
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
            Collection<short> linesIds = [.. mReport.Lines.Where(l => l.SectionId1 == section.SectionId).OrderBy(l => l.LineId).Select(l => l.LineId)];
            TreeNode treeNodeSectionLines = new()
            {
                Text = Properties.Resources.StringLines + string.Format(Properties.Resources.StringNodeItemsCount, linesIds.Count),
                Tag = LinesKey + "@",
                ImageKey = LinesKey,
                SelectedImageKey = LinesKey
            };
            treeNodeParent.Nodes.Add(treeNodeSectionLines);
            foreach (short lineId in linesIds)
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
            Collection<short> rectanglesIds = [.. mReport.Rectangles.Where(r => r.SectionId1 == section.SectionId).OrderBy(r => r.RectangleId).Select(r => r.RectangleId)];
            TreeNode treeNodeSectionRectangles = new()
            {
                Text = Properties.Resources.StringRectangles + string.Format(Properties.Resources.StringNodeItemsCount, rectanglesIds.Count),
                Tag = RectanglesKey + "@",
                ImageKey = RectanglesKey,
                SelectedImageKey = RectanglesKey
            };
            treeNodeParent.Nodes.Add(treeNodeSectionRectangles);
            foreach (short rectangleId in rectanglesIds)
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
            Collection<Model.Text> texts = [.. mReport.Texts.Where(t => t.SectionId == section.SectionId).OrderBy(t => t.TextId)];
            TreeNode treeNodeSectionTexts = new()
            {
                Text = Properties.Resources.StringTexts + string.Format(Properties.Resources.StringNodeItemsCount, texts.Count),
                Tag = TextsKey + "@",
                ImageKey = TextsKey,
                SelectedImageKey = TextsKey
            };
            treeNodeParent.Nodes.Add(treeNodeSectionTexts);
            foreach (Model.Text text in texts)
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