using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

	public static int fruitCount = 0;
	public static int iceCreamCount = 0;

	private Text fruitCounter;
	private Text iceCreamCounter;
	private Text fatCounter;

	void Awake() {
		fruitCounter    = GameObject.Find("FruitCounter").GetComponent<Text> ();
		iceCreamCounter = GameObject.Find("IceCreamCounter").GetComponent<Text>();
		fatCounter      = GameObject.Find("FatCounter").GetComponent<Text>();
	}

	public void IncreaseFruitCount() {
		fruitCount++;
		fruitCounter.text = ScoreTracker.fruitCount.ToString ();
	}

	public void IncreaseIceCreamCount() {
		iceCreamCount++;
		iceCreamCounter.text = ScoreTracker.iceCreamCount.ToString ();
	}

	public void UpdateFatCounter(int fatCount) {
		string fatCounterText = "";

		switch (fatCount) {
			case 0:
				fatCounterText = "Toothpick";
				break;
			case 1:
			case 2:
			case 3:
			case 4:
				fatCounterText = "Thinner";
				break;
			case 5:
				fatCounterText = "Normal";
				break;
			case 6:
			case 7:
			case 8:
			case 9:
				fatCounterText = "Chubby";
				break;
			case 10:
				fatCounterText = "Fat";
				break;
			default:
				fatCounterText = "Obese";
				break;
		}
		
		fatCounter.text = "Size: " + fatCounterText +  " (" + fatCount.ToString() + "/10)";
	} 
}
