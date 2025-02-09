﻿using CardonerSistemas.Reports.Net.Model;
using System.Collections.ObjectModel;

namespace CardonerSistemas.Reports.Net.WinformsEditor
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
        private const int TreeNodeRootIndex = 0;

        private const int TreeNodeDatasourceIndex = 0;
        private const int TreeNodeDatasourceParametersIndex = 0;
        private const int TreeNodeDatasourceFieldsIndex = 0;

        private const int TreeNodeFontsIndex = 1;
        private const int TreeNodeBrushesIndex = 2;
        private const int TreeNodeSectionsIndex = 3;


        private readonly string mApplicationTitle;
        private readonly Model.Report mReport;
        private string mFilePath;

        private ReportEditorPanels.PanelReport? mPanelReport;
        private ReportEditorPanels.PanelDatasource? mPanelDatasource;
        private ReportEditorPanels.PanelDatasourceParameters? mPanelDatasourceParameters;
        private ReportEditorPanels.PanelDatasourceParameter? mPanelDatasourceParameter;
        private ReportEditorPanels.PanelDatasourceFields? mPanelDatasourceFields;

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

        private Tuple<string, string> GetNodeInfo(TreeNode treeNode)
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

        private void TreeViewReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is null || e.Node.Tag is null)
            {
                return;
            }

            PanelControlsHide();

            Tuple<string, string> nodeInfo = GetNodeInfo(e.Node);
            switch (nodeInfo.Item1)
            {
                case ReportKey:
                    PanelReportShow();
                    break;
                case DatasourceKey:
                    PanelDatasourceShow();
                    break;
                case DatasourceParametersKey:
                    PanelDatasourceParametersShow();
                    break;
                case DatasourceParameterKey:
                    PanelDatasourceParameterShow(nodeInfo.Item2);
                    break;
                case DatasourceFieldsKey:
                    PanelDatasourceFieldsShow();
                    break;
            }
        }

        #endregion Events

        #region Panel controls

        private void PanelControlsHide()
        {
            mPanelReport?.Hide();
            mPanelDatasource?.Hide();
            mPanelDatasourceParameters?.Hide();
            mPanelDatasourceParameter?.Hide();
            mPanelDatasourceFields?.Hide();
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

            CreateDatasourceParametersNodes();
            CreateDatasourceFieldsNodes();
        }

        private void PanelDatasourceShow()
        {
            if (mPanelDatasource is null)
            {
                mPanelDatasource = new(mApplicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(mPanelDatasource);
                mPanelDatasource.DatasourceAdded += DatasourceAdded;
                mPanelDatasource.DatasourceDeleted += DatasourceDeleted;
            }
            mPanelDatasource.SetObject(mReport);
            mPanelDatasource.Show();
        }

        private void DatasourceAdded(object sender, EventArgs e)
        {
            CreateDatasourceParametersNodes();
            CreateDatasourceFieldsNodes();
        }

        private void DatasourceDeleted(object sender, EventArgs e)
        {
            treeViewReport.SuspendLayout();
            treeViewReport.Nodes[0].Nodes[0].Nodes.Clear();
            treeViewReport.ResumeLayout();
        }

        #endregion Datasource

        #region Datasource parameters

        private void CreateDatasourceParametersNodes()
        {

            if (mReport.Datasource is null)
            {
                return;
            }
            TreeNode treeNodeDatasourceParameters = new()
            {
                Text = Properties.Resources.StringDatasourceParameters + string.Format(Properties.Resources.StringNodeItemsCount, mReport.Datasource.Parameters.Count),
                Tag = DatasourceParametersKey + "@",
                ImageKey = DatasourceParametersKey,
                SelectedImageKey = DatasourceParametersKey
            };
            treeViewReport.Nodes[TreeNodeRootIndex].Nodes[TreeNodeDatasourceIndex].Nodes.Add(treeNodeDatasourceParameters);
            foreach (string parameterName in mReport.Datasource.Parameters.Select(p => p.Name))
            {
                treeNodeDatasourceParameters.Nodes.Add(new TreeNode()
                {
                    Text = parameterName,
                    Tag = DatasourceParameterKey + "@" + parameterName,
                    ImageKey = DatasourceParameterKey,
                    SelectedImageKey = DatasourceParameterKey
                });
            }
        }

        private void PanelDatasourceParametersShow()
        {
            if (mPanelDatasourceParameters is null)
            {
                mPanelDatasourceParameters = new(mReport.Datasource)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(mPanelDatasourceParameters);
            }
            else
            {
                mPanelDatasourceParameters.SetDatasource(mReport.Datasource);
            }
            mPanelDatasourceParameters.Show();
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

        private void CreateDatasourceFieldsNodes()
        {
            if (mReport.Datasource is null)
            {
                return;
            }
            TreeNode treeNodeDatasourceFields = new()
            {
                Text = Properties.Resources.StringDatasourceFields + string.Format(Properties.Resources.StringNodeItemsCount, mReport.Datasource.Fields.Count),
                Tag = DatasourceFieldsKey + "@",
                ImageKey = DatasourceFieldsKey,
                SelectedImageKey = DatasourceFieldsKey
            };
            treeViewReport.Nodes[TreeNodeRootIndex].Nodes[TreeNodeDatasourceIndex].Nodes.Add(treeNodeDatasourceFields);
            foreach (string fieldName in mReport.Datasource.Fields.Select(f => f.Name))
            {
                treeNodeDatasourceFields.Nodes.Add(new TreeNode()
                {
                    Text = fieldName,
                    Tag = DatasourceFieldKey + "@" + fieldName,
                    ImageKey = DatasourceFieldKey,
                    SelectedImageKey = DatasourceFieldKey
                });
            }
        }

        private void PanelDatasourceFieldsShow()
        {
            if (mPanelDatasourceFields is null)
            {
                mPanelDatasourceFields = new(mReport.Datasource, mApplicationTitle)
                {
                    Dock = DockStyle.Fill
                };
                splitContainerMain.Panel2.Controls.Add(mPanelDatasourceFields);
            }
            else
            {
                mPanelDatasourceFields.SetDatasource(mReport.Datasource);
            }
            mPanelDatasourceFields.Show();
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