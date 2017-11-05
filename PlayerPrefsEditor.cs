using UnityEngine;
using UnityEditor;

public class PlayerPrefsEditor : EditorWindow
{
    [MenuItem("Edit/Player Prefs")]
    public static void OpenWindow()
    {

        PlayerPrefsEditor window = (PlayerPrefsEditor)GetWindow(typeof(PlayerPrefsEditor));
        window.titleContent = new GUIContent("Player Prefs Editor");
        window.Show();
    }

    public enum FieldType { String, Integer, Float }
    private FieldType fieldType = FieldType.String;
    private string getKey = "";
    private string newValue = "";
    private string error = null;

    void OnGUI()
    {
        fieldType = (FieldType)EditorGUILayout.EnumPopup("Key Type", fieldType);
        getKey = EditorGUILayout.TextField("Key name: ", getKey);
        newValue = EditorGUILayout.TextField("New value for Key: ", newValue);

        EditorGUILayout.Separator();
        EditorGUILayout.Separator();

        if (error != null)
        {
            EditorGUILayout.HelpBox(error, MessageType.Error);
        }

        if (GUILayout.Button("Set Key"))
        {
            switch (fieldType)
            {
                case FieldType.Integer:
                    int result1;
                    if (!int.TryParse(newValue, out result1))
                    {
                        error = "Invalid input \"" + newValue + "\"";
                        return;
                    }

                    PlayerPrefs.SetInt(getKey, result1);
                    break;
                case FieldType.Float:
                    float result2;
                    if (!float.TryParse(newValue, out result2))
                    {
                        error = "Invalid input \"" + newValue + "\"";
                        return;
                    }

                    PlayerPrefs.SetFloat(getKey, result2);
                    break;
                case FieldType.String:
                    PlayerPrefs.SetString(getKey, newValue);
                    break;
            }

            PlayerPrefs.Save();
            error = null;
        }

        if (GUILayout.Button("Get Key"))
        {
            switch (fieldType)
            {
                case FieldType.Integer:
                    newValue = PlayerPrefs.GetInt(getKey).ToString();
                    break;
                case FieldType.Float:
                    newValue = PlayerPrefs.GetFloat(getKey).ToString();
                    break;
                case FieldType.String:
                    newValue = PlayerPrefs.GetString(getKey);
                    break;
            }
        }

        if (GUILayout.Button("Delete Key"))
        {
            PlayerPrefs.DeleteKey(getKey);
            PlayerPrefs.Save();
        }

        if (GUILayout.Button("Delete All Keys"))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }

        for (int i = 0; i < 15; i++)
        {
            EditorGUILayout.Separator();
        }

        EditorGUILayout.LabelField("by Ismael Nascimento");
    }
}
