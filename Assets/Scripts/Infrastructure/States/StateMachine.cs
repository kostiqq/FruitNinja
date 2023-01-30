﻿using System;
using System.Collections.Generic;

namespace Infrastructure.States
{
    public class StateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public StateMachine()
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this),
                [typeof(MainMenuState)] = new MainMenuState(this),
                [typeof(PlayModeState)] = new PlayModeState(this),
                [typeof(GameOverState)] = new GameOverState(this)
            };
        }
        
        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            IState state = _states[typeof(TState)];
            _activeState = state;
            state.Enter();
        }
    }
}