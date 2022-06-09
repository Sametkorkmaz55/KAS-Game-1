using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject karakter;

    void Start()
    {
        karakter = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, karakter.transform.position + new Vector3(0, 4, -7), Time.deltaTime * 10); //Vector3.Lerp(mevcut position, hedef position, yavaþlatma miktarý)
    }
}
