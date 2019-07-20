using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    [SerializeField]
    private EndlessRoadScript endlessScript;

    [SerializeField]
    private Transform[] Obstacles;

    [SerializeField]
    [Tooltip("Must be between 0-100")]
    private int ObstacleFreq;

    [SerializeField]
    private Datas dT;

    public void SpawnObstacle(float width)
    {
        int SpawnChance = Random.Range(0, 100);

        if(SpawnChance < ObstacleFreq && dT.curEnemy == null)
        {
            Vector3 roadPos = endlessScript.curRoadPos;
            float spawnLocX = Random.Range(-width,width);
            Vector3 newObstaclePos = new Vector3(spawnLocX,roadPos.y + 1, roadPos.z);

            //TODO: ADD RANDOMIZATION OF THE OBSTACLES HERE

            Instantiate(Obstacles[0], newObstaclePos, Quaternion.identity);
        }

    }

}
