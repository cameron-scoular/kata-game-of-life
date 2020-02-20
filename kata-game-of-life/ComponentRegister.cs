using System;
using System.Collections.Generic;

namespace kata_game_of_life
{
    public class ComponentRegister
    {
        
        private readonly Dictionary<Type, ComponentRegistration> _boardComponentRegistrations = new Dictionary<Type, ComponentRegistration>();
        
        private static ComponentRegister _instance;
        public static ComponentRegister GetComponentRegisterInstance()
        {
            return _instance ??= new ComponentRegister();
        }

        public void RegisterComponent<TComponent>(Type boardType, object componentInstance)
        {
            ComponentRegistration boardComponentRegistration;
            if (_boardComponentRegistrations.ContainsKey(boardType))
            {
                boardComponentRegistration = _boardComponentRegistrations[boardType];
                boardComponentRegistration.RegisterComponent<TComponent>(componentInstance);
            }
            else{
                
                boardComponentRegistration = new ComponentRegistration();
                boardComponentRegistration.RegisterComponent<TComponent>(componentInstance);
                _boardComponentRegistrations.Add(boardType, boardComponentRegistration);
            }
        }

        public TComponent ResolveComponent<TComponent>(Type boardType)
        {
            var componentRegistration = _boardComponentRegistrations[boardType];
            return (TComponent)componentRegistration.ResolveComponent<TComponent>();
        }

    }

    public class ComponentRegistration
    {
        private readonly Dictionary<Type, object> _componentRegistrations = new Dictionary<Type, object>();

        public void RegisterComponent<T>(object instance)
        {
            _componentRegistrations.Add(typeof(T), instance);
        }

        public object ResolveComponent<T>()
        {
            return _componentRegistrations[typeof(T)];
        }
    }
}