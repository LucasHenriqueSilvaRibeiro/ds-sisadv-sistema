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
    /// Lógica interna para Cadastrarcliente.xaml
    /// </summary>
    public partial class Cadastrarcliente : Window
    {
        private Cliente _cliente;
        private int _id;

        public Cadastrarcliente()
        {
            InitializeComponent();
            Loaded += Cadastrarcliente_Loaded;
        }
        public Cadastrarcliente(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += Cadastrarcliente_Loaded;
        }

        private void Cadastrarcliente_Loaded(object sender, RoutedEventArgs e)
        {
            _cliente = new Cliente();

            if (_id > 0)
                FillForm();
        }

        private void SaveData()
        {
            try
            {
                if (Validate())
                {
                    var dao = new ClienteDAO();
                    var text = "atualizado";

                    if (_cliente.Id == 0)
                    {
                        dao.Insert(_cliente);
                        text = "adicionado";
                    }
                    else
                        dao.Update(_cliente);

                    MessageBox.Show($"O Servico foi {text} com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    CloseFormVerify();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool Validate()
        {
            var validator = new ClienteValidator();
            var result = validator.Validate(_cliente);

            if (!result.IsValid)
            {
                string errors = null;
                var count = 1;

                foreach (var failure in result.Errors)
                {
                    errors += $"{count++} - {failure.ErrorMessage}\n";
                }

                MessageBox.Show(errors, "Validação de Dados", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            return result.IsValid;
        }

        private void CloseFormVerify()
        {
            if (_cliente.Id == 0)
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
            var dao = new ClienteDAO();
            _cliente = dao.GetById(_id);

            textId.Text = _cliente.Id.ToString();
            textNome.Text = _cliente.Nome;
            textDescricao.Text = _cliente.Descricao;
            //textemail.Text = _cliente.Email;
            textProfissao.Text = _cliente.Profissao;
            textTelefone.Text = _cliente.Telefone;

            //MessageBox.Show($"nome {_cliente.Nome} descrição {_cliente.Descricao} email {_cliente.Email} profissão {_cliente.Profissao} telefone {_cliente.Telefone}", "", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void ClearInputs()
        {
            //implementar, coloquei uma mensagem só para teste
            MessageBox.Show("Campos limpos", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
