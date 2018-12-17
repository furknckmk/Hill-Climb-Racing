using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTakip : MonoBehaviour {

	public Transform nesne;
	void Start () {
		
	}
	
	
	void Update () {
		Vector3 konum=new Vector3(nesne.position.x,nesne.position.y,transform.position.z);
		transform.position=konum;
	}
}
