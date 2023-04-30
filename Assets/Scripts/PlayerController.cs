using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed, sprintingSpeed,turnSpeed;
    private Animator playerAnimator;
    private Transform pointToFollow;

    private bool running;
    private float count;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        pointToFollow = GameObject.Find("PointToFollow").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        var x = Input.GetAxis("HorizontalAD");
        var z = Input.GetAxis("VerticalSW");
        var dir = new Vector3(x, 0, z).normalized;
        var _speed = speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerAnimator.SetBool("Sprinting", true);
            _speed = sprintingSpeed;
        }
        else
        {
            playerAnimator.SetBool("Sprinting", false);
        }

        transform.Translate(dir * _speed * Time.deltaTime, Space.World);
        bool isRunning = dir != Vector3.zero;
        switch (isRunning)
        {
            case true:
                pointToFollow.localPosition = Vector3.zero;
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
