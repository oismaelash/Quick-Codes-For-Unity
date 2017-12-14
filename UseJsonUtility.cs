using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class UseJsonUtility : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(GetInformation_Coroutine());
    }

    private IEnumerator GetInformation_Coroutine()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://thegamingworld.info/"))
        {
            yield return request.Send();

            if (request.isNetworkError || request.isHttpError)
            {
                print("Error::\n " + request.error);
            }
            else
            {
                string dataAsJson = request.downloadHandler.text;
                print(dataAsJson);

                print("==========================");

                // FromJson
                Players newPlayer = JsonUtility.FromJson<Players>(dataAsJson);
                print(newPlayer[0].Name);

                print("==========================");

                // ToJson
                newPlayer[0].Name = "Ismael Nascimento";
                string newJson = JsonUtility.ToJson(newPlayer);
                print("New json::\n " + newJson);
            }
        }
    }
}

[System.Serializable]
public class Players
{
    public List<Player> players;
}

[System.Serializable]
public class Player
{
    public int Id;
    public string Name;
    public string Password;
}
