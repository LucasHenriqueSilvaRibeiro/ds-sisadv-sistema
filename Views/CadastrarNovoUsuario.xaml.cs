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
    /// Lógica interna para CadastrarNovoUsuario.xaml
    /// </summary>
    public partial class CadastrarNovoUsuario : Window
    {
        private Usuario _usuario; 

        public CadastrarNovoUsuario()
        {
            InitializeComponent();
            Loaded += CadastrarNovoUsuario_Loaded;            
        }

        private void CadastrarNovoUsuario_Loaded(object sender, RoutedEventArgs e)
        {
            _usuario = new Usuario();
            LoadCombobox();
        }

        private void BtnSalvarUsuario_Click(object sender, RoutedEventArgs e)
        {
            /*fazer validações

            if(TxbLogin.Text != null)
                _usuario.NomeUser = TxbLogin.Text;
            else
                MessageBox.Show("Preencha o campo Login. Verifique e tente novamente.", "Alerta", MessageBoxButton.OK, MessageBoxImage.Warning);

            if (PassConfirmarSenha.Password == PassSenha.Password)
                _usuario.Senha = PassSenha.Password;
            else
                MessageBox.Show("As senhas estão diferentes. Verifique e tente novamente.", "Alerta", MessageBoxButton.OK, MessageBoxImage.Warning);*/

            _usuario.NomeUser = TxbLogin.Text;
            _usuario.Senha = PassSenha.Password;
            _usuario.Advogado = ComboboxAdvogado.SelectedItem as Advogado;

            SaveData();

            ChamarTelaPrincipal();
        }

        private void ChamarTelaPrincipal()
        {
            Login login = new Login();
            login.ShowDialog();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }        

        public void SaveData()
        {
            var dao = new UsuarioDAO();

            dao.Insert(_usuario);

            MessageBox.Show($"Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }
        private void LoadCombobox()
        {
            ComboboxAdvogado.ItemsSource = new AdvogadoDAO().List();
        }
    }
}
