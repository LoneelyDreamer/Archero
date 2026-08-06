using System.Text;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

namespace Assets._Progect.Develop.Ediror
{
    public class UnityLayersGenerator
    {
        private const string OutputPath = "Assets/_Progect/Develop/Runtime/UI/Generated/UnityLayers.cs";

        [MenuItem("Tools/Generate Unity Layers")]
        public static void Generate()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using UnityEngine;");
            sb.AppendLine();
            sb.AppendLine("public static class UnityLayers");
            sb.AppendLine("{");

            // Сначала собираем все существующие слои
            var layerNames = new Dictionary<int, string>();
            for (int i = 0; i < 32; i++)
            {
                string name = LayerMask.LayerToName(i);
                if (!string.IsNullOrEmpty(name))
                {
                    layerNames[i] = name;
                }
            }

            // Генерируем поля для идентификаторов слоёв
            foreach (var pair in layerNames)
            {
                string varName = "Layer" + ToPascalCase(pair.Value);
                sb.AppendLine($"    public static readonly int {varName} = LayerMask.NameToLayer(\"{pair.Value}\");");
            }

            sb.AppendLine();

            // Генерируем поля для масок слоёв
            foreach (var pair in layerNames)
            {
                string layerVar = "Layer" + ToPascalCase(pair.Value);
                string maskVar = "LayerMask" + ToPascalCase(pair.Value);
                sb.AppendLine($"    public static readonly int {maskVar} = 1 << {layerVar};");
            }

            sb.AppendLine("}");

            // Запись файла
            string fullPath = Path.GetFullPath(OutputPath);
            string directory = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            File.WriteAllText(fullPath, sb.ToString(), new UTF8Encoding(false));
            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();

            Debug.Log($"UnityLayers generated at {OutputPath}");
        }

        /// <summary>
        /// Преобразует имя слоя (может содержать пробелы) в PascalCase без пробелов.
        /// Пример: "Ignore Raycast" -> "IgnoreRaycast"
        /// </summary>
        private static string ToPascalCase(string layerName)
        {
            if (string.IsNullOrEmpty(layerName))
                return layerName;

            // Разбиваем по пробелам и другим разделителям, приводим каждую часть к PascalCase
            string[] parts = layerName.Split(new char[] { ' ', '\t', '_', '-' }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].Length > 0)
                {
                    parts[i] = char.ToUpperInvariant(parts[i][0]) + parts[i].Substring(1).ToLowerInvariant();
                }
            }
            return string.Join("", parts);
        }
    }
}


