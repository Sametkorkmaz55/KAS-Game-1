using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private GameController game;
    private UIController uI;

    private Rigidbody fizik;
    private Animator anim;

    private Vector3 ilkDokunuþ;
    private bool haraketedebilirMi;
    private int karakterPosX;


    void Start()
    {
        game = GameObject.FindObjectOfType<GameController>();
        uI = GameObject.FindObjectOfType<UIController>();
        karakterPosX = 0;

        fizik = GetComponent<Rigidbody>();
        anim = transform.GetChild(0).GetComponent<Animator>(); //Cocuk objesine erismede kullanilir
        Debug.Log("A");
    }


    void Update()
    {
        if (game.oyunAktifMi)
        {
            Haraket();
        }
    }

    // Quaternion.Euler()    icerisine Vector3 cinsinden deger verilerek rotasyon degerini degistirilebilir
    private void Haraket()
    {
        transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * 8);
        transform.position = Vector3.Lerp(transform.position, new Vector3(karakterPosX, transform.position.y, transform.position.z), Time.deltaTime * 6);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(Vector3.up * (karakterPosX - transform.position.x) * 40), Time.deltaTime * 10); //Yavasca donmeyi saglar

        if (Input.GetMouseButtonDown(0))
        {
            ilkDokunuþ = Input.mousePosition;
            haraketedebilirMi = true;
        }

        if (Input.GetMouseButton(0) && haraketedebilirMi)
        {
            if ((Input.mousePosition.y - ilkDokunuþ.y) >= 500)
            {
                haraketedebilirMi = false;
                Ziplama();
            }

            if ((Input.mousePosition.y - ilkDokunuþ.y) <= -500)
            {
                haraketedebilirMi = false;
                //Assagi egilecek
            }

            if ((Input.mousePosition.x - ilkDokunuþ.x) >= 500 && karakterPosX < 2)
            {
                haraketedebilirMi = false;
                karakterPosX += 2;
            }

            if ((Input.mousePosition.x - ilkDokunuþ.x) <= -500 && karakterPosX > -2)
            {
                haraketedebilirMi = false;
                karakterPosX -= 2;
            }
        }

    }

    private void Ziplama()
    {
        if (fizik.velocity.y == 0)
        {
            fizik.velocity = new Vector3(0, 5, 0);
            anim.SetTrigger("ZiplamaP");
        }
    }

    public void KosmaAnimasyonBaslat()
    {
        anim.SetBool("YurumeP", true);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("finish"))
        {
            game.oyunAktifMi = false;
            uI.OyunSonuAyarlari();
        }
        else if (other.CompareTag("Engel"))
        {
            game.oyunAktifMi = false;
            uI.OyunSonuAyarlari();
            anim.SetTrigger("DusmeP");
        }
        else if (other.CompareTag("Peynir"))
        {
            game.ScoreArtir();
            Destroy(other.gameObject);  //Destroy yok etmek demektir      parentez içindeki objeyi yok eer
        }
    }
}
