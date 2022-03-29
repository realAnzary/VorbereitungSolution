namespace Backend_7
{
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    public partial class MainWindow : Window
    {
        private char[,] field = new char[3, 3];
        private bool gameOver;
        private int turn;

        public MainWindow()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            field = new char[3, 3];
            gameOver = false;
            turn = 1;
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = (SolidColorBrush?)new BrushConverter().ConvertFrom("#FF525252");
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (gameOver || turn == 10)
            {
                StartGame();
                return;
            }

            if (btn.Content == string.Empty)
            {
                char symbol = (turn % 2 != 0) ? 'X' : 'O';
                btn.Content = symbol;
                field[Grid.GetColumn(btn), Grid.GetRow(btn)] = symbol;
                turn++;
                CheckWinner();
            }
        }

        private void CheckWinner()
        {
            var btnList = Container.Children.Cast<Button>().ToList();

            for (int i = 0; i < 3; i++)
            {
                if (CheckEqual(field[i, 0], field[i, 1], field[i, 2]) && !gameOver)
                {
                    btnList[0 + (i * 3)].Background = Brushes.Green;
                    btnList[1 + (i * 3)].Background = Brushes.Green;
                    btnList[2 + (i * 3)].Background = Brushes.Green;
                    gameOver = true;
                }

                if (CheckEqual(field[0, i], field[1, i], field[2, i]) && !gameOver)
                {
                    btnList[(0 * 3) + i].Background = Brushes.Green;
                    btnList[(1 * 3) + i].Background = Brushes.Green;
                    btnList[(2 * 3) + i].Background = Brushes.Green;
                    gameOver = true;
                }
            }

            if (!gameOver && CheckEqual(field[0, 0], field[1, 1], field[2, 2]))
            {
                btnList[0].Background = Brushes.Green;
                btnList[4].Background = Brushes.Green;
                btnList[8].Background = Brushes.Green;
                gameOver = true;
            }

            if (!gameOver && CheckEqual(field[0, 2], field[1, 1], field[2, 0]))
            {
                btnList[2].Background = Brushes.Green;
                btnList[4].Background = Brushes.Green;
                btnList[6].Background = Brushes.Green;
                gameOver = true;
            }
        }

        public bool CheckEqual(char a, char b, char c)
        {
            return a == b && b == c && a != '\0';
        }
    }
}
