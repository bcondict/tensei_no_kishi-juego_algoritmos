using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float speed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            rigidbody.MovePosition(new Vector2(speed * Time.deltaTime, 0));
            // rigidbody.AddForce(new Vector2(speed * Time.deltaTime, 0));
        }
        if (Input.GetKey("a"))
        {
            // rigidbody.AddForce(new Vector2((speed * Time.deltaTime) * -1, 0));
        }
        if (Input.GetKey("s"))
        {
            // rigidbody.AddForce(new Vector2(0, (speed * Time.deltaTime) * -1));

        }
        if (Input.GetKey("w"))
        {
            // rigidbody.AddForce(new Vector2(0, speed * Time.deltaTime));
        }
    }
}
