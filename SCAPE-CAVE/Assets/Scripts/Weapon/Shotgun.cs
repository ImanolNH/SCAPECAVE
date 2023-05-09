using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shotgun : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bullet;

    public float shotForce=700f;
    public float shotRate =0.5f;
    
    private float shotRateTime =0;

    // Start is called before the first frame update

    public TMP_Text municion;
    public TMP_Text cargador;
    //public estadisticas municion;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(Time.time>shotRateTime && GameManager.Instance.shotgunAmmo > 0){
                GameManager.Instance.shotgunAmmo--;

                string ammoEscopeta = GameManager.Instance.shotgunAmmo.ToString();
                municion.text = ammoEscopeta;

                Debug.Log("Municion disparo:  " + ammoEscopeta);
                GameObject newBullet;

                newBullet=Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward*shotForce);
                
                shotRateTime=Time.time+shotRate;

                Destroy(newBullet, 0.25f);
            }
            
        }
    }
}
