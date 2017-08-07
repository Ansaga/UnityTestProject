using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Monster : MonoBehaviour
{
	//=================
	// Constants
	//=================
	enum State
	{
		PATROL,
		CHASE,
		ATTACK
	}

	//=================
	// Editor Fields
	//=================
	[SerializeField] GameObject player;
	[SerializeField] Character character;
	[SerializeField] State state;
	// Patrolling
	[SerializeField] float patrolThreshold = 5f;
	[SerializeField] float patrolSpeed = 1f;
	// Chasing
	[SerializeField] float chaseDistance = 10f;
	[SerializeField] float chaseSpeed = 2f;
	// Attacking
	[SerializeField] float attackDistance = 2f;

	//=================
	// Data
	//=================
	NavMeshAgent agent;
	// Patrolling
	GameObject[] waypoints;
	int waypointIdx;
	// Chasing
	GameObject target;


	//=================
	// Life Cycle
	//=================
	void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
		waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
		waypointIdx = Random.Range(0, waypoints.Length);
	}

	void Start()
	{
		agent.updatePosition = true;
		agent.updateRotation = true;

		state = State.PATROL;
	}

	void Update()
	{
		UpdateState();
	}

	//=================
	// Private Methods
	//=================
	void UpdateState()
	{
		switch(state)
		{
		case State.PATROL:
			Patrol();
			break;
		case State.CHASE:
			Chase();
			break;
		case State.ATTACK:
			Attack();
			break;
		}
	}

	void Patrol()
	{
		if(player != null && Vector3.Distance(transform.position, player.transform.position) <= chaseDistance)
		{
			target = player;
			state = State.CHASE;
		}
		else
		{
			agent.speed = patrolSpeed;
			character.Walk();
			if(Vector3.Distance(transform.position, waypoints[waypointIdx].transform.position) >= patrolThreshold)
			{
				agent.SetDestination(waypoints[waypointIdx].transform.position);
			}
			else
			{
				waypointIdx = Random.Range(0, waypoints.Length);
			}
		}
	}

	void Chase()
	{
		if(player != null && Vector3.Distance(transform.position, player.transform.position) <= attackDistance)
		{
			state = State.ATTACK;
		}
		else if(Vector3.Distance(transform.position, player.transform.position) >= chaseDistance)
		{
			state = State.PATROL;
		}
		else
		{
			agent.speed = chaseSpeed;
			character.Run();
			agent.SetDestination(target.transform.position);
		}
	}

	void Attack()
	{
		if(player != null && Vector3.Distance(transform.position, player.transform.position) <= attackDistance)
		{
			agent.speed = 0;
			character.Attack();
		}
		else if(player != null && Vector3.Distance(transform.position, player.transform.position) <= chaseDistance)
		{
			target = player;
			state = State.CHASE;
		}
		else
		{
			state = State.PATROL;
		}
	}
}
