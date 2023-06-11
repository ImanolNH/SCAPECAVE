using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tiempoSupervivenciaSpawn : MonoBehaviour
{
    public Slider slider;
    public float countdownDuration = 14f;

    private float currentTime;

    private void Start()
    {
        currentTime = countdownDuration;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            // Aqu� puedes agregar cualquier acci�n adicional que desees realizar cuando se complete el contador
        }

        // Actualiza el valor del slider en funci�n del tiempo restante
        slider.value = currentTime;
    }
}
