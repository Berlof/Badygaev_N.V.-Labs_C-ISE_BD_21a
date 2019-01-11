﻿using lab1;
using System;
using System.Drawing;


namespace WindowsFormsCars
{
    public class Car : Vehicle, IComparable<Car>, IEquatable<Car>
    {
        private const int carWidth = 130;
        /// <summary>
        /// Ширина отрисовки автомобиля
        /// </summary>
        private const int carHeight = 80;

        /// <summary>
        /// Максимальная скорость
        /// </summary>

        public Car(string info)
        {
            string[] strs = info.Split(';');
            if (strs.Length == 3)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
            }
        }

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
            g.DrawRectangle(pen, _startPosX, _startPosY, 50, 15);
            g.DrawRectangle(pen, _startPosX, _startPosY, 50, 40);
            g.DrawEllipse(pen, _startPosX - 0, _startPosY + 40, 100, 25);
            g.DrawRectangle(pen, _startPosX + 50, _startPosY + 15, 20, 25);
            Brush ss = new SolidBrush(MainColor);
            g.FillRectangle(ss, _startPosX, _startPosY, 50, 40);
            g.FillRectangle(ss, _startPosX + 50, _startPosY + 15, 20, 25);
            Brush brBlue = new SolidBrush(Color.Turquoise);
            g.FillRectangle(brBlue, _startPosX, _startPosY, 50, 15);
            Brush brBlack = new SolidBrush(Color.Black);
            g.FillEllipse(brBlack, _startPosX - 0, _startPosY + 40, 100, 25);
        }
        public override string ToString()
        {
            return MaxSpeed + ";" + Weight + ";" + MainColor.Name;
        }
        /// <summary>
        /// Метод интерфейса IComparable для класса Car
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Car other)
        {
            if (other == null)
            {
                return 1;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return MaxSpeed.CompareTo(other.MaxSpeed);
            }
            if (Weight != other.Weight)
            {
                return Weight.CompareTo(other.Weight);
            }
            if (MainColor != other.MainColor)
            {
                MainColor.Name.CompareTo(other.MainColor.Name);
            }
            return 0;
        }
        /// <summary>
        /// Метод интерфейса IEquatable для класса Car
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Car other)
        {
            if (other == null)
            {
                return false;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return false;
            }
            if (Weight != other.Weight)
            {
                return false;
            }
            if (MainColor != other.MainColor)
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
            Car carObj = obj as Car;
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