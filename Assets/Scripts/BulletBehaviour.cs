using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletBehaviour : MonoBehaviour
{
    public GameObject hitEffect;

    public Text textScore;

    public bool scoreBool = false;

    void Start()
    {
        Destroy(gameObject, 2f);
        GetComponent<Rigidbody>().AddForce(4000 * transform.forward);
    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject hitTemp = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(hitTemp, 1);
        if (collider.gameObject.tag == "enemy" || collider.gameObject.tag == "boss")
        {
            EnemyBehaviour enemy = collider.gameObject.GetComponent<EnemyBehaviour>();
            enemy.health--;
            enemy.slider.value= enemy.health;
            if(enemy.health == 0){
            Destroy(collider.gameObject);
            TowerBehaviour.score++;
            textScore.text = "score: " + TowerBehaviour.score;
            }
        }
        Destroy(gameObject);
    }
}

