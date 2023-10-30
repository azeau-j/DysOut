using UnityEngine;

namespace Dys_The_Game.Utils
{
    public static class InputUtils
    {
        public static Vector3 GetMouseWorldPosition(RectTransform transform)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                transform,
                Input.mousePosition, null,
                out Vector2 movePos);

            Vector3 mousePos = transform.TransformPoint(movePos);
            mousePos.z = 0;

            return mousePos;
        }
    }
}