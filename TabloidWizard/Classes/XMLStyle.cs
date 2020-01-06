using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TabloidWizard.Classes
{
    public enum PredefinedXMLStyle { Default };

    public static class XMLToolsStyle
    {
        public static void setXMLStyle(Scintilla ctrl, PredefinedXMLStyle s)
        {
            //ctrl.Styles
        }

        public static Theme load(string fileName)
        {
            var r = new StreamReader(fileName);
            var obj = XMLToolsStyle.Deserialize<Theme>(r.ReadToEnd());
            r.Close();
            return obj;
        }

        public static string Serialize<T>(T value)
        {
            if (value == null) return null;

            var serializer = new XmlSerializer(typeof(T), new Type[] { typeof(XMLStyle) });

            var settings = new XmlWriterSettings();
            settings.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
            settings.Indent = false;
            settings.OmitXmlDeclaration = false;

            using (StringWriter textWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.Serialize(xmlWriter, value);
                }
                return textWriter.ToString();
            }
        }

        public static T Deserialize<T>(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return default(T);
            }

            var serializer = new XmlSerializer(typeof(T));

            var settings = new XmlReaderSettings();
            // No settings need modifying here

            using (StringReader textReader = new StringReader(xml))
            {
                using (XmlReader xmlReader = XmlReader.Create(textReader, settings))
                {
                    return (T)serializer.Deserialize(xmlReader);
                }
            }
        }
    }

    public class Theme
    {
        [XmlElement("Style")]
        public List<XMLStyle> Styles { get; set; }

        [XmlElement(Type = typeof(XmlColor))]
        public Color? Background { get; set; }

        [XmlElement(Type = typeof(XmlColor))]
        public Color? ControlBackground { get; set; }

        public Theme()
        { }

        public Theme(bool setDefault)
        {
            if (setDefault)
            {
                Background = Color.Black;//SystemColors.Control;
                ControlBackground = Color.FromArgb(64, 64, 64);//Color.White;

                //    Styles = new List<XMLStyle>() {
                //    new XMLStyle(Style.Default) { Font = "Tahoma", Size = 10},//must be added at first
                //    new XMLStyle(Style.Xml.Default) {ForeColor=Color.FromArgb(55, 0, 0) },
                //    new XMLStyle(Style.Xml.Comment) {ForeColor=Color.FromArgb(0, 128, 0) },
                //    new XMLStyle(Style.Xml.Tag) {ForeColor=Color.FromArgb(0,50, 0) },
                //    new XMLStyle(Style.Xml.TagEnd) {ForeColor=Color.FromArgb(0, 0, 255) },
                //    new XMLStyle(Style.Xml.Attribute) {ForeColor=Color.Blue },
                //    new XMLStyle(Style.Xml.DoubleString) {ForeColor=Color.Brown }
                //};
                Styles = new List<XMLStyle> {
                new XMLStyle(Style.Default) { Font = "Tahoma", Size = 10,ForeColor=Color.White,BackColor=Color.Black},//must be added at first
                new XMLStyle(Style.Xml.Default) {ForeColor=Color.FromArgb(255, 255, 255),BackColor=Color.Black },
                new XMLStyle(Style.Xml.Comment) {ForeColor=Color.FromArgb(96, 139, 78) },
                new XMLStyle(Style.Xml.Tag) {ForeColor=Color.FromArgb(86,156, 158) },
                new XMLStyle(Style.Xml.TagEnd) {ForeColor=Color.FromArgb(86,156, 158) },
                new XMLStyle(Style.Xml.Attribute) {ForeColor=Color.FromArgb(69,201, 153) },
                new XMLStyle(Style.Xml.DoubleString) {ForeColor=Color.FromArgb(214,115,65) },
                new XMLStyle(Style.LineNumber) {BackColor=Color.Black},
                new XMLStyle(Style.IndentGuide) {BackColor=Color.Black}
                };
            }
        }

        /// <summary>

        /// Save styles collection to file
        /// </summary>
        /// <param name="fileName">Name of file</param>
        public void save(string fileName)
        {
            var w = new StreamWriter(fileName);
            w.Write(XMLToolsStyle.Serialize(this));
            w.Close();
        }

        public void apply(XMLEditor frm, Scintilla ctrl)
        {
            frm.toolStrip1.BackColor = frm.treeView1.BackColor = (Color)ControlBackground;

            frm.BackColor = (Color)Background;

            ctrl.CaretLineVisible = true;
            ctrl.CaretLineBackColorAlpha = 30;
            ctrl.CaretLineBackColor = Color.White;

            foreach (XMLStyle s in Styles)
            {
                s.apply(ctrl);
                if (s.type == Style.Default)
                    ctrl.StyleClearAll();//apply default style to all style
            }
        }
    }

    public class XMLStyle
    {
        public XMLStyle()
        {
        }

        public XMLStyle(int XMLType)
        {
            type = XMLType;
        }

        private void setDefault()
        {
            this.Size = 11;
        }

        public void apply(Scintilla ctrl)
        {
            var scintillaStyle = ctrl.Styles[type];

            foreach (PropertyInfo prop in typeof(XMLStyle).GetProperties())
            {
                if (prop.Name != "type" && prop.GetValue(this, null) != null)
                    typeof(Style).GetProperty(prop.Name).SetValue(scintillaStyle, prop.GetValue(this, null), null);
            }
        }

        public int type { get; set; }

        // Résumé :
        //     Gets or sets the background color of the style.
        //
        // Retourne :
        //     A Color object representing the style background color. The default is White.
        //
        // Notes :
        //     Alpha color values are ignored.
        [XmlElement(Type = typeof(XmlColor))]
        public Color? BackColor { get; set; }

        //
        // Résumé :
        //     Gets or sets whether the style font is bold.
        //
        // Retourne :
        //     true if bold; otherwise, false. The default is false.
        //
        // Notes :
        //     Setting this property affects the ScintillaNET.Style.Weight property.
        public bool? Bold { get; set; }

        //
        // Résumé :
        //     Gets or sets the casing used to display the styled text.
        //
        // Retourne :
        //     One of the ScintillaNET.StyleCase enum values. The default is ScintillaNET.StyleCase.Mixed.
        //
        // Notes :
        //     This does not affect how text is stored, only displayed.
        public StyleCase? Case { get; set; }

        //
        // Résumé :
        //     Gets or sets whether the remainder of the line is filled with the ScintillaNET.Style.BackColor
        //     when this style is used on the last character of a line.
        //
        // Retourne :
        //     true to fill the line; otherwise, false. The default is false.
        public bool? FillLine { get; set; }

        //
        // Résumé :
        //     Gets or sets the style font name.
        //
        // Retourne :
        //     The style font name. The default is Verdana.
        //
        // Notes :
        //     Scintilla caches fonts by name so font names and casing should be consistent.
        public string Font { get; set; }

        //
        // Résumé :
        //     Gets or sets the foreground color of the style.
        //
        // Retourne :
        //     A Color object representing the style foreground color. The default is Black.
        //
        // Notes :
        //     Alpha color values are ignored.
        [XmlElement(Type = typeof(XmlColor))]
        public Color? ForeColor { get; set; }

        //
        // Résumé :
        //     Gets or sets whether hovering the mouse over the style text exhibits hyperlink
        //     behavior.
        //
        // Retourne :
        //     true to use hyperlink behavior; otherwise, false. The default is false.
        public bool? Hotspot { get; set; }

        //
        // Résumé :
        //     Gets or sets whether the style font is italic.
        //
        // Retourne :
        //     true if italic; otherwise, false. The default is false.
        public bool? Italic { get; set; }

        //
        // Résumé :
        //     Gets or sets the size of the style font in points.
        //
        // Retourne :
        //     The size of the style font as a whole number of points. The default is 8.
        public int? Size { get; set; }

        //
        // Résumé :
        //     Gets or sets the size of the style font in fractoinal points.
        //
        // Retourne :
        //     The size of the style font in fractional number of points. The default is
        //     8.
        public float? SizeF { get; set; }

        //
        // Résumé :
        //     Gets or sets whether the style is underlined.
        //
        // Retourne :
        //     true if underlined; otherwise, false. The default is false.
        public bool? Underline { get; set; }

        //
        // Résumé :
        //     Gets or sets whether the style text is visible.
        //
        // Retourne :
        //     true to display the style text; otherwise, false. The default is true.
        public bool? Visible { get; set; }

        //
        // Résumé :
        //     Gets or sets the style font weight.
        //
        // Retourne :
        //     The font weight. The default is 400.
        //
        // Notes :
        //     Setting this property affects the ScintillaNET.Style.Bold property.
        public int? Weight { get; set; }
    }
}