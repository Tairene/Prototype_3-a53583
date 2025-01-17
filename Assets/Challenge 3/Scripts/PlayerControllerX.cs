﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    //public float bounceForce;
    public float maxHeight;
    public float minHeight;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;
    private bool isLowEnough = true;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    //public AudioClip bounceSound;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= maxHeight)
        {
            isLowEnough = false;
        }
        else
        {
            isLowEnough = true;
        }
        if (transform.position.y <= minHeight)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }

        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && isLowEnough)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }

    }

    private void FixedUpdate()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.transform.position = other.transform.position;
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        }

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.transform.position = other.transform.position;
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }
        /* else if (other.gameObject.CompareTag("Ground"))
         {
             playerRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
             playerAudio.PlayOneShot(bounceSound, 1.0f);
         }
        */

    }

}
