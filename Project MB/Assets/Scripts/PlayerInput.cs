using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput instance;

    bool isMainMenu = true;
    public GameObject mainMenu;

    public GameObject gameOver;
    public RockSpawner rockSpawner;
    [HideInInspector] public RockBehavior currentRock;
    public TMP_Text scoreText;

    public CameraFollow cameraScript;
    private int moveCount;

    private Rigidbody rb;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        if (isMainMenu == true)
        {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                Touch touch = Input.GetTouch(0);
                mainMenu.SetActive(false);
                isMainMenu = false;
                rockSpawner.SpawnRock();
            }

            else if (Input.GetMouseButtonDown(0))
            {
                mainMenu.SetActive(false);
                isMainMenu = false;
                rockSpawner.SpawnRock();
            }
        }
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
            cameraScript.targetPos.y += 7f;
        }
    }

    public void RestartGame()
    {
        RockBehavior.RockPoints = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    void DetectInput()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            currentRock.DropRock();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            currentRock.DropRock();
        }
    }
}
