using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform Enemy;
    private float Timer;

    void Start()
    {
        Timer = Time.time + 10;
    }


    void Update()
    {
        if (Timer < Time.time)
        { 
            Instantiate(Enemy, transform.position, transform.rotation);
            Timer = Time.time + 10; 
        }
    }
}
