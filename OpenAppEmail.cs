using UnityEngine;

public class OpenAppEmail : MonoBehaviour
{
    public void OnButtonFeedbackClicked()
    {
        var emailToReceiveFeedback = "email@email.com";
        string subjectEmail = "Feedback about any";
        string bodyEmail = "";
        Application.OpenURL("mailto:" + emailToReceiveFeedback + "?subject=" + subjectEmail + "&body=" + bodyEmail);
    }
}
