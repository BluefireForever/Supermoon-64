using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FireUpTrigger : MonoBehaviour
{
    public GameObject text;
    bool gained;
    bool off;
    bool firstTime;
    float time;
    int numOfFlashes;
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        gained = false;
        off = true;
        firstTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gained)
        {
            if (firstTime)
            {
                text.SetActive(true);
                firstTime = false;
                off = false;
                sound.Play();
            }
            time += Time.deltaTime;
            if (numOfFlashes > 3)
            {
                gained = false;
                text.SetActive(false);
                firstTime = true;
                time = 0;
                numOfFlashes = 0;
            }
            else if (time > 0.5f && off)
            {
                text.SetActive(true);
                time = 0.0f;
                off = false;
                numOfFlashes += 1;
            }
            else if (time > 0.5f && !off)
            {
                text.SetActive(false);
                time = 0.0f;
                off = true;
            }
        }
    }

    public void PowerUpGained()
    {
        gained = true;
    }
}
