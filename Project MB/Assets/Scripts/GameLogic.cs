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
    GameObject previousRock;
    GameObject currentRock;

    Camera mainCamera;
    float rockHoldTime;
    Rigidbody rockRB;
    Vector3 rockSpawnPoint;
    Vector3 previousRockPositoin;
    bool instantiated = true;

    void Start()
    {
        rockRB = GetComponent<Rigidbody>();
    }

    void RockSpawner()
    {
        if(isActiveRock == false)
        {
            rockSpawnPoint = new Vector3(0, 15, 0);
            isActiveRock = true;
            int i = Random.Range(0, LRock.Length);
            LRock[i].transform.position = rockSpawnPoint;
            LRock[i].GetComponentInChildren<Rigidbody>().isKinematic = false;
            //instanciatedObjects[i] = Instantiate(LRock[i]) as GameObject;
            Instantiate(LRock[i]);
            currentRock = LRock[i];
            Debug.Log(currentRock);
            previousRockPositoin = LRock[i].transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider)
        {
            RockSpawner();
        }
    }

    public void RockOnContact(bool isRockStall)
    {

    }
    void RockDrop()
    {

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
