using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class havadaMi : MonoBehaviour 
{
    private Oyuncu oyuncu;
	// Use this for initialization
	void Start () 
    {
		oyuncu = gameObject.GetComponentInParent<Oyuncu>();  //oyuncu scriptini buluyor.
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void OnTriggerEnter2D(Collider2D col) 
    {
        oyuncu.havada = false;
    }

    void onTriggerStay2D(Collider2D col) 
    {
        oyuncu.havada = false;
    }

    void OnTriggerExit2D(Collider2D col) 
    {
        oyuncu.havada = true;
    }
}
