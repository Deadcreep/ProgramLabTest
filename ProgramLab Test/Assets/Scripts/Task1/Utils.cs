namespace Assets.Scripts.Task1
{
    static class Utils
    {
        public static bool CheckFirstRectangleIsLeft(Rectangle first, Rectangle second)
        {
            if (first.LeftX <= second.LeftX)
                return true;
            else
                return false;
        }
    }
}
