using System.Collections.Generic;
using Microsoft.Extensions.Options;
using NeuralNetworks.Examples.FraudDetection.Services.Configuration;
using NeuralNetworks.Library.Data;

namespace NeuralNetworks.Examples.FraudDetection.Services.Domain
{
    public class TrainingDataProvider 
    {
        public List<TrainingDataSet> TrainingData { get; }

        private readonly DataSourceConfiguration dataSource;

        public TrainingDataProvider(IOptions<DataSourceConfiguration> dataSource)
        {
            this.dataSource = dataSource.Value;
        }
    }
}