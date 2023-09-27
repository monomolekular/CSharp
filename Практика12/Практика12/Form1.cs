using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Практика12
{
    public partial class Form1 : Form
    {
        private readonly Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private List<string> makeNewCords()
        {
            var toReturn = new List<string>();
            var tempX = rnd.Next(1, 799);
            var temp2x = tempX + 1;
            var tempY = rnd.Next(1, 599);
            var temp2y = tempY + 1;
            for (var i = tempX - 1; i != tempX + 2; i++)
            for (var j = tempY - 1; j != tempY + 2; j++)
            {
                var keyToCheck = tempX + "_" + tempY;
                toReturn.Add(keyToCheck);
            }

            return toReturn;
        }

        private void CreateStars(Graphics g)
        {
            var starCounter = rnd.Next(1000, 2000);
            var createdStars = 0;
            var usedCords = new Dictionary<string, bool>();
            while (createdStars < starCounter)
            {
                var condition = false;
                var newCordsx16 = new List<string>();
                while (!condition) // делает новые корды
                {
                    var tempCordsx16 = makeNewCords();
                    foreach (var key in tempCordsx16)
                        if (usedCords.ContainsKey(key))
                            break;
                    newCordsx16 = tempCordsx16;
                    condition = true;
                }

                foreach (var key in newCordsx16)
                    if (!usedCords.ContainsKey(key))
                        usedCords.Add(key, true);
                //осталось нарисовать :|
                var x1 = int.Parse(newCordsx16[5].Split('_')[0]);
                var y1 = int.Parse(newCordsx16[5].Split('_')[1]);
                g.DrawLine(Pens.White, x1, y1, x1 + 1, y1);
                g.DrawLine(Pens.White, x1, y1 + 1, x1 + 1, y1 + 1);
                createdStars += 1;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.FillRectangle(Brushes.MidnightBlue, 0, 0, 800, 600); // небо
            CreateStars(g); // звёздачки))
            g.FillRectangle(Brushes.DarkGreen, 0, 400, 800, 200); // трава у дома
            g.DrawLine(Pens.Black, 0, 400, 800, 400);
            g.FillRectangle(Brushes.Brown, 225, 250, 250, 150); // стена дома
            g.DrawRectangle(Pens.Black, 225, 250, 250, 150); // рамка дома
            g.FillRectangle(Brushes.CornflowerBlue, 275, 300, 50, 50); // окно дома
            g.DrawRectangle(Pens.Black, 275, 300, 50, 50); // рамка окна дома
            g.DrawLine(Pens.Black, 300, 300, 300, 350); // вертикальная перегородка
            g.DrawLine(Pens.Black, 275, 325, 325, 325); // горизонтальная перегородка
            g.FillRectangle(Brushes.Peru, 375, 300, 50, 100);
            g.DrawRectangle(Pens.Black, 375, 300, 50, 100);
            g.FillEllipse(Brushes.Gold, 415, 350, 5, 5);
            DrawRoof(g); // крышу запилить
        }

        private void DrawRoof(Graphics g)
        {
            var i1 = 225;
            var j1 = 250;
            var i2 = 350;
            var j2 = 200;
            //g.DrawLine(Pens.Black, i1,j1,i2,j2);
            while (i1 != i2 && j2 != j1)
            {
                g.DrawLine(Pens.Gold, i1, j1, i2, j2);
                i1++;
                j2++;
            }

            i1 = 475;
            j1 = 250;
            i2 = 350;
            j2 = 200;
            //g.DrawLine(Pens.Black, i1,j1,i2,j2);
            while (i1 != i2 && j2 != j1)
            {
                g.DrawLine(Pens.Gold, i1, j1, i2, j2);
                i1--;
                j2++;
            }

            // завершающий штришок))))
            g.DrawLine(Pens.Black, 225, 250, 475, 250); // нижняя
            g.DrawLine(Pens.Black, 225, 250, 350, 200); // левая 
            g.DrawLine(Pens.Black, 350, 200, 475, 250); // правая
        }
    }
}