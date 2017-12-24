using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class OyuncuKontrolleri : NetworkBehaviour
{

    public GameObject mermiPrefab;
    public Transform namlu;
    [SyncVar] public string pname = "Oyuncu";
    
    void OnGUI()
    {
        if (isLocalPlayer)
        {
            pname = GUI.TextField(new Rect(25, Screen.height - 40, 100, 30), pname);
            if (GUI.Button(new Rect(130, Screen.height - 40, 80, 30), "Change"))
            {
                CmdChangeName(pname);
            }
        }

    }
    [Command]
    public void CmdChangeName(string newName)
    {
        pname = newName;
        this.GetComponentInChildren<TextMesh>().text = pname;
    }


    void Start()
    {
        if (isLocalPlayer)
        {
            //GetComponent<drive>().enabled = true;
            //Camera.main.transform.position = this.transform.position - this.transform.forward * 10 - this.transform.up * 3;
            //Camera.main.transform.LookAt(this.transform.position);
            //Camera.main.transform.parent = this.transform;
            KameraTakip2.target = this.transform;
        }
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        this.GetComponentInChildren<TextMesh>().text = pname;

        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            CmdAtesEt();
        }
        
    }

    [Command] //metot serverda çağırılacak*/
    void CmdAtesEt()
    {
        GameObject mermi = Instantiate(mermiPrefab, namlu.position, namlu.rotation);
        mermi.GetComponent<Rigidbody>().velocity = mermi.transform.forward * 6.0f;
        NetworkServer.Spawn(mermi);
        Destroy(mermi, 2);
    }
    //eklendi
    public IEnumerator GeriItme(float itmeSuresi, float itmeGucu, Vector3 itmeYonu)
    {
        Rigidbody rb = this.GetComponentInChildren<Rigidbody>();
        float zamanlayici = 0;
        rb.velocity = new Vector3(rb.velocity.x,0, 0);
        while (itmeSuresi > zamanlayici)
        {
            zamanlayici += Time.deltaTime;
            rb.AddForce(new Vector3(itmeYonu.x * 50, transform.position.y, itmeYonu.z * itmeGucu));
        }
        yield return 0;
    }
}
