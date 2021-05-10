using UnityEngine;
using System.Linq;

public enum GameState {
    WAIT_FOR_INPUT, PLAYING, WAIT_FOR_RESTART
}

public class _ {
    public static bool DidInputOnce() =>
        Input.GetMouseButtonDown(0) ||
        Input.touches.Any(x => x.phase == TouchPhase.Began);

    public static bool IsInputHeld() =>
        Input.GetMouseButton(0);

    public static void GizmosDrawCross2D(Vector2 pos, float size){
        // horz
        Gizmos.DrawLine(new Vector3(pos.x - size * 0.5f, pos.y, 0), new Vector3(pos.x + size * 0.5f, pos.y, 0));
        // vert
        Gizmos.DrawLine(new Vector3(pos.x, pos.y - size * 0.5f, 0), new Vector3(pos.x, pos.y + size * 0.5f, 0));
    }

    public static float GetCameraTopEdgeWorldY()
    {
        return Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1f, 0f)).y;
    }

    public static float GetCameraRightEdgeWorldX()
    {
        return Camera.main.ViewportToWorldPoint(new Vector3(1f, 0.5f, 0f)).x;
    }

    public static float GetCameraBottomEdgeWorldY()
    {
        return Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, 0f)).y;
    }

    public static float GetCameraLeftEdgeWorldX()
    {
        return Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0f)).x;
    }
}