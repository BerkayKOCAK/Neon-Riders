using UnityEngine;

public class FlareControl : MonoBehaviour {
	/*
	 *	  SCRIPT DESCRIPTION
	 * Handles flare collission
	 * 
	 */

	private TrailRenderer trail;
	[SerializeField]
	private GameObject flareCollider;
	[SerializeField]
	private GameObject enemy;
	
	private void Start () {
		trail = GetComponent<TrailRenderer>();
	}

	private void Update () {
		Vector3[] positions = new Vector3[35];
		int size = trail.GetPositions(positions);

		int index = 0;
		float min = float.MaxValue;
		for (int i = 0;i < size;++i) {
			float distance = Vector3.Distance(positions[i], enemy.transform.position);
			if (distance < min) {
				index = i;
				min = distance;
			}
		}

		flareCollider.transform.position = positions[index];
	}
}
