using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionamientoColumna : MonoBehaviour
{
    public bool[] arrayCristales = new bool[3];
    public EnemigoTroll eT;
    public bool destruida = false;
    public int numColumna;
    public FuncionamientoCCristales fc;
    public GameObject gestorColumnas;

    private void Start()
    {
        GameObject columna = GameObject.Find("troll 1");
        eT = columna.GetComponent<EnemigoTroll>();


        fc = gestorColumnas.GetComponent<FuncionamientoCCristales>();
        arrayCristales[0] = false;
        arrayCristales[1] = false;
        arrayCristales[2] = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(destruida.ToString()+" "+numColumna.ToString());
        if (comprobarCristales()==3)
        { 
            //hace falta un boolean para que solo se meta una vez

            fc.arrayColumnas[numColumna]=true;
            eT.vulnerable = true;
            tiempoVulnerable();
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

    private IEnumerator tiempoVulnerable()
    {
        eT.vulnerable = true;
        Debug.Log("espera inical");
        yield return new WaitForSeconds(3);
        Debug.Log("espera terminada");
        eT.vulnerable = false;
        destruida = true;
    }
}
