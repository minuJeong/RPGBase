﻿using UnityEngine;
using System.Collections;

public class AstarTile : MonoBehaviour
{
	public Vector2 DEBUG_XZ;


	public bool IsWalkable = true;
	public AstarTile PathParent = null;

	public Vector2 XZ
	{
		get
		{ 
			return new Vector2 (X, Z);
		}
	}

	public int X
	{
		get
		{ 
			return (int)transform.position.x;
		}
	}

	public int Z
	{
		get
		{ 
			return (int)transform.position.z;
		}
	}

	void Start ()
	{
		DEBUG_XZ = XZ;
	}
}
