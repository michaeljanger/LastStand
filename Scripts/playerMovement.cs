using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum LookDirection
{
	Left = 0,
	Right = 180,
	Up = 90,
	Down = 270,
	Background = 90,
	Foreground = 270
}

[RequireComponent(typeof(Rigidbody))]
public class playerMovement : MonoBehaviour
{
	public float Speed = 1f;
	public float HorizontalDeadzone = 0.3f;
	public float VerticalDeadzone = 0.3f;
	public float VerticalThreshold = 0.8f;
	public float HeightOffset = 1f;
	public float LeftYRotation = 0f;

	private Rigidbody body;
	private float baseHeight = 0f;
	private LookDirection lookDir = LookDirection.Left;

	private bool vMovHandled = false;

	public PlayerMeshAnim childMesh;

	void Start()
	{
		body = GetComponent<Rigidbody>();
	}

	void Update()
	{
			if (!childMesh.IsInAnim)
			{

	         	if (Input.GetButtonUp("Fire1"))
				{

					if (shouldAnim)
					{
						//childMesh.PlayScare();
					}

				}
				else
				{
					float speed = body.velocity.magnitude;
					if (speed > 0f)
						childMesh.SetSpeed(speed > HorizontalDeadzone ? speed : 0f);
						childMesh.SetSpeed(speed > VerticalDeadzone ? speed : 0f);
				}
			}
		  
	}

	void FixedUpdate()
	{
			if (!childMesh.IsInAnim)
			{
				float vmov = Input.GetAxis("Vertical");
				bool vmovJustPressed = false;
				if (Mathf.Abs(vmov) > VerticalThreshold)
				{
					float vmov = Input.GetAxis("Vertical");
					float absVmov = Mathf.Abs(vmov);
					if (absVmov > VerticalDeadzone)
					{
						float moveDist = Mathf.Sign(vmov) * ((absVmov - .3f) / .7f) * Speed;
						lookDir = moveDist > 0f ? LookDirection.Up : LookDirection.Down;
						body.velocity = new Vector3(moveDist, 0f, 0f);
						var rot = Quaternion.Euler(0f, LeftYRotation + (float)lookDir, 0f);
						body.rotation = rot;
					}
					if (!vMovHandled)
					{
						vMovHandled = true;
						vmovJustPressed = true;
					}
				}
				else
				{
					vMovHandled = false;

					float hmov = Input.GetAxis("Horizontal");
					float absHmov = Mathf.Abs(hmov);
					if (absHmov > HorizontalDeadzone)
					{
						float moveDist = Mathf.Sign(hmov) * ((absHmov - .3f) / .7f) * Speed;
						lookDir = moveDist > 0f ? LookDirection.Right : LookDirection.Left;
						body.velocity = new Vector3(moveDist, 0f, 0f);
						var rot = Quaternion.Euler(0f, LeftYRotation + (float)lookDir, 0f);
						body.rotation = rot;
					}
				}

				if (vmovJustPressed)
				{
						if (vmov > 0f)
						{
							
							
						}
						body.velocity = Vector3.zero;
					}
					else
					{
						if (vmov > 0f)
							lookDir = LookDirection.Background;
						else
							lookDir = LookDirection.Foreground;

						var rot = Quaternion.Euler(0f, LeftYRotation + (float)lookDir, 0f);
						body.rotation = rot;
					}
				}
			}
}
