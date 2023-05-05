using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leapold : MonoBehaviour
{
    public Rigidbody2D myRigidBody2d; 

    int numberOfTimes = 5;
    string nameOfTheKey = "Enter";
    float speedOfBreaking = 6.94f;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("If you press the up arrow you'll JUMP");
        //Debug.Log("If you Press the right arrow " + numberOfTimes + " you'll move!");

        //Debug.LogWarning("If you press the " + nameOfTheKey + ", nothing happens");
        //Debug.LogError("If you smash the keyboard at a speed of " + speedOfBreaking + " nothing happens, you just cry");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            myRigidBody2d.velocity = new Vector2(0f, 10f);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            myRigidBody2d.velocity = new Vector2(0f, -10f);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            myRigidBody2d.velocity = new Vector2(-10f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            myRigidBody2d.velocity = new Vector2(10f, 0f);
        }

    }
}
