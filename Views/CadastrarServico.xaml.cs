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
    /// Lógica interna para CadastrarServico.xaml
    /// </summary>

    public partial class CadastrarServico : Window
    {
        private int _id;

        private Servico _servico;        

        public CadastrarServico()
        {
            InitializeComponent();
            Loaded += CadastrarServico_Loaded;
        }

        public CadastrarServico(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += CadastrarServico_Loaded;
        }

        private void CadastrarServico_Loaded(object sender, RoutedEventArgs e)
        {
            _servico = new Servico();

            if (_id > 0)
                FillForm();
        }

        private void btnPesquisarServico_Click(object sender, RoutedEventArgs e)
        {
            BuscarServico buscarServico = new BuscarServico();

            buscarServico.ShowDialog();
        }

        private void listArquivos_Drop(object sender, DragEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /*Código errado, com as FK, deixarei para lembrar
               _servico.Fk_advogado = 1;
               _servico.Fk_cliente = 1;
               _servico.Fk_evento = 1;*/
                //Deixarei dessa forma por enquanto até assistir as aulas do ID e como pegar os id de advogado, cliente e evento.
                _servico.Advogado = 2;
                _servico.Evento = 1;
                _servico.Cliente = 2;

                if (double.TryParse(txbValor.Text, out double valor))
                    _servico.Valor = valor;

                if (datepickerDataServico.SelectedDate != null)
                    _servico.Data = (DateTime)datepickerDataServico.SelectedDate;               

                if (rbtipoEleitoral.IsChecked.Value)
                    _servico.Tipo = "Eleitoral";
                else if (rbtipoCriminal.IsChecked.Value)
                    _servico.Tipo = "Criminal";
                else if (rbtipoCivil.IsChecked.Value)
                    _servico.Tipo = "Civil";

                //No código do professor tem um código para validação, ainda não cheguei nessas aulas, então ficará assim por enquanto
                ServicoDAO servicoDAO = new ServicoDAO();
                servicoDAO.Insert(_servico);

                MessageBox.Show("O Serviço foi cadastrado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);

                //Código do SpaceSistema (programa do professor).
                var result = MessageBox.Show("Deseja continuar adicionando serviços?", "Continuar?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                    this.Close();
                else
                    ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAtribuirEvento_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Evento Atribuido com Sucesso", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnAdicionarServico_Click(object sender, RoutedEventArgs e)
        {
            ClearInputs();
        }

        private void FillForm()
        {
            try
            {
                var dao = new ServicoDAO();
                _servico = dao.GetById(_id);

                txbId.Text = _servico.Id.ToString();
                comboboxCliente.Text = _servico.ClienteNome;
                datepickerDataServico.SelectedDate = _servico.Data;
                txbValor.Text = _servico.Valor.ToString();

                if (rbtipoEleitoral.IsChecked.Value)
                    rbtipoEleitoral.Content = _servico.Tipo;
                else if (rbtipoCriminal.IsChecked.Value)
                    rbtipoCriminal.Content = _servico.Tipo;
                else if (rbtipoCivil.IsChecked.Value)
                    rbtipoCivil.Content = _servico.Tipo;

                /*var dao = new FuncionarioDAO();
                _funcionario = dao.GetById(_id);

                txtId.Text = _funcionario.Id.ToString();
                txtNome.Text = _funcionario.Nome;
                txtCPF.Text = _funcionario.CPF;
                txtRG.Text = _funcionario.RG;
                dtPickerDataNascimento.SelectedDate = _funcionario.DataNascimento;
                txtEmail.Text = _funcionario.Email;
                txtCelular.Text = _funcionario.Celular;
                txtFuncao.Text = _funcionario.Funcao;
                txtSalario.Text = _funcionario.Salario.ToString();*/

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearInputs()
        {
            txbValor.Clear();
            txbDescricao.Clear();
            /*txbEvento.Clear();
            txbHorario.Clear();
            datepickerDataEvento.SelectedDate = null*/;
            datepickerDataServico.SelectedDate = null;
            comboboxCliente = null;
        }
    }
}
