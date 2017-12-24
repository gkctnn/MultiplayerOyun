using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanUzak : MonoBehaviour
{
    private int saglik =5;
    public float mesafe;
    private float hazirlanmaMesafesi = 6;
   
    private float mermiHizi = 20;
    private float mermiZamanlayicisi = 0.2f;
    public bool hazir = false;
    private Animator anim;
    public Transform hedef;
    public GameObject mermi;
    public Transform namluSag;
    public float mermiSikligi;
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    // Use this for initialization
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Hazir", hazir);
        MesafeHesapla();
    }

    void MesafeHesapla()
    {
        mesafe = Vector3.Distance(transform.position, hedef.transform.position);
        if (mesafe < hazirlanmaMesafesi)
        {
            hazir = true;
            mermiZamanlayicisi += Time.deltaTime;
            if (mermiZamanlayicisi >= mermiSikligi)
            {
                Vector3 mermiYonu = hedef.transform.position - transform.position;
                mermiYonu.Normalize();

                GameObject mermiKopyasi;
                mermiKopyasi = Instantiate(mermi, namluSag.transform.position, namluSag.transform.rotation);
                mermiKopyasi.GetComponent<Rigidbody>().velocity = mermiYonu * mermiHizi;
                mermiZamanlayicisi = 0;

            }
        }
        else
        {
            hazir = false;
        }
    }


}
