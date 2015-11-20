using UnityEngine;
using System.Collections;

public class AI: MonoBehaviour {

	public float geschwindigkeit;
	public bool isPlayer = false;
	protected CharacterController cc;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(isPlayer)
			cc.SimpleMove(transform.forward * (geschwindigkeit * Input.GetAxisRaw("Vertical")));
	}

	void CheckSelected() {

	}
}
