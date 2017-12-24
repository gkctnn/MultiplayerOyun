using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Saglik : NetworkBehaviour
{

    public const int maxSaglik = 75;
    [SyncVar(hook = "SaglikCubugunuYonet")]
    public int saglik = maxSaglik;
    public RectTransform saglikCubugu;
    private NetworkStartPosition[] spawnNoktalari;

    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            spawnNoktalari = FindObjectsOfType<NetworkStartPosition>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HasarAl(int hasar)
    {
        if (!isServer)
        {
            return;
        }

        saglik -= hasar;

        if (saglik <= 0)
        {
            //saglik = 0;
            //Debug.Log("Eldummm");
            //saglik = maxSaglik;
            //RpcRespawn();
            Destroy(gameObject);
        }
    }

    void SaglikCubugunuYonet(int saglik)
    {
        saglikCubugu.sizeDelta = new Vector2(saglik * 2, saglikCubugu.sizeDelta.y);
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            //transform.position = Vector3.zero;
            Vector3 spawnNoktasi = Vector3.zero;
            if (spawnNoktalari != null && spawnNoktalari.Length > 0)
            {
                spawnNoktasi = spawnNoktalari[Random.Range(0, spawnNoktalari.Length)].transform.position;
            }
        }
    }
}
