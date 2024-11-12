using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using T3_Grupo1.Datos;

namespace T3_Grupo1.Models
{
    public class RecommendationEngine
    {
        private readonly MLContext _mlContext;
        private readonly ITransformer _model;

        public RecommendationEngine(string dataPath)
        {
            _mlContext = new MLContext();
            var data = BookDataLoader.LoadData(dataPath, _mlContext);  // Cargamos y preprocesamos los datos
            _model = BuildAndTrainModel(data);  // Entrenamos el modelo
        }

        public ITransformer BuildAndTrainModel(IDataView trainingData)
        {
            // Crear el pipeline de entrenamiento
            var pipeline = _mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(Book.Title))
                .Append(_mlContext.Transforms.Text.FeaturizeText("Features", nameof(Book.CombinedFeatures)))
                .Append(_mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
                .Append(_mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel", "PredictedTitle"));

            // Entrenar el modelo
            var model = pipeline.Fit(trainingData);
            return model;
        }

        public BookPrediction PredictBookRecommendation(string inputTitle)
        {
            // Usamos el modelo para hacer la predicción basada en el título del libro
            var input = new Book { Title = inputTitle };  // El título que ingresa el usuario

            var predictionFunction = _mlContext.Model.CreatePredictionEngine<Book, BookPrediction>(_model);
            var prediction = predictionFunction.Predict(input);  // Predicción del libro recomendado

            return prediction;
        }
    }
}
