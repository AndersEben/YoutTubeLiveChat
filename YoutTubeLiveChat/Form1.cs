using System;
using System.Windows.Forms;
using CefSharp.WinForms;

using static System.Windows.Forms.TabControl;

namespace YoutTubeLiveChat
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CefSettings _settings = new CefSettings();
            CefSharp.Cef.Initialize(_settings);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != null || textBox1.Text != "")
            {
                MyRequestHandler _handler = new MyRequestHandler();
                _handler.videoID = textBox1.Text;

                ChromiumWebBrowser _browser = new ChromiumWebBrowser("https://www.youtube.com/live_chat?v=" + textBox1.Text)
                {
                    RequestHandler = _handler
                };

                TabPage _newPage = new TabPage();
                _newPage.Text = textBox1.Text;

                Panel _newPanel = new Panel();
                _newPanel.Dock = DockStyle.Fill;
                _newPanel.Controls.Add(_browser);

                _newPage.Controls.Add(_newPanel);

                comboBox1.Items.Add(textBox1.Text);
                tabControl1.TabPages.Add(_newPage);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                if (comboBox1.Items[comboBox1.SelectedIndex].ToString() != "" || comboBox1.Items[comboBox1.SelectedIndex].ToString() != null)
                {
                    TabPageCollection _coll = tabControl1.TabPages;
                    foreach (TabPage page in _coll)
                    {
                        if (page.Text == comboBox1.Items[comboBox1.SelectedIndex].ToString())
                        {
                            tabControl1.TabPages.Remove(page);
                            comboBox1.Items.Remove(comboBox1.Items[comboBox1.SelectedIndex]);
                            break;
                        }
                    }
                }
            }
        }
    }
}
