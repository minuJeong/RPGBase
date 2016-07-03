using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MoveToTargetIndicator : MonoBehaviour
{
	float Progress = 0.0F;

	public MeshRenderer TargetRenderer;
	Material _TargetMaterial;

	// Use this for initialization
	void Start ()
	{
		Debug.Assert (TargetRenderer != null);

		_TargetMaterial = TargetRenderer.material;
		TargetRenderer.transform.DOScale (new Vector3 (0, 0, 0), 1.0F);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Progress += Time.deltaTime;
		_TargetMaterial.SetFloat ("_Progress", Progress);

		if (Progress >= 1.0F)
		{
			Destroy (gameObject);
		}
	}
}
