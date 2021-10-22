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
    /// Lógica interna para BuscarCliente.xaml
    /// </summary>
    public partial class BuscarCliente : Window
    {
        public BuscarCliente()
        {
            InitializeComponent();
            Loaded += BuscarCliente_Loaded;
        }

        public void BuscarCliente_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void buttonExcluir_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Deseja excluir este(s) cadastro(s)?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        private void buttonPesquisar_Click(object sender, RoutedEventArgs e)
        {
            if (textCliente.Text == null && textRg.Text == null && textcpf.Text == null)
                MessageBox.Show("Nenhum dos campos foi inserido. Insira dados em algum dos campos para realizar uma consulta!", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
            else
               ConsultaLoadDataGrid();
        }

        private void ConsultaLoadDataGrid()
        {
            try
            {
                var dao = new ClienteDAO();
                string nome = null;
                string rg = null;
                string cpf = null;

                if (textCliente.Text != null)
                    nome = textCliente.Text;

                if (textRg.Text != null)
                    rg = textRg.Text;

                if (textcpf.Text != null)
                    cpf = textcpf.Text;

                dataGridBuscarCliente.ItemsSource = null;
                dataGridBuscarCliente.ItemsSource = dao.ListConsulta(nome, rg, cpf);
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
                var dao = new ClienteDAO();

                dataGridBuscarCliente.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Não foi possível carregar as listas de Clientes. Verifique e tente novamente.", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
