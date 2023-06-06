using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] 
    private GameObject mouseIndicator, cellIndicator;
    [SerializeField] 
    private InputManager inputManager;
    [SerializeField]
    private Grid grid;


    //YO AGREGUE
    [SerializeField] private GameObject gridParent;
    private void Update()
    {
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
        mouseIndicator.transform.position = mousePosition;
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
        cellIndicator.transform.position = new Vector3(cellIndicator.transform.position.x, 0.01f, cellIndicator.transform.position.z);
    }

    //yo agregué
    public void DisableGrid()
    {
        mouseIndicator.SetActive(!mouseIndicator.activeSelf);
        cellIndicator.SetActive(!cellIndicator.activeSelf);
        gridParent.SetActive(!gridParent.activeSelf);

    }
}

