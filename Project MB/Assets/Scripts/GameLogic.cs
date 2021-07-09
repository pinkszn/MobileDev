using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] bool Fail;
    [SerializeField] bool isActiveRock;
    [SerializeField] List<GameObject> Rock;

    Camera mainCamera;
    float rockHoldTime;
    Rigidbody rockRB;
    Vector3 rockSpawnPoint;

    void Start()
    {
        rockRB = GetComponent<Rigidbody>();
        rockSpawnPoint = new Vector3(0, 15, 0);

        RockSpawner();
    }

    void RockSpawner()
    {
        // Make rocks fall in a certain position

        rockRB.isKinematic = false;

        /*for (int i = 0; i<1; i++) {
            Instantiate(this.gameObject, rockSpawnPoint, Quaternion.identity);
        }*/
        // Choose from the list of rocks



        // randomize rock selection

        Random.Range(0, Rock.Count);
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
    }
}
