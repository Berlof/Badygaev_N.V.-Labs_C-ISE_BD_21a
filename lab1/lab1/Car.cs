using lab1;
using System.Drawing;


namespace WindowsFormsCars
{
    public class Car : Vehicle
    {

        private const int carWidth = 130;
        /// <summary>
        /// Ширина отрисовки автомобиля
        /// </summary>
        private const int carHeight = 80;
        /// <summary>
        /// Максимальная скорость
        /// </summary>


        public Car(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }
        public override void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
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
        public override void DrawCar(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            //границы автомобиля
            // теперь отрисуем основной кузов автомобиля
            //границы автомобиля
            g.DrawRectangle(pen, _startPosX, _startPosY, 50, 15);
            g.DrawRectangle(pen, _startPosX, _startPosY, 50, 40);
            g.DrawEllipse(pen, _startPosX - 10, _startPosY + 40, 100, 25);
            g.DrawRectangle(pen, _startPosX + 50, _startPosY + 15, 20, 25);




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