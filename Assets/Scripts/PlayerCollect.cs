using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    
    [SerializeField] InventoryControl Inventory; 
    [SerializeField] BarConroller bar;

    private BaseItemData toList;


    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CanCollect>())
        {
            toList = collision.gameObject.GetComponent<CanCollect>().Data;

            Destroy(collision.gameObject);

            Inventory.Adding(toList);

        }
    }*/

    public void RayCastCollection()
    {
        // Ограниченный луч. 
       if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(0,0,3)), out RaycastHit item, 10f))
        {
            if (item.transform.GetComponent<CanCollect>())
            {
                bar.NearCollect();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    toList = item.transform.GetComponent<CanCollect>().Data;

                    Destroy(item.transform.gameObject);
                    Inventory.Adding(toList);

                    Destroy(bar.NearCollect());
                }
            }
        }
        else
            Destroy(bar.NearCollect());
    }

    private void FixedUpdate()
    {
        RayCastCollection();
    }
}


