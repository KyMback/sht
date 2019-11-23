using System;
using System.Collections.Generic;
using SHT.Domain.Models.Common;

namespace SHT.Application.StateMachineConfigs.Core
{
    internal class StateConfiguration<TEntity> : IStateConfiguration<TEntity>
        where TEntity : class, IHasState
    {
        public string FromState { get; set; }

        public string ToState { get; set; }

        public string Trigger { get; set; }

        public IList<Type> Handlers { get; set; } = new List<Type>();

        public IList<Type> Guards { get; set; } = new List<Type>();

        public IStateConfiguration<TEntity> From(string state)
        {
            FromState = state;
            return this;
        }

        public IStateConfiguration<TEntity> WithTrigger(string trigger)
        {
            Trigger = trigger;
            return this;
        }

        public IStateConfiguration<TEntity> To(string state)
        {
            ToState = state;
            return this;
        }

        public IStateConfiguration<TEntity> WithGuard<TGuard>()
            where TGuard : IStateTransitionGuard<TEntity>
        {
            Guards.Add(typeof(TGuard));
            return this;
        }

        public IStateConfiguration<TEntity> Use<THandler>()
            where THandler : IStateTransitionHandler<TEntity>
        {
            Handlers.Add(typeof(THandler));
            return this;
        }
    }
}