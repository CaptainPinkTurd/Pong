using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody2D ball;
    internal int hitCount = 0;
    public float movementSpeed = 200f;
    public float accelearateSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game started");
        Vector2 initial = new Vector2(-200f, 0f);
        ball.AddForce(initial);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float y = (ball.transform.position.y - collision.gameObject.transform.position.y) / collision.gameObject.transform.localScale.y;    
        if (collision.gameObject.CompareTag("Player 1"))
        {
            MoveBall(new Vector2(1f, y));
        } else if(collision.gameObject.CompareTag("Player 2"))
        {
            MoveBall(new Vector2(-1f, y));
        }
    }

    private void MoveBall(Vector2 dir)
    {
        dir = dir.normalized;
        hitCount = hitCount < 10 ? hitCount+=1 : hitCount = 10;
        float speed = movementSpeed + (accelearateSpeed * hitCount);
        ball.velocity = speed * dir;
        //Debug.Log("Hit count: " + hitCount);
    }
}
