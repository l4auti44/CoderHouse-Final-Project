using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed, turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var dir = new Vector3(x, 0, z).normalized;

        transform.Translate(dir * speed * Time.deltaTime, Space.World);
        if (dir != Vector3.zero)
        {
            Quaternion rot = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
        }
    }
}
