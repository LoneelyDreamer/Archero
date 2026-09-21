using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Assets._Progect.Develop.Ediror
{
    public class EntityAPIGenerator
    {
        private const string AssemblyName = "Assembly-CSharp";
        private static string OutputPath
            => Path.Combine(Application.dataPath, "_Progect/Develop/Runtime/Gameplay/EntitiesCore/Generated/EntityAPI.cs");

        [InitializeOnLoadMethod]
        [MenuItem("Tools/GenerateEntityAPI")]
        private static void Generate()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                // Добавляем все необходимые using директивы
                sb.AppendLine("using UnityEngine;");
                sb.AppendLine("using Assets._Progect.Develop.Runtime.Utillitles;");
                sb.AppendLine("using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;");
                sb.AppendLine("using Assets._Progect.Develop.Runtime.Utillitles.Conditions;");
                sb.AppendLine("using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory;");
                sb.AppendLine("using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MainHero;");
                sb.AppendLine("using System.Collections.Generic;");
                sb.AppendLine();

                sb.AppendLine($"namespace {typeof(Entity).Namespace}");
                sb.AppendLine("{");
                sb.AppendLine($"\tpublic partial class {typeof(Entity).Name}");
                sb.AppendLine("\t{");

                Assembly assembly = Assembly.Load(AssemblyName);
                IEnumerable<Type> componetsTypes = GetComponentsTypeFrom(assembly);

                foreach (Type componetsType in componetsTypes)
                {
                    string typeName = componetsType.Name;
                    string fullTypeName = componetsType.FullName;
                    string componentName = RemoveSuffixIsExists(typeName, "Component");
                    string modifiedComponentName = componentName + "C";

                    sb.AppendLine($"\t\tpublic {fullTypeName} {modifiedComponentName} => GetComponent<{fullTypeName}>();");
                    sb.AppendLine();

                    if (HasSinglField(componetsType, out FieldInfo field) && field.Name == "Value")
                    {
                        sb.AppendLine($"\t\tpublic {GetValidTypeName(field.FieldType)} {componentName} => {modifiedComponentName}.{field.Name};");
                        sb.AppendLine();

                        string simpleTypeName = GetSimpleTypeName(field.FieldType);
                        string paramName = GetVariableNameFrom(field.Name);

                        sb.AppendLine($"\t\tpublic bool TryGet{componentName}(out {simpleTypeName} {paramName})");
                        sb.AppendLine("\t\t{");
                        sb.AppendLine($"\t\t\tbool result = TryGetComponent(out {fullTypeName} component);");
                        sb.AppendLine($"\t\t\tif (result)");
                        sb.AppendLine($"\t\t\t\t{paramName} = component.{field.Name};");
                        sb.AppendLine($"\t\t\telse");
                        sb.AppendLine($"\t\t\t\t{paramName} = default({simpleTypeName});");
                        sb.AppendLine($"\t\t\treturn result;");
                        sb.AppendLine("\t\t}");
                        sb.AppendLine();

                        if (HasEmptyConstructor(field.FieldType))
                        {
                            sb.AppendLine($"\t\tpublic {typeof(Entity).FullName} Add{componentName}()");
                            sb.AppendLine("\t\t{");
                            sb.AppendLine($"\t\t\treturn AddComponent(new {fullTypeName}() {{ {field.Name} = new {GetValidTypeName(field.FieldType)}() }});");
                            sb.AppendLine("\t\t}");
                            sb.AppendLine();
                        }
                    }

                    string componentParametrs = GetParametrs(componetsType);
                    if (!string.IsNullOrEmpty(componentParametrs))
                    {
                        sb.AppendLine($"\t\tpublic {typeof(Entity).FullName} Add{componentName}({componentParametrs})");
                        sb.AppendLine("\t\t{");
                        sb.AppendLine($"\t\t\treturn AddComponent(new {fullTypeName}() {GetInitializer(componetsType)});");
                        sb.AppendLine("\t\t}");
                        sb.AppendLine();
                    }

                    if (string.IsNullOrEmpty(componentParametrs) && HasEmptyConstructor(componetsType))
                    {
                        sb.AppendLine($"\t\tpublic {typeof(Entity).FullName} Add{componentName}()");
                        sb.AppendLine("\t\t{");
                        sb.AppendLine($"\t\t\treturn AddComponent(new {fullTypeName}());");
                        sb.AppendLine("\t\t}");
                        sb.AppendLine();
                    }
                }

                sb.AppendLine("\t}");
                sb.AppendLine("}");

                string directory = Path.GetDirectoryName(OutputPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.WriteAllText(OutputPath, sb.ToString(), new UTF8Encoding(false));

                System.Threading.Thread.Sleep(100);

                AssetDatabase.Refresh();
                AssetDatabase.SaveAssets();

                Debug.Log($"EntityAPI successfully generated at: {OutputPath}");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error generating EntityAPI: {ex.Message}\n{ex.StackTrace}");
            }
        }

        // ... остальные методы остаются без изменений ...

        private static bool HasEmptyConstructor(Type type)
        {
            return type.GetConstructor(Type.EmptyTypes) != null
                   && !type.IsSubclassOf(typeof(UnityEngine.Object));
        }

        private static string GetInitializer(Type type)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            if (fields.Length == 0)
                return "{ }";

            var initializer = fields.Select(field => $"{field.Name} = {GetVariableNameFrom(field.Name)}");
            return "{ " + string.Join(", ", initializer) + " }";
        }

        private static string GetParametrs(Type type)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            if (fields.Length == 0)
                return "";

            var parametrs = fields.Select(field => $"{GetValidTypeName(field.FieldType)} {GetVariableNameFrom(field.Name)}");
            return string.Join(", ", parametrs);
        }

        private static string RemoveSuffixIsExists(string str, string suffix)
        {
            return str.EndsWith(suffix) ? str.Substring(0, str.Length - suffix.Length) : str;
        }

        private static string GetVariableNameFrom(string name)
            => char.ToLowerInvariant(name[0]) + name.Substring(1);

        private static bool HasSinglField(Type type, out FieldInfo field)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            if (fields.Length != 1)
            {
                field = null;
                return false;
            }
            field = fields[0];
            return true;
        }

        private static IEnumerable<Type> GetComponentsTypeFrom(Assembly assembly)
        {
            return assembly.GetTypes()
                .Where(type => !type.IsInterface
                               && !type.IsAbstract
                               && typeof(IEntityComponent).IsAssignableFrom(type));
        }

        public static string GetValidTypeName(Type type)
        {
            if (type.IsGenericType)
            {
                var sb = new StringBuilder();
                string fullTypeName = type.FullName;
                int backtickIndex = fullTypeName.IndexOf('`');
                if (backtickIndex >= 0)
                    fullTypeName = fullTypeName.Substring(0, backtickIndex);

                sb.Append(fullTypeName);
                sb.Append("<");

                var genericArgs = type.GetGenericArguments();
                for (int i = 0; i < genericArgs.Length; i++)
                {
                    if (i > 0) sb.Append(", ");
                    sb.Append(GetValidTypeName(genericArgs[i]));
                }
                sb.Append(">");

                return "global::" + sb.ToString();
            }
            else
            {
                return "global::" + type.FullName;
            }
        }

        public static string GetSimpleTypeName(Type type)
        {
            if (type.IsGenericType)
            {
                var sb = new StringBuilder();
                string typeName = type.Name;
                int backtickIndex = typeName.IndexOf('`');
                if (backtickIndex >= 0)
                    typeName = typeName.Substring(0, backtickIndex);

                sb.Append(typeName);
                sb.Append("<");

                var genericArgs = type.GetGenericArguments();
                for (int i = 0; i < genericArgs.Length; i++)
                {
                    if (i > 0) sb.Append(", ");
                    sb.Append(GetSimpleTypeName(genericArgs[i]));
                }
                sb.Append(">");

                return sb.ToString();
            }
            else
            {
                // C# aliases
                if (type == typeof(bool)) return "bool";
                if (type == typeof(byte)) return "byte";
                if (type == typeof(sbyte)) return "sbyte";
                if (type == typeof(char)) return "char";
                if (type == typeof(decimal)) return "decimal";
                if (type == typeof(double)) return "double";
                if (type == typeof(float)) return "float";
                if (type == typeof(int)) return "int";
                if (type == typeof(uint)) return "uint";
                if (type == typeof(long)) return "long";
                if (type == typeof(ulong)) return "ulong";
                if (type == typeof(object)) return "object";
                if (type == typeof(short)) return "short";
                if (type == typeof(ushort)) return "ushort";
                if (type == typeof(string)) return "string";

                return type.Name;
            }
        }
    }
}