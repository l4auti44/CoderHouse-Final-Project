using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Builder : MonoBehaviour
{

    [SerializeField] private GameObject trap;
    [SerializeField] private bool enableBuilder = false;
    [SerializeField] private LayerMask layerToCollide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enableBuilder && Input.GetMouseButtonDown(0))
        {
            SpawnTrapAtMousePos();
        }
    }

    public void EnableBuilder()
    {
        enableBuilder = !enableBuilder;
        Debug.Log("Builder set to: " + enableBuilder.ToString());
    }

    private void SpawnTrapAtMousePos()
    {
        if (HaveEnoughtResources())
        {
            RaycastHit hitInfo;

            Vector2 mousePosition = Mouse.current.position.ReadValue();

            Ray rayOrigin = Camera.main.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log("Object hit " + hitInfo.transform.name + " at " + hitInfo.point);

                Instantiate(trap, hitInfo.point, Quaternion.identity);
            }
        }
        
    }

    private bool HaveEnoughtResources()
    {
        var _trap = trap.GetComponent<SpikeTrap>();
        if (GameManager.instance.stone >= _trap.stoneCost && GameManager.instance.wood >= _trap.woodCost)
        {
            GameManager.instance.UseResources(Resource.RawResources.wood, _trap.woodCost);
            GameManager.instance.UseResources(Resource.RawResources.stone, _trap.stoneCost);
            return true;
        }
        else
        {
            Debug.Log("Dont Have enought resources");
            return false;
        }
        
    }
}
