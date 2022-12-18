using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayinTarlasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Usual MineField game
            InitializeComponent();
           
            int counter = 0;
            int safeCount = 0;
            List<int> mayin = new List<int>();

            Random rnd = new Random();
            while (mayin.Count < 10)
            {
                
                int may = rnd.Next(0, 54);
                if (!mayin.Contains(may))
                {
                    mayin.Add(may);
                }
                //Mayınların hangi sayıdaki butonlarda olması gerektiğini belirleyen kısım
            }
            for (int i = 0; i < 54; i++)
            {
                // Button creation area
                Button button1 = new Button();
                button1.Location = new System.Drawing.Point(3, 3);
                button1.Name = "*";
                button1.Size = new System.Drawing.Size(42, 45);
                button1.TabIndex = i;
                button1.TabStop = false; // Makes the tab order disable
                button1.Image = Image.FromFile(@"C:\Users\MAHMUT\Desktop\may.png");
                button1.Tag = null;
                button1.Click += Bttn_Clilck;
                button1.Text = "*";
                button1.UseVisualStyleBackColor = true;
                flowLayoutPanel1.Controls.Add(button1);


                if (mayin.Contains(i))
                { // Mine creation area
                    button1.Tag = 1;
                }
            }

            void Bttn_Clilck(object sender, EventArgs e)
            { //  Button clicked events
                Button cilcked = (Button)sender;
                object o = cilcked.Tag;
                if (o != null)
                { // if the clicked button is a mine this progress will  be executed
                    cilcked.BackColor = Color.Red;
                    cilcked.Enabled = false;
                    Console.Beep(1500, 400);
                    counter++;
                }
                else
                { // if clicked button is not a mine this progress will be executed
                    safeCount++;
                    cilcked.Enabled = false;
                }

                if (counter == 3)
                {// if player clicks 3 mine game overs
                    MessageBox.Show("YOU LOST :(");
                    this.Close();
                }
                else if (safeCount == 46)
                {
                    // if player cilcks less than 3 mine and all clear buttons are clicked player wins
                    MessageBox.Show("YOU WON !");
                }
            }
        }
    }
}
