using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawn enemySpawn;

    WaveConfigSO waveConfig;
    List<Transform> waypoints;

    int waypointIndex = 0;

    private void Awake()
    {
        enemySpawn = FindObjectOfType<EnemySpawn>();
    }

    void Start()
    {
        waveConfig = enemySpawn.GetCurrentWave();
        waypoints = waveConfig.GetWayPoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPos = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, delta);

            if(transform.position == targetPos)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
