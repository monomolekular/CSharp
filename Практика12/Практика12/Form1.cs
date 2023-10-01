using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Практика12
{
    public partial class Form1 : Form
    {
        private readonly Random _rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }
        
        // private List<string> OLDMakeNewCords()
        // {
        //     var toReturn = new List<string>();
        //     var tempX = _rnd.Next(1, 799);
        //     var tempY = _rnd.Next(1, 599);
        //     for (var i = tempX - 1; i != tempX + 2; i++)
        //     for (var j = tempY - 1; j != tempY + 2; j++)
        //     {
        //         var keyToCheck = tempX + "_" + tempY;
        //         toReturn.Add(keyToCheck);
        //     }
        //
        //     return toReturn;
        // }

        // private void OLDCreateStars(Graphics g)
        // {
        //     var starCounter = _rnd.Next(1000, 2000);
        //     var createdStars = 0;
        //     var usedCords = new Dictionary<string, bool>();
        //     while (createdStars < starCounter)
        //     {
        //         var condition = false;
        //         var newCordsx16 = new List<string>();
        //         while (!condition) // делает новые корды
        //         {
        //             var tempCordsx16 = OLDMakeNewCords();
        //             foreach (var key in tempCordsx16)
        //                 if (usedCords.ContainsKey(key))
        //                     break;
        //             newCordsx16 = tempCordsx16;
        //             condition = true;
        //         }
        //
        //         foreach (var key in newCordsx16)
        //             if (!usedCords.ContainsKey(key))
        //                 usedCords.Add(key, true);
        //         //осталось нарисовать :|
        //         var x1 = int.Parse(newCordsx16[5].Split('_')[0]);
        //         var y1 = int.Parse(newCordsx16[5].Split('_')[1]);
        //         g.DrawLine(Pens.White, x1, y1, x1 + 1, y1);
        //         g.DrawLine(Pens.White, x1, y1 + 1, x1 + 1, y1 + 1);
        //         createdStars += 1;
        //     }
        // }

        private double[] ChanceAdjustment(int korzinka,int k1 = 1, int k2 = 1, int k3 = 1, int k4 = 1)
        {
            double[] chanses = new double[4];
            int[] invert = new int[4];
            var temp = korzinka == 1 ? k1++ : korzinka == 2 ? k2++ : korzinka == 3 ? k3++ : korzinka > 4 ? 999 : k4++;
            
            int[] numbers = new[] {k1,k2,k3,k4};
            List<int> numbersSet = new List<int>();
            foreach (int iter in numbers)
            {
                if (numbersSet.Contains(iter))
                {
                    continue;
                }
                numbersSet.Add(iter);
            }
            numbersSet.Sort();
            int sum = 0;
            for (int i = 0; i < numbers.Length;i++)
            {
                int num = numbers[i];
                invert[i] = numbersSet[numbersSet.Count - 1 - numbersSet.FindIndex(n => n == num )];
                sum += invert[i];
            }
            double percentPerUnit = 100.0 / sum;
            for (int i = 0; i < numbers.Length;i++)
            {
                int num = numbers[i];
                chanses[i] = percentPerUnit * numbersSet[numbersSet.Count - 1 - numbersSet.FindIndex(n => n == num )];
            }
            
            return chanses;
        }
        
        private void CreateStars(Graphics g)
        {
            int numberOfStars = _rnd.Next(300, 500);
            int starsCounter = 0;
            var ms1 = CreateCordsMap(1);
            var ms2 = CreateCordsMap(2);
            var ms3 = CreateCordsMap(3);
            var ms4 = CreateCordsMap(4);
            var chances = ChanceAdjustment(5);
            int x;
            int y;
            while (starsCounter < numberOfStars)
            {
                int chance = _rnd.Next(1, 100);
                //if (chance <= chances[0]) 
                if (chance <= 34)
                {
                    int rand = _rnd.Next(0, ms1.Count);
                    chances = ChanceAdjustment(1);
                    x = (ms1[rand][0]);
                    y = (ms1[rand][1]);
                    g.DrawRectangle(Pens.White,x+1,y+1,1,1);
                    starsCounter++;
                }
                else if (chance <= 50)
                //else if (chance <= chances[0] + chances[1])
                {
                    int rand = _rnd.Next(0, ms2.Count);
                    chances = ChanceAdjustment(2);
                    x = (ms2[rand][0]);
                    y = (ms2[rand][1]);
                    g.DrawRectangle(Pens.White,x+1,y+1,1,1);
                    starsCounter++;
                }
                else if (chance <= 66)
                //else if (chance <= chances[0] + chances[1] + chances[2])
                {
                    int rand = _rnd.Next(0, ms3.Count);
                    chances = ChanceAdjustment(3);
                    x = (ms3[rand][0]);
                    y = (ms3[rand][1]);
                    g.DrawRectangle(Pens.White,x+1,y+1,1,1);
                    starsCounter++;
                }
                else
                {
                    int rand = _rnd.Next(0, ms4.Count);
                    chances = ChanceAdjustment(4);
                    x = (ms4[rand][0]);
                    y = (ms4[rand][1]);
                    g.DrawRectangle(Pens.White,x+1,y+1,1,1);
                    starsCounter++;
                }
            }
        }
        
        private List<int[]> CreateCordsMap(int checker)
        {
            List<int[]> cords = new List<int[]>();
            float y;
            switch (checker)
            {
                case 1:
                    for (int i=0; i < 55; i++)
                    {
                        for (int j=0; j < 99; j++)
                        {
                            int[] cord = new[] {i*4,j*4};
                            cords.Add(cord);
                        }
                    }
                    break;
                case 4:
                    for (int i=2; i < 57; i++)
                    {
                        for (int j=0; j < 99; j++)
                        {
                            int[] cord = new[] {i*4+475,j*4};
                            cords.Add(cord);
                        }
                    }
                    break;
                case 2:
                    for (int i=0; i < 31; i++)
                    {
                        y = -2f / 5 * (i*4+225) + 340;
                        for (int j=0; j < 62; j++)
                        {
                            if (j*4 + 8 >= y)
                            {
                                continue;
                            }
                            int[] cord = new[] {i*4+225,j*4};
                            cords.Add(cord);
                        }
                    }
                    break;
                case 3:
                    for (int i=0; i < 31; i++)
                    {
                        y = 2f / 5 * (i*4+350) + 60;
                        for (int j=0; j < 62; j++)
                        {
                            if (j*4 + 8 >= y)
                            {
                                continue;
                            }
                            int[] cord = new[] {i*4+350,j*4};
                            cords.Add(cord);
                        }
                    }
                    break;
            }
            return cords;
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.FillRectangle(Brushes.MidnightBlue, 0, 0, 800, 600); // небо
            //OLDCreateStars(g); // звёздачки))
            g.FillRectangle(Brushes.DarkGreen, 0, 400, 800, 200); // трава у дома
            g.DrawLine(Pens.Black, 0, 400, 800, 400);
            g.FillRectangle(Brushes.Brown, 225, 250, 249, 150); // стена дома
            g.DrawRectangle(Pens.Black, 225, 250, 249, 150); // рамка дома
            g.FillRectangle(Brushes.CornflowerBlue, 275, 300, 50, 50); // окно дома
            g.DrawRectangle(Pens.Black, 275, 300, 50, 50); // рамка окна дома
            g.DrawLine(Pens.Black, 300, 300, 300, 350); // вертикальная перегородка
            g.DrawLine(Pens.Black, 275, 325, 325, 325); // горизонтальная перегородка
            g.FillRectangle(Brushes.Peru, 375, 300, 50, 100);
            g.DrawRectangle(Pens.Black, 375, 300, 50, 100);
            g.FillEllipse(Brushes.Gold, 415, 350, 5, 5);
            DrawRoof(g); // крышу запилить
            CreateStars(g);
        }

        private void DrawRoof(Graphics g)
        {
            var i1 = 225;
            var j1 = 250;
            var i2 = 349;
            var j2 = 200;
            while (i1 != i2 && j2 != j1)
            {
                g.DrawLine(Pens.Gold, i1, j1, i2, j2);
                i1++;
                j2++;
            }

            i1 = 474;
            j1 = 250;
            i2 = 350;
            j2 = 200;
            while (i1 != i2 && j2 != j1)
            {
                g.DrawLine(Pens.Gold, i1, j1, i2, j2);
                i1--;
                j2++;
            }

            // завершающий штришок))))
            g.DrawLine(Pens.Black, 225, 250, 474, 250); // нижняя
            g.DrawLine(Pens.Black, 225, 250, 349, 200); // левая 
            g.DrawLine(Pens.Black, 350, 200, 474, 250); // правая
        }
    }
}