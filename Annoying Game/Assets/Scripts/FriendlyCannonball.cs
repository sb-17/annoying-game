using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyCannonball : MonoBehaviour
{
    public Rigidbody2D rb2D;
    GameObject castle;

    float force = 100f;

    void Start()
    {
        StartCoroutine(DestroyAfter());

        castle = GameObject.Find("Castle");

        Physics2D.IgnoreCollision(castle.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());

        rb2D.AddForce(Castle.mousePos * force);
    }

    IEnumerator DestroyAfter()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}