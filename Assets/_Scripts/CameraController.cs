using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform player;
	public Transform exitDoor;
	public Vector3 offsetPos;
	public float moveSpeed=5;
	public float turnSpeed=10;
	public float smoothSpeed=0.5f;

	Quaternion targetRotation;
	Vector3 targetPos;
	bool smoothRotating;

	private Transform _target;
	
	
	private void Start()
	{
		_target = player;
	}

	// Update is called once per frame
	private void Update () {
		MoveWithTarget();
		LookAtTarget();
		
		if (Input.GetKeyDown(KeyCode.G) && !smoothRotating)
		{
			StartCoroutine(RotateAroundTarget(45));
		}

		if (Input.GetKeyDown(KeyCode.H) && !smoothRotating)
		{
			StartCoroutine(RotateAroundTarget(-45));
		}
		
	}

	private void MoveWithTarget(){
		targetPos = _target.position + offsetPos;
		transform.position = Vector3.Lerp (transform.position, targetPos, moveSpeed * Time.deltaTime);
	}

	private void LookAtTarget(){
		targetRotation = Quaternion.LookRotation (_target.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,turnSpeed * Time.deltaTime); 
	}



	private IEnumerator RotateAroundTarget(float angle){
		Vector3 vel = Vector3.zero;
		Vector3 targetOffsetPos = Quaternion.Euler (0, angle, 0) * offsetPos;
		float dist = Vector3.Distance (offsetPos, targetOffsetPos);
		smoothRotating = true;
		while (dist > 0.02f) {
			offsetPos = Vector3.SmoothDamp (offsetPos, targetOffsetPos, ref vel, smoothSpeed);
			dist = Vector3.Distance (offsetPos, targetOffsetPos);
			yield return null;
		}
	
		smoothRotating = false;
		offsetPos = targetOffsetPos;
	}

	public void SetTarget(Transform newTarget)
	{
		_target = newTarget;
	}
}
