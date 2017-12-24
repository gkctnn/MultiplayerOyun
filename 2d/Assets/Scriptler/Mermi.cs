using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermi : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void OnTriggerEnter2D(Collider2D diger)
    {
        if (diger.isTrigger != true)
        {
            if (diger.CompareTag("Player"))
            {
                diger.GetComponent<Oyuncu>().HasarAl(1);
            }
            Destroy(gameObject); // oyuncu kayboluyor
        }
    }
}
