using UnityEngine;


namespace Assets.Scripts.Task1
{
    public class Rectangle
    {
        public int LeftX { get; private set; }
        public int RightX { get => LeftX + length; }
        public int UpperY { get; private set; }
        public int BottomY { get => UpperY - width; }

        private int length;
        private int width;

        public Rectangle(Vector2Int startCoords, int width, int length)
        {
            LeftX = startCoords.x;
            UpperY = startCoords.y;
            this.width = width;
            this.length = length;
        }
    }
}
