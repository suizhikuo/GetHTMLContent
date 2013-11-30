using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;
using DotNet.Utilities;
using System.IO;

namespace GetHTMLContent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            string PageUrl = "http://www.cnblogs.com/suizhikuo"; //需要获取源代码的网页
            WebClient wc = new WebClient(); // 创建WebClient实例提供向URI 标识的资源发送数据和从URI 标识的资源接收数据
            wc.Credentials = CredentialCache.DefaultCredentials; // 获取或设置用于对向 Internet 资源的请求进行身份验证的网络凭据。           
            Encoding enc = Encoding.GetEncoding("utf-8"); // 如果是乱码就改成 utf-8 / GB2312
            Byte[] pageData = wc.DownloadData(PageUrl); // 从资源下载数据并返回字节数组。
            string resultText = enc.GetString(pageData); // 输出字符串(HTML代码) 

            //htmlDcoument对象用来访问Html文档s
            HtmlAgilityPack.HtmlDocument hd = new HtmlAgilityPack.HtmlDocument();//需要引用HtmlAgilityPack.dll
            //加载Html文档
            hd.LoadHtml(resultText);
            string str = hd.GetElementbyId("leftmenu").OuterHtml;//指定的id
            this.txtResult.Text = str;
        }
    }
}
