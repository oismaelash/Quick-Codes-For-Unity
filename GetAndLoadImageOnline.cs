using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GetAndLoadImageOnline : MonoBehaviour
{
    public Image imageShowUI;

    private void Start()
    {
        StartCoroutine(GetLoadImageOnline("https://goo.gl/C162fB"));
    }

    private IEnumerator GetLoadImageOnline(string urlImage)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(urlImage))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                print("Load Error");
            }
            else
            {
                var texture = new Texture2D(Screen.width, Screen.height);
                texture.LoadImage(www.downloadHandler.data);
                var mySprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100f);
                imageShowUI.sprite = mySprite;
                print("Load Sucess");
            }
        }
    }
}
