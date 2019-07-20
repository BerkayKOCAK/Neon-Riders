using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKillaZ : MonoBehaviour {


	//Destroys the bullet shot by Sentry Gun on hit and sends game over command.
	void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.name == "Player")
		//"Player" will be the name of Player gameObject.
        {
            Destroy(gameObject);
			Debug.Log("gaem over");
        }
    }
}
