using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hobo : MonoBehaviour
{
    public Canvas hoboConvo;
    public Camera cam;
    public Camera actionCam;
    public AudioSource hobo;
    public AudioClip[] hoboClip;
    public float speed;
    public GameObject hoboObj;
    public Transform hoboMoveTo;
    public Transform hoboYeetTo;
    public bool hoboGived;
    public bool hoboYeeted;
    public int x;
    public int y;
    public int z;
    public float camTimer;

    public StatManager SM;

    private void Update()
    {
        if (hoboGived == true)
        {
            float step = speed * Time.deltaTime;
            hoboObj.transform.position = Vector3.MoveTowards(transform.position, hoboMoveTo.position, step);
            hoboObj.transform.Rotate(x, y, z);
        }
        if (hoboYeeted == true)
        {
            float step = 50 * speed * Time.deltaTime;
            hoboObj.transform.position = Vector3.MoveTowards(transform.position, hoboYeetTo.position, step);
            hoboObj.transform.Rotate(x, y, z);
            camTimer -= Time.deltaTime;
        }
        if (camTimer < 0)
        {
            actionCam.gameObject.SetActive(false);
            hoboYeeted = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            HoboBobo();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            HoboNobo();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Z))
            {
                HoboGive();
            }
            if (Input.GetKey(KeyCode.X))
            {
                HoboYeet();
            }
        }
    }

    private void HoboGive()
    {
        cam.gameObject.SetActive(false);
        hoboConvo.gameObject.SetActive(false);
        hobo.clip = hoboClip[2];
        hobo.Play();
        hoboGived = true;
        SM.money -= 1;
        SM.hoboRep += 10;
        SM.dollarsGiven++;
        //need to add UI elements expressing this loss of money and gain in hobo rep
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private void HoboYeet()
    {
        cam.gameObject.SetActive(false);
        hoboConvo.gameObject.SetActive(false);
        actionCam.gameObject.SetActive(true);
        hobo.clip = hoboClip[3];
        hobo.Play();
        hoboYeeted = true;
        SM.hoboRep -= 20;
        SM.hobosYeeted++;
        camTimer = 8;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private void HoboBobo()
    {
        cam.gameObject.SetActive(true);
        hoboConvo.gameObject.SetActive(true);
        hobo.clip = hoboClip[0];
        hobo.Play();
    }

    private void HoboNobo()
    {
        cam.gameObject.SetActive(false);
        hoboConvo.gameObject.SetActive(false);
        hobo.clip = hoboClip[1];
        hobo.Play();
    }
}