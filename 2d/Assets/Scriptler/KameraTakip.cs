using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour 
{
    private Vector2 kameraHizi;
    public float yumusatX;
    public float yumusatY;
    private GameObject oyuncu;
    public Vector3 minKameraPozisyonu;
    public Vector3 maxKameraPozisyonu;
	// Use this for initialization
	void Start () 
    {
        oyuncu = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void FixedUpdate()
    {
        float xCoord = Mathf.SmoothDamp(transform.position.x,oyuncu.transform.position.x,ref kameraHizi.x,yumusatX);
        float yCoord = Mathf.SmoothDamp(transform.position.y,oyuncu.transform.position.y,ref kameraHizi.y,yumusatY);
        transform.position = new Vector3(xCoord,yCoord,transform.position.z);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minKameraPozisyonu.y, maxKameraPozisyonu.y), transform.position.z);
    }
}
