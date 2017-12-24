using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hud : MonoBehaviour 
{
    public Sprite[] SaglikGorselleri;
    private Oyuncu oyuncu;
    public Image SaglikHUD;
    public Text skorText;
	// Use this for initialization
	void Start () 
    {
        oyuncu = GameObject.FindGameObjectWithTag("Player").GetComponent<Oyuncu>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        SaglikHUD.sprite = SaglikGorselleri[oyuncu.saglik];
        skorText.text = oyuncu.skor+""; //int stringe dönüyor +""
	}
}
