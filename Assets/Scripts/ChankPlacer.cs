using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChankPlacer : MonoBehaviour
{
    [SerializeField] Transform Player;
    public List<GameObject> SpawnedChanks;
    public List<GameObject> SpawnedEnemy;
    [SerializeField] public GameObject FirstChank;
    [SerializeField] public GameObject ChankPrefab;
    [SerializeField] public GameObject Enemy;
    int i;
    void Start()
    {
        SpawnedChanks.Add(FirstChank);
        SpawnEnemy();
    }

    void Update()
    {
        if (Player.position.z > SpawnedChanks[SpawnedChanks.Count - 1].GetComponent<Chank>().Began.transform.position.z)
        {
            SpawnChank();
            DeleteChank();
            SpawnEnemy();
        }
    }
    void SpawnEnemy() 
    {
        while (i < SpawnedChanks[SpawnedChanks.Count - 1].GetComponent<Chank>().MainSpawn.Count)
        {
            Component[] array = SpawnedChanks[SpawnedChanks.Count - 1].GetComponent<Chank>().MainSpawn[i].GetComponentsInChildren(typeof(Transform));
            Component[] newArray = RemoveFirstItemArray(ref array);
            GameObject newEnemy = Instantiate(Enemy);
            SpawnedEnemy.Add(newEnemy);
            newEnemy.transform.position = newArray[Random.Range(0, newArray.Length - 1)].GetComponent<Transform>().position;
            i++;
        }
    }

    void DeleteChank()
    {
        if (SpawnedChanks.Count > 3)
        {
            Destroy(SpawnedChanks[0].gameObject);
            SpawnedChanks.RemoveAt(0);
            for (int i = 0; i < 3; i++)
            {
                Destroy(SpawnedEnemy[i].gameObject);
                SpawnedEnemy.RemoveAt(i);
            }
        }
    }

    void SpawnChank()
    {
        GameObject newChank = Instantiate(ChankPrefab);
        newChank.transform.position = SpawnedChanks[SpawnedChanks.Count - 1].GetComponent<Chank>().End.position - newChank.GetComponent<Chank>().Began.transform.localPosition;
        SpawnedChanks.Add(newChank);
        i = 0;
        SpawnEnemy();
    }

    Component[] RemoveFirstItemArray(ref Component[] array)
    {
        Component[] newArray = new Component[array.Length - 1];
        for(int i = 1; i < array.Length; i++)
            newArray[i - 1] = array[i];
        return newArray;
    }
}
