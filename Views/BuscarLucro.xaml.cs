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
using System.Windows.Shapes;
using SisAdv.Models;

namespace SisAdv.Views
{
    /// <summary>
    /// Lógica interna para BuscarLucro.xaml
    /// </summary>
    public partial class BuscarLucro : Window
    {
        public BuscarLucro()
        {
            InitializeComponent();
            Loaded += BuscarLucro_Loaded;
        }
        
        public void BuscarLucro_Loaded(object sender, RoutedEventArgs e)
        {
            List<Lucro> listaLucro = new List<Lucro>();

            for (int i = 0; i < 30; i++)
            {
                listaLucro.Add(new Lucro()
                {
                    Data = "20/02/2020",
                    Origem = "Lucro - " + i,
                    Mensal = false,
                    Valor = 20.30 + i,
                });
            }

            dataGridBuscarLucro.ItemsSource = listaLucro;
        }

        private void buttonExcluir_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Deseja excluir este(s) cadastro(s)?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}
