using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ajanlar : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject hedef;
    public string ajan_turu;
    private int carpma_sayisi;
    private float darbe_gucu;
    public GameObject gameKontrol;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(hedef.transform.position);

        switch (ajan_turu)
        {
            case "Mavi":
                carpma_sayisi = 4;
                darbe_gucu = 20f;
                break;
            case "Sari":
                carpma_sayisi = 2;
                darbe_gucu = 15f;
                break;
            case "Pembe":
                carpma_sayisi = 1;
                darbe_gucu = 13f;
                break;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Engel"))
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

        if (other.gameObject.CompareTag("AnaHedef"))
        {
            gameKontrol.GetComponent<gameKontrol>().CanDusur(darbe_gucu);
            Destroy(gameObject);
        }
    }
}
