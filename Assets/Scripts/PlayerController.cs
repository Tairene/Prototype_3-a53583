
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public float jumpForce;
    public float gravityModifier;
    public bool isOGround = true;
    public bool gameOver = false;


     

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOGround = false;
            playerAnim.SetTrigger("Jump_trig");
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
            Debug.Log("Game Over!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        } 
    }
}