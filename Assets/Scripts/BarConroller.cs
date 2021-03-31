using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BarConroller : MonoBehaviour
{
    [SerializeField] GameObject InventoryButton;
    [SerializeField] GameObject CollectButton;

    private GameObject promt;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(InventoryButton, gameObject.transform);
    }

    public GameObject NearCollect()
    {
        return promt = (promt == null) ? Instantiate(CollectButton, gameObject.transform) : promt;
    }
}
