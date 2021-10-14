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
    /// Lógica interna para Cadastraeventonov.xaml
    /// </summary>
    public partial class Cadastraeventonov : Window
    {
        public Cadastraeventonov()
        {
            InitializeComponent();
        }

        private void BntSalvar_Click(object sender, RoutedEventArgs e)
        {
            Evento evento = new Evento();

            evento.Titulo = txbTitulo.Text;
            //Falta adicionar uma caixa para descrição, adicionar na próxima commit
            evento.Descricao = "Audiência Teste";
            evento.Horario = txbHorario.Text;
            evento.Data = (DateTime)datepickerDataServico.SelectedDate;
            evento.Importancia = txbImportancia.Text;

            if (rbNotificacao.IsChecked.Value)
            {
                evento.Notificacao = true;
            }
            else
            {
                evento.Notificacao = false;
            }

            EventoDAO eventoDAO = new EventoDAO();
            eventoDAO.Insert(evento);
            MessageBox.Show("O Evento foi registrado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
