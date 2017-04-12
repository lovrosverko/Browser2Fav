using CefSharp;
using CefSharp.WinForms;
using System;
using System.Windows.Forms;

namespace ChromiumCsharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            txtUrl.Text = " chrome://version/  ";
            ChromiumWebBrowser chrome = new ChromiumWebBrowser(txtUrl.Text);
            chrome.Parent = tabControl1.SelectedTab;
            chrome.Dock = DockStyle.Fill;
            chrome.AddressChanged += Chrome_AddressChanged;
            chrome.TitleChanged += Chrome_TitleChanged;
            
        }

        private void Chrome_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
               {
                   txtUrl.Text = e.Address;

               }));
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser chrome = tabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (chrome != null)
                chrome.Stop();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser chrome = tabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (chrome != null)
                chrome.Refresh();

        }

        private void btnNaprijed_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser chrome = tabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (chrome != null)

            {
                if (chrome.CanGoForward)
                    chrome.Forward();
            }


        }

        private void btnNazad_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser chrome = tabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (chrome != null)
            {
                if (chrome.CanGoBack)
                    chrome.Back();
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void oProgramuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oProgramu cRight = new oProgramu();
            cRight.Show();
        }

        private void btnNewTab_Click(object sender, EventArgs e)
        {
            
        }

        private void Chrome_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                tabControl1.SelectedTab.Text = e.Title;

            }));
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "New tab";
            tabControl1.Controls.Add(tab);
            tabControl1.SelectTab(tabControl1.TabCount - 1);
            ChromiumWebBrowser chrome = new ChromiumWebBrowser("chrome://newtab");
            chrome.Parent = tab;
            chrome.Dock = DockStyle.Fill;
            txtUrl.Text = "chrome://newtab";
            chrome.AddressChanged += Chrome_AddressChanged;
            chrome.TitleChanged += Chrome_TitleChanged;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void txtUrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Return))
            {
                ChromiumWebBrowser chrome = tabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;

                if (chrome != null)
                {
                    chrome.Load(txtUrl.Text);
                }

            }
        }
        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            ChromiumWebBrowser chrome = tabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            chrome.Load(clickedItem.ToolTipText);
        }
        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sigurno želite zatvoriti program?", "Izlaz", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser chrome = tabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Webpages|*.html|All Files|*.*";
            openFileDialog.Title = "Open Webpage";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string dokument = System.IO.File.ReadAllText(openFileDialog.FileName);
                string urlDok = openFileDialog.FileName.ToString();
                chrome.LoadHtml(dokument, urlDok);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Webpages|*.html|All Files|*.*";
            saveFile.Title = "Save Webpage";
            
            if (saveFile.ShowDialog(this) == DialogResult.OK)
            {
                
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser chrome = tabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
            chrome.Print();
            
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser chrome = tabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
            chrome.PrintToPdfAsync("C:\\Temp\\printPreview.pdf");

        }

        private void oProgramuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            about aboutProg = new about();
            aboutProg.Show();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sigurno želite zatvoriti program?", "Izlaz", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void oProgramuToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            about aboutProg = new about();
            aboutProg.Show();
        }

        private void bookmarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser chrome = tabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
            favorites favForm = new favorites();
            favForm.urlTxt.Text = chrome.Address.ToString();
            if (favForm.ShowDialog() == DialogResult.OK)
            {
                this.txtUrl.Text = favForm.url;
                chrome.Load(favForm.url);
            }
            

        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
