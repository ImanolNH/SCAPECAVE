using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tiempoSupervivenciaSpawn : MonoBehaviour
{
    public Slider slider;
    public float countdownDuration = 14f;

    private float currentTime;

    public GameObject spawnsEsqueletos;

    public puertaEsqueletos pE;
    public puertaEsqueletos pE2;

    private void Start()
    {
        GameObject puertaSuperior = GameObject.Find("PuertaSupE");
        pE = puertaSuperior.GetComponent<puertaEsqueletos>();
        GameObject puertaInferior = GameObject.Find("PuertaInfE");
        pE2 = puertaInferior.GetComponent<puertaEsqueletos>();
        currentTime = countdownDuration;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            pE.animacionEjecutada = false;
            pE2.animacionEjecutada = false;
            pE.saliendo = true;
            pE2.saliendo = true;
            slider.gameObject.SetActive(false);
            spawnsEsqueletos.SetActive(false);
            currentTime = 0f;
            // Aquí puedes agregar cualquier acción adicional que desees realizar cuando se complete el contador
        }

        // Actualiza el valor del slider en función del tiempo restante
        slider.value = currentTime;
    }
}
