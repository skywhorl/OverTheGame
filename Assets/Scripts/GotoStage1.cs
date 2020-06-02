using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoStage1 : MonoBehaviour
{

    public void Back_to_Stage1()
    {
        SceneManager.LoadScene("Stage1");
    }
}
