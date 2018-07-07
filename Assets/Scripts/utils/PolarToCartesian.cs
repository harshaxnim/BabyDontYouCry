using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarToCartesian {

	float angle = 0;
	float distance = 0;

	public float x, y;

	public PolarToCartesian(float d, float a) {
		angle = Mathf.Deg2Rad*a;
		distance = d;
		x = distance * Mathf.Sin (angle);
		y = distance * Mathf.Cos (angle);
	}

}
