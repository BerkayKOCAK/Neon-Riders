using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{

    //ARABA
    public Transform target;
    //The overall distance to the target
    public float dist = 7.0f;
	//Cam mode
	public bool camMode = false;

    //da' height (uçurum falan olursa atlama zıplama cix olur moruq)
    public float height = 5.0f;

    //Damp values, change them arbitrarily according to gameplay smoothness
    public float heightDamp = 1.5f;
    public float rotDamp = 2.0f;


	void Update()
	{

		if (Input.GetKeyDown("space")) {
			if (camMode == false) {
				camMode = true;
				dist = 14.0f;
			}
			else {
				camMode = false;
				dist = 7.0f;
			}
		}
	}


    //uu sen demiştin bunu boi
    void  LateUpdate()
    {
        //Dem' variablez
        float targetRotationAngle = target.eulerAngles.y;
        float targetHeight = target.position.y + height;

        float currRotationAngle = transform.eulerAngles.y;
        float currHeight = transform.position.y;

        //Damp (dem'p?) around da' y-axis
        currRotationAngle = Mathf.LerpAngle(currRotationAngle, targetRotationAngle, rotDamp * Time.deltaTime);

        //Damp da' height
        currHeight = Mathf.Lerp(currHeight, targetHeight, heightDamp * Time.deltaTime);

        //Angle-rotation conversion
        Quaternion currRotation = Quaternion.Euler(0, currRotationAngle, 0);

        //Set
        transform.position = target.position;
        transform.position -= currRotation * Vector3.forward * dist;

        transform.position = new Vector3(transform.position.x, currHeight, transform.position.z);

        transform.LookAt(target);
    }
}