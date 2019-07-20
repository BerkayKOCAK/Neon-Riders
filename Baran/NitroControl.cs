using UnityEngine;
using UnityEngine.UI;

public class NitroControl : MonoBehaviour {
	/*				
	 *				SCRIPT DESCRIPTION
	 * Handles nitrobar
	 * Call incNitro() when car takes nitro
	 * Edit line58 to change the nitro use button/condition
	 * 
	 *					CONSTANTS
	 * Feel free to change those for balance purposess
	 * 
	 * INCAMOUNT:
	 * Type: float
	 * Definition: incNitro() increases nitro by INCAMOUNT
	 * 
	 * DEC:
	 * Type: float
	 * Definition: NitroUsage/UnitTime
	 * 
	 * MAXNITRO:
	 * Type: float
	 * Definition: -
	 * 
	 */

	#region CONSTANTS

	[SerializeField]
	private const float INCAMOUNT = 30;
	[SerializeField]
	private const float DEC = 1;
	[SerializeField]
	private const float MAXNITRO = 100;

	#endregion

	[SerializeField]
	private Image nitroBar;

	private float nitroAmount;
	private float targetNitroAmout;
	private float percent;

	private void Start () {
		nitroAmount		 = MAXNITRO;
		targetNitroAmout = MAXNITRO;
		percent			 = 1;
	}

	private void FixedUpdate () {
		nitroAmount = Mathf.Lerp(nitroAmount, targetNitroAmout, percent);

		if (percent < 1)
			percent += 0.15f;

		if (Input.GetKey(KeyCode.Space) && nitroAmount > 0) {
			nitroAmount -= DEC;
			targetNitroAmout -= DEC;
			// we don't need lerp for this. it is smooth enough
		}

		nitroBar.fillAmount = nitroAmount / MAXNITRO;
	}

	public void incNitro () {
		targetNitroAmout += INCAMOUNT;

		if (targetNitroAmout > 100)
			targetNitroAmout = 100;
		percent = 0;
	}
}
