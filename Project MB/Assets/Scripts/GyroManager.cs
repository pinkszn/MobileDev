using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<GyroManager> : MonoBehaviour
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


}
