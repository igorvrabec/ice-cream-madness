using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public const float BASE_MASS = 1.0f;
	public const float MASS_INCREMENT = 0.1f;
	public const int MIN_FAT = 0;
	public const int MAX_FAT = 10;

	// Note: PlayerSize : BoxColliderX : BoxColliderY = 1.0 : 0.5 : 1.0
	public const float BASE_SCALE = 1.0f;
	public const float SCALE_INCREMENT = 0.1f;
	public const float BASE_BOX_COLLIDER_X = 0.5f;
	public const float BASE_BOX_COLLIDER_Y = 0.1f;
	public const float BOX_COLLIDER_X_INCREMENT = 0.05f;
	public const float BOX_COLLIDER_Y_INCREMENT = 0.1f;
	public const float BASE_JUMP_FORCE = 500.0f;
	public const float JUMP_FORCE_INCREMENT = 50.0f;
	public const float BASE_CRATE_MASS = 100.0f;
	public const float CRATE_MASS_INCREMENT = 5.0f;

	private BoxCollider2D playerBoxCollider;
	private GameObject[] crates;
	private ScoreTracker scoreTracker;

	public int fatCount = 5;

	void Start() {
		// reference scoreTracker object so that score can be updated on pickups
		scoreTracker = GameObject.Find ("GameController").GetComponent<ScoreTracker>();

		// set character attributes based on initial fatCount
		SetCharacterAttributes ();

		// set fat counter based on initial fatCount
		scoreTracker.UpdateFatCounter (fatCount);
	}

	/**
	 * Called when caracter enters a Collider2D object, such is a Pickup (Fruit or Ice Cream)
	 */
	void OnCollisionEnter2D(Collision2D coll) {

		// when IceCreamPickup is picked up, destroy the fruit and change player stats
		if (coll.gameObject.tag == "IceCreamPickup") {

			// destroy the pickup
			Destroy (coll.gameObject);
			// increase fruitCount
			scoreTracker.IncreaseIceCreamCount ();
			IncreaseFatLevel ();
		}
		// when FruitPickup is picked up, destroy the fruit and change player stats
		if (coll.gameObject.tag == "FruitPickup") {

			// destroy the pickup
			Destroy (coll.gameObject);
			// increase fruitCount
			scoreTracker.IncreaseFruitCount ();
			DecreaseFatLevel ();
		}
	}

	/**
	 * Increases character fat level
	 */
	private void IncreaseFatLevel(int modifier = 1) {
		if (modifier <= 0)
			Debug.Log ("Incorrect fat modifier!");

		if (fatCount < Character.MAX_FAT) {
			fatCount += modifier;

			// can't have more fat than MAX_FAT
			if (fatCount > Character.MAX_FAT)
				fatCount = Character.MAX_FAT;

			SetCharacterAttributes();
		}

		scoreTracker.UpdateFatCounter (fatCount);
	}

	/**
	 * Decreases character fat level
	 */
	private void DecreaseFatLevel(int modifier = 1) {
		if (modifier <= 0)
			Debug.Log ("Incorrect fat modifier!");

		if (fatCount > Character.MIN_FAT) {
			fatCount -= modifier;

			// can't have less fat than MIN_FAT
			if (fatCount < Character.MIN_FAT)
				fatCount = Character.MIN_FAT;

			SetCharacterAttributes();
		}

		scoreTracker.UpdateFatCounter (fatCount);
	}

	public void SetCharacterAttributes() {
		// set character mass
		gameObject.GetComponent<Rigidbody2D> ().mass = Character.BASE_MASS + Character.MASS_INCREMENT * fatCount;

		// set player box collider
		gameObject.GetComponent<BoxCollider2D> ().size = new Vector2 (Character.BASE_BOX_COLLIDER_X + Character.BOX_COLLIDER_X_INCREMENT * fatCount, 0.0f);
		gameObject.GetComponent<BoxCollider2D> ().size = new Vector2 (0.0f, Character.BASE_BOX_COLLIDER_Y + Character.BOX_COLLIDER_Y_INCREMENT * fatCount);

		// set player jump force
		gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D> ().m_JumpForce = Character.BASE_JUMP_FORCE + Character.JUMP_FORCE_INCREMENT * fatCount;

		// set player scale
		// if the player is facing right (plus X scale), localScale is set with positve value
		// if the player is facing left (minus X scale), localScale is set with negative value
		if (gameObject.transform.localScale.x > 0) {
			gameObject.transform.localScale = new Vector3 (Character.BASE_SCALE + Character.SCALE_INCREMENT * fatCount, 
												           Character.BASE_SCALE + Character.SCALE_INCREMENT * fatCount, 0.0f);
		} else {
			gameObject.transform.localScale = new Vector3 (-Character.BASE_SCALE - Character.SCALE_INCREMENT * fatCount, 
															Character.BASE_SCALE + Character.SCALE_INCREMENT * fatCount, 0.0f);
		}

		// set the mass of the crates
		crates = GameObject.FindGameObjectsWithTag ("Crate");

		foreach (GameObject crate in crates) {
			crate.GetComponent<Rigidbody2D> ().mass = Character.BASE_CRATE_MASS - Character.CRATE_MASS_INCREMENT * fatCount;
		}
	}

	void Update()
	{
		//Debug.Log (gameObject.GetComponent<BoxCollider2D> ().size);
	}
}
