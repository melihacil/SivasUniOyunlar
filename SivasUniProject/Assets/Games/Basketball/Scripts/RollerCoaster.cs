using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerCoaster : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject obje;
    public GameObject player;
    public GameObject cikis;
    int control=0;
    bool on = false;
    Vector3 konum;
    [SerializeField]
    private void Start()
    {
       
       konum =cikis.transform.position;
    }
    public void Update()
    {
        if (on == true)
        {
            player.transform.position = obje.transform.position;
            player.transform.rotation = obje.transform.rotation;

        }
        if (control == 1)
        {
            player.transform.position = konum;
            gameObject.SetActive(true);
            control = 0;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="giris")
        {
            on = true;
            gameObject.SetActive(false);

        }


    }
    private void OnTrigger(Collider other)
    {
        if (other.gameObject.tag == "cikis")
        {
            control++;
        }
    }
}
