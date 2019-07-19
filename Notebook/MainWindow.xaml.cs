using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Notebook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            int countEnum=  Enum.GetNames(typeof(FontSizeSetup)).Length;
            for (byte i =0;i< countEnum;i++)
            {
                byte numberFontSize = Convert.ToByte((FontSizeSetup)Enum.GetValues(typeof(FontSizeSetup)).GetValue(i));
                CmbxSelectionChanged.Items.Add(numberFontSize);
            }
            CmbxSelectionChanged.SelectedItem = Convert.ToByte(FontSizeSetup.Fourteen);
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            bool? res = ofd.ShowDialog();
            if (res!=false)
            {
                Stream stream;
                if ((stream = ofd.OpenFile()) != null)
                {
                    string fileName = ofd.FileName;
                    TxtField.Text = File.ReadAllText(fileName);
                }
            }
        }

        private void NewFile_Click(object sender, RoutedEventArgs e)
        {
            if (TxtField.Text != "")
            {
                SaveToFile();
            }

            TxtField.Text = "";
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveToFile();
        }

        private void ExitProgramm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FontTimesNewRoman_Click(object sender, RoutedEventArgs e)
        {
            TxtField.FontFamily = new FontFamily("Times New Roman");
            FontVerdana.IsChecked = false;
        }

        private void FontVerdana_Click(object sender, RoutedEventArgs e)
        {
            TxtField.FontFamily = new FontFamily("Verdana");
            FontTimesNewRoman.IsChecked = false;
        }

        private void SelectionChanged_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string cmbxSelectSize = CmbxSelectionChanged.SelectedItem.ToString();

            if (cmbxSelectSize == Convert.ToUInt16(FontSizeSetup.Fourteen).ToString())
                TxtField.FontSize = Convert.ToUInt16(FontSizeSetup.Fourteen);
            else if (cmbxSelectSize == Convert.ToUInt16(FontSizeSetup.FourtyEight).ToString())
                TxtField.FontSize = Convert.ToUInt16(FontSizeSetup.FourtyEight);
            else if (cmbxSelectSize == Convert.ToUInt16(FontSizeSetup.Sixteen).ToString())
                TxtField.FontSize = Convert.ToUInt16(FontSizeSetup.Sixteen);
            else if (cmbxSelectSize == Convert.ToUInt16(FontSizeSetup.Ten).ToString())
                TxtField.FontSize = Convert.ToUInt16(FontSizeSetup.Ten);
            else if (cmbxSelectSize == Convert.ToUInt16(FontSizeSetup.ThirtyTwo).ToString())
                TxtField.FontSize = Convert.ToUInt16(FontSizeSetup.ThirtyTwo);
            else if (cmbxSelectSize == Convert.ToUInt16(FontSizeSetup.Twenty).ToString())
                TxtField.FontSize = Convert.ToUInt16(FontSizeSetup.Twenty);
            else if (cmbxSelectSize == Convert.ToUInt16(FontSizeSetup.TwentyFour).ToString())
                TxtField.FontSize = Convert.ToUInt16(FontSizeSetup.TwentyFour);
        }
        private void SaveToFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            bool? res = sfd.ShowDialog();
            if (res!=false)
            {
                using (Stream s = File.Open(sfd.FileName, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        sw.Write(TxtField.Text);
                    }
                }
            }
        }
    }
}

namespace Notebook
{
    enum FontSizeSetup
    {
        Ten=10,
        Sixteen=16,
        Fourteen=14,
        Twenty=20,
        TwentyFour=24,
        ThirtyTwo=32,
        FourtyEight=48
    }
}

