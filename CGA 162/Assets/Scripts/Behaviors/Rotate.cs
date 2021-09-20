using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public AudioSource whooshies;
    public AudioClip[] whooshWhoosh;
    private float sound;
    public int speed;
    public float x;
    public float y;
    public float z;

    // Start is called before the first frame update
    private void Start()
    {
        x = Random.Range(-200, 200) / 100;
        y = Random.Range(-200, 200) / 100;
        z = Random.Range(-200, 200) / 100;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(x, y, z);
        sound -= Time.deltaTime;
        if (sound < 0)
        {
            WhooshMe();
        }
    }

    private void WhooshMe()
    {
        whooshies.clip = whooshWhoosh[Random.Range(0, 46)];
        whooshies.Play();
        sound = Random.Range(0, 2);
    }
}