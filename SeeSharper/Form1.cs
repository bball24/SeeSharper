using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tutorial.Things;
using System.IO;

// Some objects for me to use as placeholders for the workshop.
// Ignore the definitions here.
namespace Tutorial.Things
{
    public class AutomatedTestLogger : TextWriter { public override Encoding Encoding { get { throw new NotImplementedException(); } } };
    public class ConsoleWriter : TextWriter { public override Encoding Encoding { get { throw new NotImplementedException(); } } };
}

namespace SeeSharper
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        public TextWriter OutputWriter { private get; set; }

        public Point(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
            OutputWriter = null;
        }

        public Point SetOutputStream(TextWriter fileWriter)
        {
            OutputWriter = fileWriter;
            return this;
        }
    }



    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
