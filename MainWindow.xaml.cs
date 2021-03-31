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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThirdVoyage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //state is stored inside the string, this is where the user would enter their text

        private string state;
        private Caretaker ct = new Caretaker();
        private Stack<DateTime> timeStamps = new Stack<DateTime>();
        
        public MainWindow()
        {
            InitializeComponent();
            state = txbContent.Text;
        }

        //The save button "Commits the changes made"
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            saveToMemento();
        }

        public Memento saveToMemento() 
        {
            state = txbContent.Text;
            return new Memento(state);
        }

        public void getStateFromMemento(Memento memento) 
        {
            state = memento.State;
            txbContent.Text = state;
        }

        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            Memento m = ct.GetMemento();
            getStateFromMemento(m);
            lblStatus.Content = $"Status : Reverted content to {timeStamps.Pop()}";
        }

        private void txbContent_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Space || e.Key == Key.OemPeriod)
            {
                ct.add(saveToMemento());
                timeStamps.Push(DateTime.Now);
                lblStatus.Content = $"Status : Last Saved at {timeStamps.Peek()}";
            }
        }

        private void btnRedo_Click(object sender, RoutedEventArgs e)
        {
            Memento m = ct.pullQueue();
            getStateFromMemento(m);
        }
    }
}
