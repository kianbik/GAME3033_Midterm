using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;

    public GameObject dancerPrefab;
    public float spawnTimer = 10.0f;
    public float spawnRate = 10;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            SpawnDancer();
            spawnTimer = spawnRate;
        }
    }
    public void SpawnDancer()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        Instantiate(dancerPrefab, pos, Quaternion.identity);
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 1);
        Gizmos.DrawCube(center, size);
    }
}
