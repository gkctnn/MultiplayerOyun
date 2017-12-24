using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusenPlatform : MonoBehaviour 
{
    public float gecikme;
    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () 
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void OnCollisionEnter2D(Collision2D diger)
    {
        if (diger.collider.CompareTag("Player"))
        {
            StartCoroutine(Dus());
        }
    }

    IEnumerator Dus()
    {
        yield return new WaitForSeconds(gecikme);
        rb2d.isKinematic = false;
        GetComponent<Collider2D>().isTrigger = true;
        yield return 0;
    }
}
