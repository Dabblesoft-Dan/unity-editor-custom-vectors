using UnityEditor;
using UnityEngine;

namespace Dabblesoft.Unity.Editor.CustomVectors
{
    public sealed partial class EditorGUI
    {
        public static readonly int foldoutHash = "Foldout".GetHashCode();

        internal const float spacingSubLabel = 4f;

        internal static float CalcPrefixLabelWidth(GUIContent label, GUIStyle style = null)
        {
            if (style == null)
                style = EditorStyles.label;

            return style.CalcSize(label).x;
        }

        internal static int CalcRows(int valuesSize, int columns)
        {
            columns = Mathf.Max(columns, 1);
            int rowsRounded = Mathf.CeilToInt((float)valuesSize / columns);

            return columns > valuesSize ? 1 : rowsRounded;
        }
    }
}
