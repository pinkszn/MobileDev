using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] bool Fail;
    //Rock Container
    [SerializeField] GameObject[] LRock;
    [SerializeField] GameObject[] HRock;
    //Rock Properties
    public bool isActiveRock = false;
    public GameObject tempRock;
    public GameObject previousRock;
    public GameObject currentRock;
    float rockHoldTime;
    Rigidbody rockRB;
    Vector3 rockSpawnPoint;
    Vector3 previousRockPositoin;

    private GameObject[] instanciatedObjects;

    Camera mainCamera;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
    }

    void Start()
    {
        rockRB = GetComponent<Rigidbody>();
    }

    public void RockSpawner()
    {
        /*#region old
        if (isActiveRock == false)
        {
            rockSpawnPoint = new Vector3(0, 15, 0);
            isActiveRock = true;
            int i = Random.Range(0, LRock.Length);
            tempRock = LRock[i]; // sets the current rock for player control and other methods
            currentRock = tempRock;
            Instantiate(currentRock);
            currentRock.transform.position = rockSpawnPoint;
            currentRock.GetComponentInChildren<Rigidbody>().isKinematic = false; // makes the rock go down
            Debug.Log(currentRock);
        }
        #endregion*/

        if (isActiveRock == false && Fail == false)
        {
            instanciatedObjects = new GameObject[LRock.Length];
            for (int i = 0; i < LRock.Length; i++)
            {
                instanciatedObjects[i] = Instantiate(LRock[i]) as GameObject;
                instanciatedObjects = new GameObject[LRock.Length];
            }
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
