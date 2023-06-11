using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionSalida : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemigoTroll eT;

    public GameObject salida;
    public GameObject roca;

    void Start()
    {
        GameObject eTr = GameObject.Find("troll 1");
        eT = eTr.GetComponent<EnemigoTroll>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (eT.vidas == 0)
        {
            salida.SetActive(true);
            roca.SetActive(false);
        }
    }
}
