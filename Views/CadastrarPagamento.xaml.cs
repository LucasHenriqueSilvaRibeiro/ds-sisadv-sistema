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
    /// Lógica interna para CadastrarPagamento.xaml
    /// </summary>
    public partial class CadastrarPagamento : Window
    {
        private int _id;
        private Pagamento _pagamento; 
        public CadastrarPagamento()
        {
            InitializeComponent();
            Loaded += CadastrarPagamento_Loaded;
        }
        //esse é para pesquisar e preencher
        public CadastrarPagamento(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += CadastrarPagamento_Loaded;
        }

        private void CadastrarPagamento_Loaded(object sender, RoutedEventArgs e)
        {
            _pagamento = new Pagamento();
            LoadCombobox();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btnpesquisarcaixa_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btnadicionar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadCombobox()
        {
            //ComboboxAdvogado.ItemsSource = new AdvogadoDAO().List();
            boxcaixa.ItemsSource = new CaixaDAO().List();
            boxdespesa.ItemsSource = new DespesaDAO().List();
        }
    }
}
