using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public GameObject Bolinha;
    public GameObject Xis;
    Vector3 touchPosWorld;
    TouchPhase touchPhase = TouchPhase.Ended;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhase) {
             //We transform the touch position into word space from screen space and store it.
             touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
 
             Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
 
             //We now raycast with this information. If we have hit something we can process it.
             RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);
 
             if (hitInformation.collider != null) {
                 Vector3 position = hitInformation.transform.position;
                 Quaternion rotation = hitInformation.transform.rotation;
                 Instantiate(Xis, position, rotation);
                Debug.Log("Touched " + touchedObject.transform.name);
             }
         }
    }
}
