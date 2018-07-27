using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour {

	private Quaternion origin = Quaternion.identity;
	private Vector3 rotateValue;

	void Start() {
		Input.gyro.enabled=true;
	}

	void Update() {
		if (Input.touchCount > 0) // temporary: will be removed
			resetCam ();
		transform.localRotation = Quaternion.Inverse(origin) * GyroToUnity(Input.gyro.attitude);
	}

	private static Quaternion GyroToUnity(Quaternion q) {
		return new Quaternion(q.x, q.y, -q.z, -q.w);
	}

	private void resetCam () {
		origin = GyroToUnity (Input.gyro.attitude);
	}

	void OnGUI() {
		GUILayout.Label(origin.eulerAngles+" <- origin");
		GUILayout.Label(Input.gyro.attitude.eulerAngles+" <- gyro");
		GUILayout.Label(Quaternion.Inverse(Input.gyro.attitude).eulerAngles+" <- inv gyro");
		GUILayout.Label(transform.localRotation.eulerAngles+" <- localRotation");
	}

}
