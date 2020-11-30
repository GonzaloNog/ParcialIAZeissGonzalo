using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] pointsSpawn;
    public Enemy enemy;
    private float time = 0;

    void Update()
    {
        time -= Time.deltaTime;
        print(time);
        if (time <= 0f)
        {
            Spawn();
            time = 3f;
        }
    }
    public void Spawn()
    {
        print("Entro");
        int aux = Random.Range(0, pointsSpawn.Length);
        Instantiate(enemy, pointsSpawn[aux].transform.position, Quaternion.identity);
    }
}
