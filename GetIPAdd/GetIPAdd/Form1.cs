using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetIPAdd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string GetIpAddress(string Ip)
        {
            WebRequest request = WebRequest.Create("http://www.ip138.com/ips138.asp?ip="+Ip);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(),Encoding.GetEncoding("gb2312"));

            string read = reader.ReadToEnd();
            Regex regex = new Regex("<td align=\"center\"><ul class=\"ul1\"><li>本站主数据：(?<title>.*?)</li>");

            if(regex.IsMatch(read))
            {
                read = regex.Match(read).Groups["title"].Value;
            }
            return read ;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.GetIpAddress(this.textBox1.Text));
        }
    }
}
