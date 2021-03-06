﻿using UnityEngine;
using System.Collections;

public class GridInfo : InfoItem {

	public int Elevation;
	public int ExtraCost;

	public int GridType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override string GetInfo()
	{
		string print = "";
		
		if(GridType == 0){
			print = "TerrainHolder Elevation: " + Elevation + "\nConstruction Cost: " + ExtraCost;
		}
		if(GridType == 1){
			print = "WaterRoute Elevation: " + Elevation + "\nConstruction Cost: " + ExtraCost;
		}

		return print;
	}

	void OnMouseDown()
	{
		CreateManager createManager = GameObject.FindGameObjectWithTag ("createManager").transform.GetComponent<CreateManager> ();
		bool creating = createManager.creating;

		if (creating) {
			Transform newTransform = createManager.newTransform;
			Quaternion rotation = createManager.rotation;
			int maxOutput = createManager.maxOutput;
			int directionIndex = createManager.directionIndex;
			Vector3 pos = transform.position;
			pos.y += 1;
			Transform newObject = (Transform)Instantiate(newTransform, pos, rotation);

			newObject.GetComponent<TurbineInfo> ().maxOutput = maxOutput;
			newObject.GetComponent<TurbineInfo> ().directionIndex = directionIndex % 8;

			createManager.creating = false;
		}

		if (!creating) {
			GameObject.FindGameObjectWithTag ("screens").GetComponent<CustomizationSwitch> ().toSelectionP ();
			GameObject.FindGameObjectWithTag ("selectionPanel").GetComponent<InfoPanel> ().UpdateInfo (gameObject.transform.GetComponent<GridInfo>());
			Debug.Log(GetInfo ());
			
			GameObject.FindGameObjectWithTag ("createManager").transform.position = gameObject.transform.position;
		}
	}
}
