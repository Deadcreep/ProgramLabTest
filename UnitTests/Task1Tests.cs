using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Task1;


namespace UnitTests
{
    [TestClass]
    public class Task1Tests
    {
        //Первый прямоугольник - контрольный, остальные проверяются относительно его
        List<Rectangle> notIntersectingRectangles = new List<Rectangle>()
        {
                new Rectangle( new Vector2Int(2, 24), 6, 10),
                new Rectangle( new Vector2Int(2, 28), 2, 8),
                new Rectangle( new Vector2Int(6, 25), 1, 4),
                new Rectangle( new Vector2Int(5, 18), 1, 4),
                new Rectangle( new Vector2Int(2, 16), 2, 8),
                new Rectangle( new Vector2Int(12, 16), 2, 2),
                new Rectangle( new Vector2Int(2, 12), 2, 10),
                new Rectangle( new Vector2Int(12, 16), 2, 2),
                new Rectangle( new Vector2Int(16, 16), 2, 2),
                new Rectangle( new Vector2Int(12, 18), 1, 1),
                new Rectangle( new Vector2Int(12, 22), 2, 1),
                new Rectangle( new Vector2Int(12, 16), 2, 2),
                new Rectangle( new Vector2Int(12, 25), 1, 1),
                new Rectangle( new Vector2Int(12, 28), 2, 2),
                new Rectangle( new Vector2Int(14, 24), 2, 6),
                new Rectangle( new Vector2Int(16, 30), 2, 2),
        };

        //Первый прямоугольник - контрольный, остальные проверяются относительно его
        //Первое значение - площадь пересечения
        List<(int, Rectangle)> intersectingRectangles = new List<(int, Rectangle)>{
            ( 32, new Rectangle(new Vector2Int(2, 6), 4, 8)),
            ( 1, new Rectangle(new Vector2Int(3, 5), 1, 1)),
            ( 1, new Rectangle(new Vector2Int(5, 7), 2, 1)),
            ( 1, new Rectangle(new Vector2Int(5, 3), 2, 1)),
            ( 12, new Rectangle(new Vector2Int(7, 6), 4, 9)),
            ( 8, new Rectangle(new Vector2Int(8, 8), 8, 4)),
            ( 1, new Rectangle(new Vector2Int(9, 7), 2, 2)),
            ( 1, new Rectangle(new Vector2Int(9, 5), 1, 2)),
            ( 1, new Rectangle(new Vector2Int(9, 3), 2, 2)),
        };

        [TestMethod]
        public void TestNotIntersecting()
        {
            for (int index = 1; index < notIntersectingRectangles.Count(); index++)
            {
                bool result = RectangleIntersection.CheckIntersection(
                    notIntersectingRectangles[0],
                    notIntersectingRectangles[index]);
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void TestIntersecting()
        {
            for (int index = 0; index < intersectingRectangles.Count(); index++)
            {
                bool result = RectangleIntersection.CheckIntersection(
                    intersectingRectangles[0].Item2,
                    intersectingRectangles[index].Item2);
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void TestCalculateIntersectingArea()
        {
            for (int index = 0; index < intersectingRectangles.Count(); index++)
            {
                int result = RectangleIntersection.GetIntersectionArea(
                    intersectingRectangles[0].Item2,
                    intersectingRectangles[index].Item2);
                Assert.AreEqual(result, intersectingRectangles[index].Item1);
            }
        }

        [TestMethod]
        public void TestCalculateIntersectingAreaOfNotIntersectingRectangles()
        {
            for (int index = 1; index < notIntersectingRectangles.Count(); index++)
            {
                int result = RectangleIntersection.GetIntersectionArea(
                    notIntersectingRectangles[0],
                    notIntersectingRectangles[index]);
                Assert.AreEqual(result, 0);
            }
        }
    }
}
