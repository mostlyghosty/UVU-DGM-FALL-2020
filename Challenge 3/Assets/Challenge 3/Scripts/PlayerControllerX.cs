using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    //bool to set game state
    public bool gameOver;

    //modifiers for physics
    public float floatForce;
    private float gravityModifier = 1f;

    //creates a variable for the highest top bounds of the game
    private float topBounds = 15f;

    //creates a variable for the rigid body
    private Rigidbody playerRb;
    
    //particles
    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    //SFX
    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;


    // Start is called before the first frame update
    void Start()
    {
        //sets up Gravity
        Physics.gravity *= gravityModifier;

        //Calls components attatched to player
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }

        //if player goes out of bounds stop them and then push them back in bounds
        if (transform.position.y > topBounds)
        {
            transform.position = new Vector3(transform.position.x, 15, transform.position.z);
            playerRb.AddForce(Vector3.down * 2, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);

            //stops the ballon from falling to the floor and constantly bouncing
            playerRb.isKinematic = true;
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

        //if the player collides with the ground, push it upwards and play sound
        else if (other.gameObject.CompareTag("Ground"))
        {
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            playerAudio.PlayOneShot(bounceSound, 1.0f);
        }

    }

}
