
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomGhost : MonoBehaviour
{

	public enum StateType { state_chase, state_evade };
	public GameObject[] corner = new GameObject[4];
	public StateType currState = StateType.state_chase;
	public float timer;
	public Transform target;
	public int newtarget;
	public float speed;
	public NavMeshAgent nav;
	public Vector3 Target;
	public PlayerController pac;


	void Start()
	{
		nav = gameObject.GetComponent<NavMeshAgent>();
	}


	void Update()
	{

		timer += Time.deltaTime;

		if (timer >= newtarget)
		{
			GoToTarget();
			timer = 0;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (pac.dangerous == false)
			{
				other.gameObject.SetActive(false);
				other.transform.position = new Vector3(0.08f, 0.2f, -3.37f);
				other.gameObject.SetActive(true);
				//pac.AddScore(-50);
				//pac.Lives(-1);
			}

			else
			{
				this.gameObject.SetActive(false);
				this.transform.position = new Vector3(-1.1f, 0f, 0.9f);
				this.gameObject.SetActive(true);
				//pac.AddScore(50);
			}

		}

	}

	public void changeState(StateType newState)
	{
		currState = newState;
	}

	public void UpdateState(StateType CurrentState)
	{

		switch (CurrentState)
		{

		case StateType.state_evade:

			EvadeEnemy();

			break;

		case StateType.state_chase:
			//go to target
			if (pac.dangerous)
			{
				changeState(StateType.state_evade);
				Invoke("BackToChase", 5);
			}

			GoToTarget();
			break;
		}
	}
	public void EvadeEnemy()
	{

		float[] arr = new float[4];

		float temp;
		int index = 0;


		arr[0] = Vector3.Distance(pac.gameObject.transform.position, corner[0].gameObject.transform.position);
		arr[1] = Vector3.Distance(pac.gameObject.transform.position, corner[1].gameObject.transform.position);
		arr[2] = Vector3.Distance(pac.gameObject.transform.position, corner[2].gameObject.transform.position);
		arr[3] = Vector3.Distance(pac.gameObject.transform.position, corner[3].gameObject.transform.position);
		temp = arr[0];
		for (int j = 1; j <= 3; j++)
		{

			if (arr[j] > temp)
			{
				temp = arr[j];

				index = j;
			}
		}
		nav.destination = corner[index].transform.position;
	}
	private void GoToTarget()
	{
		float myX = gameObject.transform.position.x;
		float myZ = gameObject.transform.position.z;

		float xPos = myX + Random.Range(myX - 100, myX + 100);
		float zPos = myZ + Random.Range(myZ - 100, myZ + 100);

		for (int i = 0; i <= 5; i++)
		{
			if ((xPos) < 100)
			{
				if ((zPos) < 100)
				{
					Target = target.position;
				}
			}
			nav.SetDestination(Target);
		}

		Target = new Vector3(xPos, gameObject.transform.position.y, zPos);
		nav.SetDestination(Target);
	}
}


