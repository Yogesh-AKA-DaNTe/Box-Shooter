using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager gm;

	// Public variables
	public int score=0;

	public bool canBeatLevel = false;
	public int beatLevelScore=0;

	public float startTime=5.0f;
	
	public Text mainScoreDisplay;
	public Text mainTimerDisplay;

	public GameObject gameOverScoreOutline;

	public AudioSource musicAudioSource;

	public bool gameIsOver = false;

	public GameObject playAgainButtons;
	public string playAgainLevelToLoad;

	public GameObject nextLevelButtons;
	public string nextLevelToLoad;

	public GameObject restartButtons;
	public string restartLevelToLoad;

	private float currentTime;

	void Start ()
	{
		// Setup the game

		currentTime = startTime;

		if (gm == null)
		{
			gm = this.gameObject.GetComponent<GameManager>();
		}

		mainScoreDisplay.text = "0";

		if (gameOverScoreOutline)
		{
			gameOverScoreOutline.SetActive (false);
		}

		if (playAgainButtons)
		{
			playAgainButtons.SetActive (false);
		}

		if (nextLevelButtons)
		{
			nextLevelButtons.SetActive (false);
		}

		if (restartButtons)
		{
			restartButtons.SetActive (false);
		}
	}

	void Update ()
	{
		if (!gameIsOver)
		{
			if (canBeatLevel && (score >= beatLevelScore))
			{ 
				BeatLevel ();
			}
			else if (currentTime < 0)
			{
				EndGame ();
			}
			else
			{
				currentTime -= Time.deltaTime;
				mainTimerDisplay.text = currentTime.ToString ("0.00");				
			}
		}
	}

	// Function for ending the game
	void EndGame()
	{
		gameIsOver = true;
		mainTimerDisplay.text = "GAME OVER";
 
		if (gameOverScoreOutline)
		{
			gameOverScoreOutline.SetActive (true);
		}
	 
		if (playAgainButtons)
		{
			playAgainButtons.SetActive (true);
		}

		if (restartButtons)
		{
			restartButtons.SetActive (true);
		}
 
		if (musicAudioSource)
		{
			musicAudioSource.pitch = 0.5f;
		}
	}
	
	// Function for clearing the level
	void BeatLevel()
	{
		gameIsOver = true;
		mainTimerDisplay.text = "LEVEL COMPLETE";
 
		if (gameOverScoreOutline)
		{
			gameOverScoreOutline.SetActive (true);
		}
 
		if (nextLevelButtons)
		{
			nextLevelButtons.SetActive (true);
		}
		 
		if (musicAudioSource)
		{
			musicAudioSource.pitch = 0.5f;
		}
	}

	// Function to update the score or time
	public void targetHit (int scoreAmount, float timeAmount)
	{
		score += scoreAmount;
		mainScoreDisplay.text = score.ToString ();
		currentTime += timeAmount;
		
		if (currentTime < 0)
		{
			currentTime = 0.0f;
		}

		mainTimerDisplay.text = currentTime.ToString ("0.00");
	}

	// Function to restart the game
	public void RestartGame ()
	{
		SceneManager.LoadScene(playAgainLevelToLoad);
	}

	// Function to load the next level of the game
	public void NextLevel ()
	{
		SceneManager.LoadScene(nextLevelToLoad);
	}

	// Function to restart the game from beginning
	public void RestartFromBeginning ()
	{
		SceneManager.LoadScene(restartLevelToLoad);
	}
}
