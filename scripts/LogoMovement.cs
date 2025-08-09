using Godot;
using System;

public partial class LogoMovement : Sprite2D
{
	private readonly int _speed = 200;
	private bool _isMoving = false;

	public override void _Ready()
	{
		SetProcess(false);  // Start with animation stopped - logo is stationary
		var moveButton = GetNode<Button>("../MoveButton");
		moveButton.Pressed += OnMoveButtonPress;

		var rotateButton = GetNode<Button>("../RotateButton");
		rotateButton.Pressed += OnRotateButtonPress;
	}

		public override void _Process(double delta)
	{
		if (_isMoving)
		{
			// Move in the direction the logo is currently facing
			var velocity = Vector2.Up.Rotated(Rotation) * _speed;
			Position += velocity * (float)delta;
		}
	}

	public void OnMoveButtonPress()
	{
		_isMoving = !_isMoving;
		SetProcess(_isMoving);  // Enable/disable _Process based on movement state
		GD.Print("Movement toggled: " + _isMoving);
	}

	public void OnRotateButtonPress()
	{
		RotationDegrees += 90f; // rotate exactly 90° per click
		// Optional: keep value within 0..360
		RotationDegrees = Mathf.Wrap(RotationDegrees, 0f, 360f);
		
		GD.Print("Rotation: " + RotationDegrees);
	}
}
