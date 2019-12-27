using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    bool isSpawning = false;
    public GameObject[] enemies;
    public GameObject turret;

    IEnumerator SpawnObject(int index, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameObject temp = Instantiate(enemies[index], transform.position, transform.rotation);
        temp.GetComponent<EnemyBehaviour>().player = turret;
        isSpawning = false;
    }

    void Update()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            int enemyIndex = Random.Range(0, enemies.Length);
            StartCoroutine(SpawnObject(enemyIndex, Random.Range(3, 8)));
        }
    }
}

