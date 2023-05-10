using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsController : MonoBehaviour
{
    public Text scoreTxt;
    private int score;
    public static int scoreFinal;

    private void Start()
    {
        score = 0;
        scoreFinal = 0;
    }

    private void Update()
    {   
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("coins"))
        {
            score += 1;
            scoreFinal = score;
            Destroy(collider.gameObject);

            Score();
        }
    }

    void Score()
    {
        if (score < 10)
        {
            scoreTxt.text = "0" + score.ToString();
        }
        else
        {
            scoreTxt.text = score.ToString();
        }
    }
}
