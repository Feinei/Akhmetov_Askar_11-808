using System.Collections.Generic;

namespace yield
{
    public static class ExpSmoothingTask
    {
        public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
        {
            // Преподследняя точка сглаженного ряда
            var expPreviousPoint = new DataPoint { ExpSmoothedY = 0 };
            var isFirstIter = true;
            foreach (var origPoint in data)
            {
                // Если первая итерация - первая точка в сглаж. ряду = первой точке исходного ряда
                if (isFirstIter)
                {
                    isFirstIter = false;
                    expPreviousPoint = GetExpSmootPoint(origPoint, expPreviousPoint, 1);
                    yield return expPreviousPoint;
                }
                // Иначе сглаживаем 
                else
                {
                    var expPoint = GetExpSmootPoint(origPoint, expPreviousPoint, alpha);
                    expPreviousPoint = expPoint;
                    yield return expPoint;
                }
            }
        }
        // Возвращает сглаженную по формуле точку (для первой вернет исходную)
        private static DataPoint GetExpSmootPoint(DataPoint origPoint, DataPoint expPreviosPoint, double alpha)
        {
            return new DataPoint
            {
                OriginalY = origPoint.OriginalY,
                ExpSmoothedY = expPreviosPoint.ExpSmoothedY + alpha *
                        (origPoint.OriginalY - expPreviosPoint.ExpSmoothedY),
                X = origPoint.X
            };
        }
    }
}