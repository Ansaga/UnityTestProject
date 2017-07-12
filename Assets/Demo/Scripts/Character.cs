using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
	//=================
	// Constants
	//=================
	// animation bools
	const string IDLE   = "isIdle";
	const string WALK   = "isWalking";
	const string RUN    = "isRunning";
	const string ATTACK = "isAttacking";

	//=================
	// Data
	//=================
	Animator animator;
	string currentBool = IDLE;


	//=================
	// Life Cycle
	//=================
	void Awake()
	{
		animator = GetComponent<Animator>();
	}

	//=================
	// Public Methods
	//=================
	public void Idle()
	{
		ResetBool(IDLE);
		animator.SetBool(IDLE, true);
	}

	public void Walk()
	{
		ResetBool(WALK);
		animator.SetBool(WALK, true);
	}

	public void Run()
	{
		ResetBool(RUN);
		animator.SetBool(RUN, true);
	}

	public void Attack()
	{
		ResetBool(ATTACK);
		animator.SetBool(ATTACK, true);
	}

	//=================
	// Private Methods
	//=================
	void ResetBool(string boolTrigger)
	{
		if(currentBool != boolTrigger) {
			animator.SetBool(currentBool, false);
			currentBool = boolTrigger;
		}
	}
}
