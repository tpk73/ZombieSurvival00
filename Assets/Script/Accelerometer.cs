using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotSpeed = 1.0f;

    void Update()
    {
        Vector3 dir = Vector3.zero;
        // we assume that the device is held parallel to the ground
        // and the Home button is in the right hand

        // remap the device acceleration axis to game coordinates:
        // 1) XY plane of the device is mapped onto XZ plane
        // 2) rotated 90 degrees around Y axis

        dir.z = Input.acceleration.y;
        dir.x = Input.acceleration.x;

        // clamp acceleration vector to the unit sphere
        if (dir.sqrMagnitude > 1)
        {
            dir.Normalize();
        }
        else
        {

        }

        // Make it move 10 meters per second instead of 10 meters per frame...
        dir *= Time.deltaTime;

        Vector3 movDir = new Vector3(dir.z, 0, dir.x);
        movDir.Normalize();

        // Move object
        transform.Translate(dir * speed * Time.deltaTime, Space.World);

        if(movDir != Vector3.zero)
        {
            //transform.forward = movDir;
            Quaternion toRotation = Quaternion.LookRotation(movDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotSpeed * Time.deltaTime);
        }
    }
}