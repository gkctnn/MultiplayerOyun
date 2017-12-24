using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtesAraligi : MonoBehaviour 
{
    public bool sagAtesAraligi = false;
    private DusmanUzak dusmanUzak;
	// Use this for initialization
	void Start () 
    {
		dusmanUzak = gameObject.GetComponentInParent<DusmanUzak>();
    }
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void OnTriggerStay2D(Collider2D diger)
    {
        if (diger.CompareTag("Player"))
        {
            if(sagAtesAraligi)
            {
                dusmanUzak.AtesEt(true);
            }
            else
            {
                dusmanUzak.AtesEt(false);
            }
        }
    }
}
