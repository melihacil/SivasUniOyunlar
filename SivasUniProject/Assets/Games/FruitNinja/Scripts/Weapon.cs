using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;



public enum WepType
{
    Katana,
    LightSaber
}

public class Weapon : MonoBehaviour
{
    //there isn't a velocity in our sword beacuse , all the velocity is in our XR controller 
    //so i calculate manually our velocity
    //https://forum.unity.com/threads/is-there-a-way-to-get-velocity-and-acceleration-of-a-vr-user-the-headset-itself.824049/
    public float SwordVelocity;
    Vector3 lastdirectionRef;
    public Vector3 direct;
    public XRController xRController;
    public bool canSlice = false;
    public GameObject slicePanel;






    [SerializeField]
    public WepType m_WeaponType = WepType.Katana;



    private void Start()
    {
        xRController = transform.GetComponentInParent<XRController>();
    }
    public void Vibrate(float time)
    {
        xRController.SendHapticImpulse(1, time);
    }
    // manually calculate  velocity
    public void Update()
    {
        // Aletin son pozisyonu ve şimdiki pozisyonu karşılaştırılarak hızı bulunmakta
        direct = transform.position - lastdirectionRef;
        lastdirectionRef = transform.position;
        SwordVelocity = direct.magnitude / Time.deltaTime;

        direct = direct.normalized;

        // Kılıç tipine göre kesebilme booleanı değişmekte
        switch (m_WeaponType)
        {
            case WepType.Katana:
                if (Vector3.Angle(direct, transform.forward) <= 60)
                {
                    canSlice = true;
                }
                else
                {
                    canSlice = false;
                }
                break;
            case WepType.LightSaber:
                canSlice = true;
                break;
        }
    }
}

