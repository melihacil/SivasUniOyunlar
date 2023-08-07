using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyukDonmeDolap : MonoBehaviour
{
    public GameObject gameObject;
    //tur att���n� alg�layabilmemizi sa�layan trigger
    public GameObject obje;
    //donmedolap i�ndeki pozisyonu tutar
    public GameObject player;
    //XR Origin
    public GameObject cikis;
    //cikis kap�s�
    Vector3 konum;
    //��k�� kap�s�n�n konumunu tutar
    int control = 0;
    bool on = false;
    //giri�i check eder
    bool on2 = false;
    //��k��� check eder
    [SerializeField]


    int sayac = 0; //tur say�s�
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
        if (other.gameObject.tag == "d�nme dolap")
        {
            on = true;
            gameObject.SetActive(false);
            //locomotion system yani hareketi devre d��� b�rak�r



 �������}
        if (other.gameObject.tag == "check point2")
        {
            on2 = true;

            control = 1;
            sayac++; //tur att���nda sayac arts�n
        }
    }
}