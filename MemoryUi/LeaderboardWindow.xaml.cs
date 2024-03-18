using System.Collections.Generic;
using System.Windows;
using MemoryBusiness;
using MemoryDatabase;

namespace MemoryUi;

public partial class LeaderboardWindow : Window
{
    
    private List<Player> leaderboard;
    
    
    public LeaderboardWindow()
    {
        InitializeComponent();
        DataBaseManager db = new DataBaseManager();
        leaderboard = db.Results();
        DataContext = leaderboard;
    }

    private void BackButton_Click(object sender, RoutedEventArgs e)
    {
        Hoofdscherm mainWindow = new Hoofdscherm();
        mainWindow.Show();
        Close();
    }
}