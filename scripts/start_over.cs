using Godot;
using System;

public partial class start_over : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public bool flag = false;
	
	public override void _Ready()
	{
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (flag == true)
		{
			change_scene();
		}
	}
	private void OnBodyEntered(Node body)
	{
		GD.Print("Player Entered");
		flag = true;
		
		return;

		
	}
	public void change_scene()
	{
		GlobalVariables globalVars = GlobalVariables.GetInstance();
		globalVars.temp_score = globalVars.score;
		globalVars.lives += 1;
		
		GetTree().ChangeSceneToFile("res://scenes/Game.tscn");
		return;
	}
}
