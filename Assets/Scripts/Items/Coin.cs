using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Coin : MonoBehaviour
{
    [Inject] 
    private GameManager _gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _gameManager.IncreaseMoney();
            Destroy(gameObject);
        }
    }
}
