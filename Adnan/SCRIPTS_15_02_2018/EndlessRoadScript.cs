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
    public bool createdTransitionforward = false;
    public bool createdTransitionbackward = false;
    [SerializeField]
    private ObstacleSpawner obsSpawner;



    private void Update()
    {
        Player = dat.Player.position;
       // Debug.Log(curRoadPos.z - Player.z);
        if(curRoadPos.z - Player.z  < roadSpawnInterval * RoadNeededAhead)
        {
            CreateRoad();
        }
    }

    private Transform forwardTranstion;

    public void CreateRoad()
    {
        if (!IsThin)
        {
            Instantiate(roads[0], curRoadPos, Quaternion.identity);
            curRoadPos = new Vector3(curRoadPos.x, curRoadPos.y, curRoadPos.z + roadSpawnInterval);
            obsSpawner.SpawnObstacle(1);
            createdTransitionbackward = false;
        }
        else
        {
            if (!createdTransitionforward)
            {
                Instantiate(roads[1], curRoadPos, Quaternion.identity);//Creates transition road forward
                forwardTranstion = Instantiate(roads[2], Vector3.zero, Quaternion.identity);
                curRoadPos = new Vector3(curRoadPos.x, curRoadPos.y, curRoadPos.z + roadSpawnInterval);
                createdTransitionforward = true;
            }
            else if (createdTransitionbackward)
            {
                Debug.Log("HÜLOOĞĞ");
                forwardTranstion.position = curRoadPos;
                
                dat.Player.position = new Vector3(TeleportedX, dat.Player.transform.position.y, curRoadPos.z + 3);
                curRoadPos = new Vector3(curRoadPos.x, curRoadPos.y, curRoadPos.z + roadSpawnInterval);
                createdTransitionbackward = false;
                createdTransitionforward = false;
                IsThin = false;
            }
            else
            {
                Instantiate(roads[3], curRoadPos, Quaternion.identity);//Creates thin road
                curRoadPos = new Vector3(curRoadPos.x, curRoadPos.y, curRoadPos.z + roadSpawnInterval);
            }

            
        }
        
    }

    public float TeleportedX;



}
