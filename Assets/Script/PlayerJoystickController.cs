using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystickController : MonoBehaviour
{
    public FixedJoystick moveJoystick;
    public FixedJoystick lookJoystick;
    public float speed = .02f;

    void Update()
    {
        UpdateMoveJoyStick();
        //UpdateLookJoyStick();
    }

    void UpdateMoveJoyStick()
    {
        float hoz = moveJoystick.Horizontal;
        float vert = moveJoystick.Vertical;

        Vector2 convertedXY = ConvertWithCamera(Camera.main.transform.position, hoz, vert);

        Vector3 dir = new Vector3(-convertedXY.x, 0, -convertedXY.y).normalized;
        transform.Translate(dir * speed);
    }
    void UpdateLookJoyStick()
    {
        float hoz = lookJoystick.Horizontal;
        float vert = lookJoystick.Vertical;

        Vector2 convertedXY = ConvertWithCamera(Camera.main.transform.position, hoz, vert);

        Vector3 dir = new Vector3(-convertedXY.x, 0, -convertedXY.y).normalized;
        Vector3 lookAtPos = transform.position + dir;
        transform.LookAt(lookAtPos);
    }

    private Vector2 ConvertWithCamera(Vector3 cameraPos, float hoz, float vert)
    {
        Vector2 joyDir = new Vector2(hoz, vert).normalized;
        Vector2 camera2DPos = new Vector2(cameraPos.x, cameraPos.z);
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.z);
        Vector2 camToPlayerDir = (Vector2.zero - camera2DPos).normalized;
        float angle = Vector2.SignedAngle(camToPlayerDir, new Vector2(0, 1));
        Vector2 finDir = RotateVector(joyDir, -angle);
        return finDir;
    }

    private Vector2 RotateVector(Vector2 v, float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        float _x = v.x * Mathf.Cos(radian) - v.y * Mathf.Sin(radian);
        float _y = v.x * Mathf.Sin(radian) + v.y * Mathf.Cos(radian);
        return new Vector2(_x, _y);
    }
}
