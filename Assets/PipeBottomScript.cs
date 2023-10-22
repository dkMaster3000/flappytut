using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBottomScript : MonoBehaviour
{

    public float deadZoneBottom = -25;
    public float deadZoneTop = 25;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < deadZoneBottom || transform.position.y > deadZoneTop)
        {
            //Debug.Log("pipe deleted top bottom");
            Destroy(gameObject);
        }
    }
}
