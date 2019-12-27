using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBehaviour : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;

    public static int score = 0;
    public Text text;
    GameObject bulletTemp;
    public GameObject hitEffect;
    public float towerHealth = 100;

    public Slider healthBar;
    public float timeBetweenShots = 0.25f;

    private float timestamp;

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            turn(rotationSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            turn(-rotationSpeed);
        }
        if (Time.time >= timestamp && (Input.GetKey(KeyCode.Space)))
        {
            bulletTemp = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            timestamp = Time.time + timeBetweenShots;
            bulletTemp.GetComponent<BulletBehaviour>().textScore = text;
            
        }
    }

    void turn(float speed)
    {
        transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "enemy")
        {
            GameObject hitTemp = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(hitTemp, 1);
            Destroy(collider.gameObject);
            towerHealth -= 20;
            healthBar.value= towerHealth;

            if (towerHealth == 0)
            {
                StartCoroutine(EnemySpawn.WaitForRestart());
                gameObject.transform.localScale = new Vector3(0,0,0);
            }
        }

        if (collider.gameObject.tag == "boss")
        {
            GameObject hitTemp = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(hitTemp, 1);
            Destroy(collider.gameObject);
            towerHealth =0;
            healthBar.value= towerHealth;
            StartCoroutine(EnemySpawn.WaitForRestart());
            gameObject.transform.localScale = new Vector3(0, 0, 0);
        }

    }
    
}
