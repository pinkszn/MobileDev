using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : PlayerInput
{
    bool isActive = false;
    bool isRockFailed = false;
    bool controller = false;
    float pTolerance,nTolerance;
    
    void RockControl()
    {
        if (isActive == true)
        {
            playerControl();
        }
    }

    void controlTolerance()
    {
        /*
         * apply adding / subtracting numbers to accelerometer to make the balancing more engaging 
         * positive tolerance
         * negative tolerance
         */
    }

    private void OnCollisionEnter(Collision collision)
    {
        isActive = true;
    }

}
