using lab1;
using System.Drawing;

namespace WindowsFormsCars
{
    public abstract class Vehicle : Itrandport
    {
        /// <summary>       
        /// Левая координата отрисовки автомобиля  
        /// </summary>      
        protected float _startPosX;
        /// <summary>       
        /// Правая кооридната отрисовки автомобиля    
        /// </summary>     
        protected float _startPosY;
        /// <summary>       
        /// Ширина окна отрисовки
        /// </summary>
        protected int _pictureWidth;
        //Высота окна отрисовки      
        protected int _pictureHeight;
        /// <summary>  
        /// Максимальная скорость    
        /// /// </summary>      
        public int MaxSpeed { protected set; get; }
        /// <summary>
        /// Вес автомобиля
        /// </summary>
        public float Weight { protected set; get; }
        /// <summary>
        /// Основной цвет кузова
        /// </summary>
        public Color MainColor { protected set; get; }
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }
        public void SetMainColor(Color color)
        {
            MainColor = color;
        }
        public abstract void DrawCar(Graphics g);
        public abstract void MoveTransport(Direction direction);
    }
}
