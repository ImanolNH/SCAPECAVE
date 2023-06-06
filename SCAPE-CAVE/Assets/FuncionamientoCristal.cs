using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionamientoCristal : MonoBehaviour
{
    public int numeroCristal = 0;
    private FuncionamientoColumna fC;
    public GameObject columna;

    private void Start()
    {
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
