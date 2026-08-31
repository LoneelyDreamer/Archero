using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets._Progect.Develop.Runtime.Utillitles.MathfOperations
{
    public class MathfOpreartions
    {
        public static Vector3 GenerateRandomTeleportionPosition(Vector3 origin, float radius)
        {
            float angle = Random.Range(0f, Mathf.PI * 2);
            float r = Mathf.Sqrt(Random.Range(0f, 1f)) * radius;
            Vector3 offset = new Vector3(Mathf.Cos(angle) * r, 0, Mathf.Sin(angle) * r);
            Vector3 newPosition = origin + offset;

            return newPosition;
        }
    }
}
