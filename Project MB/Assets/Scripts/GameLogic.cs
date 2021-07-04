using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] bool Fail;
    [SerializeField] bool isActiveRock;
    [SerializeField] List<GameObject> Rock;

    float rockHoldTime;

    Transform rockSpawnPoint;

    void RockSpawner()
    {
        // Make rocks fall in a certain position
        // Choose from the list of rocks
        Random.Range(0, Rock.Count);

    }

    void RockHold()
    {
        //Hold for a certain amount of time to balance rock
        //disable rb after holding

    }

    void CameraLock()
    {
        //increment y transform of camera per rock spawned
        //
    }

    private void Update()
    {
        //If fail conditoin achieve show game over screen
        //return player to main menu
        //fail if a rock fails to balance
    }
}
