using System.Collections.ObjectModel;
using System.ComponentModel;

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

        private const int TreeNodeFontsIndex = 1;
        private const int TreeNodeBrushesIndex = 2;

        private readonly string _applicationTitle;
        private readonly Model.Report _report;
        private Panels.PanelReport? _panelReport;
        private Panels.PanelDatasource? _panelDatasource;
        private Panels.PanelDatasourceParameters? _panelDatasourceParameters;
        private Panels.PanelDatasourceParameter? _panelDatasourceParameter;
        private Panels.PanelDatasourceFields? _panelDatasourceFields;
        private Panels.PanelDatasourceField? _panelDatasourceField;
        private Panels.PanelFonts? _panelFonts;
        private Panels.PanelFont? _panelFont;
        private Panels.PanelBrushes? _panelBrushes;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FilePath { get; private set; }

        #endregion Declarations

        #region Form stuff

        public FormReportEditor(string applicationTitle, Model.Report report, string filePath)
        {
            InitializeComponent();
            _applicationTitle = applicationTitle;
            _report = report;
            FilePath = filePath;
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = string.IsNullOrWhiteSpace(_report.Name) ? Properties.Resources.StringReportNameNew : $"{_report.Name} ({FilePath})";
            treeViewReport.ImageList = imageListMain;
            ReportCreateNode();
        }

        private void For_reportEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_report.IsModified && MessageBox.Show(Properties.Resources.StringReportModifiedConfirmation, _applicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                SaveReport();
            }
        }

        #endregion Form stuff

        #region Methods

        public bool SaveReport()
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                return SaveReportAs();
            }
            else
            {
                return Storage.FileSystem.Save(_report, FilePath);
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
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK && Storage.FileSystem.Save(_report, saveFileDialog.FileName))
            {
                FilePath = saveFileDialog.FileName;
                Text = string.IsNullOrWhiteSpace(_report.Name) ? Properties.Resources.StringReportNameNew : $"{_report.Name} ({FilePath})";
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
                case FontsKey:
                    FontsPanelShow();
                    break;
                case FontKey:
                    FontPanelShow(short.Parse(nodeInfo.Item2));
                    break;
                case BrushesKey:
                    BrushesPanelShow();
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
            _panelReport?.Hide();
            _panelDatasource?.Hide();
            _panelDatasourceParameters?.Hide();
            _panelDatasourceParameter?.Hide();
            _panelDatasourceFields?.Hide();
            _panelDatasourceField?.Hide();
            _panelFonts?.Hide();
            _panelFont?.Hide();
            _panelBrushes?.Hide();
        }

        #endregion Panel controls

        #region Report

        private string ReportTreeNodeGetText()
        {
            return _report.DisplayName;
        }

        private void ReportCreateNode()
        {
            Cursor = Cursors.WaitCursor;
            treeViewReport.SuspendLayout();
            treeViewReport.Nodes.Clear();
            if (_report.Sections is not null)
            {
                // Root node for the report
                TreeNode treeNodeReport = AddTreeNode(ReportTreeNodeGetText(), ReportKey, string.Empty);
                treeViewReport.Nodes.Add(treeNodeReport);
                treeNodeReport.Expand();

                DatasourceCreateNodes();
                FontsCreateNodes();
                BrushesCreateNodes();
                CreateSectionsNode(treeNodeReport);
            }
            treeViewReport.ResumeLayout();
            Cursor = Cursors.Default;
        }

        private void ReportPanelShow()
        {
            if (_panelReport is null)
            {
                _panelReport = new(_report, _applicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(_panelReport);
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
                _panelReport.ReportUpdated += ReportUpdated;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            }
            _panelReport.ShowProperties();
            _panelReport.Show();
        }

        private void ReportUpdated(object sender, EventArgs e)
        {
            treeViewReport.Nodes[TreeNodeReportIndex].Text = ReportTreeNodeGetText();
        }

        #endregion Report

        #region Datasource

        private string DatasourceTreeNodeGetText()
        {
            if (_report.Datasource is null)
            {
                return Properties.Resources.StringDatasource;
            }
            else
            {
                return _report.Datasource.DisplayName;
            }
        }

        private void DatasourceCreateNodes()
        {
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes.Add(AddTreeNode(DatasourceTreeNodeGetText(), DatasourceKey, string.Empty));
            DatasourceParametersCreateNodes();
            DatasourceFieldsCreateNodes();
        }

        private void DatasourcePanelShow()
        {
            if (_panelDatasource is null)
            {
                _panelDatasource = new(_report, _applicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(_panelDatasource);
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
                _panelDatasource.DatasourceUpdated += DatasourceUpdated;
                _panelDatasource.DatasourceDeleted += DatasourceDeleted;
                _panelDatasource.FieldsUpdated += DatasourceFieldsUpdated;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            }
            _panelDatasource.ShowProperties();
            _panelDatasource.Show();
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
            return Properties.Resources.StringDatasourceParameters + string.Format(Properties.Resources.StringNodeItemsCount, _report.Datasource?.Parameters.Count);
        }

        private void DatasourceParametersCreateNodes()
        {
            if (_report.Datasource is null)
            {
                return;
            }
            if (GetTreeNodeByTag(treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex], DatasourceParametersKey, string.Empty) is not null)
            {
                return;
            }
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes.Add(AddTreeNode(DatasourceParametersTreeNodeGetText(), DatasourceParametersKey, string.Empty));
            foreach (Model.DatasourceParameter parameter in _report.Datasource.Parameters.OrderBy(p => p.Name))
            {
                DatasourceParameterCreateNode(parameter);
            }
        }

        private void DatasourceParametersPanelShow()
        {
            if (_panelDatasourceParameters is null)
            {
                _panelDatasourceParameters = new(_report, _applicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(_panelDatasourceParameters);
                _panelDatasourceParameters.ParameterAdded += DatasourceParameterUpdated;
            }
            _panelDatasourceParameters.ShowProperties();
            _panelDatasourceParameters.Show();
        }

        #endregion Datasource parameters

        #region Datasource parameter

        private static string DatasourceParameterTreeNodeGetText(Model.DatasourceParameter parameter)
        {
            return parameter.DisplayName;
        }

        private TreeNode DatasourceParameterCreateNode(Model.DatasourceParameter parameter)
        {
            TreeNode treeNodeDatasourceParameter = AddTreeNode(DatasourceParameterTreeNodeGetText(parameter), DatasourceParameterKey, parameter.Name);
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceParametersIndex].Nodes.Add(treeNodeDatasourceParameter);
            return treeNodeDatasourceParameter;
        }

        private void DatasourceParameterPanelShow(string parameterName)
        {
            Model.DatasourceParameter? parameter = _report.Datasource?.Parameters.FirstOrDefault(p => p.Name == parameterName);
            if (parameter is null)
            {
                return;
            }
            if (_panelDatasourceParameter is null)
            {
                _panelDatasourceParameter = new(_report, _applicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(_panelDatasourceParameter);
                _panelDatasourceParameter.ParameterUpdated += DatasourceParameterUpdated;
                _panelDatasourceParameter.ParameterDeleted += DatasourceParameterDeleted;
            }
            _panelDatasourceParameter.ShowProperties(parameterName);
            _panelDatasourceParameter.Show();
        }

        private void DatasourceParameterUpdated(object sender, string parameterName)
        {
            Model.DatasourceParameter? parameter = _report.Datasource?.Parameters.FirstOrDefault(p => p.Name == parameterName);
            if (parameter is null)
            {
                return;
            }
            TreeNode treeNodeDatasourceParameters = treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceParametersIndex];
            TreeNode? treeNodeDatasourceParameter = GetTreeNodeByTag(treeNodeDatasourceParameters, DatasourceParameterKey, parameter.Name);
            if (treeNodeDatasourceParameter is null)
            {
                treeNodeDatasourceParameter = DatasourceParameterCreateNode(parameter);
                treeNodeDatasourceParameters.Text = DatasourceParametersTreeNodeGetText();
            }
            else
            {
                treeNodeDatasourceParameter.Text = DatasourceParameterTreeNodeGetText(parameter);
                treeNodeDatasourceParameter.Tag = GetTreeNodeTag(DatasourceParameterKey, parameter.Name);
            }
            treeViewReport.SelectedNode = treeNodeDatasourceParameter;
            if (!treeNodeDatasourceParameter.IsVisible)
            {
                treeNodeDatasourceParameter.EnsureVisible();
            }
        }

        private void DatasourceParameterDeleted(object sender, string parameterName)
        {
            TreeNode treeNodeDatasourceParameters = treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceParametersIndex];
            TreeNode? treeNodeDatasourceParameter = GetTreeNodeByTag(treeNodeDatasourceParameters, DatasourceParameterKey, parameterName);
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
            return Properties.Resources.StringDatasourceFields + string.Format(Properties.Resources.StringNodeItemsCount, _report.Datasource?.Fields.Count);
        }

        private void DatasourceFieldsCreateNodes()
        {
            if (_report.Datasource is null)
            {
                return;
            }
            if (treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes.Count <= TreeNodeDatasourceFieldsIndex)
            {
                treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes.Add(AddTreeNode(DatasourceFieldsTreeNodeGetText(), DatasourceFieldsKey, string.Empty));
            }
            foreach (Model.DatasourceField field in _report.Datasource.Fields.OrderBy(f => f.Position))
            {
                DatasourceFieldCreateNode(field);
            }
        }

        private void DatasourceFieldsPanelShow()
        {
            if (_panelDatasourceFields is null)
            {
                _panelDatasourceFields = new(_report, _applicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(_panelDatasourceFields);
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
                _panelDatasourceFields.FieldAdded += DatasourceFieldUpdated;
                _panelDatasourceFields.FieldsUpdated += DatasourceFieldsUpdated;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            }
            _panelDatasourceFields.ShowProperties();
            _panelDatasourceFields.Show();
        }

        private void DatasourceFieldsUpdated(object sender, EventArgs e)
        {
            treeViewReport.SuspendLayout();
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceFieldsIndex].Text = DatasourceFieldsTreeNodeGetText();
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceFieldsIndex].Nodes.Clear();
            DatasourceFieldsCreateNodes();
            treeViewReport.ResumeLayout();
            if (treeViewReport.SelectedNode is not null && treeViewReport.SelectedNode.Tag == treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceFieldsIndex].Tag && _panelDatasourceFields is not null)
            {
                _panelDatasourceFields.ShowProperties();
            }
        }

        #endregion Datasource fields

        #region Datasource field

        private static string DatasourceFieldTreeNodeGetText(Model.DatasourceField field)
        {
            return field.DisplayName;
        }

        private TreeNode DatasourceFieldCreateNode(Model.DatasourceField field)
        {
            TreeNode treeNodeDatasourceField = AddTreeNode(DatasourceFieldTreeNodeGetText(field), DatasourceFieldKey, field.FieldId.ToString());
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceFieldsIndex].Nodes.Add(treeNodeDatasourceField);
            return treeNodeDatasourceField;
        }

        private void DatasourceFieldPanelShow(short fieldId)
        {
            Model.DatasourceField? field = _report.Datasource?.Fields.FirstOrDefault(f => f.FieldId == fieldId);
            if (field is null)
            {
                return;
            }
            if (_panelDatasourceField is null)
            {
                _panelDatasourceField = new(_report, _applicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(_panelDatasourceField);
                _panelDatasourceField.FieldUpdated += DatasourceFieldUpdated;
                _panelDatasourceField.FieldDeleted += DatasourceFieldDeleted;
            }
            _panelDatasourceField.ShowProperties(fieldId);
            _panelDatasourceField.Show();
        }

        private void DatasourceFieldUpdated(object sender, short fieldId)
        {
            Model.DatasourceField? field = _report.Datasource?.Fields.FirstOrDefault(f => f.FieldId == fieldId);
            if (field is null)
            {
                return;
            }
            TreeNode treeNodeDatasourceFields = treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceFieldsIndex];
            TreeNode? treeNodeDatasourceField = GetTreeNodeByTag(treeNodeDatasourceFields, DatasourceFieldKey, fieldId.ToString());
            if (treeNodeDatasourceField is null)
            {
                treeNodeDatasourceField = DatasourceFieldCreateNode(field);
                treeNodeDatasourceFields.Text = DatasourceFieldsTreeNodeGetText();
            }
            else
            {
                treeNodeDatasourceField.Text = DatasourceFieldTreeNodeGetText(field);
            }
            treeViewReport.SelectedNode = treeNodeDatasourceField;
            if (!treeNodeDatasourceField.IsVisible)
            {
                treeNodeDatasourceField.EnsureVisible();
            }
        }

        private void DatasourceFieldDeleted(object sender, short fieldId)
        {
            TreeNode treeNodeDatasourceFields = treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceFieldsIndex];
            TreeNode? treeNodeDatasourceField = GetTreeNodeByTag(treeNodeDatasourceFields, DatasourceFieldKey, fieldId.ToString());
            if (treeNodeDatasourceField is not null)
            {
                treeNodeDatasourceFields.Nodes.Remove(treeNodeDatasourceField);
                treeNodeDatasourceFields.Text = DatasourceFieldsTreeNodeGetText();
            }
        }

        #endregion Datasource field

        #region Fonts

        private string FontsTreeNodeGetText()
        {
            return Properties.Resources.StringFonts + string.Format(Properties.Resources.StringNodeItemsCount, _report.Fonts.Count);
        }

        private void FontsCreateNodes()
        {
            if (treeViewReport.Nodes[TreeNodeReportIndex].Nodes.Count <= TreeNodeFontsIndex)
            {
                treeViewReport.Nodes[TreeNodeReportIndex].Nodes.Add(AddTreeNode(FontsTreeNodeGetText(), FontsKey, string.Empty));
            }
            foreach (Model.Font font in _report.Fonts.OrderBy(f => f.FontId))
            {
                FontCreateNode(font);
            }
        }

        private void FontsPanelShow()
        {
            if (_panelFonts is null)
            {
                _panelFonts = new(_report, _applicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(_panelFonts);
                _panelFonts.FontAdded += FontUpdated;
            }
            _panelFonts.ShowProperties();
            _panelFonts.Show();
        }

        #endregion Fonts

        #region Font

        private static string FontTreeNodeGetText(Model.Font font)
        {
            return font.DisplayName;
        }

        private TreeNode FontCreateNode(Model.Font font)
        {
            TreeNode treeNodeFont = AddTreeNode(FontTreeNodeGetText(font), FontKey, font.FontId.ToString());
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeFontsIndex].Nodes.Add(treeNodeFont);
            return treeNodeFont;
        }

        private void FontPanelShow(short fontId)
        {
            Model.Font? font = _report.Fonts.FirstOrDefault(f => f.FontId == fontId);
            if (font is null)
            {
                return;
            }
            if (_panelFont is null)
            {
                _panelFont = new(_report, _applicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(_panelFont);
                _panelFont.FontUpdated += FontUpdated;
                _panelFont.FontDeleted += FontDeleted;
            }
            _panelFont.ShowProperties(fontId);
            _panelFont.Show();
        }

        private void FontUpdated(object sender, short fontId)
        {
            Model.Font? font = _report.Fonts.FirstOrDefault(f => f.FontId == fontId);
            if (font is null)
            {
                return;
            }
            TreeNode treeNodeFonts = treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeFontsIndex];
            TreeNode? treeNodeFont = GetTreeNodeByTag(treeNodeFonts, FontKey, font.FontId.ToString());
            if (treeNodeFont is null)
            {
                treeNodeFont = FontCreateNode(font);
                treeNodeFonts.Text = FontsTreeNodeGetText();
            }
            else
            {
                treeNodeFont.Text = FontTreeNodeGetText(font);
            }
            treeViewReport.SelectedNode = treeNodeFont;
            if (!treeNodeFont.IsVisible)
            {
                treeNodeFont.EnsureVisible();
            }
        }

        private void FontDeleted(object sender, short fontId)
        {
            TreeNode treeNodeFonts = treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeFontsIndex];
            TreeNode? treeNodeFont = GetTreeNodeByTag(treeNodeFonts, FontKey, fontId.ToString());
            if (treeNodeFont is not null)
            {
                treeNodeFonts.Nodes.Remove(treeNodeFont);
                treeNodeFonts.Text = FontsTreeNodeGetText();
            }
        }

        #endregion Font

        #region Brushes

        private string BrushesTreeNodeGetText()
        {
            return Properties.Resources.StringBrushes + string.Format(Properties.Resources.StringNodeItemsCount, _report.Brushes.Count);
        }

        private void BrushesCreateNodes()
        {
            if (treeViewReport.Nodes[TreeNodeReportIndex].Nodes.Count <= TreeNodeBrushesIndex)
            {
                treeViewReport.Nodes[TreeNodeReportIndex].Nodes.Add(AddTreeNode(BrushesTreeNodeGetText(), BrushesKey, string.Empty));
            }
            foreach (Model.Brush brush in _report.Brushes.OrderBy(f => f.BrushId))
            {
                BrushCreateNode(brush);
            }
        }

        private void BrushesPanelShow()
        {
            if (_panelBrushes is null)
            {
                _panelBrushes = new(_report, _applicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(_panelBrushes);
                _panelBrushes.BrushAdded += BrushUpdated;
            }
            _panelBrushes.ShowProperties();
            _panelBrushes.Show();
        }

        #endregion Brushes

        #region Brush

        private static string BrushTreeNodeGetText(Model.Brush brush)
        {
            return brush.DisplayName;
        }

        private TreeNode BrushCreateNode(Model.Brush brush)
        {
            TreeNode treeNodeBrush = AddTreeNode(BrushTreeNodeGetText(brush), BrushKey, brush.BrushId.ToString());
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeBrushesIndex].Nodes.Add(treeNodeBrush);
            return treeNodeBrush;
        }

        //private void BrushPanelShow(short brushId)
        //{
        //    Model.Brush? brush = _report.Brushs.FirstOrDefault(f => f.BrushId == brushId);
        //    if (brush is null)
        //    {
        //        return;
        //    }
        //    if (_panelBrush is null)
        //    {
        //        _panelBrush = new(_report, _applicationTitle)
        //        {
        //            Dock = DockStyle.Fill
        //        };
        //        splitContainerMain.Panel2.Controls.Add(_panelBrush);
        //        _panelBrush.BrushUpdated += BrushUpdated;
        //        _panelBrush.BrushDeleted += BrushDeleted;
        //    }
        //    _panelBrush.ShowProperties(brushId);
        //    _panelBrush.Show();
        //}

        private void BrushUpdated(object sender, short brushId)
        {
            Model.Brush? brush = _report.Brushes.FirstOrDefault(f => f.BrushId == brushId);
            if (brush is null)
            {
                return;
            }
            TreeNode treeNodeBrushs = treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeBrushesIndex];
            TreeNode? treeNodeBrush = GetTreeNodeByTag(treeNodeBrushs, BrushKey, brush.BrushId.ToString());
            if (treeNodeBrush is null)
            {
                treeNodeBrush = BrushCreateNode(brush);
                treeNodeBrushs.Text = BrushesTreeNodeGetText();
            }
            else
            {
                treeNodeBrush.Text = BrushTreeNodeGetText(brush);
            }
            treeViewReport.SelectedNode = treeNodeBrush;
            if (!treeNodeBrush.IsVisible)
            {
                treeNodeBrush.EnsureVisible();
            }
        }

        //private void BrushDeleted(object sender, short brushId)
        //{
        //    TreeNode treeNodeBrushs = treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeBrushsIndex];
        //    TreeNode? treeNodeBrush = GetTreeNodeByTag(treeNodeBrushs, BrushKey, brushId.ToString());
        //    if (treeNodeBrush is not null)
        //    {
        //        treeNodeBrushs.Nodes.Remove(treeNodeBrush);
        //        treeNodeBrushs.Text = BrushsTreeNodeGetText();
        //    }
        //}

        #endregion Brush

        #region Sections

        private void CreateSectionsNode(TreeNode treeNodeParent)
        {
            TreeNode treeNodeSections = new()
            {
                Text = Properties.Resources.StringSections + string.Format(Properties.Resources.StringNodeItemsCount, _report.Sections.Count),
                Tag = SectionsKey + "@",
                ImageKey = SectionsKey,
                SelectedImageKey = SectionsKey
            };
            treeNodeParent.Nodes.Add(treeNodeSections);
            foreach (Model.Section section in _report.Sections.OrderBy(s => s.Type).ThenBy(s => s.Order))
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
            Collection<short> linesIds = [.. _report.Lines.Where(l => l.SectionId1 == section.SectionId).OrderBy(l => l.LineId).Select(l => l.LineId)];
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
            Collection<short> rectanglesIds = [.. _report.Rectangles.Where(r => r.SectionId1 == section.SectionId).OrderBy(r => r.RectangleId).Select(r => r.RectangleId)];
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
            Collection<Model.Text> texts = [.. _report.Texts.Where(t => t.SectionId == section.SectionId).OrderBy(t => t.TextId)];
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
