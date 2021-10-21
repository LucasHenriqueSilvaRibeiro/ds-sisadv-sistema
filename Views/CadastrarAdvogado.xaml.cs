﻿using System;
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
    /// Lógica interna para CadastrarAdvogado.xaml
    /// </summary>
    public partial class CadastrarAdvogado : Window
    {
        private Advogado _advogado;
        public CadastrarAdvogado()
        {
            InitializeComponent();
            Loaded += CadastrarAdvogado_Loaded;
        }

        private void CadastrarAdvogado_Loaded(object sender, RoutedEventArgs e)
        {
            _advogado = new Advogado();
        }

        private void BtnSalvarAdvogado_Click(object sender, RoutedEventArgs e)
        {
            _advogado.Nome = TxbNome.Text;
            _advogado.Cpf = TxbCpf.Text;
            _advogado.Telefone = TxbTelefone.Text;            
            _advogado.Email = TxbEmail.Text;

            if (TxbRg.Text != null)
                _advogado.Rg = TxbRg.Text;
            else
                _advogado.Rg = null;

            if (datePickerNascimento.SelectedDate != null)
                _advogado.DataNasc = (DateTime)datePickerNascimento.SelectedDate;

            _advogado.Descricao = "Teste de inserção ADVOGADO, INSERIR TXB DPS";

            SaveData();

            CarregarCadastrarUsuario();
        }

        private void CarregarCadastrarUsuario()
        {
            CadastrarNovoUsuario cadastrarNovoUsuario = new CadastrarNovoUsuario();
            cadastrarNovoUsuario.ShowDialog();
        }

        private void SaveData()
        {
            try
            {
                if (Validate())
                {
                    var dao = new AdvogadoDAO();
                    var text = "atualizado";

                    if (_advogado.Id == 0)
                    {
                        dao.Insert(_advogado);
                        text = "adicionado";
                    }
                    else
                        dao.Update(_advogado);

                    MessageBox.Show($"Advogado {text} com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);                    

                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool Validate()
        {
            var validator = new AdvogadoValidator();
            var result = validator.Validate(_advogado);

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
    }
}