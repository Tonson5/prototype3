using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator animator;

    //particles
    public ParticleSystem dustCloud;

    void Start()
    {
        
        animator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        dustCloud.Stop();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            animator.SetTrigger("Jump_trig");
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
    if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obsticle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
        }
    } 
   
}
