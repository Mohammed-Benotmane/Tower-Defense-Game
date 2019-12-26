using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public GameObject hitEffect;

    void Start()
    {
        Destroy(gameObject, 2f);
        GetComponent<Rigidbody>().AddForce(4000 * transform.forward);
    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject hitTemp = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(hitTemp, 1);
        if (collider.gameObject.tag == "enemy")
        {
            EnemyBehaviour enemy = collider.gameObject.GetComponent<EnemyBehaviour>();
            enemy.health--;
            enemy.slider.value= enemy.health;
            if(enemy.health == 0)
            Destroy(collider.gameObject);
        }
        Destroy(gameObject);
    }
}

