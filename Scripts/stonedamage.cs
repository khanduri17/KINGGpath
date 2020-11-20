using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stonedamage : MonoBehaviour
{
    
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Platform")
        {
            Destroy(gameObject);
        }
        
        
    }
    void Update()
    {
        
    }
}
