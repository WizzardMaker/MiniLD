using UnityEngine;
using System.Collections;

public enum Modes : int {
	FirstPerson,
	RTS
}

public class GameManager : MonoBehaviour {



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
	
	}

}
