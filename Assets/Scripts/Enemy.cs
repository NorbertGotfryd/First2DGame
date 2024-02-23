using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 targetPosition;
    private Vector3 startPosition;

    public float moveSpeed;
    private bool movingToTargetPos;

    // Start is called before the first frame update
    void Start ()
    {
        startPosition = transform.position;
        movingToTargetPos = true;
    }

    // Update is called once per frame
    void Update ()
    {
        // are we moving to the target position?
        if(movingToTargetPos == true)
        {
            // move to the target over time
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // are we at the target position?
            if(transform.position == targetPosition)
            {
                movingToTargetPos = false;
            }
        }
        // are we moving to the start position?
        else
        {
            // move to the start over time
            transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);

            // are we at the start?
            if(transform.position == startPosition)
            {
                movingToTargetPos = true;
            }
        }
    }

    // called on the frame that we collide with another object
    private void OnCollisionEnter2D (Collision2D collision)
    {
        // did we collide with the player?
        if(collision.gameObject.CompareTag("Player"))
        {
            // call the player's GameOver function
            collision.gameObject.GetComponent<Player>().GameOver();
        }
    }
}
