using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bullet;

    public float shotForce=1500f;
    public float shotRate =0.5f;
    
    private float shotRateTime =0; 
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet;

            newBullet=Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
