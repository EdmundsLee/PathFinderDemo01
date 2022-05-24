using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remover : MonoBehaviour
{
    private bool currentlyRemoving;

    private float placementIndicatorUpdateRate = 0.05f;
    private float lastUpdateTime;
    private Vector3 curPlacementPos;

    [SerializeField] private GameObject placementIndicator;
    [SerializeField] private List<GameObject> placementButtons;
    public static Remover inst;
    void Awake()
    {
        inst = this;
    }

    public void BeginNewBuildingRemovement()
    {
        currentlyRemoving = true;
        placementIndicator.SetActive(true);
        foreach (var button in placementButtons) button.gameObject.SetActive(false);
    }
    public void CancelBuildingRemovement()
    {
        currentlyRemoving = false;
        placementIndicator.SetActive(false);
        foreach (var button in placementButtons) button.gameObject.SetActive(true);
    }

    void RemoveBuilding()
    {
        float radius = 0.1f;
        Collider[] hitColliders = Physics.OverlapSphere(curPlacementPos, radius);
        foreach (Collider hit in hitColliders)
        {
            if (hit.gameObject.layer == 8)
            {
                Destroy(hit.gameObject);
                break;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.B))
            CancelBuildingRemovement();
        if (Time.time - lastUpdateTime > placementIndicatorUpdateRate && currentlyRemoving)
        {
            lastUpdateTime = Time.time;
            curPlacementPos = Selector.inst.GetCurTilePosition();
            placementIndicator.transform.position = curPlacementPos;
        }
        if (currentlyRemoving && Input.GetMouseButtonDown(0))
        {
            RemoveBuilding();
        }
    }
}
