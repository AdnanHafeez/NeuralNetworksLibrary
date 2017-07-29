﻿using System.Linq;
using NeuralNetworks.Library.Components;

namespace NeuralNetworks.Library.Training.BackPropagation
{
    public sealed class NeuronErrorGradientCalculator
    {
        private NeuronErrorGradientCalculator()
        {}

        public void SetNeuronErrorGradient(Neuron neuron, double target)
        {
			neuron.ErrorRate = CalculateErrorForOutputAgainstTarget(neuron, target) *
							   neuron.ActivationFunction.Derivative(neuron.LatestFedValueFromInputSynapses);
        }

        public void SetNeuronErrorGradient(Neuron neuron)
        {
			neuron.ErrorRate = neuron.OutputSynapses.Sum(a => a.OutputNeuron.ErrorRate * a.Weight) *
							   neuron.ActivationFunction.Derivative(neuron.LatestFedValueFromInputSynapses);
        }

        public double CalculateErrorForOutputAgainstTarget(Neuron neuron, double target)
            => target - neuron.Output;

        public static NeuronErrorGradientCalculator Create()
            => new NeuronErrorGradientCalculator();
    }
}