using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public static CameraMovement active;

	public float distance = 5;
	public Transform target;
	public bool fixY = false, rotate = true, fixRotY = false;
	public Vector3 offset, RotOffset;
	public string RTSCamera = "--------------";
	public float maxDistance = 5f, geschwindigkeit = 5f, zoomGeschwindigkeit;

	protected Vector3 oldPos;

	// Use this for initialization
	void Start () {
		active = this;
	}
	
	public void ChangeCamera() {

	}

	// Update is called once per frame
	void Update () {
		if (GameManager.Mode == Modes.FirstPerson) {
			transform.position = target.TransformPoint(offset);//(new Vector3(followTransform.position.x, fixY ? 0 : followTransform.position.y, followTransform.position.z) + transform.forward * -distance) + followTransform.InverseTransformPoint(offset);
			if (rotate) {
				transform.rotation = Quaternion.Euler(fixRotY ? StandardFunktionen.ConvertVector3(target.rotation.eulerAngles, true, 0, false, 0, true, 0) + RotOffset : target.rotation.eulerAngles + RotOffset);
			}
		}else if(GameManager.Mode == Modes.RTS) {
			if (transform.position == oldPos)
				return;

			transform.position += transform.forward * (Input.GetAxisRaw("Mouse ScrollWheel") * zoomGeschwindigkeit);
			bool maxZoom = false;
			RaycastHit info;
			if(Physics.Raycast(new Ray(transform.position,transform.forward),out info, Mathf.Infinity,1<<8)) {
				if (Vector3.Distance(info.point, transform.position) <= maxDistance)
					transform.position -= (transform.forward * (maxDistance - Vector3.Distance(info.point, transform.position)));

			}
			Debug.Log(Vector3.Distance(info.point, transform.position));

			transform.position += Vector3.right * (geschwindigkeit * Input.GetAxisRaw("Horizontal")) + Vector3.forward * (geschwindigkeit * Input.GetAxisRaw("Vertical"));

		}
	}
}
