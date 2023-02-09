using System;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    public Rigidbody playerRB;
    public Transform _playerPos;
    public float bounceForce = 6f;

    [Inject]
    private AudioManager _audioManager;

    private void Start()
    {
        _playerPos = transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _audioManager.Play("bounce");
        playerRB.velocity = new Vector3(playerRB.velocity.x, bounceForce, playerRB.velocity.z);
        string materialName = collision.transform.GetComponentInChildren<MeshRenderer>().material.name;
        if (materialName == "Safe (Instance)")
        {
            
        }
        else if (materialName == "Unsafe (Instance)")
        {
            _audioManager.Play("game over");
            GameManager.gameOver = true;
        }
        else if (materialName == "LastRing (Instance)" && !GameManager.levelComplete)
        {
            _audioManager.Play("win level");
            GameManager.levelComplete = true;
        }
    }
}
