using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyperlink : MonoBehaviour
{
    [SerializeField] private string link;

    public void OpenLink()
    {
        Application.OpenURL(link);
    }
}
