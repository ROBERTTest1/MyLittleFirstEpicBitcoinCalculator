using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace BitcoinCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currencyselector.SelectedItem.ToString() == "EUR")
            {
                button1.Visible = true;
                suva.Visible = true;
                BitcoinRates newbitcoinrate = GetRates();
                float result = float.Parse(bitcoinamountinput.Text) * (float)newbitcoinrate.Bpi.EUR.rate_float;
                tulemuslabel.Text = $"{result} Bitcoini {newbitcoinrate.Bpi.EUR.code}";
            }
            if (currencyselector.SelectedItem.ToString() == "USD")
            {
                button1.Visible = true;
                suva.Visible = true;
                BitcoinRates newbitcoinrate = GetRates();
                float result = float.Parse(bitcoinamountinput.Text) * (float)newbitcoinrate.Bpi.USD.rate_float;
                tulemuslabel.Text = $"{result} Bitcoini {newbitcoinrate.Bpi.USD.code}";
            }
            if (currencyselector.SelectedItem.ToString() == "GBP")
            {
                button1.Visible = true;
                suva.Visible = true;
                BitcoinRates newbitcoinrate = GetRates();
                float result = float.Parse(bitcoinamountinput.Text) * (float)newbitcoinrate.Bpi.GBP.rate_float;
                tulemuslabel.Text = $"{result} Bitcoini {newbitcoinrate.Bpi.GBP.code}";
            }
            if (currencyselector.SelectedItem.ToString() == "EEK")
            {
                button1.Visible = true;
                suva.Visible = true;
                float bitcoinAmount = float.Parse(bitcoinamountinput.Text);
                BitcoinRates newbitcoinrate = GetRates();
                float eurAmount = bitcoinAmount * (float)newbitcoinrate.Bpi.EUR.rate_float;
                const double eurToEekRate = 15.6466;
                double eekAmount = eurAmount * eurToEekRate;

                tulemuslabel.Text = $"{eekAmount} EEK";
            }
        }


        public static BitcoinRates GetRates()
        {
            string url = "https://api.coindesk.com/v1/bpi/currentprice.json";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            BitcoinRates bitcoin;
            using (var responseReader = new StreamReader(webStream))
            {
                var data = responseReader.ReadToEnd();
                bitcoin = JsonConvert.DeserializeObject<BitcoinRates>(data);
            }  
            return bitcoin;
        }
    }
}
