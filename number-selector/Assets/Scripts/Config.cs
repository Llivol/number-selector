using UnityEngine;

public static class Config
{
    public static readonly float FADE_TIME_IN_SECONDS = 2f;

    public static readonly int MIN_VALUE = 1;
    public static readonly int[] MAX_VALUES = new int[] { 10, 1000, 10000000 };

    public static readonly Color COLOR_BG_DEFAULT = new Color(1f, 1f, 1f);
    public static readonly Color COLOR_BG_CORRECT = new Color(0.09411765f, 0.8156863f, 0f);
    public static readonly Color COLOR_BG_WRONG = new Color(0.9137255f, 0.1098039f, 0.1098039f);
    public static readonly Color COLOR_TXT_DEFAULT = new Color(0.1098039f, 0.1254902f, 0.1372549f);
    public static readonly Color COLOR_TXT_CORRECT = new Color(1f, 1f, 1f);
    public static readonly Color COLOR_TXT_WRONG = new Color(1f, 1f, 1f);
}