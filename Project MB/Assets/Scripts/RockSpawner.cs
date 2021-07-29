using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    //public GameObject rockPrefab;
    [SerializeField] GameObject[] LRock;
    int i;
    [SerializeField]GameObject cameraToFollow;
    public void SpawnRock()
    {
        Randomizer();
        Instantiate(LRock[i]);
        Vector3 temp = transform.position;
        temp.z = 0f;
        temp.x = 0f;
        temp.y = 0f;
        LRock[i].transform.position = temp;
        
    }

    void Randomizer()
    {
        i = Random.Range(0, LRock.Length);
    }
}
