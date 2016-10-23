using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {
	public GameObject objectToDestroy;
	public float delayInSec;

	// Update is called once per frame
	void Update () {
		Destroy (objectToDestroy, delayInSec);
	}
}
