using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpookyBatSwarm : MonoBehaviour
{
    public Transform swarmTo;
    public GameObject player;
    public float speed;
    public float murderTime;

    private void Update()
    {
        murderTime += Time.deltaTime;
        float step = speed * Time.deltaTime;
        if (murderTime < 8)
        {
            transform.position = Vector3.MoveTowards(transform.position, swarmTo.position, step);
            transform.LookAt(swarmTo);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
            transform.LookAt(player.transform.position);
        }
    }
}