using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void Go_to_Tutorial()
    {
        SceneManager.LoadScene("");
    }

    // Update is called once per frame
    public void Go_to_PacMan()
    {
        SceneManager.LoadScene("");
    }

    public void Go_to_Galagon()
    {
        SceneManager.LoadScene("Stage1");
    }
}
