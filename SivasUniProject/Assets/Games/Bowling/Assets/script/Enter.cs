using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{
    public Material effectMaterial; // Kırmızı efektin uygulanacağı Material
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = effectMaterial;
            }
        }
    }
   

    
}
