using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionamientoCristal : MonoBehaviour
{
    public int numeroCristal = 0;
    private FuncionamientoColumna fC;

    private void Start()
    {
        GameObject columna = GameObject.Find("Columna1");
        fC = columna.GetComponent<FuncionamientoColumna>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Bala"))
        {

            fC.arrayCristales[numeroCristal] = true;
            Destroy(gameObject);

        }
        else if (other.gameObject.CompareTag("ShotgunAmmo"))
        {
            fC.arrayCristales[numeroCristal] = true;
            Destroy(gameObject);
        }
    }
}
