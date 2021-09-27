using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpookyBat : MonoBehaviour
{
    public Transform[] spots;
    public int whichSpot;
    public float speed;
    public float newTarget;
    public QuestManager QM;
    public GameObject player;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, spots[whichSpot].position, step);
        transform.LookAt(spots[whichSpot]);
        if (QM.batChase == false)
        {
            newTarget += Time.deltaTime;
            if (newTarget > 5)
            {
                whichSpot++;
                newTarget = 0;
            }
            if (whichSpot == 4)
            {
                whichSpot = 0;
            }
        }

        if (QM.batChase == true)
        {
            speed = 1;
            player.transform.position = player.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
            transform.LookAt(player.transform);
        }
    }
}