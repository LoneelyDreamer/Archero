using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore;
using System.Linq;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;

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
            StringBuilder sb = new StringBuilder();

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

                    if(HasEmptyConstructor(field.FieldType))
                    {
                        string initializator = "{ " + field.Name + " = new " + GetValidTypeName(field.FieldType) + "() }";

                        sb.AppendLine($"\t\tpublic {typeof(Entity).FullName} Add{componentName}()");
                        sb.AppendLine("\t\t{");
                        sb.AppendLine($"\treturn AddComponent (new {fullTypeName}() {initializator}); ");
                        sb.AppendLine("\t\t}");
                        sb.AppendLine();
                    }
                }

                string componentParametrs = GetParametrs(componetsType);
                sb.AppendLine($"\t\tpublic {typeof(Entity).FullName} Add{componentName}({componentParametrs})");
                sb.AppendLine("\t\t{");
                sb.AppendLine($"\treturn AddComponent (new {fullTypeName}() {GetInitializer(componetsType)}); ");
                sb.AppendLine("\t\t}");
                sb.AppendLine();

            }

            sb.AppendLine("\t}");

            sb.AppendLine("}");

            File.WriteAllText(OutputPath, sb.ToString(), new UTF8Encoding(false));

            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }

        private static bool HasEmptyConstructor(Type type)
        {
            return
                type.GetConstructor(Type.EmptyTypes) != null
                && type.IsSubclassOf(typeof(UnityEngine.Object)) == false;
        }

        private static object GetInitializer(Type type)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            if (fields.Any() == false)
                return "";

            IEnumerable<string> initializer = fields
                .Select(field => $"{field.Name} = {GetVariableNameFrom(field.Name)}");

            return "{" + string.Join(", ", initializer) + "}";
        }

        private static string GetParametrs(Type type)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            if (fields.Any() == false)
                return "";

            IEnumerable<string> parametrs = fields
                .Select(field => $"{GetValidTypeName(field.FieldType)} {GetVariableNameFrom(field.Name)}");

            return string.Join(",", parametrs);
        }

       

        private static string RemoveSuffixIsExists(string str, string suffix) 
        {
            if(str.EndsWith(suffix))
            {
                return str.Substring(0, str.Length - suffix.Length);
            }

            return str;
        }

        private static object GetVariableNameFrom(string name) => char.ToLowerInvariant(name[0]) + name.Substring(1);
        
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
            return assembly
                .GetTypes()
                .Where(type => type.IsInterface == false
                    && type.IsAbstract == false
                    && typeof(IEntityComponent).IsAssignableFrom(type));
        }

        public static string GetValidTypeName(Type type)
        {
            if (type.IsGenericType)
            {
                StringBuilder sb = new StringBuilder();
                string fullTypeName = type.FullName;
                int backtickIndex = fullTypeName.IndexOf('`');

                if (backtickIndex >= 0)
                    fullTypeName = fullTypeName.Substring(0, backtickIndex);

                sb.Append(fullTypeName);
                sb.Append("<");

                Type[] genericArgs = type.GetGenericArguments();
                for (int i = 0; i < genericArgs.Length; i++)
                {
                    if (i > 0)
                        sb.Append(", ");
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
    }
}
