using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MathemathicalLinguisticsTask1
{
    public class ParkingMeter : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private State _currentState;
        public State CurrentState
        {
            get { return _currentState; }
            set
            {
                _currentState = value;
                if (_currentState == UnacceptableState)
                    ReturnCoins();
                else if (_currentState == AcceptState)
                    PrintTicket();

                DisplayText = _currentState.DisplayText;
                CurrentStateName = _currentState.Name;
            }
        }

        public IList<State> States { get; private set; }
        public State BeginState { get; private set; }
        public State UnacceptableState { get; private set; }
        public State AcceptState { get; set; }

        private bool _restNotTaken;
        public bool RestNotTaken
        {
            get { return _restNotTaken; }
            set
            {
                SetField(ref _restNotTaken, value);
            }
        }

        private bool _isFeePaid;
        public bool IsFeePaid
        {
            get { return _isFeePaid; }
            set
            {
                SetField(ref _isFeePaid, value);
            }
        }

        private string _displayText;
        public string DisplayText
        {
            get { return _displayText; }
            set
            {
                SetField(ref _displayText, value);
            }
        }

        private string _currentStateName;
        public string CurrentStateName
        {
            get { return _currentStateName; }
            set
            {
                SetField(ref _currentStateName, value);
            }
        }

        public ParkingMeter()
        {
            States = new List<State>()
            {
                new State("Q0","0.00"),
                new State("Q1","1.00"),
                new State("Q2","2.00"),
                new State("Q3","3.00"),
                new State("Q4","4.00"),
                new State("Q5","5.00"),
                new State("Q6","6.00"),
                new State("Q7","7.00"),
                new State("Q8","Error"),
            };

            InitializeStateTransferLogic();

            BeginState = States.Single(s => s.Name.Equals("Q0"));
            UnacceptableState = States.Single(s => s.Name.Equals("Q8"));
            AcceptState = States.Single(s => s.Name.Equals("Q7"));
            CurrentState = BeginState;
        }

        private void InitializeStateTransferLogic()
        {
            States.Single(s => s.Name.Equals("Q0")).FollowingStates = new Dictionary<double, State>()
            {
                {1, States.Single(s => s.Name.Equals("Q1"))},
                {2, States.Single(s => s.Name.Equals("Q2"))},
                {5, States.Single(s => s.Name.Equals("Q5"))}
            };
            States.Single(s => s.Name.Equals("Q1")).FollowingStates = new Dictionary<double, State>()
            {
                {1, States.Single(s => s.Name.Equals("Q2"))},
                {2, States.Single(s => s.Name.Equals("Q3"))},
                {5, States.Single(s => s.Name.Equals("Q6"))}
            };
            States.Single(s => s.Name.Equals("Q2")).FollowingStates = new Dictionary<double, State>()
            {
                {1, States.Single(s => s.Name.Equals("Q3"))},
                {2, States.Single(s => s.Name.Equals("Q4"))},
                {5, States.Single(s => s.Name.Equals("Q7"))}
            };
            States.Single(s => s.Name.Equals("Q3")).FollowingStates = new Dictionary<double, State>()
            {
                {1, States.Single(s => s.Name.Equals("Q4"))},
                {2, States.Single(s => s.Name.Equals("Q5"))}
            };
            States.Single(s => s.Name.Equals("Q4")).FollowingStates = new Dictionary<double, State>()
            {
                {1, States.Single(s => s.Name.Equals("Q5"))},
                {2, States.Single(s => s.Name.Equals("Q6"))}
            };
            States.Single(s => s.Name.Equals("Q5")).FollowingStates = new Dictionary<double, State>()
            {
                {1, States.Single(s => s.Name.Equals("Q6"))},
                {2, States.Single(s => s.Name.Equals("Q7"))}
            };
            States.Single(s => s.Name.Equals("Q6")).FollowingStates = new Dictionary<double, State>()
            {
                {1, States.Single(s => s.Name.Equals("Q7"))}
            };
            States.Single(s => s.Name.Equals("Q7")).FollowingStates = new Dictionary<double, State>();
            States.Single(s => s.Name.Equals("Q8")).FollowingStates = new Dictionary<double, State>();
        }

        public void InsertCoin(double value)
        {
            SwitchState(value);
        }

        private void SwitchState(double value)
        {
            try
            {
                CurrentState = CurrentState.GetNextState(value);
            }
            catch (KeyNotFoundException)
            {
                CurrentState = UnacceptableState;
            }
        }

        private void ReturnCoins()
        {
            //Returns Coins to the user.
            RestNotTaken = true;
        }

        private void PrintTicket()
        {
            //Print valid parking ticket.
            IsFeePaid = true;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value,[CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
