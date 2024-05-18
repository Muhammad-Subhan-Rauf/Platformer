using Godot;
using System;

public partial class new_level : Area2D
{
	public bool flag = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// on body entered
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
					
	}

	public override void _Process(double delta)
	{
		if (flag == true)
		{
			change_scene();
			return;
		}
	}
	
	private void OnBodyEntered(Node body)
	{
		
		flag = true;
		return;
	}
	public void change_scene()
	{
		GlobalVariables globalVars = GlobalVariables.GetInstance();
		globalVars.temp_score = globalVars.score;
		GD.Print("Temp:	" + globalVars.temp_score);
		GetTree().ChangeSceneToFile("res://scenes/game_2.tscn");
		return;
		
		
	}
}
