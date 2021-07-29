using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    //public GameObject rockPrefab;
    [SerializeField] GameObject[] LRock;
    int i;
    [SerializeField]CameraFollow cameraToFollow;

    public void SpawnRock()
    {
        Randomizer();
        GameObject Rock = Instantiate(LRock[i]);
        Vector3 temp = transform.position;
        temp.z = 0f;
        LRock[i].transform.position = temp;
    }

    void Randomizer()
    {
        i = Random.Range(0, LRock.Length);
    }
}
