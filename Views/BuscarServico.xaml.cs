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
using MySql.Data.MySqlClient;

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
        
        private void btn_excluir_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Deseja excluir esse serviço?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        private void Btn_Update_Click(object sender, RoutedEventArgs e)
        {
            var servicoSelected = dataGridBuscarServico.SelectedItem as Servico;

            var window = new CadastrarServico(servicoSelected.Id);

            window.ShowDialog();

            LoadDataGrid();
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            var servicoSelected = dataGridBuscarServico.SelectedItem as Servico;

            var result = MessageBox.Show($"Deseja realmente remover o servico do cliente `{servicoSelected.ClienteNome}`?", "Confirmação de Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new ServicoDAO();
                    dao.Delete(servicoSelected);
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

                MessageBox.Show(ex.Message, "Não foi possível carregar as listas de serviços. Verifique e tente novamente.", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        
    }
}
