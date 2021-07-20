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

    public UnityEngine.Gyroscope gyro;
    private Rigidbody rb;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            Input.gyro.enabled = true;
        }
    }

    private void Start()
    {
        rockSpawner.SpawnRock();
    }

    private void Update()
    {

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

    protected void playerControl()
    {
        if (SystemInfo.supportsGyroscope)
            transform.rotation = GyroToUnity(Input.gyro.attitude);
    }

    Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
