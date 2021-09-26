using UnityEngine;

namespace Interaction {

    internal static class ExtensionMethods {
        // Most this code based off this: https://answers.unity.com/questions/589983/using-mathfround-for-a-vector3.html
        public static Vector3 RoundVector3(this Vector3 vector3, float yPosition, int decimalPlaces = 1) {
            /*float multiplier = 1;

            for (int i = 0; i < decimalPlaces; i++) {
                multiplier *= 10f;
            }*/

            return new Vector3(
                Mathf.Round(vector3.x),
                vector3.y = yPosition, // My own code
                Mathf.Round(vector3.z));
        }

        public static bool FindDifferenceBetweenVector3(Vector3 vector1, Vector3 vector2) {
            int allowedDifference = 15;

            var dX = vector1.x - vector2.x;
            var dZ = vector1.z - vector2.z;

            if (dX > allowedDifference || dX < allowedDifference) {
                return false;
            } 
            else if (dZ > allowedDifference || dZ < allowedDifference) {
                return false;
            }
            else {
                return true;
            }
        }
    }
}