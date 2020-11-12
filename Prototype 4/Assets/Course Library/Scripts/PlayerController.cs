using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody playerRb;

    public GameObject focalPoint;
    
    public bool hasPowerUp;

    private float powerUpStr = 15.0f;

    public GameObject powerUpIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        focalPoint = GameObject.Find("Focal Point");

    }

    // Update is called once per frame
    void Update()
    {
       float forwardInput = Input.GetAxis("Vertical");
       playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

       powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDown());
            powerUpIndicator.gameObject.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 pushAway = (other.gameObject.transform.position - transform.position);
            enemyRb.AddForce(pushAway * powerUpStr, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(7); hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);

    }
}

