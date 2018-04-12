// Add this script to a GameObject. The Start() function fetches an
// image from the site. It is then applied as the texture on the GameObject.

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class LoadImageOnlineForTexture : MonoBehaviour
{
	public string urlImage = "https://i.ytimg.com/vi/allOoYWE1n4/maxresdefault.jpg";

    private IEnumerator Start()
    {
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(urlImage))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Texture2D newTexture;
                newTexture = DownloadHandlerTexture.GetContent(request);
                GetComponent<Renderer>().material.mainTexture = newTexture;
            }
        }
    }
}
