using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{

    class bulldozer
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right

        }
        /// <summary>
        /// Левая координата отрисовки автомобиля
        /// </summary>
        private float _startPosX;
        /// <summary>
        /// Правая кооридната отрисовки автомобиля
        /// </summary>
        private float _startPosY;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private int _pictureWidth;
        //Высота окна отрисовки
        private int _pictureHeight;
        /// <summary>
        /// Ширина отрисовки автомобиля
        /// </summary>
        private const int carWidth = 100;
        /// <summary>
        /// Ширина отрисовки автомобиля
        /// </summary>
        private const int carHeight = 60;
        /// <summary>
        /// Максимальная скорость
        /// </summary>
        public int MaxSpeed { private set; get; }
        /// <summary>
        /// Вес автомобиля
        /// </summary>
        public float Weight { private set; get; }
        /// <summary>
        /// Основной цвет кузова
        /// </summary>
        public Color MainColor { private set; get; }
        /// <summary>
        /// Дополнительный цвет
        /// </summary>
        public Color DopColor { private set; get; }
        /// <summary>
        /// Признак наличия переднего ковша
        /// </summary>
        public bool FrontLadle { private set; get; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="frontLadle">Признак наличия переднего ковша</param>
        /// <param name="sideSpoiler">Признак наличия боковых спойлеров</param>
        /// <param name="backSpoiler">Признак наличия заднего спойлера</param>
        public bulldozer(int maxSpeed, float weight, Color mainColor, Color dopColor, bool
       frontLadle)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            FrontLadle = frontLadle;
            
        }
        /// <summary>
        /// Установка позиции автомобиля
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }
        /// <summary>
        /// Изменение направления пермещения
        /// </summary>
        /// <param name="direction">Направление</param>
        public void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 60 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - carWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - step > 0)
                    {
                        _startPosX -= step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step > 0)
                    {
                        _startPosY -= step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - carHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }
        /// <summary>
        /// Отрисовка автомобиля
        /// </summary>
        /// <param name="g"></param>
        public void DrawCar(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            // отрисуем сперва передний спойлер автомобиля (чтобы потом отрисовк автомобиля на него "легла")
 if (FrontLadle)
            {
                g.DrawLine(pen, _startPosX + 70, _startPosY + 20, _startPosX + 95, _startPosY + 60);
                g.DrawLine(pen, _startPosX + 95, _startPosY + 60, _startPosX + 105, _startPosY + 60);
                g.DrawLine(pen, _startPosX + 70, _startPosY + 20, _startPosX + 105, _startPosY + 60);
                int n = 0;
                while (n < 20)
                {
                    n++;
                    g.DrawLine(pen, _startPosX + 70, _startPosY + 20, _startPosX + 95 + n, _startPosY + 60);
                }
                Brush spoiler = new SolidBrush(DopColor);
                
            }

            // теперь отрисуем основной кузов автомобиля
            //границы автомобиля
            g.DrawRectangle(pen, _startPosX , _startPosY, 50, 15);
            g.DrawRectangle(pen, _startPosX, _startPosY, 50, 40);
            g.DrawEllipse(pen, _startPosX - 10, _startPosY+40, 100, 25);
            g.DrawRectangle(pen, _startPosX + 50, _startPosY +15, 20, 25);
            

            
            
            //g.DrawEllipse(pen, _startPosX, _startPosY, 140, 40);
            //g.DrawEllipse(pen, _startPosX, _startPosY + 30, 20, 20);
            //g.DrawEllipse(pen, _startPosX + 70, _startPosY, 20, 20);
            //g.DrawEllipse(pen, _startPosX + 70, _startPosY + 30, 20, 20);
            //g.DrawRectangle(pen, _startPosX - 1, _startPosY + 10, 10, 30);
            //g.DrawRectangle(pen, _startPosX + 80, _startPosY + 10, 10, 30);
            //g.DrawRectangle(pen, _startPosX + 10, _startPosY - 1, 70, 52);
            //задние фары
            

            // g.FillEllipse(brRed, _startPosX, _startPosY, 20, 20);
            //  g.FillEllipse(brRed, _startPosX, _startPosY + 30, 20, 20);
            //передние фары
            Brush brYellow = new SolidBrush(Color.Yellow);
             
            g.FillRectangle(brYellow, _startPosX, _startPosY, 50, 40);
            g.FillRectangle(brYellow, _startPosX + 50, _startPosY + 15, 20, 25);
            Brush brBlue = new SolidBrush(Color.Turquoise);
            g.FillRectangle(brBlue, _startPosX, _startPosY, 50, 15);
            Brush brBlack = new SolidBrush(Color.Black);
            g.FillEllipse(brBlack, _startPosX - 10, _startPosY + 40, 100, 25);

            //кузов
            // Brush br = new SolidBrush(MainColor);
            // g.FillRectangle(br, _startPosX, _startPosY + 10, 10, 30);
            //  g.FillRectangle(br, _startPosX + 80, _startPosY + 10, 10, 30);
            // g.FillRectangle(br, _startPosX + 10, _startPosY, 70, 50);


        }
    }

}

