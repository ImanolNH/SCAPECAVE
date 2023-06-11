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
            // Aquí puedes agregar cualquier acción adicional que desees realizar cuando se complete el contador
        }

        // Actualiza el valor del slider en función del tiempo restante
        slider.value = currentTime;
    }
}
