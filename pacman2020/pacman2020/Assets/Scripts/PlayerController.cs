using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//so that we can be able to use TEXT
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public bool dangerous = false;//to make the player dangerous
	public Text liveleft;
	private int live=3;

	private Rigidbody rb;
	private int scoreCount;//for counting the eaten balls 
	private int scoreDecreased=150;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		scoreCount = 0;
		setScore(0);//initial our text displayed
		//will be Score:0
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))// ("Pick Up"))
		{
			other.gameObject.SetActive (false);//remove the object we collide with from the game view
			//scoreCount++;
			setScore (5);

		}

		if (other.gameObject.CompareTag("pill"))
		{
			other.gameObject.SetActive(false);
			setScore (20);

			dangerous = true;
			speed = 15;
			Invoke ("isDangerous", 5);

		}




	}


	public void setScore(int score)
	{
		scoreCount = scoreCount + score;
		if (scoreCount >= 300) 
		{
			PlayerPrefs.SetInt ("Score", scoreCount);
			SceneManager.LoadScene (2);


		}
		if (score==-50)
		{
			scoreDecreased += score;
			live--;
			if (scoreDecreased==0)
				{
					PlayerPrefs.SetInt ("Score", scoreCount);
					SceneManager.LoadScene (3);
				}

				}
		countText.text = "SCORE: " + scoreCount.ToString ();//to update our score when the player collide 
		//with the ball
		liveleft.text="LIVES: "+live.ToString();
	}

	private void isDangerous()
	{

		dangerous = false;
		speed = 10;
	}
}

