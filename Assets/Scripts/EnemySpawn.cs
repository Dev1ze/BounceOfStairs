using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] List<GameObject> Spawns;
    int countEnemy;
    void Start()
    {
        Debug.Log("Enemy: " + enemy.transform.localPosition);
    }

    void Awake()
    {
        while (countEnemy < 2)
        {
            int randomSpawnsIndex = Random.Range(0, Spawns.Count);
            Vector3 randomPosition = Spawns[randomSpawnsIndex].transform.position;
            Instantiate(enemy, randomPosition, Quaternion.identity);
            Spawns.RemoveAt(randomSpawnsIndex);
            countEnemy++;
        }
    }
}
