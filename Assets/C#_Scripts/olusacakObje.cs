using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class olusacakObje : MonoBehaviour
{
    private int carpma_sayisi = 3;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ajan"))
        {
            if (carpma_sayisi != 0)
            {
                carpma_sayisi--;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
