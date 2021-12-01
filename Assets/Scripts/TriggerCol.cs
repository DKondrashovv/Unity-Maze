using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCol : MonoBehaviour
{
    public GameObject TextInfo;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="End")
        {
            TextInfo.SetActive(true); 
        }
    }
}
