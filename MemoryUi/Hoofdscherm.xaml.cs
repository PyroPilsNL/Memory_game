using System.Windows;

namespace MemoryUi;

public partial class Hoofdscherm : Window
{
    public Hoofdscherm() => InitializeComponent();

    private void PlayButton_Click(object sender, RoutedEventArgs e)
    {
        Dialog dia = new Dialog();
        dia.Show();
        Close();
    }

    private void LeaderboardButton_Click(object sender, RoutedEventArgs e)
    {
        LeaderboardWindow leaderboardWindow = new LeaderboardWindow();
        leaderboardWindow.Show();
        Close();
    }
    private void QuitButton_Click(object sender, RoutedEventArgs e) => Close();
}