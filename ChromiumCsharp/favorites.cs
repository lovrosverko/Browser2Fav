using System;
using System.Windows.Forms;

namespace ChromiumCsharp
{
    public partial class favorites : Form
    {
        public object ListViewItem1;
        public string url;

        public favorites()
        {
            InitializeComponent();
        }

        private void favorites_Load(object sender, EventArgs e)
        {
            System.Xml.XmlDocument loadDoc = new System.Xml.XmlDocument();
            loadDoc.Load(Application.StartupPath + "\\Favorites.xml");
            foreach (System.Xml.XmlNode favNode in loadDoc.SelectNodes("/Favorites/Item"))
            {
                listView1.Items.Add(favNode.Attributes["url"].InnerText);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem(urlTxt.Text);
            listView1.Items.Add(urlTxt.Text);
            System.Xml.XmlTextWriter writer = new
           System.Xml.XmlTextWriter(Application.StartupPath + "\\Favorites.xml", null);
            writer.WriteStartElement("Favorites");
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                writer.WriteStartElement("Item");
                writer.WriteAttributeString("url", listView1.Items[i].Text);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
                System.Xml.XmlTextWriter writer = new
           System.Xml.XmlTextWriter(Application.StartupPath + "\\Favorites.xml", null);
                writer.WriteStartElement("Favorites");
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    writer.WriteStartElement("Item");
                    writer.WriteAttributeString("url", listView1.Items[i].Text);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.Close();
            }
            catch
            {
                MessageBox.Show("You need to select an item");
            }
        }

        private void btnOdaberi_Click(object sender, EventArgs e)
        {
            url = listView1.SelectedItems[0].Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void Favoriti_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void listView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Return))
            {
                ListViewItem item = new ListViewItem(urlTxt.Text);
                listView1.Items.Add(urlTxt.Text);
            }
        }
        
    }
}

