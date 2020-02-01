using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewOrder : MonoBehaviour
{
    private ItemSlot itemSlot;
    [SerializeField]
    private GameObject newOrder;
    [SerializeField]
    private float timeToNewOrder;
    private float time;
    private void Start()
    {
        itemSlot = GetComponent<ItemSlot>();
    }
    void Update()
    {

        if(itemSlot.Item == null && time < timeToNewOrder)
        {
            time += Time.deltaTime;
        }
        else if(itemSlot.Item == null)
        {
            GameObject order = Instantiate(newOrder);
            order.transform.parent = itemSlot.transform;
            order.transform.Rotate(0, -90, 0);
            itemSlot.AddItemToSlot(order);
            time = 0;
        }
    }
}
