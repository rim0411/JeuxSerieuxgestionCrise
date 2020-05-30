using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour
{

    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.name == "Character4")
        {
            Debug.Log("jjjjjj");
        }
    }
}
