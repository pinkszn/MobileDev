using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroManager : MonoBehaviour
{
    [Header("Logic")]
    private Gyroscope gyro;
    private Quaternion rotation;
    private bool gyroActive;

    public void enableGyro()
    {
        if (gyroActive)
            return;

        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            gyroActive = gyro.enabled;
        }        
    }
    public Quaternion GetGyroRotation()
    {
        return rotation;
    }

    private void Update()
    {
        if (gyroActive)
        {
            rotation = gyro.attitude;
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(500, 300, 200, 40), "Gyro rotation rate " + gyro.rotationRate);
        GUI.Label(new Rect(500, 350, 200, 40), "Gyro attitude" + gyro.attitude);
        GUI.Label(new Rect(500, 400, 200, 40), "Gyro enabled : " + gyro.enabled);
    }


}
