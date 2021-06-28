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
    /// Lógica interna para BuscarCliente.xaml
    /// </summary>
    public partial class BuscarCliente : Window
    {
        public BuscarCliente()
        {
            InitializeComponent();
            Loaded += BuscarCliente_Loaded;
        }

        public void BuscarCliente_Loaded(object sender, RoutedEventArgs e)
        {
            List<Cliente> listaCliente = new List<Cliente>();

            for (int i = 0; i < 30; i++)
            {
                listaCliente.Add(new Cliente()
                {
                    Id = i + 1,
                    Nome = "Joãozinho - " + i,
                    Cpf = "304980239-01",
                    Rg = "0394802",
                });
            }

            //Está dando um erro nesta linha, descobrir o que é!!
            dataGridBuscarCliente.ItemsSource = listaCliente;
        }
    }
}
