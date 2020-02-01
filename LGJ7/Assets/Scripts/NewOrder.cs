using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewOrder : MonoBehaviour
{
    private ItemSlot itemSlot;
    [SerializeField]
    private List<GameObject> newOrder = new List<GameObject>();
    [SerializeField]
    private float timeToNewOrder;
    private float time;

    private void Start()
    {
        itemSlot = GetComponent<ItemSlot>();
        time = 30;
    }

    void Update()
    {

        if(itemSlot.Item == null && time < timeToNewOrder)
        {
            time += Time.deltaTime;
        }
        else if(itemSlot.Item == null)
        {
            GameObject order = Instantiate(newOrder[Random.Range(0, newOrder.Count)]);
            order.transform.parent = itemSlot.transform;
            //order.transform.GetChild(0).transform.localScale = new Vector3(1, 1, 1);
            order.transform.Rotate(0, -90, 0);
            itemSlot.AddItemToSlot(order);
            time = 0;
        }
    }
}
