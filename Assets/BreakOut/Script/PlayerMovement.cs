using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 9;
    public float boundary = 7.9f;
    private float movementHorizontal;

    // Update is called once per frame
    private void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal");
        if ((movementHorizontal > 0 && transform.position.x < boundary) || (movementHorizontal < 0 && transform.position.x > -boundary))
        {
            transform.position += Vector3.right * movementHorizontal * speed * Time.deltaTime;
        }
    }
}