using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    
    public Rigidbody2D beeRB;
    public float velocity;
    public float flipTime;

    private float flipCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        flipCounter += Time.deltaTime;

        if(flipCounter >= flipTime){
            velocity = -velocity;
            beeRB.velocity = new Vector2 (velocity, beeRB.velocity.y);
            flipCounter = 0f;
        }

        if (velocity > 0){
            transform.eulerAngles = new Vector2(0f, 180f);
        } else if (velocity < 0){
            transform.eulerAngles = new Vector2(0f, 0f);
        }
    }
}
