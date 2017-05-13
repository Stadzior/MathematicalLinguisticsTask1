using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathemathicalLinguisticsTask1
{
    public class ParkingMeter
    {
        private State _currentState;
        public State CurrentState
        {
            get { return _currentState; }
            set
            {
                _currentState = value;
                if(_currentState.Name.Equals("QUnacceptable"))
                {
                    ReturnCoins();
                    SwitchState("Q0");
                }
                else if (_currentState.Name.Equals("Q7"))
                {
                    PrintTicket();
                    SwitchState("Q0");
                }
            }
        }

        public IList<State> States { get; private set; }
        public double InsertedValue { get; private set; }
        public ParkingMeter()
        {
            States = new List<State>()
            {
                new State("Q0"),
                new State("Q1"),
                new State("Q2"),
                new State("Q3"),
                new State("Q4"),
                new State("Q5"),
                new State("Q6"),
                new State("Q7"),
                new State("QUnacceptable"),
            };

            SwitchState("Q0");
        }
        public void InsertCoin(double value)
        {
            InsertedValue += value;
            switch (InsertedValue)
            {
                case 1:
                    SwitchState("Q1");
                    break;
                case 2:
                    SwitchState("Q2");
                    break;
                case 3:
                    SwitchState("Q3");
                    break;
                case 4:
                    SwitchState("Q4");
                    break;
                case 5:
                    SwitchState("Q5");
                    break;
                case 6:
                    SwitchState("Q6");
                    break;
                case 7:
                    SwitchState("Q7");
                    break;
                default:
                    SwitchState("QUnacceptable");
                    break;
            }
        }

        private void SwitchState(string targetStateName)
        {
            try
            {
                CurrentState = States.Single(s => s.Name.Equals(targetStateName));
            }
            catch (Exception)
            {
                CurrentState = States.Single(s => s.Name.Equals("QUnacceptable"));
            }
        }

        private void ReturnCoins()
        {
            //Returns Coins to the user.
            InsertedValue = 0;
        }

        private void PrintTicket()
        {
            //Print valid parking ticket.
            InsertedValue = 0;
        }
    }
}
