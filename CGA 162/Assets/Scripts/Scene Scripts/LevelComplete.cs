using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public QuestManager QM;

    private void OnTriggerEnter(Collider other)
    {
        QM.LevelCompleteOne();
    }
}