using UnityEngine;

namespace Utils
{
    public class CameraPoints
    {
        private static Camera camera = Camera.main;

        public static Vector2 DefaultLeftBottomScreenPosition = Vector2.zero;
        public static Vector2 DefaultRightBottomScreenPosition = new Vector2(1920, 0);
        public static Vector2 DefaultLeftTopScreenPosition = new Vector2(0, 1080);

        public static Vector3 DefaultLeftBottomWorldPosition =
            new Vector3(-8.888889f, -5f, 0f);//camera.ScreenToWorldPoint(DefaultLeftBottomScreenPosition);
        public static Vector3 DefaultRightBottomWorldPosition =
            new Vector3(8.888889f, -5f, 0f); //camera.ScreenToWorldPoint(DefaultRightBottomScreenPosition);
        public static Vector3 DefaultLeftTopWorldPosition =
            new Vector3(-8.888889f, 5f, 0f); //camera.ScreenToWorldPoint(DefaultLeftTopScreenPosition);
    
        public static float DefaultWorldWidth =
            Vector3.Distance(DefaultLeftBottomWorldPosition, DefaultRightBottomWorldPosition);
        public static float DefaultWorldHeight =
            Vector3.Distance(DefaultLeftBottomWorldPosition, DefaultLeftTopWorldPosition);
    
        public static Vector2 LeftBottomScreenPosition = Vector2.zero;
        public static Vector2 RightBottomScreenPosition = new Vector2(Screen.width, 0);
        public static Vector2 LeftTopScreenPosition = new Vector2(0, Screen.height);
    
        public static Vector3 LeftBottomWorldPosition =
            camera.ScreenToWorldPoint(LeftBottomScreenPosition);
        public static Vector3 RightBottomWorldPosition =
            camera.ScreenToWorldPoint(RightBottomScreenPosition);
        public static Vector3 LeftTopWorldPosition =
            camera.ScreenToWorldPoint(LeftTopScreenPosition);

        public static float WorldWidth =
            Vector3.Distance(LeftBottomWorldPosition, RightBottomWorldPosition);
        public static float WorldHeight =
            Vector3.Distance(LeftBottomWorldPosition, LeftTopWorldPosition);
    }
}