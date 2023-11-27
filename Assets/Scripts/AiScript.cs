using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class AiScript : MonoBehaviour
{
    public Rigidbody2D racket;
    public Rigidbody2D ball;
    public float speed = 5f;

    private void FixedUpdate()
    {
        if (ball.velocity.x > 0f)
        {
            FollowBall(new Vector2(0f, ball.position.y - racket.position.y));
        }
        else
        {
            racket.velocity = new Vector2(0f, 0f);
        }
    }
    internal void FollowBall(Vector2 dir)
    {
        dir = dir.normalized;
        float aiRein = ball.transform.localPosition.y - racket.transform.localPosition.y;
        if (aiRein >= -0.3f && aiRein <= 0.3f)
        {
            racket.velocity = new Vector2(0f, 0f);
        }
        racket.velocity = racket.velocity.y >= 5f ? new Vector2(0f, 5f) : racket.velocity + (dir * speed * Time.deltaTime);
    }

    //private IEnumerator AiBehavior()
    //{
    //    racket.velocity = new Vector2 (0f, 0f); 
    //    yield return new WaitWhile(() => ball.velocity.x < 0f);
    //    FollowBall(new Vector2(0f, ball.position.y - racket.position.y));
    //}
}
