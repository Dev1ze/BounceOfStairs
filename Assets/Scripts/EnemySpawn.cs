using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //[SerializeField] GameObject Enemy;
    //[SerializeField] List<GameObject> Spawns = new List<GameObject>();
    int countEnemy;
    void Start()
    {
        
    }

    void Awake()
    {
        Spawning();
    }
    public void Spawning()
    {
        //int randomSpawnsIndex = Random.Range(0, Spawns.Count);
        //Vector3 randomPosition = Spawns[randomSpawnsIndex].transform.position;
        //Instantiate(Enemy, randomPosition, Quaternion.identity);
        //countEnemy++;
        //Spawns.RemoveAt(randomSpawnsIndex);
        //Debug.Log(randomPosition);
    }

    
}

