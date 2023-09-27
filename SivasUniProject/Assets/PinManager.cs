using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinManager : MonoBehaviour
{
    // Start is called before the first frame update

    private List<Vector3> pinPositions;
    private List<Quaternion> pinRotations;

    public static PinManager instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Debug.Log("Pin manager Starting");
        var pins = GameObject.FindGameObjectsWithTag("Pin");
        pinPositions = new List<Vector3>();
        pinRotations = new List<Quaternion>();

        foreach (var pin in pins)
        {
            pinPositions.Add(pin.transform.position);
            pinRotations.Add(pin.transform.rotation);
        }
        ResetPins();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Test Pin Reset")]
    public void ResetPins()
    {

            var pins = GameObject.FindGameObjectsWithTag("Pin");

            for (int i = 0; i < pins.Length; i++)
            {
                var pinPhysics = pins[i].GetComponent<Rigidbody>();
                pinPhysics.velocity = Vector3.zero;
                pinPhysics.position = pinPositions[i];
                pinPhysics.rotation = pinRotations[i];
                pinPhysics.velocity = Vector3.zero;
                pinPhysics.angularVelocity = Vector3.zero;

                //Count was used to check if the pin is hit and a score gained
                pins[i].GetComponent<BowlingPins>().ResetPin();
            }


            /*if (k < score.Length)
            {
                score[k] = counter;
                k++;
            }*/


            //if (startingTime > 0)
            //{
            //    toplam[j] = counter;
            //    if (j < 30)
            //    {
            //        j++;

            //    }
            //    else
            //    {
            //        Debug.Log("maks atýþ sýnýrý");
            //    }

            //}


            // Against the programmer ethics 
            // Should be done through one pin script like the final version
            //pin1.count1 = 0;
            //pin2.count2 = 0;
            //pin3.count3 = 0;
            //pin4.count4 = 0;
            //pin5.count5 = 0;
            //pin6.count6 = 0;
            //pin6.count6 = 0;
            //pin7.count7 = 0;
            //pin8.count8 = 0;
            //pin9.count9 = 0;
            //pin10.count10 = 0;
            //scoreText.text = "Score:" + counter;

            // Score hesaplamasýný güncelle
            //UpdateScore();
    }

}
