using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TournamentGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int _participantCouner = 8;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int columns = (int)Math.Log2(_participantCouner) + 1;
            for (int i = 0; i < columns; i++)
            {
                ColumnDefinition columnDefinition = new ColumnDefinition();
                TournamentGrid.ColumnDefinitions.Add(columnDefinition);

                int lines = (int)(_participantCouner / (Math.Pow(2, i)));
                Grid subGrid = new Grid();
                subGrid.ShowGridLines = true;
                for (int j = 0; j < lines; j++)
                {
                    RowDefinition rowDefinition = new RowDefinition();
                    subGrid.RowDefinitions.Add(rowDefinition);

                    TournamentCell cell = new TournamentCell();
                    TournamentCellViewModel viewModel = new TournamentCellViewModel()
                    {
                        TextBlockText = "Участник",
                        IsChecked = false,
                    };
                    cell.DataContext = viewModel;
                    Grid.SetColumn(cell, 0);
                    Grid.SetRow(cell, j);
                    subGrid.Children.Add(cell);
                }
                Grid.SetColumn(subGrid, i);
                TournamentGrid.Children.Add(subGrid);
            }
        }
    }
}