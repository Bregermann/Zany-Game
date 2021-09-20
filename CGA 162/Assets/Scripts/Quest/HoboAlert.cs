using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoboAlert : MonoBehaviour
{
    public Camera camcam;
    private float camno;
    public AudioSource hoboSource;
    public GameObject spinningTrees;
    public Text updateText;

    public void Start()
    {
        camno = -1;
    }

    public void Update()
    {
        if (camno > -1)
        {
            camno -= Time.deltaTime;
        }
        if (camno > -1 && camno < 0)
        {
            Deactivate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            camcam.gameObject.SetActive(true);
            camno = 3;
            hoboSource.Play();
            spinningTrees.SetActive(false);
            updateText.text = "";
        }
    }

    private void Deactivate()
    {
        camcam.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}