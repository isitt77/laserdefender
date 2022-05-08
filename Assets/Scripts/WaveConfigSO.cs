using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WaveConfig", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] float spawnTimeVariance;
    [SerializeField] float minSpawnTime = 0.2f;


    public int GetEnemyCount()
    {
        //Debug.Log(enemyPrefabs.Count);
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }


    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }


    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }


    public float GetMoveSpeed()
    {
        return moveSpeed;
    }


    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenSpawns - spawnTimeVariance,
                                        timeBetweenSpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);
    }
}
