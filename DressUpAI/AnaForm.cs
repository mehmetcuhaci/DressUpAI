using DressUpAI.Models;
using System;
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
        }
    }
}
