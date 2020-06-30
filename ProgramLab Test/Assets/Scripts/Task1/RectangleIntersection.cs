using System;
using UnityEngine;


namespace Assets.Scripts.Task1
{
    public static class RectangleIntersection
    {
        /// <returns>Возвращает площадь пересечения прямоугольников. Если прямоугольники не пересекаются, то возвращает ноль</returns>        
        public static int GetIntersectionArea(Rectangle firstRectangle, Rectangle secondRectangle)
        {
            if (CheckIntersection(firstRectangle, secondRectangle))
            {
                //Координаты левого верхнего угла
                Vector2Int startCoords = new Vector2Int(
                    Math.Max(firstRectangle.LeftX, secondRectangle.LeftX),
                    Math.Min(firstRectangle.UpperY, secondRectangle.UpperY)
                    );
                //Координаты правого нижнего угла
                Vector2Int endCoords = new Vector2Int(
                    Math.Min(firstRectangle.RightX, secondRectangle.RightX),
                    Math.Max(firstRectangle.BottomY, secondRectangle.BottomY)
                    );
                int length = endCoords.x - startCoords.x;
                int width = startCoords.y - endCoords.y;
                return length * width;
            }
            else
                return 0;
        }


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

            if (rightRectangle.LeftX >= leftRectangle.RightX
                || leftRectangle.UpperY <= rightRectangle.BottomY
                || rightRectangle.UpperY <= leftRectangle.BottomY)
                return false;
            else
                return true;
        }
    }
}
