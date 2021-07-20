using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class Singleton<GameLogic> : MonoBehaviour
{
    [SerializeField] bool Fail;
    [SerializeField] protected bool isActiveRock;
    [SerializeField] private GameObject[] LRock;
    [SerializeField] private GameObject[] HRock;
    private GameObject[] instanciatedObjects;
    GameObject tempRock;
    GameObject previousRock;
    GameObject currentRock;

    Camera mainCamera;
    float rockHoldTime;
    Rigidbody rockRB;
    Vector3 rockSpawnPoint;
    Vector3 previousRockPositoin;

    void Start()
    {
        rockRB = GetComponent<Rigidbody>();
    }

    protected void RockSpawner()
    {
        if(isActiveRock == false)
        {
            rockSpawnPoint = new Vector3(0, 15, 0);
            isActiveRock = true;
            int i = Random.Range(0, LRock.Length);
            tempRock = LRock[i]; // sets the current rock for player control and other methods
            currentRock = tempRock;
            currentRock.transform.position = rockSpawnPoint;
            currentRock.GetComponentInChildren<Rigidbody>().isKinematic = false; // makes the rock go down
            Instantiate(currentRock);
            Debug.Log(currentRock);
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
}*/
