using Godot;
using System;

public partial class Player : CharacterBody3D
{
	[Export]
	public PackedScene BulletScene { get; set; }
	

	public override void _Ready()
	{
		// Hide the mouse cursor and lock it to the center of the screen
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}
	
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventMouseMotion motion)
		{
			// Rotate the player left and right
			RotationDegrees = new Vector3(
				RotationDegrees.X,
				RotationDegrees.Y - motion.Relative.X/2,
				RotationDegrees.Z
			);
			// Safer and strongly typed:
			Camera3D camera = GetNode<Camera3D>("Camera3D");
			// Node3D gun_m = GetNode<Node3D>("%gun_model");
			
			// Calculate the new camera rotation for up/down movement
			float newCameraRotationX = camera.RotationDegrees.X - motion.Relative.Y / 5;

			// Clamp the rotation to a specific range (e.g., -80 to 80 degrees)
			newCameraRotationX = Mathf.Clamp(newCameraRotationX, -80, 80);
			
			camera.RotationDegrees = new Vector3(
			newCameraRotationX, // Apply up/down rotation to the camera's X-axis
			camera.RotationDegrees.Y,
			camera.RotationDegrees.Z
			);
		} else if (@event.IsActionPressed("ui_cancel")) {
			Input.MouseMode = Input.MouseModeEnum.Visible;
		} else if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
			{
				if (mouseEvent.ButtonIndex == MouseButton.Left)
				{
					Shoot();
				}
			}
		}
		private void Shoot()
		{
			if (BulletScene == null)
				return;

			// Create a new bullet
			var bullet = BulletScene.Instantiate<Bullet3d>();

			// Get the camera
			Camera3D camera = GetNode<Camera3D>("Camera3D");

			// Place the bullet at the camera position
			bullet.GlobalTransform = camera.GlobalTransform;

			// Add it to the scene tree (as a sibling of Player, or to the root)
			GetTree().CurrentScene.AddChild(bullet);
		}

}
