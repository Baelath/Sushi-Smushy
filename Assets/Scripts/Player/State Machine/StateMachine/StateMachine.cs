using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
	private PlayerStateMachine player;
	private Animator anim;
	public PlayerState CurrentState { get; private set; }

	public void Initialize(PlayerStateMachine player, PlayerState startingState)
	{
		CurrentState = startingState;
		this.player = player;
		this.player.CurrentState = CurrentState.ToString();

		anim = player.GetComponent<Animator>();
	}

	public void ChangeState(PlayerState newState, int animState)
	{
		if (CurrentState.ExitingState)
			return;

		anim.SetInteger("state", animState);

		CurrentState.Exit();
		CurrentState = newState;
		player.CurrentState = CurrentState.ToString();
		CurrentState.Enter();
	}
}
