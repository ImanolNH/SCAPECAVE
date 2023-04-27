using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bullet;

    public float shotForce=700f;
    public float shotRate =0.5f;
    
    private float shotRateTime =0;

    // Start is called before the first frame update

    //public TMP_Text municionTexto;
    //public estadisticas municion;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(Time.time>shotRateTime && GameManager.Instance.gunAmmo>0){
                GameManager.Instance.gunAmmo--;


                GameObject newBullet;

                newBullet=Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward*shotForce);
                
                shotRateTime=Time.time+shotRate;

                Destroy(newBullet, 3);
            }
            
        }
    }

    /*
    public void Coleccionar()
    {
        municionTexto.text = GameManager.Instance.gunAmmo.ToString();
    }*/
}
