using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoatMovement : MonoBehaviour
{
    public float boatSpeed;
    public float rotationSpeed;
    private float currentRotation;
    private float horizInput;
    private float vertInput;
    private Rigidbody rb;
    public Transform boat;
    private void BoatInput()
    {
        horizInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");
    }
    private void MoveBoat()
    {
        rb.AddForce(boat.transform.forward.normalized * boatSpeed * vertInput, ForceMode.Impulse);
    }
    private void RotateBoat()
    {
        float deltaBoatRotation = horizInput * Time.deltaTime * rotationSpeed;
        currentRotation += deltaBoatRotation;
        boat.rotation = Quaternion.Euler(0, currentRotation, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentRotation = boat.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        BoatInput();
    }
    void FixedUpdate()
    {
        MoveBoat();
        RotateBoat();
    }
}
