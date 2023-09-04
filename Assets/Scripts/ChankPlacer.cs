using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChankPlacer : MonoBehaviour
{
    [SerializeField] Transform Player;
    public List<GameObject> spawnedChanks;
    [SerializeField] public GameObject FirstChank;
    [SerializeField] public GameObject ChankPrefab;
    [SerializeField] public GameObject Enemy;
    void Start()
    {
        spawnedChanks.Add(FirstChank);
        GameObject newEnemy = Instantiate(Enemy);
        newEnemy.transform.position = spawnedChanks[spawnedChanks.Count - 1].GetComponent<Chank>().Spawn.position;

    }

    void Update()
    {
        if (Player.position.z > spawnedChanks[spawnedChanks.Count - 1].GetComponent<Chank>().End.transform.position.z)
        {
            SpawnChank();
        }
    }

    void SpawnChank()
    {
        GameObject newChank = Instantiate(ChankPrefab);
        newChank.transform.position = spawnedChanks[spawnedChanks.Count - 1].GetComponent<Chank>().End.position - newChank.GetComponent<Chank>().Began.transform.localPosition;
        spawnedChanks.Add(newChank);
        GameObject newEnemy = Instantiate(Enemy);
        newEnemy.transform.position = spawnedChanks[spawnedChanks.Count - 1].GetComponent<Chank>().Spawn.position;

    }
}
