using UnityEngine;
using System.Collections;


public abstract class DataModel
{
}

public class InitLevelData : DataModel
{
	public PlayerPawn _Pawn;
	public string _CurrentSceneName;
}
