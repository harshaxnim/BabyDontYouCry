using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeSpawner : MonoBehaviour {

	Terrain huntsGround;

	public int treeCount = 5;

	float angRange = 360;
	float xRange = 150;
	float xStart = 50;
	float terrainSize;
	float terrainCenter;

	string[] treeFabNames = {"Acacia"};
	
	
	public UnityEngine.Object[] trees;

	// Use this for initialization
	void Start () {
		huntsGround = GameObject.Find ("HuntsGround").GetComponent(typeof(Terrain)) as Terrain;

		terrainSize = huntsGround.terrainData.size.x; // Assuming that the terrrain is a square
		xStart = terrainSize / 6;
		xRange = terrainSize / 2;
		terrainCenter = terrainSize / 2;

		// Load the trees
		trees = new UnityEngine.Object[treeFabNames.Length];
		gatherTrees();

		// Grow trees
		growTrees (xStart, xRange, angRange);
	}

	void growTrees(float xStart, float xRange, float angRange) {
		Debug.Log ("growing trees");

		for (int i = 0; i < treeCount; i++) {
			float dis = Random.Range (xStart, xRange);
			float ang = Random.Range (0, angRange);
			int tId = Random.Range (0, trees.Length);
			Debug.Log ("tid: "+tId);

			PolarToCartesian randLoc = new PolarToCartesian (dis, ang);

			GameObject treeInstance = (GameObject) Instantiate (trees[tId], new Vector3 (randLoc.x + terrainCenter, 0, randLoc.y + terrainCenter), Quaternion.identity);
			treeInstance.name = treeFabNames[tId] + i;
			treeInstance.gameObject.transform.LookAt (new Vector3 (150, 0, 150));
		}

	}

	void gatherTrees(){
		for (int i = 0; i < treeFabNames.Length; i++) {
			Debug.Log ("gathering");
			trees[i] = Resources.Load ("trees/"+treeFabNames[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
