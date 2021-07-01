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

namespace SisAdv
{
    /// <summary>
    /// Lógica interna para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btacessar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void btnovousuario_Click(object sender, RoutedEventArgs e)
        {
            CadastrarNovoUsuario cadastrarNovoUsuario = new CadastrarNovoUsuario();
            this.Close();
            cadastrarNovoUsuario.ShowDialog();
        }

        private void bttrocarsenha_Click(object sender, RoutedEventArgs e)
        {
            AlterarSenha alterarSenha = new AlterarSenha();

            alterarSenha.ShowDialog();
        }
    }
}
