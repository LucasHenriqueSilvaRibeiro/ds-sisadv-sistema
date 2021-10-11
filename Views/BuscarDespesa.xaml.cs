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
    /// Lógica interna para BuscarDespesa.xaml
    /// </summary>
    public partial class BuscarDespesa : Window
    {
        public BuscarDespesa()
        {
            InitializeComponent();
            Loaded += BuscarDespesa_Loaded;
        }

        public void BuscarDespesa_Loaded(object sender, RoutedEventArgs e)
        {
            List<Despesa> listaDespesa = new List<Despesa>();

            for (int i = 0; i < 30; i++)
            {
                listaDespesa.Add(new Despesa()
                {
                    Data = "20/02/2020",
                    Origem = "Despesa - " + i,
                    Mensal = true,
                    Valor = 20.30 + i,
                });
            }

            dataGridBuscarDespesa.ItemsSource = listaDespesa;
        }

        private void buttonExcluir_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Deseja excluir este(s) cadastros?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}
