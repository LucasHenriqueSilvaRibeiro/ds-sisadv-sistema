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
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            try
            {
                var dao = new ServicoDAO();

                dataGridBuscarServico.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        private void btn_excluir_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Deseja excluir esse serviço?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}
