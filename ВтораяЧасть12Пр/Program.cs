using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ВтораяЧасть12Пр
{
    public class Program : Form
    {
        private static readonly int PixelsPerUnit = 25;
        private static string _defaultProgram = "1";
        private static bool _madeAction;

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
                "1) Нарисовать отрезок по двум координатам \n2) Нарисовать прямоугольник по двум координатам противоположенных вершин \n3) Нарисовать окружность по координатам центра и радиусу \n4) Нарисовать равносторонний треугольник по координатам одной вершины(левой) и высоте");
            _defaultProgram = Console.ReadLine();
            string[] possibleCommands = new[] { "1", "2", "3", "4" };
            if (_defaultProgram == null || !possibleCommands.Contains(_defaultProgram))
            {
                Console.WriteLine("Введена некорректная информация. Выход из программы...");
                Application.Exit();
            }
            else
            {
                _defaultProgram = _defaultProgram.TrimEnd(')');
                Application.Run(new Program());
            }
        }

        private void Program_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            if (!_madeAction)
            {
                DrawAxis(g);
                switch (_defaultProgram)
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
        }

        private void DrawAxis(Graphics g)
        {
            for (var i = 0; i < 1000; i += PixelsPerUnit)
            {
                g.DrawLine(Pens.LightGray, 0, i, 1000, i);
                g.DrawLine(Pens.LightGray, i, 0, i, 1000);
            }
            g.DrawLine(Pens.Black, 500, 0, 500, 1000);
            g.DrawLine(Pens.Black, 0, 500, 1000, 500);
            for (var i = 0; i < 1000; i += PixelsPerUnit)
            {
                g.DrawLine(Pens.Black, 500-PixelsPerUnit/10, i, 500+PixelsPerUnit/10, i);
                g.DrawLine(Pens.Black, i, 500-PixelsPerUnit/10, i, 500+PixelsPerUnit/10);
            }
        }

        private void DrawLineByCords(Graphics g)
        {
            Console.WriteLine("Введите координаты в формате: `x1;y1 x2;y2`");
            var input = Console.ReadLine();
            string[] cords = new [] {"0"};
            if (input == null)
            {
                Console.WriteLine("Введена некорректная информация. Выход из программы...");
                Application.Exit();
            }
            else
            {
                cords = input.Split(' ');
            }
            var x1 = 500 + int.Parse(cords[0].Split(';')[0]) * PixelsPerUnit;
            var y1 = 500 + -1 * int.Parse(cords[0].Split(';')[1]) * PixelsPerUnit;
            var x2 = 500 + int.Parse(cords[1].Split(';')[0]) * PixelsPerUnit;
            var y2 = 500 + -1 * int.Parse(cords[1].Split(';')[1]) * PixelsPerUnit;
            g.DrawLine(Pens.Red, x1, y1, x2, y2);
            _madeAction = true;
        }

        private void DrawRectangleByCords(Graphics g)
        {
            Console.WriteLine("Введите координаты в формате: `x1;y1 x2;y2`");
            var input = Console.ReadLine();
            string[] cords = new [] {"0"};
            if (input == null)
            {
                Console.WriteLine("Введена некорректная информация. Выход из программы...");
                Application.Exit();
            }
            else
            {
                cords = input.Split(' ');
            }
            var x1 = 500 + int.Parse(cords[0].Split(';')[0]) * PixelsPerUnit;
            var y1 = 500 + -1 * int.Parse(cords[0].Split(';')[1]) * PixelsPerUnit;
            var x2 = 500 + int.Parse(cords[1].Split(';')[0]) * PixelsPerUnit;
            var y2 = 500 + -1 * int.Parse(cords[1].Split(';')[1]) * PixelsPerUnit;
            var width = Math.Abs(x2 - x1);
            var heigh = Math.Abs(y2 - y1);
            var coolCordX = x1;
            var coolCordY = y1;
            if (x1 > x2) coolCordX = x2;
            if (y1 > y2) coolCordY = y2;
            g.DrawRectangle(Pens.Red, coolCordX, coolCordY, width, heigh);
            _madeAction = true;
        }

        private void DrawCircleByCords(Graphics g)
        {
            Console.WriteLine("Введите координаты в формате: `x;y R`");
            var input = Console.ReadLine();
            string[] cords = new [] {"0"};
            if (input == null)
            {
                Console.WriteLine("Введена некорректная информация. Выход из программы...");
                Application.Exit();
            }
            else
            {
                cords = input.Split(' ');
            }
            var x1 = 500 + int.Parse(cords[0].Split(';')[0]) * PixelsPerUnit;
            var y1 = 500 + -1 * int.Parse(cords[0].Split(';')[1]) * PixelsPerUnit;
            var r = int.Parse(cords[1].Split(';')[0]) * PixelsPerUnit;
            var tempCordX = x1 - r;
            var tempCordY = y1 - r;
            g.DrawEllipse(Pens.Red, tempCordX, tempCordY, 2 * r, 2 * r);
            _madeAction = true;
        }

        private void DrawTriangleByCords(Graphics g)
        {
            Console.WriteLine("Введите координаты в формате: `x;y H`");
            var input = Console.ReadLine();
            string[] cords = new [] {"0"};
            if (input == null)
            {
                Console.WriteLine("Введена некорректная информация. Выход из программы...");
                Application.Exit();
            }
            else
            {
                cords = input.Split(' ');
            }
            var x1 = 500 + int.Parse(cords[0].Split(';')[0]) * PixelsPerUnit;
            var y1 = 500 + -1 * int.Parse(cords[0].Split(';')[1]) * PixelsPerUnit;
            var h = int.Parse(cords[1]) * PixelsPerUnit;
            var side = (float)Math.Sqrt(4 * Math.Pow(h, 2) / 3);
            var x2 = side / 2 + x1;
            var y2 = y1 - h;
            var p = Pens.Red;
            g.DrawLine(p, x1, y1, x2, y2);
            g.DrawLine(p, x1 + side, y1, x2, y2);
            g.DrawLine(p, x1, y1, x1 + side, y1);
            _madeAction = true;
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
            ClientSize = new Size(784, 561);
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            CausesValidation = false;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Program";
            Paint += Program_Paint;
            ResumeLayout(false);
        }
    }
}