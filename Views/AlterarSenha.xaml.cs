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
    /// Lógica interna para AlterarSenha.xaml
    /// </summary>
    public partial class AlterarSenha : Window
    {
        public AlterarSenha()
        {
            InitializeComponent();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Confirme o e-mail que será enviado!", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
