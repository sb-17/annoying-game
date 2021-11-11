using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannonball : MonoBehaviour
{
    public Rigidbody2D rb2D;
    GameObject castle;
    Text ScoreText;

    public static float force = 20f;

    void Start()
    {
        if(transform.position.x > -9f && transform.position.x < 9 && transform.position.y > -9 && transform.position.y < 9)
        {
            Destroy(gameObject);
        }

        if(transform.position.x < -30f && transform.position.x > 30 && transform.position.y < -30 && transform.position.y > 30)
        {
            Destroy(gameObject);
        }

        StartCoroutine(DestroyAfter());

        castle = GameObject.Find("Castle");

        ScoreText = GameObject.Find("/Canvas/ScoreText").GetComponent<Text>();

        rb2D.AddForce((castle.transform.position-transform.position) * force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "FriendlyCannonball")
        {
            if(Castle.health > 0)
            {
                Castle.score += 1;
                ScoreText.text = "Score: " + Castle.score.ToString();
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyAfter()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
