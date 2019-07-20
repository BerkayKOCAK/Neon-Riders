using UnityEngine;

public class PointThang :ScoreHandler {
	/*				
	 *				SCRIPT DESCRIPTION
	 * Handles PointThang collision
	 * 
	 *					CONSTANTS
	 * Feel free to change those for balance purposess
	 * 
	 * SCOREPOINT:
	 * Type: int
	 * Definition: When vehicle collides with a PointThang
	 * SCORE is increased by SCOREINC
	 * 
	 */

	#region CONSTANTS

	[SerializeField]
	private const int		SCOREPOINT	= 500;

	#endregion

	private void OnTriggerEnter (Collider other) {
		if (other.tag == "Vehicle") {
			SCORE += SCOREPOINT;
			Destroy(gameObject);
		}

	}

}
