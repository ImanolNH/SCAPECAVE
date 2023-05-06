using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaDestroy : MonoBehaviour
{
    public float cronometro;
    // Update is called once per frame
    void Update()
    {
        comportamientoBala();
    }

    public void comportamientoBala()
    {
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 0.5)
        {
            Destroy(gameObject);
        }

    }
}
