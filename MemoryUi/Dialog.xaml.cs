using System;
using System.Windows;

namespace MemoryUi;

public partial class Dialog : Window
{
    public Dialog()
    {
        InitializeComponent();
    }
    
    private void OK_Click(object sender, RoutedEventArgs e)
    {
        string name = nameTextBox.Text;
        string pairs = pairsTextBox.Text.Trim();
        if (CheckName(name) && CheckPairs(pairs))
        {
            int.TryParse(pairs, out int cardAmount);
            Gamewindow gameWindow = new Gamewindow(name, cardAmount);
            gameWindow.Show();
            Close();
        }
        else
        {
            MessageBox.Show("De naam is niet 3 tekens lang of de pairs is niet minimaal 5 max 10");
        }
    }
    
    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        Hoofdscherm mainWindow = new Hoofdscherm();
        mainWindow.Show();
        Close();
    }
    
    private bool CheckName(string name)
    {
        if (name == null || name.Length < 3) return false;
        else return true;
    }

    private bool CheckPairs(string amount)
    {
        if (int.TryParse(amount, out int cardAmount))
        {
            if (cardAmount >= 5 && cardAmount <= 10)
            {
                return true;
            }
        }
        return false;
    }
    
    
}