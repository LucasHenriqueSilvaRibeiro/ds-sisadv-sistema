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
    /// Lógica interna para BuscarServico.xaml
    /// </summary>
    public partial class BuscarServico : Window
    {
        public BuscarServico()
        {
            InitializeComponent();
            Loaded += BuscarServico_Loaded;
        }
        public void BuscarServico_Loaded(object sender, RoutedEventArgs e)
        {
            List<Servico> listaServico = new List<Servico>();

            for (int i = 0; i < 30; i++)
            {
                listaServico.Add(new Servico()
                {
                    Cliente = "Joãozinho - " + i,
                    Tipo = "Civil - " + i,
                    Data = "01/06/2021",
                });
            }
            dataGridBuscarServico.ItemsSource = listaServico;
        }
        private void btn_excluir_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Deseja excluir esse serviço?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}
