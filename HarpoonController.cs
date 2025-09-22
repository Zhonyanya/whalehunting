using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonController : MonoBehaviour
{
    public bool readyToThrow = true;
    public GameObject harpoonPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && readyToThrow)
        {
            readyToThrow = false;
            Instantiate(harpoonPrefab, transform.position, transform.rotation);
        }
    }
}
