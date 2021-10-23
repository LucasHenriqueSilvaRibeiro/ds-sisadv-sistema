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
    /// Lógica interna para Cadastrarlucro.xaml
    /// </summary>
    public partial class Cadastrarlucro : Window
    {
        public Lucro _lucro;
        public int _id;

        public Cadastrarlucro()
        {
            InitializeComponent();
            Loaded += Cadastrarlucro_Loaded;
        }

        public Cadastrarlucro(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += Cadastrarlucro_Loaded;
        }

        public void Cadastrarlucro_Loaded(object sender, RoutedEventArgs e)
        {
            _lucro = new Lucro();

            LoadDataGrid();

            if (_id > 0)
                FillForm();
        }

        private void FillForm()
        {
            try
            {
                var dao = new LucroDAO();
                _lucro = dao.GetById(_id);

                textId.Text = _lucro.Id.ToString();
                dateLucro.SelectedDate = _lucro.Data;
                textvalor.Text = _lucro.Valor.ToString();
                textDescricao.Text = _lucro.Descricao;
                textOrigem.Text = _lucro.Origem;

                if (_lucro.FormaPagamento == "Dinheiro")
                    rbDinheiro.IsChecked = true;
                if (_lucro.FormaPagamento == "Transferência")
                    rbTransferência.IsChecked = true;
                if (_lucro.FormaPagamento == "Cartão")
                    rbCartao.IsChecked = true;
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
                var dao = new LucroDAO();

                gridcadastrarlucro.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Não foi possível carregar as listas de serviços. Verifique e tente novamente.", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
