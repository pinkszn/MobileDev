using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] bool Fail;
    [SerializeField] bool isActiveRock;
    [SerializeField] private GameObject[] LRock;
    [SerializeField] private GameObject[] HRock;
    private GameObject[] instanciatedObjects;

    Camera mainCamera;
    float rockHoldTime;
    Rigidbody rockRB;
    Vector3 rockSpawnPoint;
    bool instantiated = true;

    void Start()
    {
        rockRB = GetComponent<Rigidbody>();
        rockSpawnPoint = new Vector3(0, 15, 0);
    }

    void RockSpawner()
    {
        // Make rocks fall in a certain position

        rockRB.isKinematic = false;

        instanciatedObjects = new GameObject[LRock.Length];
        for (int i = 0; i < LRock.Length; i++)
        {
            instanciatedObjects[i] = Instantiate(LRock[i]) as GameObject;
        }

        // Choose from the list of rocks



        // randomize rock selection

        Random.Range(0, LRock.Length);
    }

    void RockHold()
    {
        //Hold for a certain amount of time to balance rock
        //disable rb after holding
        if (rockHoldTime <= 0)
        {
            rockRB.isKinematic = true; // disables the physics part
            //rockspawn then reset rock hold time
        }
    }

    void CameraLock()
    {
        //increment y transform of camera per rock spawned
        //call when rockspawn is called
    }

    private void Update()
    {
        //If fail conditoin achieve show game over screen
        //return player to main menu
        //fail if a rock fails to balance

        RockSpawner();
    }
}
