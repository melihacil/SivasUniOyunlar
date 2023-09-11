using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballReset : MonoBehaviour
{
    [SerializeField] LayerMask m_layerMask;
    private Rigidbody m_rb;
    private bool m_done = true; // To prevent the disable function working more than once
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer.Equals(19) && m_done)
        {
            Invoke(nameof(DisableBasketball), 5f);
            m_done = false;
        }
    }



    private void DisableBasketball()
    {
        Debug.Log("Setting inactive");
        m_rb.angularVelocity = Vector3.zero;
        m_done = true;
        this.gameObject.SetActive(false);
    }


    IEnumerator DisableBasketballRoutine()
    {
        yield return new WaitForSeconds(2f);

        DisableBasketball();

        yield return null;
    }



}
