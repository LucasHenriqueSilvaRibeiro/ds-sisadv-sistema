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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SisAdv.Models;

namespace SisAdv.Views
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            ShowColumnChart();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();

            //Agenda();
        }

        private void Teste()
        {
            DateTime data = agendacompromissos.SelectedDate.Value;
            string teste = data.ToString();

            MessageBox.Show(teste);
        }

        private void LoadDataGrid()
        {
            try
            {
                var dao = new ServicoDAO();

                dataGridServicosRecentes.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Não foi possível carregar as listas de serviços. Verifique e tente novamente.", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void Agenda()
        {
            try
            {
                string dataCalendario = null;
                DateTime? data = null;

                DateTime? selectedDate = (DateTime?)agendacompromissos.SelectedDate.Value;
                data = selectedDate;
                dataCalendario = data?.ToString("yyyy-MM-dd");

                GridAgenda gridAgenda = new GridAgenda(dataCalendario);
                gridAgenda.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /* Código do calendário, vou tentar implementar esse que achei na internet
         string _query = "SELECT * FROM calendario WHERE estado=1 AND utilizador=@user;";

            using (MySqlConnection con  = new MySqlConnection(ConSql))
            {
                using (MySqlCommand cmd = new MySqlCommand(_query, con))
                {
                    con.Open();
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@user", Sessao.Id);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            		monthCalendar1.AddBoldedDate(DateTime.Parse(funcao.OutHoras(reader["dataAviso"].ToString())));

                        }
                        reader.Close();
                    }
                }
                con.Close();
            }
         * */

        private void ShowColumnChart()
        {
            List<KeyValuePair<string, int>> valueList = new List<KeyValuePair<string, int>>();
            valueList.Add(new KeyValuePair<string, int>("Segunda", 8));
            valueList.Add(new KeyValuePair<string, int>("Terça", 7));
            valueList.Add(new KeyValuePair<string, int>("Quarta", 7));
            valueList.Add(new KeyValuePair<string, int>("Quinta", 10));
            valueList.Add(new KeyValuePair<string, int>("Sexta", 6));
            valueList.Add(new KeyValuePair<string, int>("Sábado", 4));

            //Setting data for column chart
            columnChart.DataContext = valueList;
        }

        private void btadicionar_Click(object sender, RoutedEventArgs e)
        {
            funcoesadicionar.Visibility = Visibility.Visible;
            funcoesbuscar.Visibility = Visibility.Collapsed;
        }        

        private void btbuscar_Click(object sender, RoutedEventArgs e)
        {
            funcoesbuscar.Visibility = Visibility.Visible;
            funcoesadicionar.Visibility = Visibility.Collapsed;
        }


        private void btaddrevento_Click(object sender, RoutedEventArgs e)
        {
            Cadastraeventonov cadastrarEvento = new Cadastraeventonov();

            cadastrarEvento.ShowDialog();
        }

        private void btImprimirRelatorio_Click(object sender, RoutedEventArgs e)
        {
            ImprimirRelatorio imprimirRelatorio = new ImprimirRelatorio();

            imprimirRelatorio.ShowDialog();
        }

        private void btbuscarcliente_Click(object sender, RoutedEventArgs e)
        {
            BuscarCliente buscarCliente = new BuscarCliente();
            funcoesbuscar.Visibility = Visibility.Collapsed;
            buscarCliente.ShowDialog();            
        }

        private void btbuscaservico_Click(object sender, RoutedEventArgs e)
        {
            BuscarServico buscarServico = new BuscarServico();
            funcoesbuscar.Visibility = Visibility.Collapsed;
            buscarServico.ShowDialog();
        }

        private void btsair_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja Realmente Sair?", "Save error", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
                this.Close();
        }

        private void btOcultarServicos_Click(object sender, RoutedEventArgs e)
        {
            //Código inicial para ocultar a grid dos serviços recentes :)
            dataGridServicosRecentes.Visibility = Visibility.Collapsed;
            textRecente.Visibility = Visibility.Collapsed;
            gridDireitaRecentes.Width = 80;
            gridCentral.Width = 800;
        }

        private void btbuscardespesa_Click(object sender, RoutedEventArgs e)
        {
            BuscarDespesa buscarDespesa = new BuscarDespesa();
            funcoesbuscar.Visibility = Visibility.Collapsed;
            buscarDespesa.ShowDialog();
        }

        private void btbuscarlucro_Click(object sender, RoutedEventArgs e)
        {
            BuscarLucro buscarLucro = new BuscarLucro();
            funcoesbuscar.Visibility = Visibility.Collapsed;
            buscarLucro.ShowDialog();
        }

        private void btaaddservico_Click(object sender, RoutedEventArgs e)
        {
            CadastrarServico cadastrarServico = new CadastrarServico();
            funcoesadicionar.Visibility = Visibility.Collapsed;
            cadastrarServico.ShowDialog();
        }

        private void btacessardiariojustica_Click(object sender, RoutedEventArgs e)
        {
            AcessarDiarioJustiça acessarDiarioJustiça = new AcessarDiarioJustiça();

            acessarDiarioJustiça.ShowDialog();
        }

        private void btaddcliente_Click(object sender, RoutedEventArgs e)
        {
            Cadastrarcliente cadastrarCliente = new Cadastrarcliente();
            funcoesadicionar.Visibility = Visibility.Collapsed;
            cadastrarCliente.ShowDialog();
        }

        private void btadddespesa_Click(object sender, RoutedEventArgs e)
        {
            CadastrarDespesa cadastrarDespesa = new CadastrarDespesa();
            funcoesadicionar.Visibility = Visibility.Collapsed;
            cadastrarDespesa.ShowDialog();
        }

        private void btaddlucro_Click(object sender, RoutedEventArgs e)
        {
            Cadastrarlucro cadastrarLucro = new Cadastrarlucro();
            funcoesadicionar.Visibility = Visibility.Collapsed;
            cadastrarLucro.ShowDialog();
        }

        private void btconfiguracoes_Click(object sender, RoutedEventArgs e)
        {
            ConfigurarPreferenciasRecursos configurarPreferenciasRecursos = new ConfigurarPreferenciasRecursos();
            funcoesadicionar.Visibility = Visibility.Collapsed;
            configurarPreferenciasRecursos.ShowDialog();
        }

        private void Btn_visualizarServico_Click(object sender, RoutedEventArgs e)
        {
            var servicoSelected = dataGridServicosRecentes.SelectedItem as Servico;

            var window = new CadastrarServico(servicoSelected.Id);

            window.ShowDialog();

            LoadDataGrid();
        }

        private void btaddAdvogado_Click(object sender, RoutedEventArgs e)
        {
            CadastrarAdvogado cadastrarAdvogado = new CadastrarAdvogado();
            funcoesadicionar.Visibility = Visibility.Collapsed;
            cadastrarAdvogado.ShowDialog();
        }

        private void btaddUsuario_Click(object sender, RoutedEventArgs e)
        {
            CadastrarNovoUsuario cadastrarNovoUsuario = new CadastrarNovoUsuario();
            funcoesadicionar.Visibility = Visibility.Collapsed;
            cadastrarNovoUsuario.ShowDialog();
        }

        private void btbuscaAdvogado_Click(object sender, RoutedEventArgs e)
        {
            BuscarAdvogado buscarAdvogado = new BuscarAdvogado();
            funcoesbuscar.Visibility = Visibility.Collapsed;
            buscarAdvogado.ShowDialog();
        }

        private void btaddProcesso_Click(object sender, RoutedEventArgs e)
        {
            CadastrarProcesso cadastrarProcesso = new CadastrarProcesso();
            funcoesbuscar.Visibility = Visibility.Collapsed;
            cadastrarProcesso.ShowDialog();
        }

        private void btbuscaProcesso_Click(object sender, RoutedEventArgs e)
        {
            BuscarProcesso buscarProcesso = new BuscarProcesso();
            funcoesbuscar.Visibility = Visibility.Collapsed;
            buscarProcesso.ShowDialog();
        }

        private void btaddCaixa_Click(object sender, RoutedEventArgs e)
        {
            Cadastrarcaixa cadastrarcaixa = new Cadastrarcaixa();
            funcoesbuscar.Visibility = Visibility.Collapsed;
            cadastrarcaixa.ShowDialog();
        }
    }
}
    
