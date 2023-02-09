using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class HelixManager : MonoBehaviour
{
    public GameObject[] helixRings;

    public float ySpawn = 0;
    public float ringDistance = 5;

    public int numberOfRings;

    [Inject] private DiContainer _diContainer;
    void Start()
    {
        numberOfRings = GameManager.currentLevelIndex + 5;
        for (int i = 0; i < numberOfRings; i++)
        {
            if (i == 0)
                SpawnRing(0);
            else            
                SpawnRing(Random.Range(1, helixRings.Length - 1));
        } 
        SpawnRing(helixRings.Length - 1);
    }
    
    public void SpawnRing(int ringIndex)
    {
        GameObject go = _diContainer.InstantiatePrefab(helixRings[ringIndex], transform.up * ySpawn, Quaternion.identity, null);
        go.transform.parent = transform;
        ySpawn -= ringDistance;
    }
}
