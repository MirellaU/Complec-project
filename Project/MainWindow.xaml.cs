using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;


namespace Project
{



    public partial class MainWindow : Window
    {

        Complex[] h;
        double[] Z;
        double[] phase;

        public MainWindow()
        {
            InitializeComponent();
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double R1_text;
            double R2_text;
            double C_text;
            double fromfreq_text;
            double tofreq_text;

            if (!Double.TryParse(R1_textbox.Text, out R1_text) & !Double.TryParse(R2_textbox.Text, out R2_text) & !Double.TryParse(C_textbox.Text, out C_text) & !Double.TryParse(from_freq_textbox.Text, out fromfreq_text) & !Double.TryParse(to_freq_textbox.Text, out tofreq_text))
            {
                MessageBox.Show("Broken");
            }
            else
            {
                Impedance(R1_text, R2_text, C_text, fromfreq_text, tofreq_text);


                SeriesCollection = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Impedancja",
                        Values = new ChartValues<double>{ }
                    }
                };
                for (int i = 0; i < Z.Length; i++)
                    SeriesCollection[0].Values.Add(Z[i]);

            }
        }

        public void Impedance(double R1, double R2, double C, double f1, double f2)
        {
            int n = (int)Math.Round(f2 - f1);
            int i;
            double f = f1;
            h = new Complex[n];
            Z = new double[n];
            phase = new double[n];
            Complex R1C = new Complex(R1, 0);
            Complex R2C = new Complex(R2, 0);
            Complex CC = new Complex(0, 1 / (2 * Math.PI * f * C));
            for (i = 0; i < n; i++)
            {
                CC.Imaginary = 1 / (2 * Math.PI * f * C);
                Complex part1 = Complex.Subtraction(R2C, CC);
                Complex part2 = Complex.Multiplication(R1C, part1);
                Complex part3 = Complex.Addition(R1C, R2C);
                Complex part4 = Complex.Subtraction(part3, CC);
                h[i] = Complex.Division(part2, part4);
                Z[i]=Math.Sqrt(Math.Pow(h[i].Real,2)+ Math.Pow(h[i].Imaginary, 2));
                phase[i] = Math.Atan(h[i].Imaginary / h[i].Real)*(180/Math.PI);
                f = f + 1;
            }

        }

        public SeriesCollection SeriesCollection { get; set; }
    }
}
