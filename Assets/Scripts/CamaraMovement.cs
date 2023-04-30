using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    [SerializeField] private float cameraSpeed = 6f, maxZoomOut = 25f, minZoomIn = 3f;
    [SerializeField] private Transform pointToFollow;
    private CinemachineVirtualCamera _cm1;

    // Start is called before the first frame update
    void Start()
    {
        _cm1 = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {

        var x = Input.GetAxis("HorizontalLeftRight");
        var z = Input.GetAxis("VerticalUpDown");
        var dir = new Vector3(x, 0, z).normalized;

        pointToFollow.transform.Translate(dir * cameraSpeed * Time.deltaTime, Space.World);


        if (Input.GetAxis("Mouse ScrollWheel") > 0f && _cm1.m_Lens.OrthographicSize > minZoomIn)
        {
            _cm1.m_Lens.OrthographicSize--;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f && _cm1.m_Lens.OrthographicSize < maxZoomOut)
        {
            _cm1.m_Lens.OrthographicSize++;
        }

    }

}
