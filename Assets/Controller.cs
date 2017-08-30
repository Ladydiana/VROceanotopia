using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	private bool swimming = true;
	private Vector3 spawnPoint;
	GameObject[] sardines;
	GameObject[] whales;
	Vector3[] sardineSpawnPosition;
	Vector3[] whaleSpawnPosition;
	GameObject[] carps;
	Vector3[] carpSpawnPosition;
	GameObject[] probes;
	Vector3[] probeSpawnPosition;
	int arrayLength, arrayLength2, arrayLength3, arrayLength4;
	int timer, timerWhale, timerCarp, timerProbe;


	// Use this for initialization
	void Start () {
		int count = 0;
		timer = 0;
		timerWhale = 0;
		timerCarp = 0;
		timerProbe = 0;

		//player spawn point
		spawnPoint = transform.position;

		//get initial position for sardines


		if (sardines == null) {
			sardines = GameObject.FindGameObjectsWithTag ("SimpleSardineSkinWithControllerBoids");
		}
		arrayLength = sardines.Length;
		sardineSpawnPosition = new Vector3[arrayLength];
		foreach (GameObject pos in sardines)
		{
			sardineSpawnPosition[count] = pos.transform.position;
			count++;
		}

		//get initial position for whales
		if (whales == null) {
			whales = GameObject.FindGameObjectsWithTag ("Whale");
		}
		arrayLength2 = whales.Length;
		count = 0;
		whaleSpawnPosition = new Vector3[arrayLength2];
		foreach (GameObject pos in whales)
		{
			whaleSpawnPosition[count] = pos.transform.position;
			count++;
		}

		//get initial position for carps
		if (carps == null) {
			carps = GameObject.FindGameObjectsWithTag ("Carp");
		}
		arrayLength3 = carps.Length;
		count = 0;
		carpSpawnPosition = new Vector3[arrayLength3];
		foreach (GameObject pos in carps)
		{
			carpSpawnPosition[count] = pos.transform.position;
			count++;
		}

		//get initial position for probes
		if (probes == null) {
			probes = GameObject.FindGameObjectsWithTag ("Probe");
		}
		arrayLength4 = probes.Length;
		count = 0;
		probeSpawnPosition = new Vector3[arrayLength4];
		foreach (GameObject pos in probes)
		{
			probeSpawnPosition[count] = pos.transform.position;
			count++;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
		//move player
		if (swimming == true) {
			transform.position = transform.position + Camera.main.transform.forward * 1.5f * Time.deltaTime;
		}

		//respawn sardines every 700 frames
		timer++;
		if (timer == 700 ) {
			for (int i = 0; i < arrayLength; i++) {
				sardines[i].transform.position = sardineSpawnPosition[i];
			}
			timer = 0;
		}

		//whale movement and respawn
		timerWhale++;
		for (int i = 0; i < arrayLength2; i++) {
			if (timerWhale == 1500) {
				whales [i].transform.position = whaleSpawnPosition [i];
			} 
			else {
				whales[i].transform.Translate(Vector3.back * Time.deltaTime);
			}
		}
		if (timerWhale == 1500) {
			timerWhale = 0;
		}
			

		//carp movement and respawn
		timerCarp++;
		for (int i = 0; i < arrayLength3; i++) {
			if (timerCarp == 700) {
				carps [i].transform.position = carpSpawnPosition [i];
			} 
			else {
				carps[i].transform.Translate(Vector3.forward * Time.deltaTime);
			}
		}
		if (timerCarp == 700) {
			timerCarp = 0;
		}

		//probe movement and respawn
		timerProbe++;
		for (int i = 0; i < arrayLength4; i++) {
			if (timerProbe == 700) {
				probes [i].transform.position = probeSpawnPosition [i];
			} 
			else {
				probes[i].transform.Translate(Vector3.up * Time.deltaTime);
			}
		}
		if (timerProbe == 700) {
			timerProbe = 0;
		}


	}
}
