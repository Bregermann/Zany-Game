using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerOnCollision : MonoBehaviour
{
    public QuestManager QM;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            QM.QuestFail();
        }
    }
}