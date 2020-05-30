using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide : MonoBehaviour
{
    public GameObject panel;
    private void OnClick()
    {
        panel.SetActive(false);
    }
}

