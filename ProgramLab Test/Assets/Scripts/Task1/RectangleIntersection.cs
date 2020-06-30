using System;
using UnityEngine;


namespace Assets.Scripts.Task1
{
    public static class RectangleIntersection
    {
        /// <returns>Возвращает площадь пересечения прямоугольников. Если прямоугольники не пересекаются, то возвращает ноль</returns>
        //Верхняя у-координата - минимальная из двух исходных верхних
        //Нижняя у-координата - максимальная из двух исходных нижних
        //Левая х-координата - максильная из двух исходных левых
        //Правая х-координата - минимальная из двух исходных правых
        public static int GetIntersectionArea(Rectangle firstRectangle, Rectangle secondRectangle)
        {
            if (CheckIntersection(firstRectangle, secondRectangle))
            {
                Vector2Int startCoords = new Vector2Int(Math.Max(firstRectangle.StartCoords.x, secondRectangle.StartCoords.x),
                                                  Math.Min(firstRectangle.StartCoords.y, secondRectangle.StartCoords.y));
                //Координаты правого нижнего угла
                Vector2Int endCoords = new Vector2Int(Math.Min(firstRectangle.StartCoords.x + firstRectangle.Length,
                                                               secondRectangle.StartCoords.x + secondRectangle.Length),
                                                      Math.Max(firstRectangle.StartCoords.y - firstRectangle.Width,
                                                               secondRectangle.StartCoords.y - secondRectangle.Width));
                int length = endCoords.x - startCoords.x;
                int width = startCoords.y - endCoords.y;
                return length * width;
            }
            else
                return 0;
        }


        //Если левая грань правого прямоугольника лежит правее правой грани левого или совпадает с ней,
        //либо нижняя грань правого выше верхней левого или совпадает с ней,
        //либо верхняя грань правого ниже нижней левого, то они не пересекаются.
        public static bool CheckIntersection(Rectangle firstRectangle, Rectangle secondRectangle)
        {
            Rectangle leftRectangle;
            Rectangle rightRectangle;
            if (Utils.CheckFirstRectangleIsLeft(firstRectangle, secondRectangle))
            {
                leftRectangle = firstRectangle;
                rightRectangle = secondRectangle;
            }
            else
            {
                leftRectangle = secondRectangle;
                rightRectangle = firstRectangle;
            }

            if (rightRectangle.StartCoords.x >= leftRectangle.StartCoords.x + leftRectangle.Length
                || leftRectangle.StartCoords.y <= rightRectangle.StartCoords.y - rightRectangle.Width
                || rightRectangle.StartCoords.y <= leftRectangle.StartCoords.y - leftRectangle.Width)
                return false;
            else
                return true;
        }
    }
}
