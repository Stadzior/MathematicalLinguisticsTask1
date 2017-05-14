using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathemathicalLinguisticsTask1
{
    public class State
    {
        public string Name { get; private set; }
        public string DisplayText { get; private set; }
        public Dictionary<double, State> FollowingStates { get; set; }

        public State(string name, string displayText = "")
        {
            Name = name;
            DisplayText = displayText;
        }

        public State GetNextState(double value)
            => FollowingStates[value];
    }
}
