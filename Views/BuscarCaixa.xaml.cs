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
    /// Lógica interna para BuscarCaixa.xaml
    /// </summary>
    public partial class BuscarCaixa : Window
    {
        public BuscarCaixa()
        {
            InitializeComponent();
        }

        private void Btn_Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Pesquisar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdicionarNovocaixa_Click(object sender, RoutedEventArgs e)
        {
            Cadastrarcaixa cadastrarcaixa = new Cadastrarcaixa();
            cadastrarcaixa.ShowDialog();
        }
    }
}
