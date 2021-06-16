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

namespace SisAdv
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btadicionar_Click(object sender, RoutedEventArgs e)
        {
            funcoesadicionar.Visibility = Visibility.Visible;
        }
        private void btadicionar_LostFocus(object sender, RoutedEventArgs e)
        {
            funcoesadicionar.Visibility = Visibility.Collapsed;
        }

        

        private void btbuscar_Click(object sender, RoutedEventArgs e)
        {
            funcoesbuscar.Visibility = Visibility.Visible;
        }

        private void btbuscar_LostFocus(object sender, RoutedEventArgs e)
        {
            funcoesbuscar.Visibility = Visibility.Collapsed;
        }
    }
    }
    
