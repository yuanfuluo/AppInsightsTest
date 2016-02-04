using Microsoft.ApplicationInsights;
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
using System.Management;
using System.Reflection;
using Microsoft.ApplicationInsights.DataContracts;

namespace AppInsightsTestApp
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        private TelemetryClient tc = new TelemetryClient();

        private int comboCount = 0;
        private int exceCount = 0;

        private Random randomDice = new Random();
        public string[] DisplayName = { "?", "Paper", "Scissor", "Stone" };
        public string[] FileName = { "Unknown.png", "Paper.png", "Scissor.png", "Stone.png" };
        public Color[] DisplayColor = { Color.FromArgb(255, 96, 96, 96), Color.FromArgb(255, 27, 161, 226), Color.FromArgb(255, 240, 163, 10), Color.FromArgb(255, 96, 169, 23) };

        public MainWindow()
        {
            InitializeComponent();

            tc.InstrumentationKey = "66a222f9-bfc7-4998-92a6-8cc16bbd0db4";

            tc.Context.User.Id = Environment.UserName;
            tc.Context.Session.Id = Guid.NewGuid().ToString();
            tc.Context.Device.OperatingSystem = Environment.OSVersion.ToString();

            tc.Context.Device.OperatingSystem = GetWindowsFriendlyName();

            tc.Context.Component.Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            tc.Context.Device.OemName = (from x in
                new ManagementObjectSearcher("SELECT Manufacturer FROM Win32_ComputerSystem").Get()
                    .OfType<ManagementObject>()
                                         select x.GetPropertyValue("Manufacturer")).FirstOrDefault()?.ToString() ?? "Unknown";
            tc.Context.Device.Model = (from x in
               new ManagementObjectSearcher("SELECT Model FROM Win32_ComputerSystem").Get()
                   .OfType<ManagementObject>()
                                       select x.GetPropertyValue("Model")).FirstOrDefault()?.ToString() ?? "Unknown";

            tc.TrackPageView("MainWindow");

            tc.TrackEvent("ExceptionButton_Click");
            tc.TrackEvent("CrashButton_Click");

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            ShowComputerResult(0);
            ShowPlayerResult(0);

        }

        

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tc != null)
            {
                tc.Flush(); // only for desktop apps
                System.Threading.Thread.Sleep(1000);
            }
        }

        private string GetWindowsFriendlyName()
        {
            var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().OfType<ManagementObject>()
                        select x.GetPropertyValue("Caption")).FirstOrDefault();

            return name?.ToString() ?? Environment.OSVersion.ToString();
        }


        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception)
            {
                tc.TrackException(new ExceptionTelemetry((Exception)e.ExceptionObject));
                tc.Flush();
                System.Threading.Thread.Sleep(1000);
            }
        }


        private void ScissorButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPlayerResult(2);
            RandomComputerResult(2);
        }

        private void StoneButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPlayerResult(3);
            RandomComputerResult(3);
        }

        private void Paperbutton_Click(object sender, RoutedEventArgs e)
        {
            ShowPlayerResult(1);
            RandomComputerResult(1);
        }

        private void RandomComputerResult(int playerResult)
        {
            int pcResult = randomDice.Next() % 3 + 1;
            ShowComputerResult(pcResult);
            EvaluateGame(pcResult, playerResult);
        }

        private void ShowComputerResult(int status)
        {
            ComResultPanel.Background = new SolidColorBrush(DisplayColor[status]);
            ComResultImage.Source = new BitmapImage(new Uri(@"\Images\" + FileName[status], UriKind.Relative));
            ComResultTextBlock.Text = DisplayName[status];
        }

        private void ShowPlayerResult(int status)
        {
            PlayerResultPanel.Background = new SolidColorBrush(DisplayColor[status]);
            PlayerResultImage.Source = new BitmapImage(new Uri(@"\Images\" + FileName[status], UriKind.Relative));
            PlayerResultTextBlock.Text = DisplayName[status];
        }

        private void EvaluateGame(int pc, int player)
        {
            if (pc == player)
            {
                ResultTextBlock.Text = "DRAW";
                tc.TrackEvent("GameDraw");
            }
            else if (player - pc == 1 || player - pc == -2)
            {
                ResultTextBlock.Text = "WIN";
                comboCount++;
                tc.TrackEvent("GameWin");
            }
            else
            {
                ResultTextBlock.Text = "LOSE";
                comboCount = 0;
                tc.TrackEvent("GameLose");
            }

            tc.TrackMetric("Combo Count", comboCount);
            ComboValueTextBlock.Text = comboCount + "";
           
        }

        private void ExceptionButton_Click(object sender, RoutedEventArgs e)
        {
            int randomResult = randomDice.Next() % 3;

            int[] a = new int[2];
            try
            {
                switch (randomResult)
                {
                    case 0:                       
                        a[6] = 5;
                        break;
                    case 1:
                        a[0] = 0;
                        a[1] = 5 / a[0];
                        break;
                    case 2:
                        object b = null;
                        string crash = b.ToString();
                        break;
                }
            }            
            catch (Exception ex)
            {
                exceCount++;
                ExceptionTextBlock.Text = "(" + exceCount + ")";
                tc.TrackException(ex);
            }
        }

        private void CrashButton_Click(object sender, RoutedEventArgs e)
        {
            object b = null;
            string crash = b.ToString();
        }
    }
}
