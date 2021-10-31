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
            float dX = 0;
            float dZ = 0;

            // Finding the difference between x values of the two vectors
            if (vector1.x > vector2.x) {
                if (vector2.x < 0 && vector1.x > 0) { // If vector 2 is negative and vector 1 is positive
                    dX = vector1.x - vector2.x;
                }
                else if (vector2.x < 0 && vector1.x < 0) { // If both vector 1 and 2 are negative
                    dX = vector1.x - vector2.x;
                }
                else if (vector2.x == 0) {
                    dX = vector1.x;
                }
            }
            else if (vector1.x < vector2.x) {
                if (vector1.x < 0 && vector2.x > 0) { // If vector 1 is negative and vector 2 is positive
                    dX = vector2.x - vector1.x;
                }
                else if (vector1.x < 0 && vector2.x < 0) { // If both vector 1 and 2 are negative
                    dX = vector2.x - vector1.x;
                }
                else if (vector1.x == 0) {
                    dX = vector2.x;
                }
            }

            // Finding difference between z values of the two vectors
            if (vector1.z > vector2.z) {
                if (vector2.z < 0 && vector1.z > 0) { // If vector 2 is negative and vector 1 is positive
                    dZ = vector1.z - vector2.z;
                }
                else if (vector2.z < 0 && vector1.z < 0) { // If both vector 1 and 2 are negative
                    dZ = vector1.z - vector2.z;
                }
                else if (vector2.z == 0) {
                    dZ = vector1.z;
                }
            }
            else if (vector1.z < vector2.z) {
                if (vector1.z < 0 && vector2.z > 0) { // If vector 1 is negative and vector 2 is positive
                    dZ = vector2.z - vector1.z;
                }
                else if (vector1.x < 0 && vector2.x < 0) { // If both vector 1 and 2 are negative
                    dZ = vector2.z - vector1.z;
                }
                else if (vector1.z == 0) {
                    dZ = vector2.z;
                }
            }


            if (dX > allowedDifference) {
                return false;
            }
            else if (dZ > allowedDifference) {
                return false;
            }
            else {
                return true;
            }
        }
        public static bool AccountingForPlayerEnemyDistance(Vector3 vector1, Vector3 vector2) {
            int allowedDifference = 5;
            float dX = 0;
            float dZ = 0;

            // Finding the difference between x values of the two vectors
            if (vector1.x > vector2.x) {
                if (vector2.x < 0 && vector1.x > 0) { // If vector 2 is negative and vector 1 is positive
                    dX = vector1.x - vector2.x;
                }
                else if (vector2.x < 0 && vector1.x < 0) { // If both vector 1 and 2 are negative
                    dX = vector1.x - vector2.x;
                }
                else if (vector2.x == 0) {
                    dX = vector1.x;
                }
            }
            else if (vector1.x < vector2.x) {
                if (vector1.x < 0 && vector2.x > 0) { // If vector 1 is negative and vector 2 is positive
                    dX = vector2.x - vector1.x;
                }
                else if (vector1.x < 0 && vector2.x < 0) { // If both vector 1 and 2 are negative
                    dX = vector2.x - vector1.x;
                }
                else if (vector1.x == 0) {
                    dX = vector2.x;
                }
            }

            // Finding difference between z values of the two vectors
            if (vector1.z > vector2.z) {
                if (vector2.z < 0 && vector1.z > 0) { // If vector 2 is negative and vector 1 is positive
                    dZ = vector1.z - vector2.z;
                }
                else if (vector2.z < 0 && vector1.z < 0) { // If both vector 1 and 2 are negative
                    dZ = vector1.z - vector2.z;
                }
                else if (vector2.z == 0) {
                    dZ = vector1.z;
                }
            }
            else if (vector1.z < vector2.z) {
                if (vector1.z < 0 && vector2.z > 0) { // If vector 1 is negative and vector 2 is positive
                    dZ = vector2.z - vector1.z;
                }
                else if (vector1.x < 0 && vector2.x < 0) { // If both vector 1 and 2 are negative
                    dZ = vector2.z - vector1.z;
                }
                else if (vector1.z == 0) {
                    dZ = vector2.z;
                }
            }


            if (dX > allowedDifference) {
                return false;
            }
            else if (dZ > allowedDifference) {
                return false;
            }
            else {
                return true;
            }
        }
    }
}