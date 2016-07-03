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
		TargetRenderer.transform.DOScaleY (0.001F, 1.0F).SetEase(Ease.OutQuart);
		TargetRenderer.transform.DOMoveY (0.001F, 1.0F).SetEase(Ease.OutQuart);
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
