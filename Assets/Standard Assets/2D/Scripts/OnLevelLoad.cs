using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnLevelLoad : MonoBehaviour {
	public Text levelName;

	// Use this for initialization
	void Start () {
		//Debug.Log ("OnLevelLoad started.");
		//Debug.Log(SceneManager.GetActiveScene ().name);

		// get the reference to the LevelName gameObject
		levelName = GameObject.Find ("LevelName").GetComponent<Text>();
		// set the text of the LevelName to current Scene name
		levelName.text = SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
