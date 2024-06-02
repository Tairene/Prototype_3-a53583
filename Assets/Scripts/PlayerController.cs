
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOGround = true;
    public bool gameOver = false;

     

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOGround = false;
        }
    }
       
    
        private void OnCollisionEnter(Collision Collision)
        {
            if (Collision.gameObject.CompareTag("Ground"))
            {

                isOGround = true;
            }
            else if (Collision.gameObject.CompareTag("Obstacle"))
            
            { 
            gameOver = true;
            Debug.Log("Game Over!");
        } 
    }
}