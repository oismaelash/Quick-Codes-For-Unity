public static class FadeAlphaGraphicUI
{
    public static void CrossFadeAlphaFixed(this Graphic img, float alpha, float duration, bool ignoreTimeScale)
    {
        //Make the alpha 1
        Color fixedColor = img.color;
        fixedColor.a = 1;
        img.color = fixedColor;

        //Set the 0 to zero then duration to 0
        img.CrossFadeAlpha(0f, 0f, true);

        //Finally perform CrossFadeAlpha
        img.CrossFadeAlpha(alpha, duration, ignoreTimeScale);
    }
    
    // How Use, e.g
    // Image.CrossFadeAlphaFixed(1f, 1f. false);
}
