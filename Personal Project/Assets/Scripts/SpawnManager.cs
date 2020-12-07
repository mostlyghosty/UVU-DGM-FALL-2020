using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] emptySpawns;
    private Vector3 spawnPos;
    private Quaternion spawnRot;
    public string spawnReplace;

    private GameObject spawnTarget;
    private int arrayPos;

    // Update is called once per frame
    void Update()
    {
        if(spawnReplace != "")
        {
            //if the player picks up the bone item
            if (spawnReplace == "Bone")
            {
                //get information about position of 'skulls'
               GameObject skulls = GameObject.Find("Skulls");
               Vector3 skullsposition = skulls.transform.position;
               Quaternion skullsRotation = skulls.transform.rotation;
               GameObject.Find(spawnReplace).SetActive(false);

               skulls.SetActive(false);

                //Instantiate new intteractable 'skulls' game object
               skulls.SetActive(false);
               Instantiate(emptySpawns[0], skullsposition, skullsRotation);

               spawnReplace = "";
            } 

            else
            {
                spawnTarget = GameObject.Find(spawnReplace);
                spawnPos = spawnTarget.transform.position;
                spawnRot = spawnTarget.transform.rotation;

                spawnTarget.SetActive(false);

                FindArrayPos();

                Instantiate(emptySpawns[arrayPos], spawnPos, spawnRot);

                spawnReplace = "";
            }  
        }
    }

    void FindArrayPos ()
    {
        if(spawnReplace == "Knife")
        {
            arrayPos = 1;
        }

        if(spawnReplace == "Ancient Note")
        {
            arrayPos = 2;
        }

        if(spawnReplace == "Spider Web")
        {
            arrayPos = 3;
        }

        if(spawnReplace == "Strange Gem")
        {
            arrayPos = 4;
        }
    }
}
