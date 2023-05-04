using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] public float timeToGather = 3f, distanceForGathering = 2f, resourceAmount;
    private PlayerController _player;
    private bool gathering = false;
    private float _timeToGather;
    public RawResources _type;
    

    public enum RawResources
    {
        stone,
        wood
    }
    // Start is called before the first frame update
    void Start()
    {
        _timeToGather = timeToGather;
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Gathering();
    }
    private void Gathering()
    {
        if (gathering)
        {
            _timeToGather -= Time.deltaTime;
            if (_timeToGather <= 0)
            {
                _player.StopAction();
                GameManager.instance.AddAmountResource(_type, resourceAmount);
                //GameObject.Find("GameManager").GetComponent<GameManager>().AddAmountResource(_type, resourceAmount);
                Destroy(gameObject);
            }
        }
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(_player.transform.position, transform.position) < distanceForGathering)
        {
            _player.StartAction(_type);
            gathering = true;
        }
        else
        {
            Debug.Log("Is too far away");
        }

    }
}


