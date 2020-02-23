using System;
using System.Collections.Generic;
using kata_game_of_life.Interfaces;

namespace kata_game_of_life
{
    public class ComponentRegister
    {
        private readonly Dictionary<Type, ComponentRegistration> _boardComponentRegistrations =
            new Dictionary<Type, ComponentRegistration>();

        private readonly ComponentRegistration _componentRegistration = new ComponentRegistration();

        private static ComponentRegister _instance;

        public static ComponentRegister GetComponentRegisterInstance()
        {
            return _instance ??= new ComponentRegister();
        }

        public void RegisterComponent<TComponent>(object componentInstance)
        {
            _componentRegistration.RegisterComponent<TComponent>(componentInstance);
        }

        public TComponent ResolveComponent<TComponent>()
        {
            return (TComponent) _componentRegistration.ResolveComponent<TComponent>();
        }

        public void RegisterComponent<TComponent> (Type boardType, object componentInstance)
        {
            if (!typeof(IBoard).IsAssignableFrom(boardType))
            {
                throw new ArgumentException("Specified parameter type does not implement IBoard");
            }
            
            ComponentRegistration boardComponentRegistration;
            if (_boardComponentRegistrations.ContainsKey(boardType))
            {
                boardComponentRegistration = _boardComponentRegistrations[boardType];
                boardComponentRegistration.RegisterComponent<TComponent>(componentInstance);
            }
            else
            {
                boardComponentRegistration = new ComponentRegistration();
                boardComponentRegistration.RegisterComponent<TComponent>(componentInstance);
                _boardComponentRegistrations.Add(boardType, boardComponentRegistration);
            }
        }

        public TComponent ResolveComponent<TComponent>(Type boardType)
        {
            if (!typeof(IBoard).IsAssignableFrom(boardType))
            {
                throw new ArgumentException("Specified parameter type does not implement IBoard");
            }
            
            var componentRegistration = _boardComponentRegistrations[boardType];
            return (TComponent) componentRegistration.ResolveComponent<TComponent>();
        }

        private class ComponentRegistration
        {
            private readonly Dictionary<Type, object> _componentRegistrations = new Dictionary<Type, object>();

            public void RegisterComponent<TComponent>(object instance)
            {
                if (!(instance is TComponent))
                {
                    throw new ArgumentException("Injected instance is not of correct type");
                }
                
                _componentRegistrations.Add(typeof(TComponent), instance);
            }

            public object ResolveComponent<TComponent>()
            {
                return _componentRegistrations[typeof(TComponent)];
            }
        }
    }
}