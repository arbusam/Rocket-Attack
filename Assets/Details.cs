using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Details : MonoBehaviour
{

    TMP_Text scoreDetails;

    Score score;

    private void Start()
    {
        scoreDetails = GetComponent<TMP_Text>();
        score = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreDetails.text = "You won with a score of " + score.score.ToString() + ".";
        
    }
}
