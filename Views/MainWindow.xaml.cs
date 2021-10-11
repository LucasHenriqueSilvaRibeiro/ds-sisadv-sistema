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
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
           List<Servico> listaServicos = new List<Servico>();

            for (int i = 0; i < 30; i++)
            {
                listaServicos.Add(new Servico()
                {
                    Id = i + 1,
                    Cliente = "Clientão - " + i,
                    Valor = 5 * i,
                    Descricao = "Caso Civil" + 1,
                });
            }

            //Está dando um erro nesta linha, descobrir o que é!!
            dataGridServicosRecentes.ItemsSource = listaServicos;
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

            configurarPreferenciasRecursos.ShowDialog();
        }
    }
    }
    
