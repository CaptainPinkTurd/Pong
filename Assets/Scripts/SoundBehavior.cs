using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBehavior : MonoBehaviour
{
    public AudioSource bounceSound;
    public AudioSource goalSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.bounceSound.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.goalSound.Play();  
    }
}
