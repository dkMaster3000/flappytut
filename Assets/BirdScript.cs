using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public CircleCollider2D circleCollider;
    private float colliderTimer = 0;
    private readonly int ghostTime = 3;



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

            if (Input.GetKeyDown(KeyCode.D) && circleCollider.enabled)
            {
                circleCollider.enabled = false;
                setAlpha(0.5f);

            } 

            if (!circleCollider.enabled)
            {
                colliderTimer += Time.deltaTime;
                if(colliderTimer > ghostTime)
                {
                    colliderTimer = 0;
                    circleCollider.enabled = true;
                    setAlpha(1f);
                }

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

    void setAlpha(float alpha)
    {
        SpriteRenderer[] children = GetComponentsInChildren<SpriteRenderer>();
        Color newColor;
        foreach (SpriteRenderer child in children)
        {
            newColor = child.color;
            newColor.a = alpha;
            child.color = newColor;
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
