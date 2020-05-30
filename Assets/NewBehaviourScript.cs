using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject targe;

    private void OnTriggerEnter(Collider col )
    {

        if (col.tag == "Character3")
        {
            targe.SetActive(true);
           
        }
    }
}
