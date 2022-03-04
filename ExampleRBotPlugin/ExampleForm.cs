using RBot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleRBotPlugin
{
    public partial class ExampleForm : Form
    {
        public static ExampleForm Instance { get; } = new ExampleForm();

        public static ScriptInterface Bot => ScriptInterface.Instance;
        public ExampleForm()
        {
            InitializeComponent();
        }

        private void ExampleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* Keeps the example form from disposing itself so it can be reopened
             * This should be in every plugin
             */
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bot.Options.CustomName = textBox1.Text;
        }
    }
}
