using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRB;

    //movement controls
    public float jumpForce;
    public float gravityMod;

    //bools to set states
    public bool isGrounded = true;

    public bool gameOver = false;

    //animations
    private Animator playerAnim;

    //particle effects
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    //sfx
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        //calls and then stores different compnents in the appropriate controllers
        playerRB = GetComponent<Rigidbody>();

        playerAnim = GetComponent<Animator>();

        playerAudio = GetComponent<AudioSource>();

        // *= is a = a * b (keeps the value in a without replacing it)
        Physics.gravity *= gravityMod;
        
    }

    // Update is called once per frame
    void Update()
    {
        // == is a comparison
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true && !gameOver)
        {
            isGrounded = false;

            //Plays the jump sound
            playerAudio.PlayOneShot(jumpSound, 1.0f);

            //adds momentum in a direction (posititve y)
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            //Triggers the Jump animation
            playerAnim.SetTrigger("Jump_trig");

            //stops the dirt particle from playing
            dirtParticle.Stop();

        }
    }

    void OnCollisionEnter(Collision other)
    {
        // if the player is on the ground set the bool and play the dirt particle effect
        if(other.gameObject.CompareTag("Ground") && !gameOver)
        {
            isGrounded = true;
            dirtParticle.Play();
        }

        //If you hit an obstacle play death animation, play explosion and sound, and stop the dirt particles from playing
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAudio.PlayOneShot(crashSound, 1.0f);
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
        }
    }


}
