using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameKontrol : MonoBehaviour
{
    public GameObject olusacak_obje;
    public GameObject olusacak_nav_obje;
    private float saglik;
    public Image HealthBar;
    private int kalan_sayi_deger;
    public Text kalan_sayi_text;
    private int navmesh_kalan_sayi_deger;
    public Text navmesh_kalan_sayi_text;
    public GameObject gameOverPanel;

    public GameObject[] noktalar;
    public Button[] butonlar;
    public Button[] nav_butonlar;
    // Start is called before the first frame update
    void Start()
    {
        saglik = 100f;

        kalan_sayi_deger = 30;
        kalan_sayi_text.text = kalan_sayi_deger.ToString();

        navmesh_kalan_sayi_deger = 5;
        navmesh_kalan_sayi_text.text = navmesh_kalan_sayi_deger.ToString();
    }
    private void butonKontroller()
    {
        if (kalan_sayi_deger == 0)
        {
            foreach (var buton in butonlar)
            {
                buton.interactable = false;
            }
        }
    }
    private void navbutonKontroller()
    {
        if (navmesh_kalan_sayi_deger == 0)
        {
            foreach (var buton in nav_butonlar)
            {
                buton.interactable = false;
            }
        }
    }
    public void noktaButonlari(int index)
    {
        kalan_sayi_deger -= 1;
        kalan_sayi_text.text = kalan_sayi_deger.ToString();
        Instantiate(olusacak_obje, noktalar[index].transform.position, Quaternion.identity);
        butonKontroller();
    }
    public void navMeshEngelButon(int index)
    {
        navmesh_kalan_sayi_deger -= 1;
        navmesh_kalan_sayi_text.text = navmesh_kalan_sayi_deger.ToString();
        Instantiate(olusacak_nav_obje, noktalar[index].transform.position, Quaternion.identity);
        navbutonKontroller();
    }
    public void CanDusur(float darbe)
    {
        saglik -= darbe;
        HealthBar.fillAmount = (saglik / 100);
        CanKontrolEt();
    }
    private void CanKontrolEt()
    {
        if (saglik <= 0)
        {
            //GameOver Canvas
            gameOverPanel.SetActive(true);

            Time.timeScale = 0;
        }
    }
}
