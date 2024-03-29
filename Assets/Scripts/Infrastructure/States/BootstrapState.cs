﻿using Services;
using Services.CutterService;
using Services.Factory;
using Services.Progress;
using Services.ServiceLocator;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly ServiceLocator<IService> _services;
        private readonly ProjectConfig _configs;
        
        public BootstrapState(StateMachine stateMachine, ServiceLocator<IService> allServices,
            ProjectConfig configsHandler)
        {
            _stateMachine = stateMachine;
            _services = allServices;
            _configs = configsHandler;
            RegisterAllServices();
        }

        private void RegisterAllServices()
        {

        }

        public void Enter()
        {
            _stateMachine.Enter<MainMenuState>();
        }
        

        public void Exit()
        {
            
        }
    }
}