using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class NPCLookForPlayer : MonoBehaviour
{
    public float walkSpeed;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.parent.transform.position = Vector3.MoveTowards(transform.parent.transform.position, other.gameObject.transform.position, walkSpeed * Time.deltaTime);
            transform.parent.transform.LookAt(other.gameObject.transform);
        }
    }
}
