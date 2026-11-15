using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class JokeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject joke;
    [SerializeField] private float notOnScreen = 2f;
    [SerializeField] private float spawnChange = 10000;
    private List<GameObject> jokes = new List<GameObject>();
    // private float spawnChangeConst;
    // private float timeFromRespawn;
    private float screenWidth;
    private void Awake()
    {
        screenWidth = Camera.main.orthographicSize * 2;
        // timeFromRespawn = Time.time;
        // spawnChangeConst = spawnChange;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // spawnChange = spawnChange - (Time.time - timeFromRespawn);

        // if (spawnChange < 1) spawnChange = spawnChangeConst;

        if (Mathf.Round(Random.Range(0, spawnChange)) == Mathf.Round(spawnChange / 2))
        {
            Vector2 jokePos = Vector2.zero;
            if (Random.Range(1, 10) <= 5)
            {
                jokePos.x = -screenWidth - notOnScreen;
            }
            else
            {
                jokePos.x = screenWidth + notOnScreen;
            }

            jokePos.y = Random.Range(-4, 4);

            GameObject go = Instantiate<GameObject>(joke);
            go.transform.position = jokePos;
            jokes.Add(go);
            
            Vector2 jokeNewPos = Vector2.zero;
            jokeNewPos.x = -jokePos.x;
            jokeNewPos.y = Random.Range(-3, 3);

            // timeFromRespawn = Time.time;
            // spawnChange = spawnChangeConst;

            go.GetComponent<Rigidbody2D>().linearVelocity = jokeNewPos;
        }
    }
}
