using UnityEngine;

namespace Dys_The_Game.Utils.Ui
{
    public static class UiUtils
    {
        public static Rect GetScreenCoordinates(RectTransform uiElement)
        {
            Vector3[] worldCorners = new Vector3[4];
            uiElement.GetWorldCorners(worldCorners);
            Rect result = new Rect(
                worldCorners[0].x,
                worldCorners[0].y,
                worldCorners[2].x - worldCorners[0].x,
                worldCorners[2].y - worldCorners[0].y);
            return result;
        }
    }
}