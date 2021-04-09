using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    GameObject parent;
    [SerializeField] int scorePerHit = 1;

    [SerializeField] int startHP = 1;
    int HP;

    ScoreBoard scoreBoard;

    TMP_Text HPtext;

    private void Start()
    {
        Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        parent = GameObject.FindWithTag("SpawnAtRuntime");
        HPtext = GetComponentInChildren<TMP_Text>();
        HP = startHP;
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void Update()
    {
        HPtext.text = HP.ToString();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        UpdateScore();
    }

    private void ProcessHit()
    {
        HP -= 1;
        if (HP == 0)
        {
            GameObject vfx = Instantiate(deathVFX, this.transform.position, Quaternion.identity);
            vfx.transform.parent = parent.transform;
            HP -= 1;
            Destroy(gameObject);
        }
        
    }

    private void UpdateScore()
    {
        scoreBoard.modifyScoreBy(scorePerHit);
    }
}
