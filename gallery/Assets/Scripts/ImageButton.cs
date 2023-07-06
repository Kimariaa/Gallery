using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class ImageButton : MonoBehaviour
{
    public GameDataScript count;
    [SerializeField] Image image;

    public void ImageTab()
    {
        count.numberOfTabImage = Convert.ToInt32(image.name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
