using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diken : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        GameObject vurulanObje = col.gameObject;
        Saglik saglik = vurulanObje.GetComponent<Saglik>();
        OyuncuKontrolleri oyuncu = vurulanObje.GetComponent<OyuncuKontrolleri>();
        if (saglik != null)
        {
            saglik.HasarAl(2);
            //eklendi
            StartCoroutine(oyuncu.GeriItme(0.025f, 100, oyuncu.transform.position));
        }
        //Destroy(gameObject);
    }
}
