using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float jumpForce;
    public float gravityMod;

    public bool isGrounded = true;

    public bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        //Stores the rigidbody component in the variable playerRB
        playerRB = GetComponent<Rigidbody>();

        // *= is a = a * b (keeps the value in a without replacing it)
        Physics.gravity *= gravityMod;
        
    }

    // Update is called once per frame
    void Update()
    {
        // == is a comparison
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            //adds momentum in a direction (posititve y)
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        else if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");
        }
    }


}
