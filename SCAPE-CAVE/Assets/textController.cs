using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textController : MonoBehaviour
{
    public TMP_Text[] textos; // Array de los frames de la animaci�n
    public float frameRate = 0.3f; // Velocidad de reproducci�n de la animaci�n

    private int currentFrameIndex = 0;
    private float timer = 0f;

    private void Start()
    {
        //image = GetComponent<Image>();
        textos[0].gameObject.SetActive(true);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= frameRate)
        {
            timer = 0f;

            if (currentFrameIndex < textos.Length)
            {
                textos[currentFrameIndex].gameObject.SetActive(false);
                currentFrameIndex++;
                if (currentFrameIndex == 8)
                {
                    currentFrameIndex = 0;
                }
                textos[currentFrameIndex].gameObject.SetActive(true);
                

            }
        }
    }
}
