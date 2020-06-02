using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoStage2 : MonoBehaviour
{

    public void Back_to_Stage2()
    {
        SceneManager.LoadScene("Stage2");
    }
}

