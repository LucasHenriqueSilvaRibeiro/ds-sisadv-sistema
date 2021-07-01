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
    /// Lógica interna para CadastrarDespesa.xaml
    /// </summary>
    public partial class CadastrarDespesa : Window
    {
        public CadastrarDespesa()
        {
            InitializeComponent();
            Loaded += CadastrarDespesa_Loaded;
        }

        public void CadastrarDespesa_Loaded(object sender, RoutedEventArgs e)
        {
            List<Despesa> listaDespesa = new List<Despesa>();

            for (int i = 0; i < 10; i++)
            {
                listaDespesa.Add(new Despesa()
                {
                    Valor = i + 10,
                });
            }

            gridcadastrardespesa.ItemsSource = listaDespesa;
        }
    }
}
