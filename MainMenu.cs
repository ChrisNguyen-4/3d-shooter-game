using Godot;
using System;

public partial class MainMenu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("MainMenu Ready!");

		var b1 = GetNode<Button>("VBoxContainer/Button");
		var b2 = GetNode<Button>("VBoxContainer/Button2");
		var b3 = GetNode<Button>("VBoxContainer/Button3");

		//GD.Print("✅ Ready fired, buttons found:",
		//GetNode<Button>("VBoxContainer/Button") != null,
		//GetNode<Button>("VBoxContainer/Button2") != null,
		//GetNode<Button>("VBoxContainer/Button3") != null);

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//
	}

	private void _on_normal_pressed()
	{
		// Replace with function body.
		GetTree().ChangeSceneToFile("res://scenes/normal.tscn");
	}

	private void _on_master_pressed()
	{
		// Replace with function body.
		GetTree().ChangeSceneToFile("res://scenes/master_scene.tscn");
	}

	private void _on_exit_pressed()
	{
		// Replace with function body.
		GD.Print("Exit pressed");
		GetTree().Quit();
	}
}
