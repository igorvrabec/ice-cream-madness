using UnityEngine;
using System.Collections;

public class LoopedMovement : MonoBehaviour {

	public float  movementTreshold = 5.0f;       	// movement treshold
	public float  speed = 5.0f;             		// movement speed
	public string movementAxis = "x";             	// movement axis

	protected float angle = -90.0f;             	// angle to determin the height by using the sinus
	protected float toDegrees = Mathf.PI/180.0f;    // radians to degrees
	protected Vector3 startPosition;                // postition of the object when the script starts

	void Start() {
		startPosition = gameObject.transform.localPosition;
	}

	void FixedUpdate() {
		angle += speed * Time.deltaTime;

		if (angle > 270.0f)
			angle -= 360.0f;
		
		//Debug.Log (maxUpAndDown * (1.0f + Mathf.Sin (angle * toDegrees)) / 2.0f);
		if (movementAxis == "x")
			gameObject.transform.localPosition = new Vector3(startPosition.x + movementTreshold * (1.0f + Mathf.Sin(angle * toDegrees)) / 2.0f, startPosition.y, startPosition.z);
		else if (movementAxis == "y")
			gameObject.transform.localPosition = new Vector3(startPosition.x, startPosition.y + movementTreshold * (1.0f + Mathf.Sin(angle * toDegrees)) / 2.0f, startPosition.z);
	}
}
