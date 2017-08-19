﻿using System;
using System.Linq;
using NeuralNetworks.Library.Data;
using NeuralNetworks.Library.Extensions;
using NeuralNetworks.Library.Components;
using System.Threading.Tasks;

namespace NeuralNetworks.Library.Training.BackPropagation
{
    public sealed class BackPropagation : NeuralNetworkTrainer
    {
        private readonly NeuralNetwork neuralNetwork;
		private readonly NeuronErrorGradientCalculator neuronErrorGradientCalculator;
		private readonly SynapseWeightCalculator synapseWeightCalculator;
        private readonly ParallelOptions parallelOptions; 

        private BackPropagation(
            NeuralNetwork neuralNetwork, 
            NeuronErrorGradientCalculator neuronErrorGradientCalculator, 
            SynapseWeightCalculator synapseWeightCalculator,
            ParallelOptions parallelOptions)
            : base(neuralNetwork)
        {
            this.neuralNetwork = neuralNetwork;
            this.neuronErrorGradientCalculator = neuronErrorGradientCalculator;
            this.synapseWeightCalculator = synapseWeightCalculator; 
            this.parallelOptions = parallelOptions; 
        }

        public override double PerformSingleEpochProducingErrorRate(TrainingDataSet trainingDataSet)
        {
            neuralNetwork.PredictionFor(trainingDataSet.Inputs);
            return BackPropagate(trainingDataSet.Outputs);
        }

        private double BackPropagate(params double[] targets)
        {
            SetNeuronErrorGradients(targets);
            PropagateResultOfNeuronErrors();
            return CalculateError(targets);
        }

        private void SetNeuronErrorGradients(double[] targets)
        {
            neuralNetwork.OutputLayer.Neurons
                         .ParallelForEach((neuron, i) => 
                            neuronErrorGradientCalculator.SetNeuronErrorGradient(neuron, targets[i]),
                            parallelOptions);

            neuralNetwork.HiddenLayers
                         .ApplyInReverse(layer => 
                            layer.Neurons.ParallelForEach(
                                neuron => neuronErrorGradientCalculator.SetNeuronErrorGradient(neuron),
                                parallelOptions)
                         ); 
        }

        private void PropagateResultOfNeuronErrors()
        {
            neuralNetwork.OutputLayer.Neurons
                .Where(NeuronNotProducingCorrectResult)
                .ParallelForEach(
                    neuron => synapseWeightCalculator.CalculateAndUpdateInputSynapseWeights(neuron, parallelOptions),
                    parallelOptions);

            neuralNetwork.HiddenLayers
                .ParallelForEach(layer =>
                    layer.Neurons
                        .Where(NeuronNotProducingCorrectResult)
                        .ParallelForEach(
                            neuron => synapseWeightCalculator.CalculateAndUpdateInputSynapseWeights(neuron, parallelOptions),
                            parallelOptions),
                    parallelOptions);
        }

        private bool NeuronNotProducingCorrectResult(Neuron neuron)
            => neuron.ErrorGradient != 0; 

        private double CalculateError(params double[] targets)
        {
            var i = 0;
            return neuralNetwork.OutputLayer.Neurons.Sum(
                neuron => Math.Abs(
                    neuronErrorGradientCalculator.CalculateErrorForOutputAgainstTarget(neuron, targets[i++])));
        }

        public static BackPropagation WithSingleThreadedConfiguration(
            NeuralNetwork network, 
            double learningRate = 1, 
            double momentum = 0)
        {
            var singleThreadedOptions = new ParallelOptions{
                MaxDegreeOfParallelism = 1
            }; 

            return BackPropagation.WithMultiThreadedConfiguration(
                network, 
                singleThreadedOptions, 
                learningRate, 
                momentum); 
        }

        public static BackPropagation WithMultiThreadedConfiguration(
            NeuralNetwork network, 
            ParallelOptions parallelOptions,
            double learningRate = 1, 
            double momentum = 0)
        {
            return new BackPropagation(
                network,
                NeuronErrorGradientCalculator.Create(),
                SynapseWeightCalculator.For(learningRate, momentum),
                parallelOptions
            ); 
        }
    }
}