using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


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

    public static IEnumerator WaitForRestart()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

