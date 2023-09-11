using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballReset : MonoBehaviour
{
    [SerializeField] LayerMask m_layerMask;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == m_layerMask )
        {
            Debug.Log("Setting inactive");

            Invoke(nameof(DisableBasketball), 2.5f);
        }
    }



    private void DisableBasketball()
    {
        this.gameObject.SetActive(false);
    }


    IEnumerator DisableBasketballRoutine()
    {
        yield return new WaitForSeconds(2f);

        DisableBasketball();

        yield return null;
    }



}
