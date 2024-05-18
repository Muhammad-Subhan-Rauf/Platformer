using Godot;
using System;

public partial class GameManager : Node
{
	public int Score = 0;
	public int Lives = 5;

	public int health = 100;
	public bool flag = false;

	public override void _Process(double delta)
	{
		if (flag == true)
		{
			GetTree().ChangeSceneToFile("res://scenes/game_over.tscn");
		}
	}
	public void AddScore(int score)
	{
		GlobalVariables globalVars = GlobalVariables.GetInstance();
		

		globalVars.score += score;

		Score = globalVars.score;

		

		var scorelbl = GetParent().GetNode<Node>("Labels").GetNode<Label>("score");
		scorelbl.Text = "You collected " +  Score + " coins";
	}
	
	public void lose_life(int life)
	{

		GlobalVariables globalVars = GlobalVariables.GetInstance();
		
		globalVars.score = globalVars.temp_score;
		
		globalVars.lives -= life;
		Lives = globalVars.lives;

		if (Lives < 0)
		{
			
			flag = true;
			return;
			
		}
		
		
		

		globalVars.health = 100;
		


		var lifelbl = GetParent().GetNode<Player>("Player").GetNode<Camera2D>("Camera2D").GetNode<Label>("Life");
		lifelbl.Text = "Lives: " + Lives;
		
		
	}
	public void lose_health(int damage)
	{
		GlobalVariables globalVars = GlobalVariables.GetInstance();

		
		
		globalVars.health -= damage;
		health = globalVars.health;
		


		var hplbl = GetParent().GetNode<Player>("Player").GetNode<Camera2D>("Camera2D").GetNode<Label>("Life2");
		hplbl.Text = "HP: " + health;
	}

	
}
