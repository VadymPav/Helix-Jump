using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody playerRB;
    public float bounceForce = 6f;

    private AudioManager _audioManager;
    private void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _audioManager.Play("bounce");
        playerRB.velocity = new Vector3(playerRB.velocity.x, bounceForce, playerRB.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;
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
