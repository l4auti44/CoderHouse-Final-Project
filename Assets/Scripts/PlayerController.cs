using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed, sprintingSpeed,turnSpeed;
    private Animator playerAnimator;
    private Transform pointToFollow;

    private bool running, performingAction = false;
    private float count;
    [SerializeField] private GameObject[] tools;


    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        pointToFollow = GameObject.Find("PointToFollow").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!performingAction)
        {
            PlayerMovement();
        }
        else
        {
            var x = Input.GetAxis("HorizontalAD");
            var z = Input.GetAxis("VerticalSW");
            var dir = new Vector3(x, 0, z).normalized;
            if (dir != Vector3.zero)
            {
                //stop action
                StopAction();
            }
        }
       
        
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

    public void StartAction(Resource.RawResources _type)
    {
        switch (_type)
        {
            case Resource.RawResources.rock:
                
                playerAnimator.SetBool("Mining", true);
                tools[0].SetActive(true);
                performingAction = true;
                break;
            case Resource.RawResources.wood:
                tools[1].SetActive(true);
                playerAnimator.SetBool("Mining", true);
                performingAction = true;
                break;
        }
        
        

    }

    public void StopAction()
    {
        foreach(var tool in tools) tool.SetActive(false);
        performingAction = false;
        playerAnimator.SetBool("Mining", false);
    }

}
