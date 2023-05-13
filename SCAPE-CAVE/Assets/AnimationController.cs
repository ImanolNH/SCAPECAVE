using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    public Sprite[] frames; // Array de los frames de la animación
    public float frameRate = 0.3f; // Velocidad de reproducción de la animación

    public Image image;
    private int currentFrameIndex = 0;
    private float timer = 0f;

    private void Start()
    {
        //image = GetComponent<Image>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= frameRate)
        {
            timer = 0f;

            if (currentFrameIndex < frames.Length)
            {
                image.sprite = frames[currentFrameIndex];
                currentFrameIndex++;
                if (currentFrameIndex == 29)
                {
                    currentFrameIndex = 0;
                }
            }
        }
    }
}
