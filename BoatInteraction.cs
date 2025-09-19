using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatInteraction : MonoBehaviour
{
    public BasicMovement movementScript;
    public BoatMovement boatMover;
    public Transform controlPos;
    public Transform player;
    public bool isControlled = false;
    public KeyCode interactKey = KeyCode.E;
    public KeyCode stopInteract = KeyCode.Q;

    private void ControlInteraction()
    {
        if (Input.GetKeyDown(interactKey))
        {
            isControlled = true;
        }
        else if (Input.GetKeyDown(stopInteract))
        {
            isControlled = false;
        }
    }
    private void PlayerPosSnapper()
    {
        Vector3 snap = controlPos.position;
        player.position = snap;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ControlInteraction();
        }
    }
    void Update()
    {
        if (isControlled)
        {
            boatMover.enabled = true;
            movementScript.enabled = false;
            PlayerPosSnapper();
        }
        else
        {
            boatMover.enabled = false;
            movementScript.enabled = true;
        }
    }
}
