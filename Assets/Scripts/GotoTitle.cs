using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoTitle: MonoBehaviour
{

    public void Back_to_menu() {
        SceneManager.LoadScene("Title");
    }
}

