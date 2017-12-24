using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermi : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        GameObject vurulanObje = col.gameObject;
        Saglik saglik = vurulanObje.GetComponent<Saglik>();
        
        DusmanSaglik saglikDusman = vurulanObje.GetComponent<DusmanSaglik>();
        if (saglik != null)
        {
            saglik.HasarAl(5);
           

        }
        if (saglikDusman != null)
        {
            saglikDusman.HasarAl(5);
        }
        Destroy(gameObject);
    }
}
