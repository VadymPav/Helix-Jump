using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private Transform player;

    private AudioManager _audioManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > player.position.y)
        {
            _audioManager.Play("whoosh");
            GameManager.numberOfPassedRings++;
            Destroy(gameObject);
        }
    }
}
