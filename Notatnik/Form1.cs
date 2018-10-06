using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Notatnik
{
    public partial class Form1 : Form
    {
        String filename;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            filename = dlg.FileName;
            FileStream stream = File.Open(dlg.FileName, FileMode.Open);
            StreamReader sr = new StreamReader(stream, Encoding.Default);
            richTextBox1.Text = "";
            String str;
            while ((str = sr.ReadLine()) != null)
            {
                richTextBox1.Text = richTextBox1.Text + str + "\n";
            }
            sr.Close();
            stream.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = filename;
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            FileStream stream = File.Open(dlg.FileName, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(stream);

            sw.Write(richTextBox1.Text, Encoding.Default);
            sw.Flush();

            sw.Close();
            stream.Close();
        }
    }
}
