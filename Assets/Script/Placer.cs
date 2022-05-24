using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placer : MonoBehaviour
{
    private bool currentlyPlacing;
    private GameObject obstacle;

    private float placementIndicatorUpdateRate = 0.05f;
    private float lastUpdateTime;
    private Vector3 curPlacementPos;

    [SerializeField] private GameObject placementIndicator;
    [SerializeField] private List<GameObject> placementButtons;
    public static Placer inst;
    void Awake()
    {
        inst = this;
    }

    public void BeginNewBuildingPlacement(GameObject obstacle)
    {
        currentlyPlacing = true;
        this.obstacle = obstacle;
        placementIndicator.SetActive(true);
        foreach (var button in placementButtons) button.gameObject.SetActive(false);
    }
    public void CancelBuildingPlacement()
    {
        currentlyPlacing = false;
        placementIndicator.SetActive(false);
        foreach (var button in placementButtons) button.gameObject.SetActive(true);
    }
    void PlaceBuilding()
    {
        bool occupied = false;
        float radius = 0.1f;
        Collider[] hitColliders = Physics.OverlapSphere(curPlacementPos, radius);
        foreach (Collider hit in hitColliders)
        {
            occupied = true;
            break;
        }
        if (!occupied) 
        {
            GameObject buildingObj = Instantiate(obstacle, curPlacementPos, Quaternion.identity);
        }
        //CancelBuildingPlacement();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.B))
            CancelBuildingPlacement();
        if (Time.time - lastUpdateTime > placementIndicatorUpdateRate && currentlyPlacing)
        {
            lastUpdateTime = Time.time;
            curPlacementPos = Selector.inst.GetCurTilePosition();
            placementIndicator.transform.position = curPlacementPos;
        }
        if (currentlyPlacing && Input.GetMouseButtonDown(0))
        {
            PlaceBuilding();
        }
    }
}
