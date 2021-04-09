using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{

    Score score;

    TMP_Text scoreText;

    private void Start()
    {
        score = FindObjectOfType<Score>();
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = score.score.ToString();
    }

    public void modifyScoreBy(int amount)
    {
        score.score += amount;
        scoreText.text = score.score.ToString();
        //TODO: Game over if score is < 0.
    }

}
