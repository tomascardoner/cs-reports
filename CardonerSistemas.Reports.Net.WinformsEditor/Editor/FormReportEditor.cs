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
        private const int TreeNodeSectionsIndex = 3;

        private const int TreeNodeLinesIndex = 0;
        private const int TreeNodeRectanglesIndex = 1;
        private const int TreeNodeTextsIndex = 2;

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
        private Panels.PanelBrush? _panelBrush;
        private Panels.PanelSections? _panelSections;
        private Panels.PanelSection? _panelSection;
        private Panels.PanelLines? _panelLines;
        private Panels.PanelLine? _panelLine;
        private Panels.PanelRectangles? _panelRectangles;
        private Panels.PanelRectangle? _panelRectangle;
        private Panels.PanelText? _panelText;
        private Panels.PanelTexts? _panelTexts;

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
            ReportCreateTreeNode();
        }

        private void This_FormClosing(object sender, FormClosingEventArgs e)
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
                    DatasourceParameterPanelShow(short.Parse(nodeInfo.Item2));
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
                case BrushKey:
                    BrushPanelShow(short.Parse(nodeInfo.Item2));
                    break;
                case SectionsKey:
                    SectionsPanelShow();
                    break;
                case SectionKey:
                    SectionPanelShow(short.Parse(nodeInfo.Item2));
                    break;
                case LinesKey:
                    LinesPanelShow(GetShortIdFromParentNode(e.Node));
                    break;
                case LineKey:
                    LinePanelShow(short.Parse(nodeInfo.Item2));
                    break;
                case RectanglesKey:
                    RectanglesPanelShow(GetShortIdFromParentNode(e.Node));
                    break;
                case RectangleKey:
                    RectanglePanelShow(short.Parse(nodeInfo.Item2));
                    break;
                case TextsKey:
                    TextsPanelShow(GetShortIdFromParentNode(e.Node));
                    break;
                case TextKey:
                    TextPanelShow(short.Parse(nodeInfo.Item2));
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
            TreeNode treeTreeNodeNew = new()
            {
                Text = nodeText,
                Tag = GetTreeNodeTag(nodeType, nodeId),
                ImageKey = nodeType,
                SelectedImageKey = nodeType
            };
            return treeTreeNodeNew;
        }

        private static Tuple<string, string> GetTreeNodeInfoFromTag(TreeNode treeNode)
        {
            string nodeTag = treeNode.Tag!.ToString()!;
            string nodeType = nodeTag[..nodeTag.IndexOf('@')];
            string nodeId = nodeTag[(nodeType.Length + 1)..];
            return Tuple.Create(nodeType, nodeId);
        }

        private static short GetShortIdFromParentNode(TreeNode treeNode)
        {
            if (treeNode.Parent is null || treeNode.Parent.Tag is null)
            {
                return 0;
            }
            Tuple<string, string> nodeInfo = GetTreeNodeInfoFromTag(treeNode.Parent);
            return short.Parse(nodeInfo.Item2);
        }

        private static TreeNode? GetTreeNodeByTag(TreeNode parentTreeNode, string nodeType, string nodeId)
        {
            foreach (TreeNode treeTreeNode in parentTreeNode.Nodes)
            {
                if (treeTreeNode.Tag is not null && treeTreeNode.Tag.ToString() == nodeType + "@" + nodeId)
                {
                    return treeTreeNode;
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
            _panelBrush?.Hide();
            _panelSections?.Hide();
            _panelSection?.Hide();
            _panelLines?.Hide();
            _panelLine?.Hide();
            _panelRectangles?.Hide();
            _panelRectangle?.Hide();
            _panelTexts?.Hide();
            _panelText?.Hide();
        }

        #endregion Panel controls

        #region Report

        private string ReportTreeNodeGetText()
        {
            return _report.DisplayName;
        }

        private void ReportCreateTreeNode()
        {
            Cursor = Cursors.WaitCursor;
            treeViewReport.SuspendLayout();
            treeViewReport.Nodes.Clear();
            if (_report.Sections is not null)
            {
                // Root node for the report
                TreeNode treeTreeNodeReport = AddTreeNode(ReportTreeNodeGetText(), ReportKey, string.Empty);
                treeViewReport.Nodes.Add(treeTreeNodeReport);
                treeTreeNodeReport.Expand();

                DatasourceCreateTreeNodes();
                FontsCreateTreeNodes();
                BrushesCreateTreeNodes();
                SectionsCreateTreeNodes();
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
                _panelReport.ReportUpdated += ReportUpdated!;
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

        private void DatasourceCreateTreeNodes()
        {
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes.Add(AddTreeNode(DatasourceTreeNodeGetText(), DatasourceKey, string.Empty));
            DatasourceParametersCreateTreeNodes();
            DatasourceFieldsCreateTreeNodes();
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
                _panelDatasource.DatasourceUpdated += DatasourceUpdated!;
                _panelDatasource.DatasourceDeleted += DatasourceDeleted!;
                _panelDatasource.FieldsUpdated += DatasourceFieldsUpdated!;
            }
            _panelDatasource.ShowProperties();
            _panelDatasource.Show();
        }

        private void DatasourceUpdated(object sender, EventArgs e)
        {
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Text = DatasourceTreeNodeGetText();
            DatasourceParametersCreateTreeNodes();
            DatasourceFieldsCreateTreeNodes();
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
            return Properties.Resources.StringDatasourceParameters + string.Format(Properties.Resources.StringTreeNodeItemsCount, _report.Datasource?.Parameters.Count);
        }

        private void DatasourceParametersCreateTreeNodes()
        {
            if (_report.Datasource is null)
            {
                return;
            }
            if (treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes.Count <= TreeNodeDatasourceParametersIndex)
            {
                treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes.Add(AddTreeNode(DatasourceParametersTreeNodeGetText(), DatasourceParametersKey, string.Empty));
            }
            foreach (Model.DatasourceParameter parameter in _report.Datasource.Parameters.OrderBy(p => p.Name))
            {
                DatasourceParameterCreateTreeNode(parameter);
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

        private TreeNode DatasourceParameterCreateTreeNode(Model.DatasourceParameter parameter)
        {
            TreeNode treeTreeNodeDatasourceParameter = AddTreeNode(DatasourceParameterTreeNodeGetText(parameter), DatasourceParameterKey, parameter.ParameterId.ToString());
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceParametersIndex].Nodes.Add(treeTreeNodeDatasourceParameter);
            return treeTreeNodeDatasourceParameter;
        }

        private void DatasourceParameterPanelShow(short parameterId)
        {
            Model.DatasourceParameter? parameter = _report.Datasource?.Parameters.FirstOrDefault(p => p.ParameterId == parameterId);
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
            _panelDatasourceParameter.ShowProperties(parameterId);
            _panelDatasourceParameter.Show();
        }

        private void DatasourceParameterUpdated(object sender, short parameterId)
        {
            Model.DatasourceParameter? parameter = _report.Datasource?.Parameters.FirstOrDefault(p => p.ParameterId == parameterId);
            if (parameter is null)
            {
                return;
            }
            TreeNode treeTreeNodeDatasourceParameters = treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceParametersIndex];
            TreeNode? treeTreeNodeDatasourceParameter = GetTreeNodeByTag(treeTreeNodeDatasourceParameters, DatasourceParameterKey, parameterId.ToString());
            if (treeTreeNodeDatasourceParameter is null)
            {
                treeTreeNodeDatasourceParameter = DatasourceParameterCreateTreeNode(parameter);
                treeTreeNodeDatasourceParameters.Text = DatasourceParametersTreeNodeGetText();
            }
            else
            {
                treeTreeNodeDatasourceParameter.Text = DatasourceParameterTreeNodeGetText(parameter);
                treeTreeNodeDatasourceParameter.Tag = GetTreeNodeTag(DatasourceParameterKey, parameter.Name);
            }
            treeViewReport.SelectedNode = treeTreeNodeDatasourceParameter;
            if (!treeTreeNodeDatasourceParameter.IsVisible)
            {
                treeTreeNodeDatasourceParameter.EnsureVisible();
            }
        }

        private void DatasourceParameterDeleted(object sender, short parameterId)
        {
            TreeNode treeTreeNodeDatasourceParameters = treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceParametersIndex];
            TreeNode? treeTreeNodeDatasourceParameter = GetTreeNodeByTag(treeTreeNodeDatasourceParameters, DatasourceParameterKey, parameterId.ToString());
            if (treeTreeNodeDatasourceParameter is not null)
            {
                treeTreeNodeDatasourceParameters.Nodes.Remove(treeTreeNodeDatasourceParameter);
                treeTreeNodeDatasourceParameters.Text = DatasourceParametersTreeNodeGetText();
            }
        }

        #endregion Datasource parameter

        #region Datasource fields

        private string DatasourceFieldsTreeNodeGetText()
        {
            return Properties.Resources.StringDatasourceFields + string.Format(Properties.Resources.StringTreeNodeItemsCount, _report.Datasource?.Fields.Count);
        }

        private void DatasourceFieldsCreateTreeNodes()
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
                DatasourceFieldCreateTreeNode(field);
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
                _panelDatasourceFields.FieldAdded += DatasourceFieldUpdated;
                _panelDatasourceFields.FieldsUpdated += DatasourceFieldsUpdated!;
            }
            _panelDatasourceFields.ShowProperties();
            _panelDatasourceFields.Show();
        }

        private void DatasourceFieldsUpdated(object sender, EventArgs e)
        {
            treeViewReport.SuspendLayout();
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceFieldsIndex].Text = DatasourceFieldsTreeNodeGetText();
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceFieldsIndex].Nodes.Clear();
            DatasourceFieldsCreateTreeNodes();
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

        private TreeNode DatasourceFieldCreateTreeNode(Model.DatasourceField field)
        {
            TreeNode treeTreeNodeDatasourceField = AddTreeNode(DatasourceFieldTreeNodeGetText(field), DatasourceFieldKey, field.FieldId.ToString());
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceFieldsIndex].Nodes.Add(treeTreeNodeDatasourceField);
            return treeTreeNodeDatasourceField;
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
            TreeNode treeTreeNodeDatasourceFields = treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceFieldsIndex];
            TreeNode? treeTreeNodeDatasourceField = GetTreeNodeByTag(treeTreeNodeDatasourceFields, DatasourceFieldKey, fieldId.ToString());
            if (treeTreeNodeDatasourceField is null)
            {
                treeTreeNodeDatasourceField = DatasourceFieldCreateTreeNode(field);
                treeTreeNodeDatasourceFields.Text = DatasourceFieldsTreeNodeGetText();
            }
            else
            {
                treeTreeNodeDatasourceField.Text = DatasourceFieldTreeNodeGetText(field);
            }
            treeViewReport.SelectedNode = treeTreeNodeDatasourceField;
            if (!treeTreeNodeDatasourceField.IsVisible)
            {
                treeTreeNodeDatasourceField.EnsureVisible();
            }
        }

        private void DatasourceFieldDeleted(object sender, short fieldId)
        {
            TreeNode treeTreeNodeDatasourceFields = treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeDatasourceIndex].Nodes[TreeNodeDatasourceFieldsIndex];
            TreeNode? treeTreeNodeDatasourceField = GetTreeNodeByTag(treeTreeNodeDatasourceFields, DatasourceFieldKey, fieldId.ToString());
            if (treeTreeNodeDatasourceField is not null)
            {
                treeTreeNodeDatasourceFields.Nodes.Remove(treeTreeNodeDatasourceField);
                treeTreeNodeDatasourceFields.Text = DatasourceFieldsTreeNodeGetText();
            }
        }

        #endregion Datasource field

        #region Fonts

        private string FontsTreeNodeGetText()
        {
            return Properties.Resources.StringFonts + string.Format(Properties.Resources.StringTreeNodeItemsCount, _report.Fonts.Count);
        }

        private void FontsCreateTreeNodes()
        {
            if (treeViewReport.Nodes[TreeNodeReportIndex].Nodes.Count <= TreeNodeFontsIndex)
            {
                treeViewReport.Nodes[TreeNodeReportIndex].Nodes.Add(AddTreeNode(FontsTreeNodeGetText(), FontsKey, string.Empty));
            }
            foreach (Model.Font font in _report.Fonts.OrderBy(f => f.FontId))
            {
                FontCreateTreeNode(font);
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

        private TreeNode FontCreateTreeNode(Model.Font font)
        {
            TreeNode treeTreeNodeFont = AddTreeNode(FontTreeNodeGetText(font), FontKey, font.FontId.ToString());
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeFontsIndex].Nodes.Add(treeTreeNodeFont);
            return treeTreeNodeFont;
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
            TreeNode treeTreeNodeFonts = treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeFontsIndex];
            TreeNode? treeTreeNodeFont = GetTreeNodeByTag(treeTreeNodeFonts, FontKey, font.FontId.ToString());
            if (treeTreeNodeFont is null)
            {
                treeTreeNodeFont = FontCreateTreeNode(font);
                treeTreeNodeFonts.Text = FontsTreeNodeGetText();
            }
            else
            {
                treeTreeNodeFont.Text = FontTreeNodeGetText(font);
            }
            treeViewReport.SelectedNode = treeTreeNodeFont;
            if (!treeTreeNodeFont.IsVisible)
            {
                treeTreeNodeFont.EnsureVisible();
            }
        }

        private void FontDeleted(object sender, short fontId)
        {
            TreeNode treeTreeNodeFonts = treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeFontsIndex];
            TreeNode? treeTreeNodeFont = GetTreeNodeByTag(treeTreeNodeFonts, FontKey, fontId.ToString());
            if (treeTreeNodeFont is not null)
            {
                treeTreeNodeFonts.Nodes.Remove(treeTreeNodeFont);
                treeTreeNodeFonts.Text = FontsTreeNodeGetText();
            }
        }

        #endregion Font

        #region Brushes

        private string BrushesTreeNodeGetText()
        {
            return Properties.Resources.StringBrushes + string.Format(Properties.Resources.StringTreeNodeItemsCount, _report.Brushes.Count);
        }

        private void BrushesCreateTreeNodes()
        {
            if (treeViewReport.Nodes[TreeNodeReportIndex].Nodes.Count <= TreeNodeBrushesIndex)
            {
                treeViewReport.Nodes[TreeNodeReportIndex].Nodes.Add(AddTreeNode(BrushesTreeNodeGetText(), BrushesKey, string.Empty));
            }
            foreach (Model.Brush section in _report.Brushes.OrderBy(f => f.BrushId))
            {
                BrushCreateTreeNode(section);
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

        private TreeNode BrushCreateTreeNode(Model.Brush brush)
        {
            TreeNode treeTreeNodeBrush = AddTreeNode(BrushTreeNodeGetText(brush), BrushKey, brush.BrushId.ToString());
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeBrushesIndex].Nodes.Add(treeTreeNodeBrush);
            return treeTreeNodeBrush;
        }

        private void BrushPanelShow(short brushId)
        {
            Model.Brush? brush = _report.Brushes.FirstOrDefault(b => b.BrushId == brushId);
            if (brush is null)
            {
                return;
            }
            if (_panelBrush is null)
            {
                _panelBrush = new(_report, _applicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(_panelBrush);
                _panelBrush.BrushUpdated += BrushUpdated;
                _panelBrush.BrushDeleted += BrushDeleted;
            }
            _panelBrush.ShowProperties(brushId);
            _panelBrush.Show();
        }

        private void BrushUpdated(object sender, short brushId)
        {
            Model.Brush? brush = _report.Brushes.FirstOrDefault(f => f.BrushId == brushId);
            if (brush is null)
            {
                return;
            }
            TreeNode treeTreeNodeBrushs = treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeBrushesIndex];
            TreeNode? treeTreeNodeBrush = GetTreeNodeByTag(treeTreeNodeBrushs, BrushKey, brush.BrushId.ToString());
            if (treeTreeNodeBrush is null)
            {
                treeTreeNodeBrush = BrushCreateTreeNode(brush);
                treeTreeNodeBrushs.Text = BrushesTreeNodeGetText();
            }
            else
            {
                treeTreeNodeBrush.Text = BrushTreeNodeGetText(brush);
            }
            treeViewReport.SelectedNode = treeTreeNodeBrush;
            if (!treeTreeNodeBrush.IsVisible)
            {
                treeTreeNodeBrush.EnsureVisible();
            }
        }

        private void BrushDeleted(object sender, short brushId)
        {
            TreeNode treeTreeNodeBrushs = treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeBrushesIndex];
            TreeNode? treeTreeNodeBrush = GetTreeNodeByTag(treeTreeNodeBrushs, BrushKey, brushId.ToString());
            if (treeTreeNodeBrush is not null)
            {
                treeTreeNodeBrushs.Nodes.Remove(treeTreeNodeBrush);
                treeTreeNodeBrushs.Text = BrushesTreeNodeGetText();
            }
        }

        #endregion Brush

        #region Sections

        private string SectionsTreeNodeGetText()
        {
            return Properties.Resources.StringSections + string.Format(Properties.Resources.StringTreeNodeItemsCount, _report.Sections.Count);
        }

        private void SectionsCreateTreeNodes()
        {
            if (treeViewReport.Nodes[TreeNodeReportIndex].Nodes.Count <= TreeNodeSectionsIndex)
            {
                treeViewReport.Nodes[TreeNodeReportIndex].Nodes.Add(AddTreeNode(SectionsTreeNodeGetText(), SectionsKey, string.Empty));
            }
            foreach (Model.Section section in _report.Sections.OrderBy(s => s.Type).ThenBy(s => s.Order))
            {
                SectionCreateTreeNode(section);
            }
        }

        private void SectionsPanelShow()
        {
            if (_panelSections is null)
            {
                _panelSections = new(_report, _applicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(_panelSections);
                _panelSections.SectionAdded += SectionUpdated;
            }
            _panelSections.ShowProperties();
            _panelSections.Show();
        }

        #endregion Sections

        #region Section

        private static string SectionTreeNodeGetText(Model.Section section)
        {
            return section.DisplayName;
        }

        private TreeNode SectionCreateTreeNode(Model.Section section)
        {
            TreeNode treeTreeNodeSection = AddTreeNode(SectionTreeNodeGetText(section), SectionKey, section.SectionId.ToString());
            treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeSectionsIndex].Nodes.Add(treeTreeNodeSection);

            LinesOfSectionCreateTreeNodes(section, treeTreeNodeSection);
            RectanglesOfSectionCreateTreeNodes(section, treeTreeNodeSection);
            TextsOfSectionCreateTreeNodes(section, treeTreeNodeSection);
            return treeTreeNodeSection;
        }

        private void SectionPanelShow(short sectionId)
        {
            Model.Section? section = _report.Sections.FirstOrDefault(s => s.SectionId == sectionId);
            if (section is null)
            {
                return;
            }
            if (_panelSection is null)
            {
                _panelSection = new(_report, _applicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(_panelSection);
                _panelSection.SectionUpdated += SectionUpdated;
                _panelSection.SectionDeleted += SectionDeleted;
            }
            _panelSection.ShowProperties(sectionId);
            _panelSection.Show();
        }

        private void SectionUpdated(object sender, short sectionId)
        {
            Model.Section? section = _report.Sections.FirstOrDefault(s => s.SectionId == sectionId);
            if (section is null)
            {
                return;
            }
            TreeNode treeTreeNodeSections = treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeSectionsIndex];
            TreeNode? treeTreeNodeSection = GetTreeNodeByTag(treeTreeNodeSections, SectionKey, section.SectionId.ToString());
            if (treeTreeNodeSection is null)
            {
                treeTreeNodeSection = SectionCreateTreeNode(section);
                treeTreeNodeSections.Text = SectionsTreeNodeGetText();
            }
            else
            {
                treeTreeNodeSection.Text = SectionTreeNodeGetText(section);
            }
            treeViewReport.SelectedNode = treeTreeNodeSection;
            if (!treeTreeNodeSection.IsVisible)
            {
                treeTreeNodeSection.EnsureVisible();
            }
        }

        private void SectionDeleted(object sender, short sectionId)
        {
            TreeNode treeTreeNodeSections = treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeSectionsIndex];
            TreeNode? treeTreeNodeSection = GetTreeNodeByTag(treeTreeNodeSections, SectionKey, sectionId.ToString());
            if (treeTreeNodeSection is not null)
            {
                treeTreeNodeSections.Nodes.Remove(treeTreeNodeSection);
                treeTreeNodeSections.Text = SectionsTreeNodeGetText();
            }
        }

        #endregion Section

        #region Lines

        private static string LinesTreeNodeGetText(int count)
        {
            return Properties.Resources.StringLines + string.Format(Properties.Resources.StringTreeNodeItemsCount, count);
        }

        private void LinesOfSectionCreateTreeNodes(Model.Section section, TreeNode treeTreeNodeSection)
        {
            Collection<Model.Line> lines = [.. _report.Lines.Where(l => l.SectionId1 == section.SectionId).OrderBy(l => l.LineId)];
            if (treeTreeNodeSection.Nodes.Count <= TreeNodeLinesIndex)
            {
                treeTreeNodeSection.Nodes.Add(AddTreeNode(LinesTreeNodeGetText(lines.Count), LinesKey, string.Empty));
            }
            foreach (Model.Line line in lines)
            {
                LineCreateTreeNode(line, treeTreeNodeSection.Nodes[TreeNodeLinesIndex]);
            }
        }

        private void LinesPanelShow(short sectionId)
        {
            if (_panelLines is null)
            {
                _panelLines = new(_report, sectionId, _applicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(_panelLines);
                _panelLines.LineAdded += LineUpdated;
            }
            _panelLines.ShowProperties(_report.Lines.Count(l => l.SectionId1 == sectionId));
            _panelLines.Show();
        }

        #endregion Lines

        #region Line

        private static string LineTreeNodeGetText(Model.Line line)
        {
            return line.DisplayName;
        }

        private static TreeNode LineCreateTreeNode(Model.Line line, TreeNode treeTreeNodeParent)
        {
            TreeNode treeTreeNodeLine = AddTreeNode(LineTreeNodeGetText(line), LineKey, line.LineId.ToString());
            treeTreeNodeParent.Nodes.Add(treeTreeNodeLine);
            return treeTreeNodeLine;
        }

        private void LinePanelShow(short lineId)
        {
            Model.Line? line = _report.Lines.FirstOrDefault(l => l.LineId == lineId);
            if (line is null)
            {
                return;
            }
            if (_panelLine is null)
            {
                _panelLine = new(_report, _applicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(_panelLine);
                _panelLine.LineUpdated += LineUpdated;
                _panelLine.LineDeleted += LineDeleted;
            }
            _panelLine.ShowProperties(lineId);
            _panelLine.Show();
        }

        private void LineUpdated(object sender, short lineId, short section1Id)
        {
            Model.Line? line = _report.Lines.FirstOrDefault(f => f.LineId == lineId);
            if (line is null)
            {
                return;
            }
            TreeNode? treeTreeNodeSection = GetTreeNodeByTag(treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeSectionsIndex], SectionKey, section1Id.ToString());
            if (treeTreeNodeSection is null)
            {
                return;
            }
            TreeNode treeTreeNodeLines = treeTreeNodeSection.Nodes[TreeNodeLinesIndex];
            TreeNode? treeTreeNodeLine = GetTreeNodeByTag(treeTreeNodeLines, LineKey, line.LineId.ToString());
            if (treeTreeNodeLine is null)
            {
                treeTreeNodeLine = LineCreateTreeNode(line, treeTreeNodeLines);
                treeTreeNodeLines.Text = LinesTreeNodeGetText(_report.Lines.Count(l => l.SectionId1 == section1Id));
            }
            else
            {
                treeTreeNodeLine.Text = LineTreeNodeGetText(line);
            }
            treeViewReport.SelectedNode = treeTreeNodeLine;
            if (!treeTreeNodeLine.IsVisible)
            {
                treeTreeNodeLine.EnsureVisible();
            }
        }

        private void LineDeleted(object sender, short lineId, short section1Id)
        {
            TreeNode? treeTreeNodeSection = GetTreeNodeByTag(treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeSectionsIndex], SectionKey, section1Id.ToString());
            if (treeTreeNodeSection is null)
            {
                return;
            }
            TreeNode treeTreeNodeLines = treeTreeNodeSection.Nodes[TreeNodeLinesIndex];
            TreeNode? treeTreeNodeLine = GetTreeNodeByTag(treeTreeNodeLines, LineKey, lineId.ToString());
            if (treeTreeNodeLine is not null)
            {
                treeTreeNodeLines.Nodes.Remove(treeTreeNodeLine);
                treeTreeNodeLines.Text = LinesTreeNodeGetText(_report.Lines.Count(l => l.SectionId1 == section1Id));
            }
        }

        #endregion Line

        #region Rectangles

        private static string RectanglesTreeNodeGetText(int count)
        {
            return Properties.Resources.StringRectangles + string.Format(Properties.Resources.StringTreeNodeItemsCount, count);
        }

        private void RectanglesOfSectionCreateTreeNodes(Model.Section section, TreeNode treeTreeNodeSection)
        {
            Collection<Model.Rectangle> rectangles = [.. _report.Rectangles.Where(r => r.SectionId1 == section.SectionId).OrderBy(r => r.RectangleId)];
            if (treeTreeNodeSection.Nodes.Count <= TreeNodeRectanglesIndex)
            {
                treeTreeNodeSection.Nodes.Add(AddTreeNode(RectanglesTreeNodeGetText(rectangles.Count), RectanglesKey, string.Empty));
            }
            foreach (Model.Rectangle rectangle in rectangles)
            {
                RectangleCreateTreeNode(rectangle, treeTreeNodeSection.Nodes[TreeNodeRectanglesIndex]);
            }
        }

        private void RectanglesPanelShow(short sectionId)
        {
            if (_panelRectangles is null)
            {
                _panelRectangles = new(_report, sectionId, _applicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(_panelRectangles);
                _panelRectangles.RectangleAdded += RectangleUpdated;
            }
            _panelRectangles.ShowProperties(_report.Rectangles.Count(r => r.SectionId1 == sectionId));
            _panelRectangles.Show();
        }

        #endregion Rectangles

        #region Rectangle

        private static string RectangleTreeNodeGetText(Model.Rectangle rectangle)
        {
            return rectangle.DisplayName;
        }

        private static TreeNode RectangleCreateTreeNode(Model.Rectangle rectangle, TreeNode treeTreeNodeParent)
        {
            TreeNode treeTreeNodeRectangle = AddTreeNode(RectangleTreeNodeGetText(rectangle), RectangleKey, rectangle.RectangleId.ToString());
            treeTreeNodeParent.Nodes.Add(treeTreeNodeRectangle);
            return treeTreeNodeRectangle;
        }

        private void RectanglePanelShow(short rectangleId)
        {
            Model.Rectangle? rectangle = _report.Rectangles.FirstOrDefault(l => l.RectangleId == rectangleId);
            if (rectangle is null)
            {
                return;
            }
            if (_panelRectangle is null)
            {
                _panelRectangle = new(_report, _applicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(_panelRectangle);
                _panelRectangle.RectangleUpdated += RectangleUpdated;
                _panelRectangle.RectangleDeleted += RectangleDeleted;
            }
            _panelRectangle.ShowProperties(rectangleId);
            _panelRectangle.Show();
        }

        private void RectangleUpdated(object sender, short rectangleId, short section1Id)
        {
            Model.Rectangle? rectangle = _report.Rectangles.FirstOrDefault(r => r.RectangleId == rectangleId);
            if (rectangle is null)
            {
                return;
            }
            TreeNode? treeTreeNodeSection = GetTreeNodeByTag(treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeSectionsIndex], SectionKey, section1Id.ToString());
            if (treeTreeNodeSection is null)
            {
                return;
            }
            TreeNode treeTreeNodeRectangles = treeTreeNodeSection.Nodes[TreeNodeRectanglesIndex];
            TreeNode? treeTreeNodeRectangle = GetTreeNodeByTag(treeTreeNodeRectangles, RectangleKey, rectangle.RectangleId.ToString());
            if (treeTreeNodeRectangle is null)
            {
                treeTreeNodeRectangle = RectangleCreateTreeNode(rectangle, treeTreeNodeRectangles);
                treeTreeNodeRectangles.Text = RectanglesTreeNodeGetText(_report.Rectangles.Count(l => l.SectionId1 == section1Id));
            }
            else
            {
                treeTreeNodeRectangle.Text = RectangleTreeNodeGetText(rectangle);
            }
            treeViewReport.SelectedNode = treeTreeNodeRectangle;
            if (!treeTreeNodeRectangle.IsVisible)
            {
                treeTreeNodeRectangle.EnsureVisible();
            }
        }

        private void RectangleDeleted(object sender, short rectangleId, short section1Id)
        {
            TreeNode? treeTreeNodeSection = GetTreeNodeByTag(treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeSectionsIndex], SectionKey, section1Id.ToString());
            if (treeTreeNodeSection is null)
            {
                return;
            }
            TreeNode treeTreeNodeRectangles = treeTreeNodeSection.Nodes[TreeNodeRectanglesIndex];
            TreeNode? treeTreeNodeRectangle = GetTreeNodeByTag(treeTreeNodeRectangles, RectangleKey, rectangleId.ToString());
            if (treeTreeNodeRectangle is not null)
            {
                treeTreeNodeRectangles.Nodes.Remove(treeTreeNodeRectangle);
                treeTreeNodeRectangles.Text = RectanglesTreeNodeGetText(_report.Rectangles.Count(r => r.SectionId1 == section1Id));
            }
        }

        #endregion Rectangle

        #region Texts

        private static string TextsTreeNodeGetText(int count)
        {
            return Properties.Resources.StringTexts + string.Format(Properties.Resources.StringTreeNodeItemsCount, count);
        }

        private void TextsOfSectionCreateTreeNodes(Model.Section section, TreeNode treeTreeNodeSection)
        {
            Collection<Model.Text> texts = [.. _report.Texts.Where(t => t.SectionId == section.SectionId).OrderBy(t => t.TextId)];
            if (treeTreeNodeSection.Nodes.Count <= TreeNodeTextsIndex)
            {
                treeTreeNodeSection.Nodes.Add(AddTreeNode(TextsTreeNodeGetText(texts.Count), TextsKey, string.Empty));
            }
            foreach (Model.Text text in texts)
            {
                TextCreateTreeNode(text, treeTreeNodeSection.Nodes[TreeNodeTextsIndex]);
            }
        }

        private void TextsPanelShow(short sectionId)
        {
            if (_panelTexts is null)
            {
                _panelTexts = new(_report, sectionId, _applicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(_panelTexts);
                _panelTexts.TextAdded += TextUpdated;
            }
            _panelTexts.ShowProperties(_report.Texts.Count(t => t.SectionId == sectionId));
            _panelTexts.Show();
        }

        #endregion Texts

        #region Text

        private string TextTreeNodeGetText(Model.Text text)
        {
            return text.DisplayName(_report);
        }

        private TreeNode TextCreateTreeNode(Model.Text text, TreeNode treeTreeNodeParent)
        {
            TreeNode treeTreeNodeText = AddTreeNode(TextTreeNodeGetText(text), TextKey, text.TextId.ToString());
            treeTreeNodeParent.Nodes.Add(treeTreeNodeText);
            return treeTreeNodeText;
        }

        private void TextPanelShow(short textId)
        {
            Model.Text? text = _report.Texts.FirstOrDefault(l => l.TextId == textId);
            if (text is null)
            {
                return;
            }
            if (_panelText is null)
            {
                _panelText = new(_report, _applicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(_panelText);
                _panelText.TextUpdated += TextUpdated;
                _panelText.TextDeleted += TextDeleted;
            }
            _panelText.ShowProperties(textId);
            _panelText.Show();
        }

        private void TextUpdated(object sender, short textId, short sectionId)
        {
            Model.Text? text = _report.Texts.FirstOrDefault(f => f.TextId == textId);
            if (text is null)
            {
                return;
            }
            TreeNode? treeTreeNodeSection = GetTreeNodeByTag(treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeSectionsIndex], SectionKey, sectionId.ToString());
            if (treeTreeNodeSection is null)
            {
                return;
            }
            TreeNode treeTreeNodeTexts = treeTreeNodeSection.Nodes[TreeNodeTextsIndex];
            TreeNode? treeTreeNodeText = GetTreeNodeByTag(treeTreeNodeTexts, TextKey, text.TextId.ToString());
            if (treeTreeNodeText is null)
            {
                treeTreeNodeText = TextCreateTreeNode(text, treeTreeNodeTexts);
                treeTreeNodeTexts.Text = TextsTreeNodeGetText(_report.Texts.Count(t => t.SectionId == sectionId));
            }
            else
            {
                treeTreeNodeText.Text = TextTreeNodeGetText(text);
            }
            treeViewReport.SelectedNode = treeTreeNodeText;
            if (!treeTreeNodeText.IsVisible)
            {
                treeTreeNodeText.EnsureVisible();
            }
        }

        private void TextDeleted(object sender, short textId, short sectionId)
        {
            TreeNode? treeTreeNodeSection = GetTreeNodeByTag(treeViewReport.Nodes[TreeNodeReportIndex].Nodes[TreeNodeSectionsIndex], SectionKey, sectionId.ToString());
            if (treeTreeNodeSection is null)
            {
                return;
            }
            TreeNode treeTreeNodeTexts = treeTreeNodeSection.Nodes[TreeNodeTextsIndex];
            TreeNode? treeTreeNodeText = GetTreeNodeByTag(treeTreeNodeTexts, TextKey, textId.ToString());
            if (treeTreeNodeText is not null)
            {
                treeTreeNodeTexts.Nodes.Remove(treeTreeNodeText);
                treeTreeNodeTexts.Text = TextsTreeNodeGetText(_report.Texts.Count(t => t.SectionId == sectionId));
            }
        }

        #endregion Text

    }
}
