using Godot;
using System;

public partial class Labels : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GlobalVariables globalVars = GlobalVariables.GetInstance();
		var health = globalVars.health;
		var Lives = globalVars.lives;
		var Score = globalVars.score;


		
		var hplbl = GetParent().GetNode<Player>("Player").GetNode<Camera2D>("Camera2D").GetNode<Label>("Life2");
		hplbl.Text = "HP: " + health;

		var lifelbl = GetParent().GetNode<Player>("Player").GetNode<Camera2D>("Camera2D").GetNode<Label>("Life");
		lifelbl.Text = "Lives: " + Lives;
		
		var score_lbl = GetParent().GetNode<Player>("Player").GetNode<Camera2D>("Camera2D").GetNode<Label>("Life3");
		score_lbl.Text = "" + Score;

		var scorelbl = GetParent().GetNode<Node>("Labels").GetNode<Label>("score");
		scorelbl.Text = "You collected " +  Score + " coins";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GlobalVariables globalVars = GlobalVariables.GetInstance();
		var health = globalVars.health;
		var Lives = globalVars.lives;
		var Score = globalVars.score;
		
		var hplbl = GetParent().GetNode<Player>("Player").GetNode<Camera2D>("Camera2D").GetNode<Label>("Life2");
		hplbl.Text = "HP: " + health;

		var lifelbl = GetParent().GetNode<Player>("Player").GetNode<Camera2D>("Camera2D").GetNode<Label>("Life");
		lifelbl.Text = "Lives: " + Lives;
		
		var score_lbl = GetParent().GetNode<Player>("Player").GetNode<Camera2D>("Camera2D").GetNode<Label>("Life3");
		score_lbl.Text = "" + Score;
	}
}
