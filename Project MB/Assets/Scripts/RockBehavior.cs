using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour
{
    Rigidbody rockRB;
    bool isRockFailed = false;
    bool controller = false;
    bool rockContact = false;

    bool gameOver;
    bool ignoreCollision;
    bool ignoreTrigger;

    float pTolerance,nTolerance;

    private void Awake()
    {
        rockRB = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        PlayerInput.instance.currentRock = this;
    }
    void controlTolerance()
    {
        /*
         * apply adding / subtracting numbers to accelerometer to make the balancing more engaging 
         * positive tolerance
         * negative tolerance
         */
    }

    void Landed()
    {
        if (isRockFailed)
            return;

        ignoreCollision = true;
        ignoreTrigger = true;

        PlayerInput.instance.SpawnNewRock();
        PlayerInput.instance.MoveCamera();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ignoreCollision)
            return;

        if (collision.collider) 
        {
            Invoke("Landed", 1f);
            ignoreCollision = true;
            rockContact = true;
            this.gameObject.GetComponent<Rigidbody>().isKinematic=true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ignoreTrigger)
            return;

        if(other.tag == "GameOver")
        {
            CancelInvoke("Landed");
            isRockFailed = true;
            ignoreTrigger = true;
            Invoke("RestartGame",2f);
        }

    }

    void RestartGame()
    {
        PlayerInput.instance.RestartGame();        
    }
}
