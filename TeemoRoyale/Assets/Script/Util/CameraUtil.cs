using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class CameraUtil
{

    static public Vector2 GetMouseWorldPosition(Camera camera)
    {
        Vector2 mousePos = Input.mousePosition;
        return camera.ScreenToWorldPoint(mousePos); // 2d라 z 설정 안해도됨
    }
}