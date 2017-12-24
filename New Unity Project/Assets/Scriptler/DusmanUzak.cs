using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanUzak : MonoBehaviour
{
    public int saglik;
    public int maxSaglik;
    public float mesafe;
    public float hazirlanmaMesafesi;
    public float atesEtmeMesafesi;
    public float mermiHizi, mermiZamanlayicisi;
    public bool hazir = false;

    public Transform hedef;
    public GameObject mermi;
    public Transform namluSol, namluSag;
    public float mermiSikligi;
    void Awake()
    {
       
    }
    // Use this for initialization
    void Start()
    {
        saglik = maxSaglik;
    }

    // Update is called once per frame
    void Update()
    {
        MesafeHesapla();
    }

    void MesafeHesapla()
    {
        mesafe = Vector3.Distance(transform.position, hedef.transform.position);
        if (mesafe < hazirlanmaMesafesi)
        {
            hazir = true;
        }
        else
        {
            hazir = false;
        }
    }

    //public void AtesEt(bool sagaAtesEt)
    //{
    //    mermiZamanlayicisi += Time.deltaTime;
    //    if (mermiZamanlayicisi >= mermiSikligi)
    //    {
    //        Vector2 mermiYonu = hedef.transform.position - transform.position;
    //        mermiYonu.Normalize();
    //        if (sagaAtesEt == true)
    //        {
    //            GameObject mermiKopyasi;
    //            mermiKopyasi = Instantiate(mermi, namluSag.transform.position, namluSag.transform.rotation);
    //            mermiKopyasi.GetComponent<Rigidbody2D>().velocity = mermiYonu * mermiHizi;
    //            mermiZamanlayicisi = 0;
    //        }
    //        if (sagaAtesEt == false)
    //        {
    //            GameObject mermiKopyasi;
    //            mermiKopyasi = Instantiate(mermi, namluSol.transform.position, namluSol.transform.rotation);
    //            mermiKopyasi.GetComponent<Rigidbody2D>().velocity = mermiYonu * mermiHizi;
    //            mermiZamanlayicisi = 0;
    //        }
    //    }
    //}
}
