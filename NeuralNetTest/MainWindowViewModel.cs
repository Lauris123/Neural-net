using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NeuralNetTest
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private List<InputNeuron> _inputValues;
        public List<InputNeuron> InputValues
        {
            get
            {
                return this._inputValues;
            }
            set
            {
                this._inputValues = value;

                PropertyChanged(null, new PropertyChangedEventArgs("InputValues"));
            }
        }

        private ICommand _goCommand;
        public ICommand GoCommand
        {
            get
            {
                return this._goCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            this._inputValues = new List<InputNeuron>() {
                new InputNeuron(1),
                new InputNeuron(0.6),
                new InputNeuron(0.2),
                new InputNeuron(0.95),
                new InputNeuron(0.16),
                new InputNeuron(0.7)
            };

            this._goCommand = new GoCommand(GoCommand_Executed);
            
        }

        private void GoCommand_Executed()
        {
            Neuron n1 = new InputNeuron(this.InputValues[0].InputValue);
            Neuron n2 = new InputNeuron(this.InputValues[1].InputValue);
            Neuron n3 = new InputNeuron(this.InputValues[2].InputValue);
            Neuron n4 = new InputNeuron(this.InputValues[3].InputValue);
            Neuron n5 = new InputNeuron(this.InputValues[4].InputValue);
            Neuron n6 = new InputNeuron(this.InputValues[5].InputValue);

            Neuron m1 = new Neuron();
            Neuron m2 = new Neuron();
            Neuron m3 = new Neuron();
            Neuron m4 = new Neuron();

            Neuron o1 = new Neuron();
            Neuron o2 = new Neuron();

            Neuron r1 = new Neuron();

            NeuronConnection n1m1 = new NeuronConnection(n1);
            NeuronConnection n1m2 = new NeuronConnection(n1);
            NeuronConnection n1m3 = new NeuronConnection(n1);
            NeuronConnection n1m4 = new NeuronConnection(n1);

            NeuronConnection n2m1 = new NeuronConnection(n2);
            NeuronConnection n2m2 = new NeuronConnection(n2);
            NeuronConnection n2m3 = new NeuronConnection(n2);
            NeuronConnection n2m4 = new NeuronConnection(n2);

            NeuronConnection n3m1 = new NeuronConnection(n3);
            NeuronConnection n3m2 = new NeuronConnection(n3);
            NeuronConnection n3m3 = new NeuronConnection(n3);
            NeuronConnection n3m4 = new NeuronConnection(n3);

            NeuronConnection n4m1 = new NeuronConnection(n4);
            NeuronConnection n4m2 = new NeuronConnection(n4);
            NeuronConnection n4m3 = new NeuronConnection(n4);
            NeuronConnection n4m4 = new NeuronConnection(n4);

            NeuronConnection n5m1 = new NeuronConnection(n5);
            NeuronConnection n5m2 = new NeuronConnection(n5);
            NeuronConnection n5m3 = new NeuronConnection(n5);
            NeuronConnection n5m4 = new NeuronConnection(n5);

            NeuronConnection n6m1 = new NeuronConnection(n6);
            NeuronConnection n6m2 = new NeuronConnection(n6);
            NeuronConnection n6m3 = new NeuronConnection(n6);
            NeuronConnection n6m4 = new NeuronConnection(n6);

            NeuronConnection m1o1 = new NeuronConnection(m1);
            NeuronConnection m2o1 = new NeuronConnection(m2);
            NeuronConnection m3o1 = new NeuronConnection(m3);
            NeuronConnection m4o1 = new NeuronConnection(m4);

            NeuronConnection m1o2 = new NeuronConnection(m1);
            NeuronConnection m2o2 = new NeuronConnection(m2);
            NeuronConnection m3o2 = new NeuronConnection(m3);
            NeuronConnection m4o2 = new NeuronConnection(m4);

            NeuronConnection o2r1 = new NeuronConnection(o2);
            NeuronConnection o1r1 = new NeuronConnection(o1);

            n6m1.NeuronWeight = 0.7;
            n3m2.NeuronWeight = 0;
            r1.neuronDendrons = new List<NeuronConnection>()
            {
                o1r1,
                o2r1
            };

            o2.neuronDendrons = new List<NeuronConnection>() 
            {
                m1o2,
                m2o2,
                m3o2,
                m4o2
            };

            o1.neuronDendrons = new List<NeuronConnection>()
            {
                m1o1,
                m2o1,
                m3o1,
                m4o1
            };

            m1.neuronDendrons = new List<NeuronConnection>()
            {
                n1m1,
                n2m1,
                n3m1,
                n4m1,
                n5m1,
                n6m1
            };

            m2.neuronDendrons = new List<NeuronConnection>()
            {
                n1m2,
                n2m2,
                n3m2,
                n4m2,
                n5m2,
                n6m2
            };

            m3.neuronDendrons = new List<NeuronConnection>()
            {
                n1m3,
                n2m3,
                n3m3,
                n4m3,
                n5m3,
                n6m3
            };

            m4.neuronDendrons = new List<NeuronConnection>() 
            {
                n1m4,
                n2m4,
                n3m4,
                n4m4,
                n5m4,
                n6m4
            };

            string r1Result = r1.ComputeNeuronCharge().ToString();

            
            MessageBox.Show(r1Result);


            
 
        }

    }

    public class GoCommand : ICommand
    {

        public bool CanExecute(object parameter)
        {
            return true;
        }

        // neizmantojam
        public event EventHandler CanExecuteChanged;

        Action _goCommandFunction;

        public GoCommand(Action goCommandFunction)
        {
            this._goCommandFunction = goCommandFunction;
        }

        public void Execute(object parameter)
        {
            this._goCommandFunction();
        }
    }

    public class InputNeuron:Neuron
    {
        public double InputValue
        {
            get;
            set;
        }

        public InputNeuron(double value)
        {
            this.InputValue = value;
        }

        public override double ComputeNeuronCharge()
        {
            return InputValue;
        }
    }
    public class Neuron
    {
        public List<NeuronConnection> neuronDendrons;
        
        public virtual double ComputeNeuronCharge()
        {
            double sum = 0;
            foreach (NeuronConnection neuronConnection in neuronDendrons)
            {
              sum+= neuronConnection.startNeuron.ComputeNeuronCharge() * neuronConnection.NeuronWeight;
            }
            // Par katru savienojumo no ienākošajiem neironiem
            // (Savienojms.OtraGalaNeirons.Izrēķināto vērtību * Savienojums.Svars)
            // atgreižu summu

            return sum;
        }
    }
    public class NeuronConnection
    {
        


        public NeuronConnection(Neuron startNeuron)
        {
            this.startNeuron = startNeuron;
        }

        private double _neuronWeight = 1;
        public double NeuronWeight
        {
            get { return _neuronWeight; }
            set { _neuronWeight = value; }
        }
        

      public  Neuron startNeuron
        {
            get;
            set;
        }
    }
}
