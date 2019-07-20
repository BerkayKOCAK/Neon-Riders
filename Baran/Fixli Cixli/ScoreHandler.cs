using System.IO;
using UnityEngine;

public class ScoreHandler : MonoBehaviour {
	/*				
	 *				SCRIPT DESCRIPTION
	 * Keeps score in SCORE (static int)
	 * Handles PointThang collision
	 * Call handleScore() after death
	 * 
	 *					CONSTANTS
	 * Feel free to change those for balance purposess
	 * 
	 * 
	 * SCORETIME:
	 * Type: int
	 * Definition: Every half a second SCORE is increased
	 * by SCORETIME
	 * 
	 * FILEPATH:
	 * Type: string
	 * Definition: Path of the SaveFile.txt which keeps 
	 * scores (excluding "SaveFile.txt" part at the end).
	 * It is empty right now. Feel free to modify
	 * 
	 * ARRAYLENGTH:
	 * Type: int
	 * Definition: Size of the SCOREARRAY(top scores)
	 * 
	 */


	private		int				SCORE;
	private		static int[]	SCOREARRAY;
    

	#region CONSTANTS

	[SerializeField]
	private const int		SCORETIME	= 100;
	[SerializeField]
	private const int		ARRAYLENGTH = 10;
	[SerializeField]
	private const string	FILEPATH	= "";

	#endregion

	float timeLast;

	// TODO: remove this. just for debug
	public UnityEngine.UI.Text text;

	private void Start () {
		SCORE	 = 0;
		timeLast = 0;

		SCOREARRAY = new int[ARRAYLENGTH];
		loadScore();
	}

	private void FixedUpdate () {
		if (Time.time - timeLast > 0.5f) {
			timeLast = Time.time;
			Update2hz();
		}

		// TODO: remove this. just for debug
        
		text.text = "" + SCORE;

	}

	private void Update2hz () {
		// This function is called with 2hz
		SCORE += SCORETIME;

	}

	private void saveScore () {
		// saves the score board
		StreamWriter writer = new StreamWriter(FILEPATH + "SaveFile.txt");

		for (int i = 0; i < SCOREARRAY.Length; ++i)
			writer.WriteLine(SCOREARRAY[i]);

		writer.Close();

	}

	private void loadScore () {
		// loads the score board in "SaveFile.txt"
		// if there is no "SaveFile.txt", score board is filled with 0s

		if (!File.Exists(FILEPATH + "SaveFile.txt")) {
			for (int i = 0; i < ARRAYLENGTH; ++i)
				SCOREARRAY[i] = 0;

			return;
		}

		StreamReader reader = new StreamReader(FILEPATH + "SaveFile.txt");

		for (int i = 0;i < SCOREARRAY.Length;++i) 
			SCOREARRAY[i] = System.Convert.ToInt32(reader.ReadLine());

		reader.Close();

	}

	public void handleScore () {
		// update score board if necessary
		for (int i = 0; i < ARRAYLENGTH; ++i) {

			if (SCORE > SCOREARRAY[i]) {
				for (int j = ARRAYLENGTH - 1; j > i; --j)
					SCOREARRAY[j] = SCOREARRAY[j - 1];

				SCOREARRAY[i] = SCORE;

				// save the new score board
				saveScore();

				return;
			}
		}

	}

	public void incScore (int INC) {
		SCORE += INC;
	}
}
