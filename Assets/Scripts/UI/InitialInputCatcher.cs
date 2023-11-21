using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialInputCatcher : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    private void Start()
    {
        if (!Configuration.Instance.initialInput) return;

        GoToMenu();
    }

    private void OnGUI()
    {
        if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1)) return;

        Configuration.Instance.initialInput = true;
        GoToMenu();
    }

    private void GoToMenu()
    {
        menu.SetActive(true);

        Destroy(gameObject);
    }
}
