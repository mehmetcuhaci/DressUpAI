using DressUpAI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DressUpAI
{
    public partial class Form1 : Form
    {
        private WeatherController weatherController;
        public Form1()
        {
            InitializeComponent();
            weatherController = new WeatherController();
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
    }
}
