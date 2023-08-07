using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerCoaster : MonoBehaviour
{
    public GameObject gameObject;
    //tur attýðýný algýlayabilmemizi saðlayan trigger
    public GameObject obje;
    //rollercoasterýn içndeki pozisyonu tutar
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
    Vector3 rotasyon;


    public float currentTime;
    public float duration;  //bizim belirleyece?imiz süre

    private int sayac = 0; 
    [SerializeField]


    public void Start()
    {
       konum= cikis.transform.position;
        rotasyon = new Vector3(0, 0, 0);

        currentTime = duration;
        
    }
    public void Update()
    {
        if (on == true)
        {
            player.transform.position = obje.transform.position;
            player.transform.rotation = obje.transform.rotation;

        }
        if (control == 1&& on2==true && currentTime<=0) //&& currentTime<=0 
        {
            player.transform.position = konum;
            player.transform.Rotate(rotasyon) ;
            gameObject.SetActive(true);
            control = 0;
            on2 = false;
            on = false;
            currentTime = 15;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "giris")
        {
            on = true;
            gameObject.SetActive(false);
            StartCoroutine(UpdateTime());
        }
        if (other.gameObject.tag == "check point")
        {
            on2 = true;
           
            control = 1;
            sayac++; //tur atýnca sayac artsýn
        }

    }


    IEnumerator UpdateTime()
    {
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        yield return null;
    }


}