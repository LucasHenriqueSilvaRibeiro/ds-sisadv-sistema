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
    /// Lógica interna para Cadastrarlucro.xaml
    /// </summary>
    public partial class Cadastrarlucro : Window
    {
        public Cadastrarlucro()
        {
            InitializeComponent();
            Loaded += Cadastrarlucro_Loaded;
        }
        public void Cadastrarlucro_Loaded(object sender, RoutedEventArgs e)
        {
            List<Lucro> listadeLucro = new List<Lucro>();

            for (int i = 0; i < 10; i++)
            {
                listadeLucro.Add(new Lucro()
                {
                    Valor = i + 10,
                });
            }
            gridcadastrarlucro.ItemsSource = listadeLucro;
        }
    }
}
