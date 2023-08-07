using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyukDonmeDolap : MonoBehaviour
{
    public GameObject gameObject;
    //tur attýðýný algýlayabilmemizi saðlayan trigger
    public GameObject obje;
    //donmedolap içndeki pozisyonu tutar
    public GameObject player;
    //XR Origin
    public GameObject cikis;
    //cikis kapýsý
    Vector3 konum;
    //çýkýþ kapýsýnýn konumunu tutar
    int control = 0;
    bool on = false;
    //giriþi check eder
    bool on2 = false;
    //çýkýþý check eder
    [SerializeField]


    int sayac = 0; //tur sayýsý
    public void Start()
    {
        konum = cikis.transform.position;
    }
    public void Update()
    {
        if (on == true)
        {
            player.transform.position = obje.transform.position;
           


        }
        if (control == 1 && on2 == true && sayac==2)
        {
            player.transform.position = konum;
            gameObject.SetActive(true);
            control = 0;
            on2 = false;
            on = false;
            sayac = 0;

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "dönme dolap")
        {
            on = true;
            gameObject.SetActive(false);
            //locomotion system yani hareketi devre dýþý býrakýr



        }
        if (other.gameObject.tag == "check point2")
        {
            on2 = true;

            control = 1;
            sayac++; //tur attýðýnda sayac artsýn
        }
    }
}