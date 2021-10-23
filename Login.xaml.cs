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
            string usuario = "srde";//TxbLogin.Text;
            string senha = "123";//PassWord.Password.ToString();

            if (Models.Usuario.Login(usuario, senha))
            {
                var main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario e/ou senha incorretos! Tente novamente", "Autorização negada", MessageBoxButton.OK, MessageBoxImage.Warning);
                _ = TxbLogin.Focus();
            }
        }

        private void bttrocarsenha_Click(object sender, RoutedEventArgs e)
        {
            AlterarSenha alterarSenha = new AlterarSenha();

            alterarSenha.ShowDialog();
        }
    }
}
