using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chank : MonoBehaviour
{
    [SerializeField] public Transform Began;
    [SerializeField] public Transform End;
    [SerializeField] public List<Transform> FirstSpawnLine = new List<Transform>();
    [SerializeField] public List<Transform> SecondSpawnLine = new List<Transform>();
    [SerializeField] public List<Transform> ThirdSpawnLine = new List<Transform>();
    [SerializeField] public List<GameObject> MainSpawn = new List<GameObject>();

    void Start()
    {

    }
    void Update()
    {
        
    }
}
