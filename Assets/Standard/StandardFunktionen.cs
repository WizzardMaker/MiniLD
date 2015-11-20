using UnityEngine;

public static class StandardFunktionen {

	public static Vector3 ConvertVector3(Vector3 vector,bool x = false,bool y = false,bool z = false){
		return new Vector3(x ? 0 : vector.x, y ? 0 : vector.y, z ? 0 : vector.z);
	}
	public static Vector3 ConvertVector3(Vector3 vector, bool x,float xF = 0f, bool y = false, float yF = 0f, bool z = false, float zF = 0f) {
		return new Vector3(x ? xF : vector.x, y ? yF : vector.y, z ? zF : vector.z);
	}

}