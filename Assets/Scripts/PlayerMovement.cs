using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D racket;
    // Start is called before the first frame update
    void Start()
    {
        racket = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(racket.gameObject.CompareTag("Player 1"))
        {
             float verticalMovement = Input.GetAxisRaw("Vertical");

             Vector2 movement = new Vector2(0f, verticalMovement);

             racket.velocity = movement * speed;
        } 
        if(racket.gameObject.CompareTag("Player 2"))
        {
             float verticalMovement = Input.GetAxisRaw("Vertical2");

             Vector2 movement = new Vector2(0f, verticalMovement);

             racket.velocity = movement * speed;
        }
    }
}
