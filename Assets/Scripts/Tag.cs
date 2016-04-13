using UnityEngine;
using System.Collections;


public class Tag : MonoBehaviour
{
	public enum Types
	{
		Floor,
		PlayerPawn,
		Monster,
		TownFolk,
		Obstacle
	}

	public Types Type;
}
