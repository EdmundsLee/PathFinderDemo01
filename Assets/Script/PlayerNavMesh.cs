using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public static PlayerNavMesh inst;
    public BuildToggler buildToggler;

    void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                Vector3 newPos = hit.point - new Vector3(0.5f, 0.0f, 0.5f);
                navMeshAgent.destination = new Vector3(Mathf.CeilToInt(newPos.x), 1, Mathf.CeilToInt(newPos.z));
            }
        }
    }
}
