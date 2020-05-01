using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colour : MonoBehaviour
{
    // Start is called before the first frame update
    public Material nmaterial;
    public Texture table;
    public Texture tabledefault;

    ARTapToPlaceObject selectionObject;


    void start()
    {
       

       
    }
    private void Update()
    {
        if (ARTapToPlaceObject.artapInstace.isobj1)
        {
            Debug.Log("ghgchdh");
        }
    }
    public void setColor()
    {
        if (ARTapToPlaceObject.artapInstace.isobj2)
        {
            Debug.Log("ghgchdh");
            nmaterial.SetTexture("_MainTex", table);
        }
        else
        {


            nmaterial.SetColor("_Color", Color.magenta);
        }
    }
    public void setColortoblue()
    {
        
        
        nmaterial.SetColor("_Color", Color.blue);
    }
    public void setColortoGreen()
    {
        
        nmaterial.SetColor("_Color", Color.green);
    }
    public void setColorDefault()
    {
        if (ARTapToPlaceObject.artapInstace.isobj2)
        {
            Debug.Log("ghgchdh");
            nmaterial.SetTexture("_MainTex", tabledefault);
        }

        nmaterial.SetColor("_Color", Color.white);
    }
}
