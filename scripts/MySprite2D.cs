using Godot;
using System;

/// <summary>
/// A sprite that rotates and moves upward continuously.
/// </summary>
public partial class MySprite2D : Sprite2D
{
	private readonly int _speed = 200;
	private readonly float _rotationTurn = 5f;
	private bool _isMoving = false;
	private bool _isRotating = false;

	public MySprite2D()
	{
		GD.Print("Hello worlds!");
	}
	
	public override void _Ready()
	{
		SetProcess(false); // Start with the animation stopped.
		
		// Connect the movement button signal
		var moveButton = GetNode<Button>("../MoveButton");
		moveButton.Pressed += OnMoveButtonPressed;
		
		// Connect the rotation button signal
		var rotateButton = GetNode<Button>("../RotateButton"); // Adjust path to your rotation button
		rotateButton.Pressed += OnRotateButtonPressed;
		
		/*var customTimer = GetNode<Timer>("BlinkingTimer");
		customTimer.Timeout += OnTimerTimeout;*/
	}

	/// Called every frame to update the sprite's position and rotation.
	/// <param name="delta">The time elapsed since the last frame.</param>
	public override void _Process(double delta)
	{
		// --- Movement upwards ---
		if (_isMoving)
		{
			var velocity = Vector2.Up * _speed;
			Position += velocity * (float)delta;
		}
		
		// --- Rotation ---
		if (_isRotating)
		{
			Rotation += _rotationTurn * (float)delta;
		}
	}


	/*private void OnTimerTimeout()
	{
		//Visible = !Visible;
	}/*/

	private void OnMoveButtonPressed()
	{
		_isMoving = !_isMoving; // Toggle movement on/off
		SetProcess(_isMoving || _isRotating); // Enable process if either movement or rotation is active
		GD.Print("Move button pressed! Movement toggled: " + _isMoving);
	}
	
	private void OnRotateButtonPressed()
	{
		_isRotating = !_isRotating; // Toggle rotation on/off
		SetProcess(_isMoving || _isRotating); // Enable process if either movement or rotation is active
		GD.Print("Rotate button pressed! Rotation toggled: " + _isRotating);
	}
}
