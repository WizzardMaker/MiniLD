using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Materialfarbe : MonoBehaviour {

	public Color color = Color.red;
	protected Color oldColor;
	protected Material oldMaterial;
	public Material materialToUse;

	protected MeshRenderer meshRenderer;

	// Use this for initialization
	void Awake () {
		meshRenderer = GetComponent<MeshRenderer>();
		ChangeColor();
	}
	
	public void ChangeColor() {
		Material mat = new Material(materialToUse);

		if (Application.isPlaying)
			Destroy(meshRenderer.material);
		if (Application.isEditor)
			DestroyImmediate(meshRenderer.material);

		meshRenderer.material = mat;
		oldMaterial = materialToUse;
		meshRenderer.material.color = color;
		oldColor = color;

	}

	// Update is called once per frame
	void OnGUI () {
		if (color == oldColor && materialToUse == oldMaterial)
			return;

		ChangeColor();
	}

	void OnDestroy() {

	}
}
