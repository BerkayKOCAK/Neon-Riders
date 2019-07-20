using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryGun : MonoBehaviour {

	//Target is the Player gameobject for turret watch.
	[SerializeField]
	Transform target;

	//These are the variables that our gun will trigger shoot function in range, left for SerializableField for
	//setting for the game environment manually.
	[SerializeField]
	float shoot1dist;
	[SerializeField]
	float shoot2dist;

	//The gun will shoot only twice, so these will be our boolean checks for them.
	bool shoot1done = false;
	bool shoot2done = false;

	//Bullet will be a RigidBody for instantiation practice.
	//First, create a sphere in the Editor and add it the compontent Physics.Rigidbody.
	//Secondly, set it's "Use Gravity" box to false.
	//Then, add it onto the project window as prefab and delete the Sphere from the World Space for later use.
	//Lastly, drag the Bullet prefab into the function's bullet variable in the editor.
	[SerializeField]
	Rigidbody bullet;
	//This variable is yet going to be set according to game environment.
	[SerializeField]
	float bulletSpeed = 2.00f;


	// Update is called once per frame
	void Update () {
			
			//Makes our turret to always follow the player.
			transform.LookAt(target);

			//Boolean checks to shoot: first check is for distance and the second for hasItBeenShot.
			if ((Vector3.Distance(target.position, transform.position) < shoot1dist) && (!shoot1done)) {
				
				shoot1done = true;
				Debug.Log("shot 1");
				Fire();
			}
			else if ((Vector3.Distance(target.position, transform.position) < shoot2dist) && (!shoot2done)) {

				shoot2done = true;
				Debug.Log("shot 2");
				Fire();
			}

			
	}

	//This is the shoot function, generating our bullet RigidBody from the prefab anc setting it's speed.
	void Fire() {

		Rigidbody bulletShot = (Rigidbody) Instantiate(bullet, transform.position, transform.rotation);
		//It is not necessary but in order to change instantiated object's rotation, Quaternion.AngleAxis can be used.
		bulletShot.velocity = transform.forward * bulletSpeed;
	}
}
