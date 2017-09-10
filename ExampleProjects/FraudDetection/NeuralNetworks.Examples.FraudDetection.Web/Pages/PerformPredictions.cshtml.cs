using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeuralNetworks.Examples.FraudDetection.Services;
using NeuralNetworks.Examples.FraudDetection.Services.Application;

namespace NeuralNetworks.Examples.FraudDetection.Web.Pages
{
    public class PerformPredictionsModel : PageModel
    {
        private readonly NeuralNetworkPredictionService networkPredictionService; 

        public PerformPredictionsModel(NeuralNetworkPredictionService networkPredictionService)
        {
            this.networkPredictionService = networkPredictionService; 
        }

        public void OnPostPredict()
        {
             networkPredictionService.RunPredictions();
        }
    }
}