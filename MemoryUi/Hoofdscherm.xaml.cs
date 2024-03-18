using System.Windows;
using MemoryDatabase;

namespace MemoryUi;

public partial class Hoofdscherm : Window
{
    public Hoofdscherm() => InitializeComponent();
    public void CreateDB()
    {
        DataBaseManager db = new DataBaseManager();
        db.CreateDBIfNotExcisted();
    }

    private void PlayButton_Click(object sender, RoutedEventArgs e)
    {
        Dialog dia = new Dialog();
        dia.Show();
        CreateDB();
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