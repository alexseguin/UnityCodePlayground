using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If input is given, move the player
        if (Input.GetAxis("Horizontal") != 0)
        {
            // Move the player
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * 15, 0, 0), 0.1f);
        }
    }
}
