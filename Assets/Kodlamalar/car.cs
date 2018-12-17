using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour {

	public WheelJoint2D arka_teker;
	public WheelJoint2D on_teker;
	public float hiz;
	private float hareket;
	private float rot_ilk;
	private float rot_mevcut;
	private float rot_son;
	private float rot_ilk_t;
	private float rot_mevcut_t;
	private float rot_son_t;
	void Start () {
		rot_mevcut=transform.rotation.eulerAngles.z;
		rot_ilk=rot_mevcut;
		rot_son=rot_mevcut;
		rot_mevcut_t=transform.rotation.eulerAngles.z;
		rot_ilk_t=rot_mevcut_t;
		rot_son_t=rot_mevcut_t;
	}
	
	
	void Update () 
	{
		float v= Input.GetAxis("Horizontal");	
		hareket=hiz*v;
		takla();
		TersTakla();
	}
	
	void FixedUpdate()
	{
		
		if (hareket==0)
		{
			arka_teker.useMotor=false;
			on_teker.useMotor=false;
		}
		else
		{
			arka_teker.useMotor=true;
			on_teker.useMotor=true;
			JointMotor2D motore=new JointMotor2D();
		motore.motorSpeed=hareket;
		motore.maxMotorTorque=10000;
		arka_teker.motor=motore;
		on_teker.motor=motore;
		}
		
	}
	void	takla(){

		rot_mevcut=transform.rotation.eulerAngles.z;
		if (rot_son<rot_mevcut)
		{
			rot_ilk=rot_mevcut;
		}
		else if (rot_son>rot_mevcut && rot_son-rot_mevcut>100)
		{
			rot_ilk=rot_mevcut;
		}
		if (rot_ilk-rot_mevcut>300)
		{
			Debug.Log("Takla");
			rot_ilk=rot_mevcut;
		}
		rot_son=rot_mevcut;
	}
	void TersTakla(){
		rot_mevcut_t=transform.rotation.eulerAngles.z;
		if (rot_son_t>rot_mevcut_t)
		{
			rot_ilk_t=rot_mevcut_t;
		}
		else if (rot_son_t<rot_mevcut_t && rot_mevcut_t-rot_son_t>100)
		{
			rot_ilk_t=rot_mevcut_t;
		}
		if (rot_mevcut_t-rot_ilk_t>300)
		{
			Debug.Log("Ters Takla");
			rot_ilk_t=rot_mevcut_t;
		}
		rot_son_t=rot_mevcut_t;
	}
}
