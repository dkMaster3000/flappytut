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

    public AudioSource deadSound;



    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (birdIsAlive) {
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                myRigidbody.velocity = Vector2.up * flapStrength;
            }

            if (transform.position.y < deadZoneBottom || transform.position.y > deadZoneTop)
            {
                BirdDead();
            }
        } else
        {
            logic.gameOver();
        }

    }

   void BirdDead()
    {
        if(birdIsAlive)
        {
            deadSound.Play();
            birdIsAlive = false;
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BirdDead();
    }
}
