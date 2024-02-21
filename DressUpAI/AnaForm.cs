using DressUpAI.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Forms;


namespace DressUpAI
{
    public partial class AnaForm : Form
    {
        private WeatherController weatherController;


        public AnaForm()
        {
            InitializeComponent();
            weatherController = new WeatherController();
            string apiKey = "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";
            webBrowser1.Navigate("C:\\Users\\mehme\\source\\repos\\DressUpAI\\HTMLPage1.html");



        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string city = textBox1.Text;
            if (!string.IsNullOrEmpty(city))
            {
                WeatherForecast weatherForecast = await weatherController.GetWeatherInfo(city);

                if (weatherForecast != null)
                {
                    // Kullanıcı arayüzünde gösterme
                    string message = $"{city}'da Derece: {weatherForecast.Result[0].Degree}°C";
                    MessageBox.Show(message, "Hava Durumu Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Hava durumu bilgisi alınamadı. Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir şehir adı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cikisBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ekleBtn_Click(object sender, EventArgs e)
        {
            string dress = comboBox1.Text;
            string dressColor = textBox2.Text;
            if (!string.IsNullOrEmpty(dress) && !string.IsNullOrEmpty(dressColor))
            {
                MessageBox.Show(dressColor + "  " + dress);
                dressList.Items.Add(dressColor + " " + dress);
            }
            else
            {
                MessageBox.Show("Lütfen kıyafet ve renk seçimini yapınız!", "Hata", MessageBoxButtons.OK);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await CallAPIAndDisplayResponse();
        }

        private async Task CallAPIAndDisplayResponse()
        {
            string url = "https://api.together.xyz/v1/chat/completions";
            string apiKey = "0ef6d31620e77535119e9c3ec1f21fbf28a91cc051bb4ab21a3d8754e6742f9f";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
                string jsonContent = "{\"model\":\"mistralai/Mixtral-8x7B-Instruct-v0.1\",\"max_tokens\":1024,\"messages\":[{\"role\":\"system\",\"content\":\"You are an AI assistant\"},{\"role\":\"user\",\"content\":\"Anlık bitcoin fiyatı nedir?\"}]}";

                try
                {
                    HttpResponseMessage response = await client.PostAsync(url, new StringContent(jsonContent, Encoding.UTF8, "application/json"));


                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(responseContent, "API Response");
                    }
                    else
                    {
                        MessageBox.Show("Error: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }


        }
    }
}
