using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Create Wave Config")]
public class WaveConfig : ScriptableObject
{
    [Header("Prefabs")]
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject wavePrefabs;

    [Header("Enemy Spawn Configs")]
    [SerializeField] int enemyNumber;
    [SerializeField] float enemySpawnTime;

    public List<Transform> GetWavePoints()
    {

        var wavePoints = new List<Transform>();

        foreach (Transform child in wavePrefabs.transform)
        {
            wavePoints.Add(child);
        }

        return wavePoints;
    }

    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    public int GetEnemyNumber() { return enemyNumber; }

    public float GetEnemySpawnTime() { return enemySpawnTime; }
}
