using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    //public GameObject rockPrefab;
    [SerializeField] GameObject[] LRock;
    [SerializeField] GameObject[] HRock;
    public void SpawnRock()
    {
        int i = Random.Range(0, LRock.Length);

        GameObject rock_obj = LRock[i];
        Instantiate(LRock[i]);
        Vector3 temp = transform.position;
        temp.z = gameObject.transform.position.z;

        LRock[i].transform.position = temp;
    }

    void Randomizer()
    {
        int i = Random.Range(0, LRock.Length);
    }
}
