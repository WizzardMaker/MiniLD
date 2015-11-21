using UnityEngine;
using System.Collections;

public enum Modes : int {
	FirstPerson,
	RTS
}

public class GameManager : MonoBehaviour {

	Vector3 firstMousePos = new Vector3(-1,-1,-1),lastMousePos = new Vector3(-1,-1,-1);
	bool selectingSquare;

	public static Rect selection;
	public Texture2D selectionTexture;

	static Modes mode = Modes.RTS;

	public static Modes Mode {
		get { return mode; }
		set {
			mode = value;
			CameraMovement.active.ChangeCamera();
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			firstMousePos = Input.mousePosition;
		}

		if (Input.GetMouseButton(0)) {
			if(Input.mousePosition != firstMousePos) {
				lastMousePos = Input.mousePosition;
				selection = new Rect(firstMousePos.x, PixelToRect(firstMousePos.y), lastMousePos.x-firstMousePos.x ,PixelToRect(lastMousePos.y) - PixelToRect(firstMousePos.y));
			}
			

		}

		if (Input.GetMouseButtonUp(0)) {
			firstMousePos = -Vector3.one;
			lastMousePos = -Vector3.one;
			selection = new Rect(0, 0, 0, 0);
		}

		//
	}

	public static float PixelToRect(float y) {
		return (Screen.height - y);
	}

	void OnGUI() {
		GUI.color = new Color(1, 1,1, 0.25f);
		GUI.DrawTexture(selection, selectionTexture);
	}

}
