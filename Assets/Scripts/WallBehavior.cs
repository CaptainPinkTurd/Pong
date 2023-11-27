using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WallBehavior : MonoBehaviour
{
    public Text PlayerScores;
    private int scores;
    public TMP_Text loserName;
    public BoxCollider2D currentWall;
    public Rigidbody2D ball;
    public TMP_Text winner;
    // Start is called before the first frame update
    void Start()
    {
        scores = 0;
        PlayerScores.text = scores.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        scores++;
        PlayerScores.text = scores.ToString();
        if (currentWall.name == "Left Wall")
        {
            if (scores >= 5)
            {
                winner.GetComponent<WinnerAnnouncement>().ChangeText(loserName.text);
                SceneManager.LoadScene("GameOver");
            }

            StartCoroutine(BallReset(-200f, new Vector2(-1f, 0f)));
        } else if (currentWall.name == "Right Wall")
        {
            if (scores >= 5)
            {
                winner.GetComponent<WinnerAnnouncement>().ChangeText(loserName.text);
                SceneManager.LoadScene("GameOver");
            }

            StartCoroutine(BallReset(200f, new Vector2(0.21f, 0f)));
        }
        
    }
    private IEnumerator BallReset(float dir, Vector2 newPos)
    {
        Debug.Log("Reset");
        ball.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        ball.velocity = new Vector2(0f, 0f);
        ball.transform.position = newPos;
        ball.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        ball.AddForce(new Vector2(dir, 0f));
        ball.GetComponent<BallMovement>().hitCount = 0;
    }
}
