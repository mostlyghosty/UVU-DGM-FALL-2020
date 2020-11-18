using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //speed to the player
    public float speed;

    //the players rigidbody
    private Rigidbody playerRb;

    //the focal point of the camera
    public GameObject focalPoint;
    
    //Powerups
    public bool hasPowerUp;
    private float powerUpStr = 15.0f;
    public GameObject powerUpIndicator;

    // Start is called before the first frame update
    void Start()
    {
        //initializes player rigidbody and the focal point
        playerRb = GetComponent<Rigidbody>();

        focalPoint = GameObject.Find("Focal Point");

        powerUpIndicator.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //initializes input
       float forwardInput = Input.GetAxis("Vertical");

       //moves the player forward based on input, speed, and where the focal point is
       playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        //the position of the powerup indicator is the position of the player plus an offset
       powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        //if the collision has the tag powerup
        if(other.CompareTag("PowerUp"))
        {
            //sets flag for the player to have the powerup
            hasPowerUp = true;

            //destroys the powerup
            Destroy(other.gameObject);

            //begins timer on how long the powerup lasts
            StartCoroutine(PowerUpCountDown());

            //displays the powerup indicator....
            powerUpIndicator.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //if the player collides with an enemy while having the powerup
        if(other.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            //initializes the enemy rigidbody
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            
            //initializes what direction to push the enemy away
            Vector3 pushAway = (other.transform.position - transform.position);

            //pushes the enemy away
            enemyRb.AddForce(pushAway * powerUpStr, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCountDown()
    {
        //waits for seven seconds
        yield return new WaitForSeconds(7); 

        //removes the powerup effect from the player
        hasPowerUp = false;

        //hides the powerup indicator
        powerUpIndicator.SetActive(false);
    }
}

