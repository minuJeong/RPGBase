using UnityEngine;


public abstract class Pawn : MonoBehaviour
{
	protected int MECANIM_STATE_ATTACK = 0;

	protected const float ATTACK_MOTION_TIME = 0.5F;

	protected NavMeshAgent _Motor;

	protected Animator _Mecanim;

	private float _MotionTime;


	protected void Start ()
	{
		FindComponents ();

		GetMecanimHashes ();

		Init ();
	}

	protected abstract void Init ();

	private void FindComponents ()
	{
		_Motor = GetComponent<NavMeshAgent> ();

		_Mecanim = GetComponentInChildren<Animator> ();
	}

	private void GetMecanimHashes ()
	{
		MECANIM_STATE_ATTACK = Animator.StringToHash ("Attack");
	}

	public void Move (Vector3 direction)
	{
		if (_MotionTime > Time.time)
		{
			return;
		}

		_Motor.SetDestination(transform.position + direction);
	}

	public void Attack ()
	{
		_Mecanim.Play (MECANIM_STATE_ATTACK);


		_MotionTime = Time.time + ATTACK_MOTION_TIME;

		_Motor.SetDestination(transform.position);
	}
}