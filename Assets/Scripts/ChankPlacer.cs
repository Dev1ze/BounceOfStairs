using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ChankPlacer : MonoBehaviour
{
    [SerializeField] Transform Player;
    public List<GameObject> SpawnedChanks;
    public List<GameObject> SpawnedEnemy;
    [SerializeField] public GameObject FirstChank;
    [SerializeField] public GameObject ChankPrefab;
    [SerializeField] public GameObject[] Enemy;
    int i;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        SpawnedChanks.Add(FirstChank);
        SpawnEnemy();
        InfinitySpawnEnemy();
    }

    void Update()
    {
        if (Player != null) 
        {
            if (Player.position.z > SpawnedChanks[SpawnedChanks.Count - 1].GetComponent<Chank>().Began.transform.position.z)
            {
                SpawnChank();
                DeleteChank();
            }
        }   
    }
    void SpawnEnemy() 
    {
        while (i < SpawnedChanks[SpawnedChanks.Count - 1].GetComponent<Chank>().MainSpawn.Count)
        {
            Component[] SpawnsLine = SpawnedChanks[SpawnedChanks.Count - 1].GetComponent<Chank>().MainSpawn[i].GetComponentsInChildren(typeof(Transform)); //ѕолучаем первый р€д точек-спавнов...2-ой...3-ий р€д   
            //Component[] newArray = RemoveFirstItemArray(ref array);
            GameObject newEnemy = Instantiate(Enemy[Random.Range(0, Enemy.Length)]);
            SpawnedEnemy.Add(newEnemy);
            newEnemy.transform.position = SpawnsLine[Random.Range(0, SpawnsLine.Length - 1)].GetComponent<Transform>().position;
            i++;
        }
    }

    async void InfinitySpawnEnemy()
    {
        while (Player != null)
        {
            if (SpawnedChanks[SpawnedChanks.Count - 1] != null)
            {
                Component[] array = SpawnedChanks[SpawnedChanks.Count - 1].GetComponent<Chank>().MainSpawn[2].GetComponentsInChildren(typeof(Transform));
                GameObject InfinityEnemy = Instantiate(Enemy[Random.Range(0, Enemy.Length)]);
                InfinityEnemy.transform.position = array[Random.Range(0, array.Length - 1)].GetComponent<Transform>().position;
                await Task.Delay(5000);
            }
            else await Task.Delay(5000);
        }
    }

    void DeleteChank()
    {
        if (SpawnedChanks.Count > 3)
        {
            Destroy(SpawnedChanks[0].gameObject);
            SpawnedChanks.RemoveAt(0);
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

    //Component[] RemoveFirstItemArray(ref Component[] array)
    //{
    //    Component[] newArray = new Component[array.Length - 1];
    //    for(int i = 1; i < array.Length; i++)
    //        newArray[i - 1] = array[i];
    //    return newArray;
    //}
}
