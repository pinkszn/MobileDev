using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : GameLogic
{
    bool isRockFailed = false;
    bool controller = false;
    float pTolerance,nTolerance;

    private void Update()
    {
        
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
        if (collision.collider)
        {
            Debug.Log("Rock contact");
            this.gameObject.GetComponent<Rigidbody>().isKinematic=true;
        }
    }
}
