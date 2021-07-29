using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour
{ 
    private float minX = -5.5f, maxX = 5.5f;
    bool canMove;
    float moveSpeed = 5f;
    public static int RockPoints = 0;

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

        RockPoints++;
        ignoreCollision = true;
        ignoreTrigger = true;
        PlayerInput.instance.SpawnNewRock();
        PlayerInput.instance.MoveCamera();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ignoreCollision)
            return;


        if (collision.gameObject.tag == "Platform" || collision.gameObject.GetComponentInChildren<RockBehavior>() || collision.gameObject.GetComponent <RockBehavior>()) 
        {
            Invoke("Landed", 1f);
            ignoreCollision = true;
            rockContact = true;
            this.gameObject.GetComponent<Rigidbody>().isKinematic=true;
        }
    }

    
    private void OnTriggerEnter(Collider target)
    {
        if (ignoreTrigger)
            return;

        if(target.tag == "GameOver")
        {
            PlayerInput.instance.gameOver.SetActive(true);
            Debug.Log("GAMEOVER");
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
