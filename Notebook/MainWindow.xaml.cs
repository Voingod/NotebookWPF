using Microsoft.Win32;
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
            for (int i=0;i< countEnum;i++)
            {
                int numberFontSize = Convert.ToInt32((FontSizeSetup)Enum.GetValues(typeof(FontSizeSetup)).GetValue(i));
                CmbxSelectionChanged.Items.Add(numberFontSize);
            }

           // CmbxSelectionChanged.Items.Add("93");
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
        }

        private void NewFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
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

