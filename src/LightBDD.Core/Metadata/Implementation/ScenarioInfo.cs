using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LightBDD.Core.Metadata.Implementation
{
    [DebuggerStepThrough]
    internal class ScenarioInfo : IScenarioInfo
    {
        public ScenarioInfo(string runtimeId,INameInfo name, string[] labels, string[] categories)
        {
            RuntimeId = runtimeId;
            Name = name;
            Labels = labels;
            Categories = categories;
        }

        public string RuntimeId { get; }
        public INameInfo Name { get; }
        public IEnumerable<string> Labels { get; }
        public IEnumerable<string> Categories { get; }

        public override string ToString()
        {
            return Labels.Any()
                ? $"[{string.Join("][", Labels)}] {Name}"
                : Name.ToString();
        }
    }
}