using MetroFramework.Forms;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Tabloid.Classes.Config;
using TabloidWizard.Classes;

namespace TabloidWizard
{
    public partial class XMLEditor : MetroForm
    {
        /// <summary>
        /// https://github.com/jacobslusser/ScintillaNET#lexer
        /// </summary>


        private static Dictionary<string, System.Type> nameToType = new Dictionary<string, Type>();
        private Type currentNodeType;

        public int LastErrorLine;
        public int LastErrorCaracter;

        public XMLEditor(string xml)
        {
            InitializeComponent();

            scintilla1.Text = xml;

            readTabloidConfigStructure();
            //var theme = new Theme(true);// XMLToolsStyle.load(@"D:\dev\SharpDevelop Projects\TabloidWizard\TabloidWizard\bin\Debug\Themes\black.style");
            //theme.save(@"c:\Black.style");
        }

        private void XMLEditor_Load(object sender, EventArgs e)
        {
            scintilla1.Lexer = ScintillaNET.Lexer.Xml;

            setStyle();
            setFolding();

            //AutoCompletion
            scintilla1.AutoCIgnoreCase = true;
        }

        private void setStyle()
        {
            scintilla1.StyleResetDefault();

            var theme = XMLToolsStyle.load(@"D:\dev\SharpDevelop Projects\TabloidWizard\TabloidWizard\bin\Debug\Themes\Black.style");//new Theme(true);// XMLToolsStyle.load(@"D:\dev\SharpDevelop Projects\TabloidWizard\TabloidWizard\bin\Debug\Themes\black.style");
            theme.apply(this, scintilla1);

            scintilla1.Margins[0].Width = 18;
        }

        private void setFolding()
        {
            scintilla1.SetProperty("fold", "1");
            scintilla1.SetProperty("fold.compact", "1");
            scintilla1.SetProperty("fold.html", "1");
            scintilla1.Margins[2].Type = MarginType.Symbol;
            scintilla1.Margins[2].Mask = Marker.MaskFolders;
            scintilla1.Margins[2].Sensitive = true;
            scintilla1.Margins[2].Width = 20;
            for (int i = 25; i <= 31; i++)
            {
                scintilla1.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                scintilla1.Markers[i].SetBackColor(Color.Gray);
            }
            scintilla1.Markers[Marker.Folder].Symbol = MarkerSymbol.CirclePlus;
            scintilla1.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.CircleMinus;
            scintilla1.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.CirclePlusConnected;
            scintilla1.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            scintilla1.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.CircleMinusConnected;
            scintilla1.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            scintilla1.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;
            scintilla1.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
        }

        private void scintilla_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // SECTION 1. Create a DOM Document and load the XML data into it.
                XElement root = XElement.Parse(scintilla1.Text, LoadOptions.SetLineInfo);
                //dom.Load(scintilla1.Text);

                // SECTION 2. Initialize the TreeView control.
                treeView1.Nodes.Clear();
                var rootNode = new TreeNode(root.Name.LocalName);
                treeView1.Nodes.Add(rootNode);
                foreach (XElement node in root.Elements())
                {
                    var employeeNode = new TreeNode(node.Name.ToString());
                    rootNode.Nodes.Add(employeeNode);
                    if (node.HasElements)
                    {
                        foreach (XElement employeechild in node.Descendants())
                        {
                            var childNode = new TreeNode(employeechild.Value);
                            childNode.Tag = employeechild;
                            employeeNode.Nodes.Add(childNode);
                        }
                    }
                }
                treeView1.ExpandAll();

