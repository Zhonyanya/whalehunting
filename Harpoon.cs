using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//скрипт гaвно ща другой сделaю
public class Harpoon : MonoBehaviour
{
    public float harpoonSpeed;
    public Transform cameraOrientation;
    private bool isThrown = false;
    Rigidbody rb;
    private void Throw()
    {
        Vector3 throwDirection;
        rb.useGravity = true;
        throwDirection = cameraOrientation.forward * harpoonSpeed;
        rb.AddForce(throwDirection, ForceMode.Force);
        isThrown = true;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            rb.useGravity = false;
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isThrown)
        {
            Throw();
        }
    }
}





