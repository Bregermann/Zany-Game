using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpookyTree : MonoBehaviour
{
    public QuestManager QM;
    public StatManager SM;

    // Start is called before the first frame update
    private void Start()
    {
        QM.batChase = false;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            QM.numberOfSpookyTriggersTriggered++;
            SpookyTrigger();
        }
    }

    private void SpookyTrigger()
    {
        if (QM.numberOfSpookyTriggersTriggered == 1)
        {
            QM.spookyBat.SetActive(true);
        }
        else if (QM.numberOfSpookyTriggersTriggered == 2)
        {
            QM.batChase = true;
        }
        else if (QM.numberOfSpookyTriggersTriggered == 3)
        {
            QM.swarm.SetActive(true);
            QM.questStartText.text = "Escape! Get on the boat if you want to live!";
        }
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}