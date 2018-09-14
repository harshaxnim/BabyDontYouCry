using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour {

	private Quaternion origin = Quaternion.identity;

	void Start() {
		Input.gyro.enabled=true;
	}

	void Update() {
        if (MyGameState.camera_reset) // temporary: will be removed
			resetCam ();
		transform.localRotation = Quaternion.Inverse(origin) * GyroToUnity(Input.gyro.attitude);
	}

	private static Quaternion GyroToUnity(Quaternion q) {
		return new Quaternion(q.x, q.y, -q.z, -q.w);
	}

	public void resetCam () {
		origin = GyroToUnity (Input.gyro.attitude);
	}

	void OnGUI() {
		//GUILayout.Label(origin.eulerAngles+" <- origin");
		//GUILayout.Label(Input.gyro.attitude.eulerAngles+" <- gyro");
		//GUILayout.Label(Quaternion.Inverse(Input.gyro.attitude).eulerAngles+" <- inv gyro");
        GUILayout.Label((transform.localRotation.eulerAngles).ToString());
	}

	private void OnEnable()
	{
        resetCam();
	}

}
