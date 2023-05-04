using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI resources;
    private float rock, wood;
    public static GameManager instance;
    


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        RefreshResourcesText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddAmountResource(Resource.RawResources _res, float amount)
    {
 
        switch (_res)
        {
            case Resource.RawResources.rock:
                rock += amount;
                break;
            case Resource.RawResources.wood:
                wood += amount;
                break;
        }

        RefreshResourcesText();
    }

    private void RefreshResourcesText()
    {
        resources.text = "Wood: " + wood.ToString() + "\n"
            + "Rock: " + rock.ToString();
    }
}
