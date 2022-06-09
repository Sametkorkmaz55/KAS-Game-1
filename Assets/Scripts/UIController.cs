using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private LevelController level;
    private GameController game;
    private PlayerControl player;

    public GameObject baslatMenu;
    public GameObject oyunSonuMenu;


    public Text scoreText;
    public Text toplamScoreText;

    void Start()
    {
        level = GameObject.FindObjectOfType<LevelController>(); //Ilk buldugu obje turunudekini alýr
        game = GameObject.FindObjectOfType<GameController>();
        player = GameObject.FindObjectOfType<PlayerControl>();


        toplamScoreText.text = (PlayerPrefs.GetFloat("score")).ToString();
    }

    public void Baslat()
    {
        game.oyunAktifMi = true;
        baslatMenu.SetActive(false); //objenin aktifliðini ayarlar
        player.KosmaAnimasyonBaslat();
    }

    public void TekrarOyna()
    {
        level.AyniBolumuGetir();
    }

    public void OyunSonuAyarlari()
    {
        oyunSonuMenu.SetActive(true);
    }

    public void ScoreYazdir(float deger)
    {
        scoreText.text = deger.ToString(); //verilen deðiþkenin türünü stringe çevirir
    }
}

