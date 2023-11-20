using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialInputCatcher : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;

    private void OnGUI()
    {
        if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1)) return;

        mainMenu.SetActive(true);

        Destroy(gameObject);
    }
}
