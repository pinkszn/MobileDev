using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : PlayerInput
{
    public bool isActive = false;
    bool isRockFailed = false;
    bool controller = false;
    float pTolerance,nTolerance;

    private void Update()
    {
        
    }

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

    public void RockOnContact(bool isRockStall)
    {
        if(isActive == true)
        {
            isRockStall = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider)
        {
            Debug.Log("Rock contact");
            this.gameObject.GetComponent<Rigidbody>().isKinematic=true;
            isActive = true;
            SendMessage("RockOnContact",true);
        }
    }
}
