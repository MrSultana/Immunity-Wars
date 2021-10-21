using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    public static List<Vector3> currentPositions = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++) {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
