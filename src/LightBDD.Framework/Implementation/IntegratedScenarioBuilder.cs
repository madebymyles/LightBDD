using System.Threading.Tasks;
using LightBDD.Core.Execution;
using LightBDD.Core.Extensibility;
using LightBDD.Framework.Scenarios;

namespace LightBDD.Framework.Implementation
{
    internal class IntegratedScenarioBuilder<T> : IIntegratedScenarioBuilder<T>
    {
        public IntegratedScenarioBuilder(ICoreScenarioBuilder core)
        {
            Core = core;
        }

        public IIntegratedScenarioBuilder<T> Integrate() => this;

        public async Task RunAsync()
        {
            try
            {
                var scenario = Core
                    .WithCapturedScenarioDetailsIfNotSpecified()
                    .Build();

                await scenario.ExecuteAsync();
            }
            catch (ScenarioExecutionException e)
            {
                e.GetOriginal().Throw();
            }
        }

        public ICoreScenarioBuilder Core { get; }
    }
}