                toolStripStatusLabel1.DoubleClickEnabled = false;
                toolStripStatusLabel1.ForeColor = Color.Green;
                toolStripStatusLabel1.Text = "Ok";
            }
            catch (XmlException xmlEx)
            {
                toolStripStatusLabel1.DoubleClickEnabled = true;
                LastErrorCaracter = xmlEx.LinePosition;
                LastErrorLine = xmlEx.LineNumber;
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = xmlEx.Message;
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.DoubleClickEnabled = false;
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = ex.Message;
            }
        }

        //private void AddNode(XElement inXmlNode, TreeNode inTreeNode)
        //{
        //    XmlNode xNode;
        //    TreeNode tNode;
        //    XmlNodeList nodeList;
        //    int i;

        //    // Loop through the XML nodes until the leaf is reached.
        //    // Add the nodes to the TreeView during the looping process.
        //    if (inXmlNode.HasElements)
        //    {
        //        nodeList = inXmlNode.;
        //        for (i = 0; i <= nodeList.Count - 1; i++)
        //        {
        //            xNode = inXmlNode.ChildNodes[i];
        //            inTreeNode.Nodes.Add(new TreeNode(xNode.Name));
        //            tNode = inTreeNode.Nodes[i];
        //            AddNode(xNode, tNode);
        //        }
        //    }
        //    else
        //    {
        //        // Here you need to pull the data from the XmlNode based on the
        //        // type of node, whether attribute values are required, and so forth.
        //        inTreeNode.Tag = inXmlNode;
        //        inTreeNode.ImageIndex = 2;
        //        inTreeNode.Text = (inXmlNode.OuterXml).Trim();
        //    }
        //}

        private void scintilla_CharAdded(object sender, CharAddedEventArgs e)
        {
            // Find the word start

            var i = scintilla1.Lines[scintilla1.LineFromPosition(scintilla1.CurrentPosition)].FoldingLevel;

            var currentPos = scintilla1.CurrentPosition;
            var wordStartPos = scintilla1.WordStartPosition(currentPos, true);
            var lenEntered = currentPos - wordStartPos;
            var word = scintilla1.GetTextRange(wordStartPos, lenEntered);
            var leftChar = scintilla1.GetTextRange(wordStartPos - 1, 1);

            // Display the autocompletion list

            if (lenEntered > 0)
            {
                switch (leftChar)
                {
                    case "<": //new tag
                        break;

                    default:
                        var tagType = findNodeType(scintilla1.CurrentPosition);
                        scintilla1.AutoCShow(lenEntered, getPropertiesNames(tagType, word, true));
                        break;
                }
            }
        }

        private void readTabloidConfigStructure()
        {
            readTabloidConfigStructure(typeof(TabloidConfig));
        }

        private void readTabloidConfigStructure(Type o)
        {
            foreach (PropertyInfo info in o.GetProperties())
            {
                var atts = info.GetCustomAttributes(false);
                var att = Array.Find(atts, e => e is System.Configuration.ConfigurationPropertyAttribute);

                if (att != null)
                {
                    var name = ((System.Configuration.ConfigurationPropertyAttribute)att).Name;
                    if (info.PropertyType.BaseType == typeof(ConfigurationElementCollection))
                    {
                        if (!nameToType.ContainsKey(name))
                        {
                            nameToType.Add(name, info.PropertyType.GetMethod("Add").GetParameters()[0].ParameterType);
                            readTabloidConfigStructure(info.PropertyType.GetMethod("Add").GetParameters()[0].ParameterType);
                        }
                    }
                }
            }
        }

        private string getPropertiesNames(System.Type t, string start, bool removeCollection = false)
        {
            string sep = "";
            string result = "";

            foreach (PropertyInfo info in t.GetProperties())
            {
                var atts = info.GetCustomAttributes(false);

                if (info.PropertyType.BaseType == typeof(ConfigurationElementCollection) && removeCollection) continue;

                var att = Array.Find(atts, e => e is System.Configuration.ConfigurationPropertyAttribute);

                if (att != null)
                {
                    var name = ((System.Configuration.ConfigurationPropertyAttribute)att).Name;
                    if (name.StartsWith(start, StringComparison.OrdinalIgnoreCase))
                    {
                        result += sep + name;
                        sep = " ";
                    }
                }
            }

            return result;
        }

        private Type getPropertieType(System.Type t, string propertieName)
        {
            foreach (PropertyInfo info in t.GetProperties())
            {
                var atts = info.GetCustomAttributes(false);
                var att = Array.Find(atts, e => e is System.Configuration.ConfigurationPropertyAttribute);

                if (att != null)
                {
                    var name = ((System.Configuration.ConfigurationPropertyAttribute)att).Name;
                    if (name == propertieName) return info.PropertyType;
                }
            }
            return null;
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            HighlightWord(toolStripTextBox1.Text);
        }

        private void HighlightWord(string text)
        {
            // Indicators 0-7 could be in use by a lexer
            // so we'll use indicator 8 to highlight words.
            const int NUM = 8;

            // Remove all uses of our indicator
            scintilla1.IndicatorCurrent = NUM;
            scintilla1.IndicatorClearRange(0, scintilla1.TextLength);

            // Update indicator appearance
            scintilla1.Indicators[NUM].Style = IndicatorStyle.StraightBox;
            scintilla1.Indicators[NUM].ForeColor = Color.Yellow;
            scintilla1.Indicators[NUM].OutlineAlpha = 50;
            scintilla1.Indicators[NUM].Alpha = 30;

            // Search the document
            scintilla1.TargetStart = 0;
            scintilla1.TargetEnd = scintilla1.TextLength;
            scintilla1.SearchFlags = SearchFlags.None;
            while (scintilla1.SearchInTarget(text) != -1)
            {
                // Mark the search results with the current indicator
                scintilla1.IndicatorFillRange(scintilla1.TargetStart, scintilla1.TargetEnd - scintilla1.TargetStart);

                // Search the remainder of the document
                scintilla1.TargetStart = scintilla1.TargetEnd;
                scintilla1.TargetEnd = scintilla1.TextLength;
            }
        }

        private System.Type findNodeType(int pos)
        {
            TagPicker(scintilla1.GetTextRange(0, pos));
            var nr = findNodeTag(pos);

            while (nr.tag.ToLower() == "add")
            {
                nr = findNodeTag(nr.position - 1);
                nr.child = true;//collection élément
            }

            currentNodeType = nameToType[nr.tag];

            return currentNodeType;
        }

        private NodeTypeResult findNodeTag(int pos)
        {
            var result = new NodeTypeResult();
            var length = pos;
            string text = scintilla1.GetTextRange(pos - length, length);
            //string temp = "/";
            int start = 1;

            //while (temp == "/" && start > 0)
            //{
            start = text.LastIndexOf('<') + 1;
            //    temp = text.Substring(start, 1);
            //}

            result.position = start;

            if (start > 0)
            {
                var end = -1;
                var end1 = text.IndexOf(' ', start);
                var end2 = text.IndexOf('>', start);

                if (end1 == -1) end = end2;
                else if (end2 == -1) end = end1;
                else end = Math.Min(end1, end2);

                if (end == -1) return null;
                result.tag = text.Substring(start, end - start);
                return result;
            }

            return null;
        }

        private void TagPicker(string XMLString)
        {
            string findTagString = @"<(?!\/)(.[^<>\/]+)>";//"<(.[^<>\/]+)>";//"<([^<>]+)>";
            var findTag = new Regex(findTagString);
            //List<string>
            MatchCollection textList = findTag.Matches(XMLString);//.Split(XMLString).ToList();
        }

        private class NodeTypeResult
        {
            public int position;
            public string tag;
            public bool child;//is it a collection element or main tag
        }

        private void scintilla1_AutoCSelection(object sender, AutoCSelectionEventArgs e)
        {
            Type t = getPropertieType(currentNodeType, e.Text);

            var text = "=\"\" ";
            var currentPos = scintilla1.CurrentPosition;

            scintilla1.InsertText(currentPos, text);

            scintilla1.GotoPosition(currentPos + 2);
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var node = (XElement)e.Node.Tag;
            scintilla1.GotoPosition(
            scintilla1.Lines[((IXmlLineInfo)node).LineNumber].Position +
                ((IXmlLineInfo)node).LinePosition);

            scintilla1.Focus();
        }
    }
}