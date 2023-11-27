using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardAiScript : MonoBehaviour
{
    public Rigidbody2D racket;
    public Rigidbody2D ball;
    public float speed = 5f;

    private void FixedUpdate()
    {
        FollowBall(new Vector2(0f, ball.position.y - racket.position.y));
    }
    internal void FollowBall(Vector2 dir)
    {
        dir = dir.normalized;
        float aiRein = ball.transform.localPosition.y - racket.transform.localPosition.y;
        if (aiRein >= -0.15f && aiRein <= 0.15f)
        {
            racket.velocity = new Vector2(0f, 0f);
        }
        racket.velocity = racket.velocity.y >= 12f ? new Vector2(0f, 12f) : racket.velocity + (dir * speed * Time.deltaTime);
    }
}
