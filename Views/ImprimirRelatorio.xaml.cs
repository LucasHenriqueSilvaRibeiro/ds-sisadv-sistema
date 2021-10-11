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
    /// Lógica interna para ImprimirRelatorio.xaml
    /// </summary>
    public partial class ImprimirRelatorio : Window
    {
        public ImprimirRelatorio()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            //Abrir explorador de arquivos para salvar o relatório (por enquanto vou deixar somente uma mensagem)
            MessageBox.Show("Explorador de Arquivos Aberto", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
    }
}
