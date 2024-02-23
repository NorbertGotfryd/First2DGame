using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rig;
    public float jumpForce;
    public SpriteRenderer sr;
    public int score;
    public UI ui;

    // called every 0.02 seconds - used for physics
    void FixedUpdate ()
    {
        // get our horizontal input
        float xInput = Input.GetAxis("Horizontal");

        // set our velocity based on our input
        rig.velocity = new Vector2(xInput * moveSpeed, rig.velocity.y);
    }

    // Update is called once per frame
    void Update ()
    {
        // did we press down the Up Arrow and are we grounded?
        if(Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // flip the sprite based on the horizontal move direction
        if(rig.velocity.x > 0)
        {
            sr.flipX = false;
        }
        else if(rig.velocity.x < 0)
        {
            sr.flipX = true;
        }
    }

    // are we standing on the ground?
    bool IsGrounded ()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -0.1f, 0), Vector2.down, 0.2f);
        return hit.collider != null;
    }

    // called when we collide with an enemy - restart the scene
    public void GameOver ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // adds an amount of score to our player
    public void AddScore (int amount)
    {
        score += amount;
        ui.SetScoreText(score);
    }
}
