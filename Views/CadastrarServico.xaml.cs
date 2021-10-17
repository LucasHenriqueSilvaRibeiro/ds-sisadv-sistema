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

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            //Deixarei dessa forma por enquanto até assistir as aulas do ID e como pegar os id de advogado, cliente e evento (Se der esse último(evento)).
            _servico.Cliente = 2;
            _servico.Advogado = 1;

            _servico.Descricao = txbDescricao.Text;

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

            SaveData();
        }

        private void btnAtribuirEvento_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Evento Atribuido com Sucesso", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnAdicionarServico_Click(object sender, RoutedEventArgs e)
        {
            ClearInputs();
        }

        private void SaveData()
        {
            try
            {
                var dao = new ServicoDAO();
                var text = "atualizado";

                if (_servico.Id == 0)
                {
                    dao.Insert(_servico);
                    text = "adicionado";
                }
                else
                    dao.Update(_servico);

                MessageBox.Show($"O Servico foi {text} com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                CloseFormVerify();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseFormVerify()
        {
            if (_servico.Id == 0)
            {
                var result = MessageBox.Show("Deseja continuar adicionando serviços?", "Continuar?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                    this.Close();
                else
                    ClearInputs();
            }
            else
                this.Close();
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
            datepickerDataServico.SelectedDate = null;
            comboboxCliente = null;
            comboboxAdvogado = null;
            rbtipoCivil.IsChecked = false;
            rbtipoCriminal.IsChecked = false;
            rbtipoEleitoral.IsChecked = false;
        }
    }
}
