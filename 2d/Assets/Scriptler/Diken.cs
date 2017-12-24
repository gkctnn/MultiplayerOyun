using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diken : MonoBehaviour 
{
    private Oyuncu oyuncu;
	// Use this for initialization
	void Start () 
    {
        oyuncu = GameObject.FindGameObjectWithTag("Player").GetComponent<Oyuncu>();
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void OnTriggerEnter2D(Collider2D diger)
    {
        if (diger.CompareTag("Player"))
        {
            oyuncu.HasarAl(2);
            StartCoroutine(oyuncu.GeriItme(0.025f,200,oyuncu.transform.position));
        }
    }
}
