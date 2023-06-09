using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Collider collider = gameObject.GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
