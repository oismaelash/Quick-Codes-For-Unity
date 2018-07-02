public static class FadeAlphaGraphicUI
{
    public static void CrossFadeAlphaFixed(this Graphic graphic, float alpha, float duration, Action callback)
    {
        MonoBehaviour monoBehaviour = graphic.GetComponent<MonoBehaviour>();
        monoBehaviour.StartCoroutine(CrossFadeAlphaFixed_Coroutine(graphic, alpha, duration, callback));
    }

    public static IEnumerator CrossFadeAlphaFixed_Coroutine(Graphic img, float alpha, float duration, Action callback)
    {
        Color currentColor = img.color;
        Color visibleColor = img.color;
        visibleColor.a = alpha;
        float counter = 0;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            img.color = Color.Lerp(currentColor, visibleColor, counter / duration);
            yield return null;
        }

        if (callback != null) callback();
    }
    
    // How Use, e.g
    // Image.CrossFadeAlphaFixed(1f, 1f. false, () => print("Finished"));
}
