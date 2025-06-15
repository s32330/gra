using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Collectible : MonoBehaviour
{ public ItemsDatabase ItemID;
    public object item;
    public InventoryManager Inventory;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        else
        {
            TryGetComponent(out ItemObject item);

            ItemsDatabase.Instance.Add(ItemsDatabase.Instance.Items[item.ItemID]);
            Destroy(gameObject);



        }
       
    }


}
