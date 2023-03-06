using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class chaser : MonoBehaviour {

	// Use this for initialization
	private NavMeshAgent nav;
	public PlayerController pacman;

		public enum StateType{state_RunAway,state_Chase};
	public StateType currState=StateType.state_Chase;
	public GameObject runAwayLocation;
	private string ourState;
	void Start () {
		nav=GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		UpdateState (currState);
	} 





	void UpdateState(StateType currentState)
	{

   switch (currentState)
   {

   case StateType.state_Chase:
   
if(isPacmanDangerous())//pacman is dangerous
  {
//change to run away  state

ChangeState(StateType.state_RunAway);
  }//otherwise keep chasing


   Chase();
   break;
		case StateType.state_RunAway:
			if (isPacmanDangerous ()) {//pacman is dangerous
				RunAway ();

			}
			else {
				ChangeState (StateType.state_Chase);	
			}
   break;


	}//end break
}


bool isPacmanDangerous()
{
  if(pacman.dangerous)
  {

  	return true;
  }
 else 
 return false;

}


void Chase()
{
	nav.SetDestination (pacman.gameObject.transform.position);
}

void ChangeState(StateType newState)
{
		currState = newState;

}

	void RunAway ()
	{

		nav.SetDestination (runAwayLocation.gameObject.transform.position);

	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (pacman.dangerous == false)
			{
				other.gameObject.SetActive(false);
				other.transform.position = new Vector3(-0.16f, 0.5f, 3.96f);
				other.gameObject.SetActive(true);
				pacman.setScore (-50);
				// pac.Lives(-1);
			}

			else
			{
				this.gameObject.SetActive(false);


				ChangeState (StateType.state_Chase);
				Invoke("reAppear",5);
				pacman.dangerous = false;

				pacman.setScore (50);
			}


		}

	}

	private void reAppear()
	{

		gameObject.SetActive(true);
		this.transform.position = new Vector3(-4.95f, 0f, -4.27f);//this is the position wher all the objects will reapper in when set active is returned to true 
	}


}
