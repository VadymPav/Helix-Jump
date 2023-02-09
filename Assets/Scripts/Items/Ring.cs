using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class Ring : MonoBehaviour
{
    [Inject]
    private Player player;
    [Inject]
    private AudioManager _audioManager;
    [Inject] 
    private DiContainer _diContainer;
    
    public Transform playerPos;
    public List<GameObject> coinPos;
    public GameObject coinPrefab;

    public void Start()
    {
        playerPos = player._playerPos;
        
        var i = Random.Range(0, coinPos.Count);
        if(coinPos.Count > 0)
        {
            _diContainer.InstantiatePrefab(coinPrefab, new Vector3 (coinPos[i].transform.position.x, coinPos[i].transform.position.y + 1f, coinPos[i].transform.position.z), Quaternion.identity, coinPos[i].transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > playerPos.position.y)
        {
            _audioManager.Play("whoosh");
            GameManager.numberOfPassedRings++;
            GameManager.score++;
            Destroy(gameObject);
        }
    }
}
