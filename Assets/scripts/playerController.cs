using System.Collections;
using System.Collections.Generic;
using System.Security;
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
    public ParticleSystem explosionPartical;
    public ParticleSystem dustCloud;
    public AudioClip explosion;
    public AudioClip jumpSound;
    private AudioSource AudioSource;
    //particles


    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            animator.SetTrigger("Jump_trig");
            dustCloud.Stop();
            AudioSource.PlayOneShot(jumpSound, 1.0f);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
    if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dustCloud.Play();
        }
        else if (collision.gameObject.CompareTag("Obsticle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
            explosionPartical.Play();
            dustCloud.Stop();
            AudioSource.PlayOneShot(explosion, 1.0f);
        }
    } 
   
}
