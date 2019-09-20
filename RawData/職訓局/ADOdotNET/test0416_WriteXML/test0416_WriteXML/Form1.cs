using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml;

namespace test0416_WriteXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlWriter w = XmlWriter.Create(@"C:\Users\admin\Desktop\SMIT09\ADOdotNET\data\booklist.xml");
            w.WriteStartElement("booklist"); //<booklist>

            w.WriteStartElement("book");     //<book>

            w.WriteElementString("title", "Hello! XML!");
            w.WriteElementString("price", "100");

            w.WriteEndElement();// </book>

            w.WriteStartElement("book"); //<book>

            w.WriteElementString("title", "Hello! C#!");
            w.WriteElementString("price", "200");

            w.WriteEndElement();// </book>

            w.WriteEndElement();// </booklist>
            // <booklist /> = <booklist></booklist>

            w.Close();
            button1.Text = "ok";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlWriter w = XmlWriter.Create(@"C:\Users\admin\Desktop\SMIT09\ADOdotNET\data\booklist.xml");
            w.WriteStartElement("booklist");
            for (int i = 1; i <= 3; i++)
            {
                w.WriteStartElement("book");

                w.WriteElementString("title", "Hello! XML!" + i);
                w.WriteElementString("price", "10" + i);

                w.WriteEndElement();
            }
            w.WriteEndElement();

            w.Close();
            button2.Text = "ok";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlWriter w = XmlWriter.Create(@"C:\Users\admin\Desktop\SMIT09\ADOdotNET\data\booklist.xml");
            w.WriteStartElement("booklist");
            for (int i = 1; i <= 3; i++)
            {
                w.WriteStartElement("book");
                w.WriteAttributeString("id", i.ToString());

                w.WriteElementString("title", "Hello! XML!" + i);

                w.WriteStartElement("price");
                w.WriteAttributeString("unit", "twd");
                w.WriteString((500 + i).ToString());
                w.WriteEndElement();

                w.WriteEndElement();
            }
            w.WriteEndElement();
            w.Close();
            button3.Text = "ok";
        }
    }
}
