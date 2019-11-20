using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SHT.Domain.Models.Common;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.Common.Transactions;
using Stateless;

namespace SHT.Application.StateMachineConfigs.Core
{
    internal class StateManager<TEntity> : IStateManager<TEntity>
        where TEntity : class, IHasState
    {
        private readonly StateMachine<string, string> _stateMachine;
        private readonly ISafeInjectionResolver _safeInjectionResolver;
        private TEntity _entity;

        public StateManager(
            IStateConfigurationContainer<TEntity> stateConfigurationContainer,
            ISafeInjectionResolver safeInjectionResolver)
        {
            _safeInjectionResolver = safeInjectionResolver;
            _stateMachine = new StateMachine<string, string>(
                () => _entity.State,
                state => _entity.State = state,
                FiringMode.Immediate);
            var builder = new StateConfigurationBuilder<TEntity>();
            stateConfigurationContainer.Configure(builder);

            foreach (StateConfiguration<TEntity> cfg in builder.Configurations)
            {
                var trigger = _stateMachine.SetTriggerParameters<StateTransitionContext<TEntity>>(cfg.Trigger);

                _stateMachine
                    .Configure(cfg.FromState)
                    .Permit(cfg.Trigger, cfg.ToState);

                _stateMachine
                    .Configure(cfg.ToState)
                    .OnEntryFromAsync(trigger, (context, transition) => OnStartTransition(context, transition, cfg));
            }
        }

        public Task Process(TEntity entity, string trigger)
        {
            _entity = entity;
            return _stateMachine.FireAsync(
                new StateMachine<string, string>.TriggerWithParameters<StateTransitionContext<TEntity>>(trigger),
                new StateTransitionContext<TEntity>
                {
                    Entity = entity,
                });
        }

        public Task<IReadOnlyCollection<string>> GetAvailableTriggers(TEntity entity)
        {
            _entity = entity;
            return Task.FromResult<IReadOnlyCollection<string>>(_stateMachine.GetPermittedTriggers().ToArray());
        }

        private async Task OnStartTransition(
            StateTransitionContext<TEntity> context,
            StateMachine<string, string>.Transition transition,
            StateConfiguration<TEntity> configuration)
        {
            context.SourceState = transition.Source;
            context.TargetState = transition.Destination;
            context.Trigger = transition.Trigger;
            var handlers = configuration.Handlers.Select(t => _safeInjectionResolver.Resolve(t))
                .Cast<IStateTransitionHandler<TEntity>>();

            using var transaction = TransactionsFactory.Create();
            foreach (var stateTransitionHandler in handlers)
            {
                await stateTransitionHandler.Transit(context);
            }

            transaction.Complete();
        }
    }
}