using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    [SerializeField] Image image;
    private string url;
    private bool withoutImage = true;

    public GameDataScript count;

    // Start is called before the first frame update
    void Awake()
    {
        count.ResetData();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (withoutImage)
        {
            Debug.Log("Collision detected");
            image.name = count.imageCount.ToString();
            url = "http://data.ikppbb.com/test-task-unity-data/pics/" + count.imageCount++ + ".jpg";
            StartCoroutine(DownloadImage(url));
            withoutImage = false;
        }
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
        {
            Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
            image.GetComponent<Image>().overrideSprite = sprite;
        }
    }
}
