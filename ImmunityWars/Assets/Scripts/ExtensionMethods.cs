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
    }
}