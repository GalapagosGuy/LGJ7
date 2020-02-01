using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string enemyType = "";

    private List<GameObject> hitEnemies = new List<GameObject>();

    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == enemyType && !hitEnemies.Contains(other.transform.root.gameObject))
        {
            other.transform.root.GetComponent<Character>()?.GetHit(damage);

            hitEnemies.Add(other.transform.root.gameObject);
        }
    }

    public void Reset()
    {
        hitEnemies.Clear();
    }
}
