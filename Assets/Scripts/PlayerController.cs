using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed, turnSpeed;
    private Animator playerAnimator;

    private bool running;
    private float count;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
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
        bool isRunning = dir != Vector3.zero;
        switch (isRunning)
        {
            case true:
                Quaternion rot = Quaternion.LookRotation(dir, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
                playerAnimator.SetBool("Running", true);
                break;
            case false:
                playerAnimator.SetBool("Running", false);
                break;
        }

    }


}
