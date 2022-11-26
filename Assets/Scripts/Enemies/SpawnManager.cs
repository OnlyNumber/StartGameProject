using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float repeatTime;
    [SerializeField] private List<GameObject> listOfEnemys;


    private void Start()
    {
        InvokeRepeating("SpawnRandomCreature", 1, repeatTime);
    }

    void SpawnRandomCreature()
    {
        if (Random.Range(0, 2) == 0)
        {
            Instantiate(listOfEnemys[0], new Vector2(Random.Range(-15, 15), -0.4f), transform.rotation);
        }
        else
        {
            Instantiate(listOfEnemys[1], new Vector2(Random.Range(-15, 15), 2f), transform.rotation);
        }
    }
}
