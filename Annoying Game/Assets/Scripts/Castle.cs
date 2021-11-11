using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Castle : MonoBehaviour
{
    public static int health = 5;
    float distanceFactor = 15f;
    public GameObject cannonball;
    public GameObject friendlyCannonball;
    float waitTime;

    public Sprite castle3;
    public Sprite castle2;
    public Sprite castle1;
    public Sprite castle0;
    public Sprite castleDestroyed;

    public GameObject blackScreen;

    public static Vector3 mousePos;

    public static int score;

    public static bool canShoot = true;

    void Start()
    {
        score = 0;
        canShoot = true;
        waitTime = 1.2f;
        health = 5;

        StartCoroutine(Spawning());
        StartCoroutine(BlackScreen());
    }

    GameObject SpawnCannonballNearby()
    {
        Vector3 randomPosition = Random.onUnitSphere * distanceFactor;

        GameObject instance = Instantiate(cannonball, gameObject.transform.position + randomPosition, Quaternion.identity);

        return instance;
    }

    IEnumerator BlackScreen()
    {
        while(true)
        {
            int random = Random.Range(1, 13);
            if(random == 2)
            {
                blackScreen.SetActive(true);
                yield return new WaitForSeconds(2f);
                blackScreen.SetActive(false);
            }

            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator Spawning()
    {
        while(true)
        {
            SpawnCannonballNearby();

            yield return new WaitForSeconds(waitTime);
        }
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && canShoot == true)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Instantiate(friendlyCannonball, gameObject.transform.position, Quaternion.identity);
        }
    }

    IEnumerator EndGame()
    {
        canShoot = false;

        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            score = 0;
        }

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("GameOver");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Cannonball")
        {
            waitTime -= 0.2f;
            Cannonball.force += 7;

            health -= 1;

            if(health == 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = castleDestroyed;
                StartCoroutine(EndGame());
            }
            else if(health == 1)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = castle0;
            }
            else if (health == 2)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = castle1;
            }
            else if (health == 3)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = castle2;
            }
            else if (health == 4)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = castle3;
            }

            Destroy(collision.gameObject);
        }
    }
}
