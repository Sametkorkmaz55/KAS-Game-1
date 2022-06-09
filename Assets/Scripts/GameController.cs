using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool oyunAktifMi;

    public float score;

    private UIController uIController;

    void Start()
    {
        oyunAktifMi = false;
        uIController = GameObject.FindObjectOfType<UIController>();

        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreArtir()
    {
        score = score + 1;
        PlayerPrefs.SetFloat("score", PlayerPrefs.GetFloat("score") + 1);
        uIController.ScoreYazdir(score);
    }


}
