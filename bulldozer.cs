using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsCars;

namespace lab1
{
   
    class bulldozer : Car, IComparable<bulldozer>, IEquatable<bulldozer>
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
        public bulldozer(int maxSpeed, float weight, Color mainColor, Color dopColor, bool
       frontLadle) :
            base(maxSpeed, weight, mainColor)
        {
            DopColor = dopColor;
            FrontLadle = frontLadle;

        }
        public bulldozer(string info) : base(info)
        {
            string[] strs = info.Split(';');
            if (strs.Length == 5)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
                DopColor = Color.FromName(strs[3]);
                FrontLadle = Convert.ToBoolean(strs[4]);

            }
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
                // Brush spoiler = new SolidBrush(DopColor);
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
        public void SetDopColor(Color color)
        {
            DopColor = color;
        }        public override string ToString()
        {
            return base.ToString() + ";" + DopColor.Name + ";" + FrontLadle;
        }
        /// <summary>
        /// Метод интерфейса IComparable для класса SportCar
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(bulldozer other)
        {
            var res = (this is Car).CompareTo(other is Car);
            if (res != 0)
            {
                return res;
            }
            if (DopColor != other.DopColor)
            {
                DopColor.Name.CompareTo(other.DopColor.Name);
            }
            if (FrontLadle != other.FrontLadle)
            {
                return FrontLadle.CompareTo(other.FrontLadle);
            }
            return 0;
        }
        /// <summary>
        /// Метод интерфейса IEquatable для класса SportCar
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(bulldozer other)
        {
            var res = (this as Car).Equals(other as Car);
            if (!res)
            {
                return res;
            }
            if (DopColor != other.DopColor)
            {
                return false;
            }
            if (FrontLadle != other.FrontLadle)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Перегрузка метода от object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            bulldozer carObj = obj as bulldozer;
            if (carObj == null)
            {
                return false;
            }
            else
            {
                return Equals(carObj);
            }
        }
        /// <summary>
        /// Перегрузка метода от object
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

