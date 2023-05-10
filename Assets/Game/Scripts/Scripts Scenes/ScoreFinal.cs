using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreFinal : MonoBehaviour
{
    public Text scoreTxt;
    private int score;

    void Start()
    {
        score = CoinsController.scoreFinal;

        if (score < 10)
        {
            scoreTxt.text = "0" + score.ToString();
        }
        else
        {
            scoreTxt.text = score.ToString();
        }
    }

    void Update()
    {
    }
}
