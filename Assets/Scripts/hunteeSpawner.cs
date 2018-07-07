using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class hunteeSpawner : MonoBehaviour {

	Terrain huntsGround;

	public int hunteeCount = 5;

	float angRange = 360;
	float xRange = 100;
	float xStart = 30;
	float terrainSize;
	float terrainCenter;

	string[] hunteeFabNames = {"Eyes"}; // TODO


	public UnityEngine.Object[] huntees;

	// Use this for initialization
	void Start () {
		huntsGround = GameObject.Find ("HuntsGround").GetComponent(typeof(Terrain)) as Terrain;

		terrainSize = huntsGround.terrainData.size.x; // Assuming that the terrrain is a square
		xStart = terrainSize / 6;
		xRange = terrainSize / 2;
		terrainCenter = terrainSize / 2;

		// Load the trees
		huntees = new UnityEngine.Object[hunteeFabNames.Length];
		gatherHuntees();

		// Grow trees
		placeHuntees (xStart, xRange, angRange);
	}

	void placeHuntees(float xStart, float xRange, float angRange) {
		Debug.Log ("growing trees");

		for (int i = 0; i < hunteeCount; i++) {
			float dis = Random.Range (xStart, xRange);
			float ang = Random.Range (0, angRange);
			int hId = Random.Range (0, huntees.Length);
			Debug.Log ("hid: " + hId);

			PolarToCartesian randLoc = new PolarToCartesian (dis, ang);

			GameObject hunteeInstance = (GameObject) Instantiate (huntees[hId], new Vector3 (randLoc.x + terrainCenter, 2.5f, randLoc.y + terrainCenter), Quaternion.identity);
			hunteeInstance.name = hunteeFabNames[hId] + i;
			hunteeInstance.gameObject.transform.LookAt (new Vector3 (150, 0, 150));
		}

	}

	void gatherHuntees(){
		for (int i = 0; i < hunteeFabNames.Length; i++) {
			Debug.Log ("gathering");
			huntees[i] = Resources.Load ("huntees/"+hunteeFabNames[i]);
		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
