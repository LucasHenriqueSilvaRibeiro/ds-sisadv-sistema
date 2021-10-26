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

namespace SisAdv.Views
{
    /// <summary>
    /// Lógica interna para BuscarPagamento.xaml
    /// </summary>
    public partial class BuscarPagamento : Window
    {
        public BuscarPagamento()
        {
            InitializeComponent();
        }

        private void Btn_Pesquisar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            CadastrarPagamento cadastrarPagamento = new CadastrarPagamento();
            cadastrarPagamento.Show();
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Update_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
