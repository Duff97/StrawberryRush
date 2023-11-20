using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialInputCatcher : MonoBehaviour
{
    [SerializeField] private string scene;

    private void OnGUI()
    {
        if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1)) return;

        SceneManager.LoadScene(scene);
    }
}
