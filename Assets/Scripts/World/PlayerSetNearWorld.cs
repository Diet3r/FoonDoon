using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetNearWorld : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "NearWorld")
        {
            other.gameObject.tag = "NearWorld";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "NearWorld")
        {
            other.gameObject.tag = "Untagged";
        }
    }
}
