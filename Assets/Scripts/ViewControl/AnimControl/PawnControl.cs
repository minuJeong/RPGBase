using UnityEngine;
using System.Collections;


public class PawnControl : StateMachineBehaviour
{
	Vector3 _prevPos;

	int _hashMoveSpeed;

	public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		_prevPos = animator.transform.position;

		_hashMoveSpeed = Animator.StringToHash ("MoveSpeed");
	}
	
	// OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
	override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		float distance = Vector3.Distance (animator.transform.position, _prevPos);

		animator.SetFloat (_hashMoveSpeed, distance / Time.deltaTime);

		_prevPos = animator.transform.position;
	}
}
