using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Tester : MonoBehaviour
{

    private Grid grid;
    private void Start()
    {
        Grid grid = new Grid(9, 2, 2f, new Vector3(-11, 0, 17));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), 56);
        }
    }
}
