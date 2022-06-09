using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaritaController : MonoBehaviour
{
    public GameObject[] bolumler;


    private GameObject karakter;
    private float deger;
    private float haritaDegeri;



    void Start()
    {
        karakter = GameObject.FindWithTag("Player");
        haritaDegeri = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(karakter.transform.position.z + 45 >= deger)
        {
            HaritaOlustur();
        }
    }

    public void HaritaOlustur()
    {
        Instantiate(bolumler[Random.Range(0, bolumler.Length)], new Vector3(0, 0, 40) * haritaDegeri ,Quaternion.identity);
        deger = deger + 30;
        haritaDegeri++;
    }


}
