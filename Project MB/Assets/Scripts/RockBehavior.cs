using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour
{ 
    private float minX = -5.5f, maxX = 5.5f;
    bool canMove;
    float moveSpeed = 2f;

    Rigidbody rockRB;
    bool isRockFailed = false;
    bool controller = false;
    bool rockContact = false;

    bool gameOver;
    bool ignoreCollision;
    bool ignoreTrigger;

    private void Update()
    {
        MoveRock();
    }

    private void Awake()
    {
        rockRB = GetComponent<Rigidbody>();
        rockRB.useGravity = false;
    }

    private void Start()
    {
        canMove = true;
        if (Random.Range(0, 2) > 0)
        {
            moveSpeed *= -1f;
        }
        PlayerInput.instance.currentRock = this;
    }

    void MoveRock()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x += moveSpeed * Time.deltaTime;
            if (temp.x > maxX)
            {
                moveSpeed *= -1f;
            }else if (temp.x < minX)
            {
                moveSpeed *= -1f;
            }
            transform.position = temp;
        }
    }

    void Landed()
    {
        if (gameOver)
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

    public void DropRock()
    {
        canMove = false;
        rockRB.useGravity = true;
    }

    void RestartGame()
    {
        PlayerInput.instance.RestartGame();        
    }
}
