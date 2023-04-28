using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractions : MonoBehaviour
{
    public TMP_Text municion;
    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.CompareTag("GunAmmo"))
        {
            GameManager.Instance.gunAmmo +=other.gameObject.GetComponent<AmmoBox>().ammo;
            Destroy(other.gameObject);

            string ammo = GameManager.Instance.gunAmmo.ToString();
            municion.text = ammo;
        }
    }

}
