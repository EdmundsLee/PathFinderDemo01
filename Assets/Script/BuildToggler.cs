using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildToggler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject buildUI;
    [SerializeField] private GameObject buildInput;

    private PlayerNavMesh playerScript;
    public static BuildToggler inst;

    private void Awake()
    {
        inst = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            playerScript = player.GetComponent<PlayerNavMesh>();
            playerScript.enabled = !playerScript.enabled;
            buildUI.SetActive(!buildUI.activeInHierarchy);
            buildInput.SetActive(!buildInput.activeInHierarchy);
        }
    }
}
