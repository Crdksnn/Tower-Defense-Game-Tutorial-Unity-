using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{

    WaveConfig waveConfig;
    List<Transform> pathPoints;
    int pathIndex = 0;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        pathPoints = waveConfig.GetWavePoints();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (pathIndex < pathPoints.Count)
        {
            var targetPosition = pathPoints[pathIndex].position;
            var movementThisFrame = enemy.speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                pathIndex++;
            }
        }

        else
        {
            EndPath();
        }

        enemy.speed = enemy.startSpeed;
    }

    void EndPath()
    {
        EnemySpawner.enemiesAlive--;
        PlayerStats.lives--;
        Destroy(gameObject);
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

}
