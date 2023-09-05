using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChankPlacer : MonoBehaviour
{
    [SerializeField] Transform Player;
    public List<GameObject> spawnedChanks;
    public List<GameObject> spawnedEnemy;
    [SerializeField] public GameObject FirstChank;
    [SerializeField] public GameObject ChankPrefab;
    [SerializeField] public GameObject Enemy;
    void Start()
    {
        spawnedChanks.Add(FirstChank);
        SpawnEnemy();
    }

    void Update()
    {
        if (Player.position.z > spawnedChanks[spawnedChanks.Count - 1].GetComponent<Chank>().Began.transform.position.z)
        {
            SpawnChank();
            DeleteChank();
        }
    }
    void SpawnEnemy() 
    {
        GameObject newEnemy = Instantiate(Enemy);
        spawnedEnemy.Add(newEnemy);
        int randomSpawnsIndex = Random.Range(0, spawnedChanks[spawnedChanks.Count - 1].GetComponent<Chank>()._Spawn.Count);
        newEnemy.transform.position = spawnedChanks[spawnedChanks.Count - 1].GetComponent<Chank>()._Spawn[randomSpawnsIndex].position;
    }

    void DeleteChank()
    {
        if (spawnedChanks.Count > 3)
        {
            Destroy(spawnedChanks[0].gameObject);
            spawnedChanks.RemoveAt(0);
            Destroy(spawnedEnemy[0].gameObject);
            spawnedEnemy.RemoveAt(0);
        }
    }

    void SpawnChank()
    {
        GameObject newChank = Instantiate(ChankPrefab);
        newChank.transform.position = spawnedChanks[spawnedChanks.Count - 1].GetComponent<Chank>().End.position - newChank.GetComponent<Chank>().Began.transform.localPosition;
        spawnedChanks.Add(newChank);
        SpawnEnemy();
    }
}
