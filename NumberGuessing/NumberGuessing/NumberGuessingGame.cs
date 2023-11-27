using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace NumberGuessing
{
    public partial class NumberGuessingGame : Form
    {

        private int count = 0;
        private int number = 0;
        private List<int> guessedNumbers = new List<int>();
        private Player player;
        private Games game;
        PlayerDAO playerDAO = new PlayerDAO();
        GameDAO gameDAO = new GameDAO();
        int gameID = 0;
        public NumberGuessingGame()
        {
            string pname = Interaction.InputBox("Please enter your name", "Welcome!", "Player name: ", -1, -1);
            if (string.IsNullOrEmpty(pname))
            {
                MessageBox.Show("Please enter your name!");
                this.Close();
                return;
            }
            
            if (playerDAO.checkName(pname) != null)
            {
                player = getPlayerInfo(pname);
            }
            else
            {
                player = new Player(pname, 0, 0, 0);
                playerDAO.Add(player);
                player=getPlayerInfo(pname);                
            }
            InitializeComponent();
            player.PlayCount++;
            loadNum(1, 100);
            game = new Games(player.PlayerID, 0, 0, "NA");
            gameID = gameDAO.Add(game);

        }
        private Player getPlayerInfo(string pname)
        {
            Player playertemp = new Player();
            playertemp.PlayerID = playerDAO.checkName(pname).Value;
            playertemp.PlayCount = playerDAO.getPlayCount(pname).Value;
            playertemp.WinCount = playerDAO.getWinCount(pname).Value;
            playertemp.LoseCount = playerDAO.getLoseCount(pname).Value;
            return playertemp;
        }

        private void txtInput_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
        }
        private void loadNum(int n1, int n2)
        {
            Games g=new Games();
            number = g.getRandomNum(n1, n2);
            MessageBox.Show("The number is"+number);
            
        }
        private bool IsValidNumber(string input)
        {
            int temp;
            if (int.TryParse(input, out temp))
            {
                return temp >= 1 && temp <= 100;
            }
            return false;

        }
        private void EndGame(string winorlose)
        {
            var result = MessageBox.Show("Do you want to continue?", "Game Over", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                loadNum(1, 100);
                
                count = 0;
                guessedNumbers.Clear();
                player.PlayCount++;
                lblGuess.Text = "You guessed " + count + " times";
                game = new Games(player.PlayerID, 0, 0, "NA");
                gameID = gameDAO.Add(game);
            }
            else
            {
                update(winorlose);
                this.Close();
            }
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {

            if (IsValidNumber(txtInput.Text))
            {
                string winorlose="";
                int i = Convert.ToInt32(txtInput.Text);
                if (guessedNumbers.Contains(i))
                {
                    MessageBox.Show("You have already guessed this number!");
                    txtInput.Text = "";
                }
                else
                {
                    guessedNumbers.Add(i);
                    count += 1;
                    if (i == number)
                    {
                        if (count <= 3)
                        {
                            lblGuess.Text = "You guessed " + count + " times";
                            MessageBox.Show("You are a lucky person today!");
                            winorlose = "win";
                            game.GuessCount = count;
                            player.WinCount += 1;
                            update(winorlose);
                            EndGame(winorlose);
                                                   
                        }
                        else
                        {
                            lblGuess.Text = "You guessed " + count + " times";
                            MessageBox.Show("Great guess!");
                            winorlose = "win";
                            game.GuessCount = count;
                            player.WinCount += 1;
                            update(winorlose);
                            EndGame(winorlose);                            
                                                   
                        }
                    }
                    else if (count >= 10)
                    {
                        lblGuess.Text = "You guessed " + count + " times";
                        MessageBox.Show("You lost!");
                        game.GuessCount = count;
                        player.LoseCount += 1;
                        winorlose = "lose";
                        update(winorlose);
                        EndGame(winorlose);                        
                                              
                    }
                    else if (i < number)
                    {
                        if ((number - i) <= 10)
                        {
                            MessageBox.Show("You are so close! A little bit higher!");

                        }
                        else if ((number - i) < 30)
                        {
                            MessageBox.Show("Just a little bit more! higher!");
                        }
                        else
                        {
                            MessageBox.Show("Try to highest you can think!");
                        }
                    }
                    else
                    {
                        if ((i - number) <= 10)
                        {
                            MessageBox.Show("You are so close! A little bit lower!");
                        }
                        else if ((i - number) < 30)
                        {
                            MessageBox.Show("Just a little bit lower!");
                        }
                        else
                        {
                            MessageBox.Show("Try to lowest you can think!");
                        }
                    }
                    update(winorlose);
                    txtInput.Text = "";
                    lblGuess.Text = "You guessed " + count + " times";
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number from 1 to 100!");
            }
        }
        
        private void update(string winorlose)
        {
            Player p = new Player(player.PlayCount, player.WinCount, player.LoseCount, player.PlayerID);
            playerDAO.Update(p);
            game = new Games(game.GuessCount, number, winorlose, gameID);
            gameDAO.Update(game);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game stopped, the correct number is: " + number);
            game.GuessCount = count;
            player.LoseCount++;
            string winorlose = "lose";
            update(winorlose);
            EndGame(winorlose);
        }
    }
}
