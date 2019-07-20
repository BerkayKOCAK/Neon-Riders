using UnityEngine;

public class PointThang : MonoBehaviour {
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

    private void Start () {
        sH = GameObject.Find("GlobalDataHolder").GetComponent<ScoreHandler>();
    }

    #region CONSTANTS

    [SerializeField] 
	private const int		SCOREPOINT	= 500;
    private ScoreHandler sH;
	#endregion

	private void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			sH.incScore(SCOREPOINT);
			Destroy(gameObject);
		}

	}

}
