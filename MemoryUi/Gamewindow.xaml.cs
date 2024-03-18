using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MemoryBusiness;
using MemoryDatabase;

// using MemoryDatabase;

namespace MemoryUi
{
    public partial class Gamewindow : Window
    {
        private Button? firstButton { get; set; }
        private MemoryGame game { get; set; }
        private Card? card1 { get; set; }
        private DataBaseManager DBM = new DataBaseManager();

        public Gamewindow(string naam, int paren)
        {
            InitializeComponent();

            game = new MemoryGame(naam);
            game.StartGame(paren,false);

            if (game?.gameBoard.cards == null) return;
            foreach (var card in game.gameBoard.cards)
            {
                // Create a new Button for each card.
                var cardButton = new Button
                {
                    Width = 120,
                    Height = 120,
                    Margin = new Thickness(10),
                    Tag = card,
                    Background = Brushes.Aqua,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(5),
                    FontSize = 35
                };
                

                cardButton.Click += Button_Click;
                cardsContainer.Items.Add(cardButton);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                Card choice = (Card)button.Tag;
                
                if (!choice.IsFaceUP)
                {
                    if (firstButton == null)
                    {
                        card1 = (Card)button.Tag;
                        card1.IsFaceUP = true;
                        button.Content = card1.Identifier;
                        firstButton = button;
                    }
                    else
                    {
                        var b = (Card)button.Tag;
                        button.Content = b.Identifier;
                    
                        if (card1 != null && game.CardCheck(card1, b))
                        {
                            Console.WriteLine("Deze zijn gelijk");
                            firstButton = null;
                            card1 = null;
                            if (game.gameBoard.AllCardsAreFaceUp())
                            {
                                Console.WriteLine("De game is voorbij");
                                
                                game.State.CurrentPlayer.Playerscore = game.CalculateScore();
                                
                               DBM.InsertResult(game.State.CurrentPlayer);
                               MessageBox.Show($"{game.State.CurrentPlayer.PlayerName} je hebt een score behaald van {game.State.CurrentPlayer.Playerscore} met {game.State.CurrentPlayer.Moves} aantal beurten");
                               
                               Hoofdscherm mainWindow = new Hoofdscherm();
                               mainWindow.Show();
                               Close();
                            }
                        } else
                        {
                            Task.Delay(500).ContinueWith(_ =>
                            {
                                Dispatcher.Invoke(() =>
                                {
                                    button.Content = "";
                                    firstButton.Content = "";
                                    firstButton = null;
                                    card1 = null;
                                    
                                    
                                });
                            });
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Sorry deze kaart is al ingedrukt");
                }
            }
        } 
        
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Hoofdscherm mainWindow = new Hoofdscherm();
            mainWindow.Show();
            Close();
            
        }
    }
}



          
            