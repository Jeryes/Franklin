using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof(CharacterController) )]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] float _speed = 10.0f;
	//[SerializeField] float _jumpSpeed = 15.0f; 
	//[SerializeField] float _gravity = 20.0f;
	//[SerializeField] float _sensitivity = 5f;
	[SerializeField] float _rotationSpeed = 10.0f;
	CharacterController _controller;
	float _horizontal, _vertical;
	float _mouseX, _mouseY;
	public GameObject playerBody;

	
	// use this for initialization
	void Awake ()
	{
		_controller = GetComponent<CharacterController>();
		playerBody = GameObject.Find("Player/PlayerBody");
	}

	// screen drawing update - read inputs here
	void Update ()
	{
		_horizontal = Input.GetAxis("Horizontal");
		_vertical = Input.GetAxis("Vertical");
		_mouseX = Input.GetAxis("Mouse X");
		_mouseY = Input.GetAxis("Mouse Y");
	}
	
	// physics simulation update - apply physics forces here
	void FixedUpdate ()
	{
		Vector3 moveDirection = Vector3.zero;

		// is the controller on the ground?
		//if( _controller.isGrounded )
		//{
			// feed moveDirection with input.
			moveDirection = new Vector3(_horizontal, 0, _vertical);
			moveDirection = transform.TransformDirection(moveDirection);

			// multiply it by speed.
			moveDirection.Normalize(); 
			moveDirection *= _speed;
			
			// jumping
			/*if( _jump )
				moveDirection.y = _jumpSpeed;
			*/
			if(moveDirection != Vector3.zero)
			{
				Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
				playerBody.transform.rotation = Quaternion.RotateTowards(playerBody.transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
			}
		//}
		/*
		float turner = _mouseX * _sensitivity;
		if( turner!=0 )
		{
			// action on mouse moving right
			transform.eulerAngles += new Vector3( 0 , turner , 0 );
		}
		
		float looker = -_mouseY * _sensitivity;
		if( looker!=0 )
		{
			// action on mouse moving right
			transform.eulerAngles += new Vector3( looker , 0 , 0 );
		}
		*/
		// apply gravity to the controller
		//moveDirection.y -= _gravity * Time.deltaTime;
		
		// make the character move
		_controller.Move( moveDirection * Time.deltaTime );
	}
}