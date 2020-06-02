using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScreen : MonoBehaviour
{
    // Start is called before the first frame update

    void Awake()
    {  
        Screen.SetResolution(290,515 , false);
    }
}
