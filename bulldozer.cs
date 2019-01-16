using System.Drawing;

namespace Labs
{
    class bulldozer : Tractor
    {
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
        public bulldozer(int maxSpeed, float weight, Color mainColor, Color dopColor, bool frontLadle) : base(maxSpeed, weight, mainColor)
        {
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
        public override void DrawCar(Graphics g)
        {
            // отрисуем сперва передний спойлер автомобиля (чтобы потом отрисовк автомобиля на него "легла")
            if (FrontLadle)
            {
                Pen spoiler = new Pen(DopColor);
                g.DrawLine(spoiler, _startPosX + 70, _startPosY + 20, _startPosX + 95, _startPosY + 60);
                g.DrawLine(spoiler, _startPosX + 95, _startPosY + 60, _startPosX + 105, _startPosY + 60);
                g.DrawLine(spoiler, _startPosX + 70, _startPosY + 20, _startPosX + 105, _startPosY + 60);

                int n = 0;
                while (n < 20)
                {
                    n++;
                    g.DrawLine(spoiler, _startPosX + 70, _startPosY + 20, _startPosX + 95 + n, _startPosY + 60);
                }
            }
            base.DrawCar(g);
        }
    }
}