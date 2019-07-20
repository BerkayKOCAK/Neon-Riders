using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRoadScript : MonoBehaviour
{

    [SerializeField]
    private Transform[] roads;
    /*
     0 -> Normal Road
     1 -> Thin road
     */

    [SerializeField]
    private Datas dat;
    private Vector3 Player;
    public Vector3 curRoadPos;
    [SerializeField]
    private float roadSpawnInterval;
    [SerializeField]
    private int RoadNeededAhead;
    public bool IsThin = false;
    [SerializeField]
    private ObstacleSpawner obsSpawner;

    private void Start()
    {
        

    }

    private void Update()
    {
        Player = dat.Player.position;
       // Debug.Log(curRoadPos.z - Player.z);
        if(curRoadPos.z - Player.z  < roadSpawnInterval * RoadNeededAhead)
        {
            CreateRoad();
        }
    }


    private void CreateRoad()
    {
        if (!IsThin)
        {
            Instantiate(roads[0], curRoadPos, Quaternion.identity);
            curRoadPos = new Vector3(curRoadPos.x, curRoadPos.y, curRoadPos.z + roadSpawnInterval);
            obsSpawner.SpawnObstacle(1);
        }
        else
        {
            Instantiate(roads[1], curRoadPos, Quaternion.identity);
            curRoadPos = new Vector3(curRoadPos.x, curRoadPos.y, curRoadPos.z + roadSpawnInterval);
            obsSpawner.SpawnObstacle(.5f);
        }
        
    }

}
