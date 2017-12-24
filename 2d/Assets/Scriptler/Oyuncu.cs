using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //sahneler arası geçiş yapmamızı sağlayan kütüphane


public class Oyuncu : MonoBehaviour 
{
    private Rigidbody2D rb2d;
    private Animator anim;
    public float hiz = 100f;
    public float ziplamaGucu = 200f;
    public float maxHiz = 100;
    public bool havada;
    public bool ikiliZiplamaYapabilir;
    public int saglik;
    public int maxSaglik = 6;
    public int skor;
    // Use this for initialization
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        saglik = maxSaglik;
        skor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Hız", Mathf.Abs(rb2d.velocity.x));

        if (Input.GetAxis("Horizontal") < 0f) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") > 0f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        anim.SetBool("Havada", havada);
        //ziplama methodu
        if (Input.GetButtonDown("Jump"))
        {
            if (!havada)
            {
                rb2d.AddForce(Vector2.up * ziplamaGucu);
                ikiliZiplamaYapabilir = true;
            }
            else
            {
                if(ikiliZiplamaYapabilir)
                {
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * ziplamaGucu / 1.5f);
                    ikiliZiplamaYapabilir = false;
                }
            }
            
        }
        if (saglik <= 0)
        {
            Oldur();
        }
        if (saglik >= maxSaglik)
        {
            saglik = maxSaglik;
        }

    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); // belirlenen hareketi(yatay) h'de tutuyor.
        rb2d.AddForce(Vector2.right * hiz * h);

        if (rb2d.velocity.x > maxHiz) {
            rb2d.velocity = new Vector2(maxHiz,rb2d.velocity.y);
        }
        if (rb2d.velocity.x < -maxHiz)
        {
            rb2d.velocity = new Vector2(-maxHiz, rb2d.velocity.y);
        }
        if (!havada)
        {
            //SahteSurtunme();
        }
    }

    /*void SahteSurtunme()
    {
        Vector3 hizDusurVek = rb2d.velocity;
        hizDusurVek.z = 0f;
        hizDusurVek.y = rb2d.velocity.y;
        hizDusurVek.x = hizDusurVek.x * 0.8f;

        rb2d.velocity = hizDusurVek;
    }*/

    void Oldur()
    {
        SceneManager.LoadScene(0);
    }

    public void HasarAl(int hasar)
    {
        saglik -= hasar;
        gameObject.GetComponent<Animation>().Play("Oyuncu_HasarAl");
    }

    public IEnumerator GeriItme(float itmeSuresi, float itmeGucu, Vector3 itmeYonu)
    {
        float zamanlayici = 0;
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        while (itmeSuresi > zamanlayici)
        {
            zamanlayici += Time.deltaTime;
            rb2d.AddForce(new Vector3(itmeYonu.x * 100, itmeYonu.y * itmeGucu, transform.position.z));
        }
        yield return 0;
    }

    void OnTriggerEnter2D(Collider2D diger)
    {
        if (diger.CompareTag("Altin"))
        {
            Destroy(diger.gameObject);
            skor++;
        }
        if (diger.CompareTag("BolumSonu"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
