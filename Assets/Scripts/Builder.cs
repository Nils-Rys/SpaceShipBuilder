using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public GameObject[] components;
    public GameObject currentComp;
    public Camera viewer;
    private int selector;
    private float rotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        selector = 0;
        currentComp = Instantiate(components[selector], new Vector3(0,0.5f,0),Quaternion.identity);
    }

    // Update is called once per frame
    void Update ()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 mouseLoc = new Vector3(mousePos.x, mousePos.y, viewer.transform.position.y);    
        
        
        Vector3 objectPos = viewer.ScreenToWorldPoint(mouseLoc);

        currentComp.transform.position = objectPos;
        currentComp.transform.rotation = Quaternion.Euler(0, rotation, 0);

        if(Input.GetKeyDown(KeyCode.Alpha1)){
            if(selector != 0){
                selector = 0;
                Destroy(currentComp);
                currentComp = Instantiate(components[selector], objectPos,Quaternion.Euler(0, rotation, 0));
            }
        }else if(Input.GetKeyDown(KeyCode.Alpha2)){
            if(selector != 1){
                selector = 1;
                Destroy(currentComp);
                currentComp = Instantiate(components[selector], objectPos,Quaternion.Euler(0, rotation, 0));
            }
        }

        if(Input.GetKeyDown(KeyCode.R)){
            rotation = (rotation + 90) % 360;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 girdLoc = new Vector3(Mathf.Round(objectPos.x),0,Mathf.Round(objectPos.z));

            
            Instantiate(components[selector], girdLoc, Quaternion.Euler(0, rotation, 0));

        }

    }


}
