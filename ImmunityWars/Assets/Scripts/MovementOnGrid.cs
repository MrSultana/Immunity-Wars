using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOnGrid : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);// code taken from https://answers.unity.com/questions/1386777/get-origin-of-plane-in-world-coordinates.html
            var hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit)) {
                Debug.Log(hit.point);

                Instantiate(target, hit.point, target.rotation);
            }
            
        }

    }
}
