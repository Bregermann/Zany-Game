using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demo : MonoBehaviour
{
    public int numberOfTacos;
    public int numberOfTacosEaten;
    public int numberOfTacosBeforeVomit;
    public Text tacoText;
    public GameObject taco;

    // Start is called before the first frame update
    private void Start()
    {
        numberOfTacosEaten = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        tacoText.text = numberOfTacosEaten + " Tacos";
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("HOLY COW 100%!");
            //EatTaco();
        }
    }

    public void EatTaco()
    {
        //increase number of tacos eaten
        numberOfTacosEaten++;
        if (numberOfTacosEaten == numberOfTacosBeforeVomit)
        {
            Vomit();
        }
    }

    public void Vomit()
    {
        //stuff
    }
}