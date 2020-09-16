using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //sets target for the camera to follow
    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -10);
    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        // makes the main camera follow the players position and rotation
    transform.position = player.transform.position + offset;

    }
}
