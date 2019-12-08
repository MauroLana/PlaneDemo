using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script handles target behaviour.
public class TargetBehaviour : MonoBehaviour
{
    //Transform is used to move the target
    private Transform playerTransform;
    //This public integer is used to determine how many hits a target can withstand. Wiht the variable 
    //exposed in the inspector it's easy to create target variants, with more or less health points
    public int targetLife;
    //This is used to keep track of how many times the target has been hit
    private int currentLife;
    //Reference to the UI Manager
    private UIManager uIManager;

    private void Start()
    {
        //get the script component of the UI MAnager
        uIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    //Each target is constatly facing the player. I implemented this, depending on plane position, targets could become hard to see.
    void Update()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        this.transform.LookAt(playerTransform);
    }


    //This function keeps track of collisions with bullets
    private void OnTriggerEnter(Collider col)
    {
        //Bullets have this specific tag
        if(col.gameObject.tag == ("bullet"))
        {
            uIManager.ScoreUp();
            uIManager.UpdateScore();
            currentLife++;
            //ScoreUp
            //When hit 15 times destroy target
            if (currentLife >= targetLife)
                Destroy(this.gameObject);
        }
    }
}
