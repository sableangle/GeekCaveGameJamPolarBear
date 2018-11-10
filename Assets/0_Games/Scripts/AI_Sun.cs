using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Sun : MonoBehaviour
{

    private float rayDistance = 100000.0f;
    private Ray ray;
    static public string x;
    static public string y;
    public ObjectPool numberPool;

    public Camera camera;
    void Start()
    {
        camera = Camera.main;
    }

    // // Update is called once per frame
    // void Update()
    // {
    //     mouseRay();
	// 	Debug.Log(x);
    //     switch (x)
    //     {
    //         case "Sun":
	// 			var temp = numberPool.ReUse(transform.position,transform.rotation);
	// 			numberPool.Recovery(temp,0.4f);
    //             break;
    //     }
	// 	x = "";
    // }

    // void mouseRay()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         ray = camera.ScreenPointToRay(Input.mousePosition);
    //         RaycastHit hit;
    //         if (Physics.Raycast(ray, out hit, rayDistance))
    //         {
    //             y = hit.collider.name;
    //         }
    //     }
    //     if (Input.GetMouseButtonUp(0))
    //     {
    //         ray = camera.ScreenPointToRay(Input.mousePosition);
    //         RaycastHit hit;
    //         if (Physics.Raycast(ray, out hit, rayDistance))
    //         {
    //             x = hit.collider.name;
    //         }
    //     }
    // }

}
