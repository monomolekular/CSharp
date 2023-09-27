using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ВтораяЧасть12Пр
{
    public class Program : Form
    {
        private static readonly int pixelsPerUnit = 5;
        private static string defaultProgram = "1";
        private static bool madeAction;

        public Program()
        {
            InitializeComponent();
        }

        public static void Main(string[] args)
        {
            //Console.Write(Console.Read());
            Console.WriteLine(
                "Вас приветсвтует программа, разработанная Гусевым Александром Сергеевичем, обучающимся группы КМБО-01-23");
            Console.WriteLine("Для выбора дальнейших действий введите в командную строку одну из следующих цифр:");
            Console.WriteLine(
                "1) Нарисовать отрезок по двум координатам \n2) Нарисовать прямоугольник по двум координатам противоположенных вершин \n3) Нарисовать круг по координатам центра и радиусу \n4) Нарисовать равносторонний треугольник по координатам одной вершины(левой) и высоте");
            defaultProgram = Console.ReadLine().TrimEnd(')');
            Application.Run(new Program());
        }

        private void Program_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            DrawAxis(g);
            if (!madeAction)
                switch (defaultProgram)
                {
                    case "1":
                        DrawLineByCords(g);
                        break;
                    case "2":
                        DrawRectangleByCords(g);
                        break;
                    case "3":
                        DrawCircleByCords(g);
                        break;
                    case "4":
                        DrawTriangleByCords(g);
                        break;
                }
        }

        private void DrawAxis(Graphics g)
        {
            g.DrawLine(Pens.Black, 500, 0, 500, 1000);
            g.DrawLine(Pens.Black, 0, 500, 1000, 500);
            for (var i = 0; i < 1000; i += pixelsPerUnit)
            {
                g.DrawLine(Pens.Black, 499, i, 501, i);
                g.DrawLine(Pens.Black, i, 499, i, 501);
            }
        }

        private void DrawLineByCords(Graphics g)
        {
            Console.WriteLine("Введите координаты в формате: `x1;y1 x2;y2`");
            var cords = Console.ReadLine().Split(' ');
            var x1 = 500 + int.Parse(cords[0].Split(';')[0]) * pixelsPerUnit;
            var y1 = 500 + -1 * int.Parse(cords[0].Split(';')[1]) * pixelsPerUnit;
            var x2 = 500 + int.Parse(cords[1].Split(';')[0]) * pixelsPerUnit;
            var y2 = 500 + -1 * int.Parse(cords[1].Split(';')[1]) * pixelsPerUnit;
            g.DrawLine(Pens.Red, x1, y1, x2, y2);
            madeAction = true;
        }

        private void DrawRectangleByCords(Graphics g)
        {
            Console.WriteLine("Введите координаты в формате: `x1;y1 x2;y2`");
            var cords = Console.ReadLine().Split(' ');
            var x1 = 500 + int.Parse(cords[0].Split(';')[0]) * pixelsPerUnit;
            var y1 = 500 + -1 * int.Parse(cords[0].Split(';')[1]) * pixelsPerUnit;
            var x2 = 500 + int.Parse(cords[1].Split(';')[0]) * pixelsPerUnit;
            var y2 = 500 + -1 * int.Parse(cords[1].Split(';')[1]) * pixelsPerUnit;
            var width = Math.Abs(x2 - x1);
            var heigh = Math.Abs(y2 - y1);
            var coolCordX = x1;
            var coolCordY = y1;
            if (x1 > x2) coolCordX = x2;
            if (y1 > y2) coolCordY = y2;
            g.DrawRectangle(Pens.Red, coolCordX, coolCordY, width, heigh);
            madeAction = true;
        }

        private void DrawCircleByCords(Graphics g)
        {
            Console.WriteLine("Введите координаты в формате: `x;y R`");
            var cords = Console.ReadLine().Split(' ');
            var x1 = 500 + int.Parse(cords[0].Split(';')[0]) * pixelsPerUnit;
            var y1 = 500 + -1 * int.Parse(cords[0].Split(';')[1]) * pixelsPerUnit;
            var r = int.Parse(cords[1].Split(';')[0]) * pixelsPerUnit;
            var tempCordX = x1 - r;
            var tempCordY = y1 - r;
            g.DrawEllipse(Pens.Red, tempCordX, tempCordY, 2 * r, 2 * r);
            madeAction = true;
        }

        private void DrawTriangleByCords(Graphics g)
        {
            Console.WriteLine("Введите координаты в формате: `x;y H`");
            var cords = Console.ReadLine().Split(' ');
            var x1 = 500 + int.Parse(cords[0].Split(';')[0]) * pixelsPerUnit;
            var y1 = 500 + -1 * int.Parse(cords[0].Split(';')[1]) * pixelsPerUnit;
            var h = int.Parse(cords[1]) * pixelsPerUnit;
            var side = (float)Math.Sqrt(4 * Math.Pow(h, 2) / 3);
            Console.WriteLine(side);
            var x2 = side / 2 + x1;
            var y2 = y1 - h;
            var p = Pens.Red;
            g.DrawLine(p, x1, y1, x2, y2);
            g.DrawLine(p, x1 + side, y1, x2, y2);
            g.DrawLine(p, x1, y1, x1 + side, y1);
            madeAction = true;
        }

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            var resources = new ComponentResourceManager(typeof(Program));
            SuspendLayout();
            // 
            // Program
            // 
            AutoScaleMode = AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            AutoValidate = AutoValidate.Disable;
            BackColor = SystemColors.Window;
            CausesValidation = false;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Program";
            Paint += Program_Paint;
            ResumeLayout(false);
        }
    }
}