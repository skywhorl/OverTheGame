using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoStage3 : MonoBehaviour
{
    public void Back_to_Stage3()
    {
        SceneManager.LoadScene("Stage3");
    }
}
