namespace Assets.Scripts.Task1
{
    static class Utils
    {
        public static bool CheckFirstRectangleIsLeft(Rectangle first, Rectangle second)
        {
            if (first.StartCoords.x <= second.StartCoords.x)
                return true;
            else
                return false;
        }
    }
}
