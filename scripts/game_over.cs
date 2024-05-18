using Godot;
using System;

public partial class game_over : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GlobalVariables globalVars = GlobalVariables.GetInstance();
		if (Input.IsActionJustPressed("jump")){
			
			globalVars.ResetVariables();
			GetTree().ChangeSceneToFile("res://scenes/Game.tscn");
			Engine.TimeScale = 1.0f;
			
			return;
		}
	var lbl = GetNode<Label>("Label");
	lbl.Text = "Total Score:	" + globalVars.score;
	
	}
	

}
