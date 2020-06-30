using UnityEngine;


namespace Assets.Scripts.Task1
{
    public class Rectangle
    {
        public Vector2Int StartCoords { get; private set; }
        public int Width { get; private set; }
        public int Length { get; private set; }

        public Rectangle(Vector2Int startCoords, int width, int length)
        {
            this.StartCoords = startCoords;
            this.Width = width;
            this.Length = length;
        }
        public Rectangle() { }
    }
}
