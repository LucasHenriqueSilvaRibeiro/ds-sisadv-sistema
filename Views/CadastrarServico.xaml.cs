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
    /// Lógica interna para CadastrarServico.xaml
    /// </summary>
    public partial class CadastrarServico : Window
    {
        private Servico _servico;

        public CadastrarServico()
        {
            InitializeComponent();
            Loaded += CadastrarServico_Loaded;
        }

        private void CadastrarServico_Loaded(object sender, RoutedEventArgs e)
        {
            _servico = new Servico();
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
                Servico servico = new Servico();

                //Tentei utilizar o ToString, se não der, verificaro outra solução.
                servico.Cliente = Convert.ToString(comboboxCliente.Text);
                servico.Data = (DateTime)datepickerDataServico.SelectedDate;
                servico.Valor = Convert.ToDouble(txbValor.Text);

                //ver essas questões
                servico.Fk_advogado = 1;
                servico.Fk_cliente = 1;
                servico.Fk_evento = 1;

                if (rbtipoEleitoral.IsChecked.Value)
                    servico.Tipo = "Eleitoral";
                else if (rbtipoCriminal.IsChecked.Value)
                    servico.Tipo = "Criminal";
                else if (rbtipoCivil.IsChecked.Value)
                    servico.Tipo = "Civil";

                ServicoDAO servicoDAO = new ServicoDAO();
                servicoDAO.Insert(servico);

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

        private void ClearInputs()
        {
            txbValor.Clear();
            txbDescricao.Clear();
            txbEvento.Clear();
            txbHorario.Clear();
            datepickerDataEvento.SelectedDate = null;
            datepickerDataServico.SelectedDate = null;
            comboboxCliente = null;
        }
    }
}
