using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberGuessing
{
    public partial class Form1 : Form
    {
        Random Random=new Random();
        int count = 0;
        int number = 0;
        public Form1()
        {
            InitializeComponent();
            loadNum(1, 100);
        }

        private void txtInput_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
        }
        private void loadNum(int n1, int n2)
        {
            number = Random.Next(n1, n2);
            
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            int i=Convert.ToInt32(txtInput.Text);
            count += 1;
            lblGuess.Text = "You guessed "+count+" times";
            if (count < 10)
            {
                if (i == number)
                {
                    if (count <= 3)
                    {
                        MessageBox.Show("You are a lucky person today!");
                        loadNum(1, 100);
                        txtInput.Text = "";
                        count = 0;
                    }
                    else
                    {
                        MessageBox.Show("Great guess!");
                        loadNum(1, 100);
                        txtInput.Text = "";
                        count = 0;
                    }
                }
                else if (i < number)
                {
                    if ((number - i) <= 10)
                    {
                        MessageBox.Show("You are so close! A little bit higher!");
                        txtInput.Text = "";
                    }
                    else if ((number - i) < 30)
                    {
                        MessageBox.Show("Just a little bit more! higher!");
                        txtInput.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Try to highest you can think!");
                        txtInput.Text = "";
                    }
                }
                else
                {
                    if ((i - number) <= 10)
                    {
                        MessageBox.Show("You are so close! A little bit lower!");
                        txtInput.Text = "";
                    }
                    else if ((i - number) < 30)
                    {
                        MessageBox.Show("Just a little bit lower!");
                        txtInput.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Try to lowest you can think!");
                        txtInput.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("You lost!");
                loadNum(1, 100);
                txtInput.Text = "";
                count = 0;
            }
            

        }
    }
}
