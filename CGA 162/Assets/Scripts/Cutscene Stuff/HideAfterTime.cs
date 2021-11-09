using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAfterTime : MonoBehaviour
{
    public float t;
    public AudioSource bgm;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        t -= Time.deltaTime;
        if (t <= 0)
        {
            BeginGameplay();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            BeginGameplay();
        }
    }

    private void BeginGameplay()
    {
        bgm.Play();
        this.gameObject.SetActive(false);
    }
}