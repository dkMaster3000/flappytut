using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength = 10;

    public LogicScript logic;
    public bool birdIsAlive = true;

    public float deadZoneTop = 15;
    public float deadZoneBottom = -15;



    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
     
        if (transform.position.y < deadZoneBottom || transform.position.y > deadZoneTop)
        {
            birdDead();
        }

        if (birdIsAlive == false)
        {
            logic.gameOver();
        }
        
    }

   void birdDead()
    {
        birdIsAlive = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        birdDead();
    }
}
