using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformInstall.Pages
{
    public class RichTextBoxWriter : TextWriter
    {
        private RichTextBox _richTextBox;
        private TextBox _outputTextBox;

        public RichTextBoxWriter(RichTextBox richTextBox, TextBox outputTextBox)
        {
            _richTextBox = richTextBox;
            _outputTextBox = outputTextBox;
        }

        public override void Write(char value)
        {
            _richTextBox.AppendText(value.ToString());
            _outputTextBox.AppendText(value.ToString());
        }

        public override void Write(string value)
        {
            _richTextBox.AppendText(value);
            _outputTextBox.AppendText(value);
        }

        public override System.Text.Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}
