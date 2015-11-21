using UnityEngine;
using System.Collections;

public class AI: MonoBehaviour {

	public float geschwindigkeit;
	public bool isPlayer = false;
	protected CharacterController cc;
	public Texture2D selected;
	bool isSelected = false;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		CheckSelected();

		if(isPlayer)
			cc.SimpleMove(transform.forward * (geschwindigkeit * Input.GetAxisRaw("Vertical")));
	}
	
	void CheckSelected() {
		//Debug.Log(StandardFunktionen.ConvertVector3(Camera.main.WorldToScreenPoint(transform.position), false, 0, true, GameManager.PixelToRect(Camera.main.WorldToScreenPoint(transform.position).y), false));//Camera.main.WorldToScreenPoint(transform.position));
		
		if (Input.GetMouseButton(0) && GetComponent<Renderer>().isVisible) {
			if (GameManager.selection.Contains((StandardFunktionen.ConvertVector3(Camera.main.WorldToScreenPoint(transform.position), false, 0, true, GameManager.PixelToRect(Camera.main.WorldToScreenPoint(transform.position).y), false)))) {
				isSelected = true;
            } else {
				isSelected = false;
			}

		}


		if (Input.GetMouseButtonUp(0)) {
			RaycastHit hit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition + Vector3.forward), out hit))
				if (GetComponent<Collider>().bounds.Contains(hit.point)) {
					isSelected = true;
				}
            
		}
	}

	void OnGUI() {
		if (!isSelected)
			return;
		GUI.color = Color.green;
		GUI.DrawTexture(new Rect(StandardFunktionen.ConvertVector3(Camera.main.WorldToScreenPoint(transform.position), false, 0, true, GameManager.PixelToRect(Camera.main.WorldToScreenPoint(transform.position).y)) - Vector3.one * 20, Vector3.one * 40), selected);

	}
}
