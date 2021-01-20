using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float time;

    private AudioSource adSource;
    public AudioClip beep;
    public bool isBeep = false;

    private BoxCollider2D boxCol;
    private SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        time = Random.Range(2f, 5f);
        adSource = gameObject.AddComponent<AudioSource>();
        adSource.loop = false;

        adSource.volume = 0.05f;

        boxCol = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();

        boxCol.enabled = false;
        renderer.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (time > 0f)
        {
            time -= Time.deltaTime;
            //Debug.Log(time);
        }
        

        if (time < 1f && !isBeep)
        {
            adSource.PlayOneShot(beep);
            isBeep = true;

        } else if (time < 0f)
        {
            obstacleOn();
        }
    }

    void obstacleOn()
    {
        boxCol.enabled = true;
        renderer.enabled = true;
    }
}
