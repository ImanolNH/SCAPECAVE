using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionamientoColumna : MonoBehaviour
{
    public bool[] arrayCristales = new bool[3];
    public EnemigoTroll eT;

    private void Start()
    {
        GameObject columna = GameObject.Find("troll 1");
        eT = columna.GetComponent<EnemigoTroll>();
        arrayCristales[0] = false;
        arrayCristales[1] = false;
        arrayCristales[2] = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Valor 1: " + arrayCristales[0]+"Valor 2: " + arrayCristales[1]+ "Valor 3: " + arrayCristales[2]);
        if (comprobarCristales()==3)
        {
            eT.vulnerable = true;
        }
        
    }

    public int comprobarCristales()
    {
        int total=0;
        for(int i = 0; i < arrayCristales.Length; i++)
        {
            if (arrayCristales[i]==true)
            {
                total++;
            }
        }
        return total;
    }
}
