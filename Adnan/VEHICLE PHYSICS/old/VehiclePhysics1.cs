using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehiclePhysics : MonoBehaviour {

    [SerializeField]
    [Tooltip("Put motorcycle model here!")]
    private Transform Graphics;

    private float curSideWaysSpeed;
    private float curForwardSpeed;

    [Header("Test Variables")]

    [Tooltip("Don't need to touch here if you are already manipulating speed values via other scripts. DEAFULT : 0")]
    [SerializeField]
    private float newSideWaysSpeed;
    [Tooltip("Don't need to touch here if you are already manipulating speed values via other scripts. DEAFULT : 0")]
    [SerializeField]
    private float newForwardSpeed;

    private float curRotation;
    private float newRotation;
    private Rigidbody rig;

    [Header("Acceleration Variables")]
    [SerializeField]
    private float SideWaysAcceleration;
    [SerializeField]
    private float ForwardAcceleration;
    [Tooltip("RECOMMENDED: Make this value higher than the 'Side Ways Acceleration' variable")]
    [SerializeField]
    private float RotationalAcceleration;


    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        
    }


    private void Update()
    {

        #region SPEED HANDLING

        curSideWaysSpeed = Mathf.Lerp(curSideWaysSpeed, newSideWaysSpeed, Time.deltaTime * SideWaysAcceleration);
        curForwardSpeed = Mathf.Lerp(curForwardSpeed, newForwardSpeed, Time.deltaTime * ForwardAcceleration);

        #endregion

        #region ROTATION HANDLING

        newRotation = -newSideWaysSpeed;//Might change this value in the final build
        curRotation = Mathf.Lerp(curRotation, newRotation, Time.deltaTime * RotationalAcceleration);
        curRotation = Mathf.Clamp(curRotation, -1, 1);
        Graphics.transform.rotation = Quaternion.AngleAxis(curRotation * 30,Graphics.forward);

        #endregion

    }

    private void FixedUpdate()
    {
        rig.velocity = new Vector3(curSideWaysSpeed, rig.velocity.y, curForwardSpeed);
    }




    public void setForwardSpeed(float newSpeed)
    {
        newForwardSpeed = newSpeed;
    }

    public void setSideWaysSpeed(float newSpeed)
    {
        newSideWaysSpeed = newSpeed;
    }

    public float getForwardSpeed()
    {
        return newForwardSpeed;
    }

    public float getSidewaysSpeed()
    {
        return newSideWaysSpeed;
    }


}
