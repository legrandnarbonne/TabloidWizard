using System;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;

namespace TabloidWizard.Classes
{
    public class XmlColor
    {
        private Color? color_;

        public XmlColor()
        {
        }

        public XmlColor(Color? c)
        {
            color_ = c;
        }

        public Color? ToColor()
        {
            return color_;
        }

        public void FromColor(Color? c)
        {
            color_ = c;
        }

        public static implicit operator Color?(XmlColor x)
        {
            return x.ToColor();
        }

        public static implicit operator XmlColor(Color? c)
        {
            return new XmlColor(c);
        }

        [XmlAttribute]
        public string Web
        {
            get { return color_ != null ? ColorTranslator.ToHtml((Color)color_) : ""; }
            set
            {
                try
                {
                    if (value == "") return;
                    if (Alpha == 0xFF) // preserve named color value if possible
                        color_ = ColorTranslator.FromHtml(value);
                    else
                        color_ = Color.FromArgb(Alpha, ColorTranslator.FromHtml(value));
                }
                catch (Exception)
                {
                    color_ = null;
                }
            }
        }

        [XmlAttribute]
        public byte Alpha
        {
            get { return color_ == null ? (byte)0xFF : ((Color)color_).A; }
            set
            {
                Color c = ((Color)color_);
                if (value != c.A) // avoid hammering named color if no alpha change
                    c = Color.FromArgb(value, c);
            }
        }

        public bool ShouldSerializeAlpha()
        {
            if (color_ != null) return Alpha < 0xFF;
            return false;
        }
    }
}