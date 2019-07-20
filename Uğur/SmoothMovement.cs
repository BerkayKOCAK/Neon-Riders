using UnityEngine;
using System.Collections;

public class SmoothMovement : MonoBehaviour {

	[SerializeField]
	private float speed = 2.00f;

	//kanka buna yorum yazmaya gerek yok sanırım ya sjkldhfgkjs
    void Update() {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}