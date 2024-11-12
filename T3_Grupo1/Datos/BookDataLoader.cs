using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using T3_Grupo1.Models;
using System.Linq;
using System;
using Microsoft.ML;

namespace T3_Grupo1.Datos
{
    public static class BookDataLoader
    {
        public static IDataView LoadData(string dataPath, MLContext mlContext)
        {
            // Cargar los datos en un IDataView
            var data = mlContext.Data.LoadFromTextFile<Book>(dataPath, separatorChar: ',', hasHeader: true);

            // Crear el pipeline de procesamiento
            var dataProcessPipeline = mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(Book.Title))  // Mapeamos la columna Title como la etiqueta (Label)
                .Append(mlContext.Transforms.Text.FeaturizeText("Features", nameof(Book.CombinedFeatures)))  // Transformamos el texto combinado en una columna Features
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedTitle", "PredictedLabel")); // Transformamos la etiqueta de predicción

            // Aplicar el pipeline a los datos
            var transformedData = dataProcessPipeline.Fit(data).Transform(data);

            return transformedData;
        }
    }
}
