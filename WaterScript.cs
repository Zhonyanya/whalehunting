using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    public BasicMovement movement;
    public Rigidbody rb;
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            movement.isSubmerged = !movement.isSubmerged;
            rb.useGravity = !rb.useGravity;
        }
    }
}