using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput instance;
    public RockSpawner rockSpawner;
    [HideInInspector] public RockBehavior currentRock;

    public CameraFollow cameraScript;
    private int moveCount;

    private Rigidbody rb;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        rockSpawner.SpawnRock();
    }

    private void Update()
    {
        DetectInput();
    }

    public void SpawnNewRock()
    {
        Invoke("NewRock",2f);
    }

    void NewRock()
    {
        rockSpawner.SpawnRock();
    }

    public void MoveCamera()
    {
        moveCount++;
        if(moveCount == 3)
        {
            moveCount = 0;
            cameraScript.targetPos.y += 10f;
        }
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    void DetectInput()
    {
        if (Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            currentRock.DropRock();
        }
        if (Input.GetMouseButtonDown(0))
        {
            currentRock.DropRock();
        }
    }
}
