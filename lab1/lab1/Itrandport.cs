using System.Drawing;
using WindowsFormsCars;

namespace lab1
{

    public interface Itrandport
    {
        /// <summary>
        /// Установка позиции автомобиля
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        void SetPosition(int x, int y, int width, int height);
        /// <summary>
        /// Изменение направления пермещения
        /// </summary>
        /// <param name="direction">Направление</param>
        void MoveTransport(Direction direction);
        /// <summary>
        /// Отрисовка автомобиля
        /// </summary>
        /// <param name="g"></param>
        void DrawCar(Graphics g);
        /// <summary>
        /// Смена основного цвета автомобиля
        /// </summary>
        /// <param name="color"></param>
        void SetMainColor(Color color);
    }
}
