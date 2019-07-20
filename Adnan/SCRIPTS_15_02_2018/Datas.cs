using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datas : MonoBehaviour
{
	public Transform Player;
    public Transform curEnemy;

    private EndlessRoadScript endlrd;

   

    private void Start()
    {
        endlrd = GameObject.Find("WorldCreator").GetComponent<EndlessRoadScript>();
    }
    private void Update()
    {
        if(curEnemy != null)
        {
            EnemyAImain enemyAI = curEnemy.GetComponent<EnemyAImain>();
            if(enemyAI.getState() == 2 && curEnemy.position.z < Player.transform.position.z)
            {
                endlrd.createdTransitionbackward = true;
            }
        }
    }

}
