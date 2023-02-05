using UnityEngine;

namespace Utils
{
    public class ScreenPoints
    {
        private static Camera camera = Camera.main;

        //Edit zones on full hd screen
        public static Vector3 ConfigurableLeftBottomWorldPosition =
            new Vector3(-8.888889f, -5f, 0f);

        public static Vector2 LeftBottomScreenPosition = Vector2.zero;
        
        public static Vector3 LeftBottomWorldPosition =
            camera.ScreenToWorldPoint(LeftBottomScreenPosition);
    }
}