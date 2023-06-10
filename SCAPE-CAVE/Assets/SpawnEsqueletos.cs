using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEsqueletos : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public float tiempoEntreGeneracion = 3f;

    private float tiempoPasado = 0f;
    public GameObject spawnpointSiguiente;

    public int numeroSpawn;

    void Update()
    {
        tiempoPasado += Time.deltaTime;

        if (tiempoPasado >= tiempoEntreGeneracion)
        {
            GenerarEnemigo();
            if (numeroSpawn != 4)
            {
                spawnpointSiguiente.gameObject.SetActive(true);
            }
            
            tiempoPasado = 0f;
        }
    }

    void GenerarEnemigo()
    {
        Instantiate(enemigoPrefab, transform.position, Quaternion.identity);
    }
}
