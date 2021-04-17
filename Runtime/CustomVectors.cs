using System.Reflection;
using UnityEditor;
using UnityEngine;

using EditorGUIUnity = UnityEditor.EditorGUI;
using EditorGUILayoutUnity = UnityEditor.EditorGUILayout;

namespace Dabblesoft.Unity.Editor.CustomVectors
{
    public sealed partial class EditorGUI
    {
        const string multiFieldPrefixLabel = "MultiFieldPrefixLabel";
        static readonly MethodInfo multiFieldPrefixLabelMethod = typeof(EditorGUIUnity).GetMethod(multiFieldPrefixLabel, BindingFlags.Static | BindingFlags.NonPublic);

        static float CalcSubLabelWidth(GUIContent subLabel, float prefixLabelWidth, float rectWidth)
        {
            EditorGUIUtility.labelWidth = prefixLabelWidth > 0 ? prefixLabelWidth : CalcPrefixLabelWidth(subLabel);
            float labelWidth = EditorGUIUtility.labelWidth;

            if (subLabel.text.Length > 0)
            {
                float availableWidth = rectWidth - EditorGUIUtility.fieldWidth;
                string firstLabelLetter = subLabel.text.Substring(0, 1);
                float firstLabelLetterWidth = CalcPrefixLabelWidth(EditorGUIUtility.TrTextContent(firstLabelLetter));

                if (EditorGUIUtility.labelWidth > availableWidth)
                {
                    labelWidth = Mathf.Max(availableWidth, firstLabelLetterWidth);
                }
            }

            return labelWidth;
        }

        /// <summary>
        /// Make an X and Y field for entering a Vector2.
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the field.</param>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="value">The value to edit.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        /// <returns>The value entered by the user.</returns>
        public static Vector2 Vector2Field(Rect position, string label, Vector2 value, string xLabel = "X", string yLabel = "Y", bool expandWidth = false)
        {
            return Vector2Field(position, EditorGUIUtility.TrTempContent(label), value, xLabel, yLabel, expandWidth);
        }

        /// <summary>
        /// Make an X and Y field for entering a Vector2.
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the field.</param>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="value">The value to edit.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        /// <returns>The value entered by the user.</returns>
        public static Vector2 Vector2Field(Rect position, GUIContent label, Vector2 value, string xLabel = "X", string yLabel = "Y", bool expandWidth = false)
        {
            GUIContent[] subLabels = new GUIContent[]
            {
                EditorGUIUtility.TrTextContent(xLabel),
                EditorGUIUtility.TrTextContent(yLabel)
            };

            int id = GUIUtility.GetControlID(foldoutHash, FocusType.Keyboard, position);
            int columns = expandWidth ? 1 : subLabels.Length;

            position = (Rect)multiFieldPrefixLabelMethod.Invoke(multiFieldPrefixLabel, new object[] { position, id, label, columns });
            position.height = EditorGUIUtility.singleLineHeight;

            return Vector2Field(position, subLabels, value);
        }

        static Vector2 Vector2Field(Rect position, GUIContent[] subLabels, Vector2 value)
        {
            float[] vectorValues = new float[]
            {
                value.x,
                value.y
            };

            position.height = EditorGUIUtility.singleLineHeight;

            using (var check = new EditorGUIUnity.ChangeCheckScope())
            {
                MultiFloatField(position, subLabels, vectorValues);

                if (check.changed)
                {
                    value.x = vectorValues[0];
                    value.y = vectorValues[1];
                }
            }

            return value;
        }

        /// <summary>
        /// Make an X and Y integer field for entering a Vector2Int.
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the field.</param>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="value">The value to edit.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        /// <returns>The value entered by the user.</returns>
        public static Vector2Int Vector2IntField(Rect position, string label, Vector2Int value, string xLabel = "X", string yLabel = "Y", bool expandWidth = false)
        {
            return Vector2IntField(position, EditorGUIUtility.TrTempContent(label), value, xLabel, yLabel, expandWidth);
        }

        /// <summary>
        /// Make an X and Y integer field for entering a Vector2Int.
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the field.</param>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="value">The value to edit.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        /// <returns>The value entered by the user.</returns>
        public static Vector2Int Vector2IntField(Rect position, GUIContent label, Vector2Int value, string xLabel = "X", string yLabel = "Y", bool expandWidth = false)
        {
            GUIContent[] subLabels = new GUIContent[]
            {
                EditorGUIUtility.TrTextContent(xLabel),
                EditorGUIUtility.TrTextContent(yLabel)
            };

            int id = GUIUtility.GetControlID(foldoutHash, FocusType.Keyboard, position);
            int columns = expandWidth ? 1 : subLabels.Length;

            position = (Rect)multiFieldPrefixLabelMethod.Invoke(multiFieldPrefixLabel, new object[] { position, id, label, columns });
            position.height = EditorGUIUtility.singleLineHeight;

            return Vector2IntField(position, subLabels, value);
        }

        static Vector2Int Vector2IntField(Rect position, GUIContent[] subLabels, Vector2Int value)
        {
            int[] values = new int[]
            {
                value.x,
                value.y
            };

            position.height = EditorGUIUtility.singleLineHeight;

            using (var check = new EditorGUIUnity.ChangeCheckScope())
            {
                MultiIntField(position, subLabels, values);

                if (check.changed)
                {
                    value.x = values[0];
                    value.y = values[1];
                }
            }

            return value;
        }

        /// <summary>
        /// Make an X, Y, and Z field for entering a Vector3.
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the field.</param>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="value">The value to edit.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="zLabel">Label to display for the Z field.</param>
        /// <returns>The value entered by the user.</returns>
        public static Vector3 Vector3Field(Rect position, string label, Vector3 value, string xLabel = "X", string yLabel = "Y", string zLabel = "Z")
        {
            return Vector3Field(position, EditorGUIUtility.TrTempContent(label), value, xLabel, yLabel, zLabel);
        }

        /// <summary>
        /// Make an X, Y, and Z field for entering a Vector3.
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the field.</param>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="value">The value to edit.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="zLabel">Label to display for the Z field.</param>
        /// <returns>The value entered by the user.</returns>
        public static Vector3 Vector3Field(Rect position, GUIContent label, Vector3 value, string xLabel = "X", string yLabel = "Y", string zLabel = "Z")
        {
            GUIContent[] subLabels = new GUIContent[]
            {
                EditorGUIUtility.TrTextContent(xLabel),
                EditorGUIUtility.TrTextContent(yLabel),
                EditorGUIUtility.TrTextContent(zLabel)
            };

            int id = GUIUtility.GetControlID(foldoutHash, FocusType.Keyboard, position);

            position = (Rect)multiFieldPrefixLabelMethod.Invoke(multiFieldPrefixLabel, new object[] { position, id, label, subLabels.Length });
            position.height = EditorGUIUtility.singleLineHeight;

            return Vector3Field(position, subLabels, value);
        }

        static Vector3 Vector3Field(Rect position, GUIContent[] subLabels, Vector3 value)
        {
            float[] vectorValues = new float[]
            {
                value.x,
                value.y,
                value.z
            };

            position.height = EditorGUIUtility.singleLineHeight;

            using (var check = new EditorGUIUnity.ChangeCheckScope())
            {
                MultiFloatField(position, subLabels, vectorValues);

                if (check.changed)
                {
                    value.x = vectorValues[0];
                    value.y = vectorValues[1];
                    value.z = vectorValues[2];
                }
            }

            return value;
        }

        /// <summary>
        /// Make an X, Y, and Z integer field for entering a Vector3Int.
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the field.</param>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="value">The value to edit.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="zLabel">Label to display for the Z field.</param>
        /// <returns>The value entered by the user.</returns>
        public static Vector3Int Vector3IntField(Rect position, string label, Vector3Int value, string xLabel = "X", string yLabel = "Y", string zLabel = "Z")
        {
            return Vector3IntField(position, EditorGUIUtility.TrTempContent(label), value, xLabel, yLabel, zLabel);
        }

        /// <summary>
        /// Make an X, Y, and Z integer field for entering a Vector3Int.
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the field.</param>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="value">The value to edit.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="zLabel">Label to display for the Z field.</param>
        /// <returns>The value entered by the user.</returns>
        public static Vector3Int Vector3IntField(Rect position, GUIContent label, Vector3Int value, string xLabel = "X", string yLabel = "Y", string zLabel = "Z")
        {
            GUIContent[] subLabels = new GUIContent[]
            {
                EditorGUIUtility.TrTextContent(xLabel),
                EditorGUIUtility.TrTextContent(yLabel),
                EditorGUIUtility.TrTextContent(zLabel)
            };

            int id = GUIUtility.GetControlID(foldoutHash, FocusType.Keyboard, position);

            position = (Rect)multiFieldPrefixLabelMethod.Invoke(multiFieldPrefixLabel, new object[] { position, id, label, subLabels.Length });
            position.height = EditorGUIUtility.singleLineHeight;

            return Vector3IntField(position, subLabels, value);
        }

        static Vector3Int Vector3IntField(Rect position, GUIContent[] subLabels, Vector3Int value)
        {
            int[] values = new int[]
            {
                value.x,
                value.y,
                value.z
            };

            position.height = EditorGUIUtility.singleLineHeight;

            using (var check = new EditorGUIUnity.ChangeCheckScope())
            {
                MultiIntField(position, subLabels, values);

                if (check.changed)
                {
                    value.x = values[0];
                    value.y = values[1];
                    value.z = values[2];
                }
            }

            return value;
        }

        /// <summary>
        /// Make an X, Y, Z, and W field for entering a Vector4.
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the field.</param>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="value">The value to edit.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="zLabel">Label to display for the Z field.</param>
        /// <param name="wLabel">Label to display for the W field.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        /// <param name="stackFields">Stack the fields in a 2x2 format.</param>
        /// <returns>The value entered by the user.</returns>
        public static Vector4 Vector4Field(Rect position, string label, Vector4 value, string xLabel = "X", string yLabel = "Y", string zLabel = "Z", string wLabel = "W", bool expandWidth = true, bool stackFields = false)
        {
            return Vector4Field(position, EditorGUIUtility.TrTempContent(label), value, xLabel, yLabel, zLabel, wLabel, expandWidth, stackFields);
        }

        /// <summary>
        /// Make an X, Y, Z, and W field for entering a Vector4.
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the field.</param>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="value">The value to edit.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="zLabel">Label to display for the Z field.</param>
        /// <param name="wLabel">Label to display for the W field.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        /// <param name="stackFields">Stack the fields in a 2x2 format.</param>
        /// <returns>The value entered by the user.</returns>
        public static Vector4 Vector4Field(Rect position, GUIContent label, Vector4 value, string xLabel = "X", string yLabel = "Y", string zLabel = "Z", string wLabel = "W", bool expandWidth = true, bool stackFields = false)
        {
            GUIContent[] subLabels = new GUIContent[]
            {
                EditorGUIUtility.TrTextContent(xLabel),
                EditorGUIUtility.TrTextContent(yLabel),
                EditorGUIUtility.TrTextContent(zLabel),
                EditorGUIUtility.TrTextContent(wLabel)
            };

            int id = GUIUtility.GetControlID(foldoutHash, FocusType.Keyboard, position);
            int columns = expandWidth ? 1 : 2;

            position = (Rect)multiFieldPrefixLabelMethod.Invoke(multiFieldPrefixLabel, new object[] { position, id, label, columns });
            position.height = EditorGUIUtility.singleLineHeight;

            return Vector4Field(position, subLabels, value, stackFields);
        }

        static Vector4 Vector4Field(Rect position, GUIContent[] subLabels, Vector4 value, bool stackFields = false)
        {
            if (stackFields)
            {
                float[] vectorValues = new float[]
                {
                    value.x,
                    value.y,
                    value.z,
                    value.w
                };

                position.height = EditorGUIUtility.singleLineHeight;

                using (var check = new EditorGUIUnity.ChangeCheckScope())
                {
                    MultiFloatField(position, subLabels, vectorValues, 2);

                    if (check.changed)
                    {
                        value.x = vectorValues[0];
                        value.y = vectorValues[1];
                        value.z = vectorValues[2];
                        value.w = vectorValues[3];
                    }
                }
            }
            else
            {
                float[] vectorValues = new float[]
                {
                    value.x,
                    value.y,
                    value.z,
                    value.w
                };

                position.height = EditorGUIUtility.singleLineHeight;

                using (var check = new EditorGUIUnity.ChangeCheckScope())
                {
                    int valuesCount = vectorValues.Length;
                    float width = position.width - (valuesCount - 1) * spacingSubLabel;
                    float spacingWidth = width / valuesCount;
                    var rect = new Rect(position) { width = spacingWidth };

                    float oldLabelWidth = EditorGUIUtility.labelWidth;
                    int oldIndentLevel = EditorGUIUnity.indentLevel;
                    EditorGUIUnity.indentLevel = 0;

                    for (int i = 0; i < vectorValues.Length; i++)
                    {
                        EditorGUIUtility.labelWidth = CalcSubLabelWidth(subLabels[i], -1, rect.width);
                        vectorValues[i] = EditorGUIUnity.FloatField(rect, subLabels[i], vectorValues[i]);
                        rect.x += spacingWidth + spacingSubLabel;
                    }

                    EditorGUIUtility.labelWidth = oldLabelWidth;
                    EditorGUIUnity.indentLevel = oldIndentLevel;

                    if (check.changed)
                    {
                        value.x = vectorValues[0];
                        value.y = vectorValues[1];
                        value.z = vectorValues[2];
                        value.w = vectorValues[3];
                    }
                }
            }

            return value;
        }

        /// <summary>
        /// Makes a multi-control with text fields for entering multiple floats in the same line.
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the field.</param>
        /// <param name="label">Prefix label to display in front of the field.</param>
        /// <param name="subLabels">Array with labels to show in front of each field.</param>
        /// <param name="values">Array with the values to edit.</param>
        /// <param name="columns">The amount of columns to display per row.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        public static void MultiFloatField(Rect position, string label, string[] subLabels, float[] values, int columns = 3, bool expandWidth = false)
        {
            MultiFloatField(position, EditorGUIUtility.TrTempContent(label), subLabels, values, columns, expandWidth);
        }

        /// <summary>
        /// Makes a multi-control with text fields for entering multiple floats in the same line.
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the field.</param>
        /// <param name="label">Prefix label to display in front of the field.</param>
        /// <param name="subLabels">Array with labels to show in front of each field.</param>
        /// <param name="values">Array with the values to edit.</param>
        /// <param name="columns">The amount of columns to display per row.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        public static void MultiFloatField(Rect position, GUIContent label, string[] subLabels, float[] values, int columns = 3, bool expandWidth = false)
        {
            GUIContent[] guiSubLabels = new GUIContent[subLabels.Length];

            for (int i = 0; i < subLabels.Length; i++)
            {
                guiSubLabels[i] = EditorGUIUtility.TrTextContent(subLabels[i]);
            }

            MultiFloatField(position, label, guiSubLabels, values, columns, expandWidth);
        }

        /// <summary>
        /// Makes a multi-control with text fields for entering multiple floats in the same line.
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the field.</param>
        /// <param name="label">Prefix label to display in front of the field.</param>
        /// <param name="subLabels">Array with labels to show in front of each field.</param>
        /// <param name="values">Array with the values to edit.</param>
        /// <param name="columns">The amount of columns to display per row.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        public static void MultiFloatField(Rect position, GUIContent label, GUIContent[] subLabels, float[] values, int columns = 3, bool expandWidth = false)
        {
            int id = GUIUtility.GetControlID(foldoutHash, FocusType.Keyboard, position);
            int prefixLabelColumns = expandWidth ? 1 : 2;

            position = (Rect)multiFieldPrefixLabelMethod.Invoke(multiFieldPrefixLabel, new object[] { position, id, label, prefixLabelColumns });
            position.height = EditorGUIUtility.singleLineHeight;

            MultiFloatField(position, subLabels, values, columns);
        }

        /// <summary>
        /// Makes a multi-control with text fields for entering multiple floats in the same line.
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the field.</param>
        /// <param name="subLabels">Array with labels to show in front of each field.</param>
        /// <param name="values">Array with the values to edit.</param>
        /// <param name="columns">The amount of columns to display per row.</param>
        public static void MultiFloatField(Rect position, string[] subLabels, float[] values, int columns = 3)
        {
            GUIContent[] guiSubLabels = new GUIContent[subLabels.Length];

            for (int i = 0; i < subLabels.Length; i++)
            {
                guiSubLabels[i] = EditorGUIUtility.TrTextContent(subLabels[i]);
            }

            MultiFloatField(position, guiSubLabels, values, columns);
        }

        /// <summary>
        /// Makes a multi-control with text fields for entering multiple floats in the same line.
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the field.</param>
        /// <param name="subLabels">Array with labels to show in front of each field.</param>
        /// <param name="values">Array with the values to edit.</param>
        /// <param name="columns">The amount of columns to display per row.</param>
        public static void MultiFloatField(Rect position, GUIContent[] subLabels, float[] values, int columns = 3)
        {
            MultiFloatFieldInternal(position, subLabels, values, columns);
        }

        internal static void MultiFloatFieldInternal(Rect position, GUIContent[] subLabels, float[] values, int columns, float prefixLabelWidth = -1)
        {
            if (subLabels.Length != values.Length)
            {
                if (subLabels.Length < values.Length)
                    Debug.LogError("CustomVectors MultiFloatField has fewer subLabels than values assigned to it.");
                else
                    Debug.LogError("CustomVectors MultiFloatField has more subLabels than values assigned to it.");

                return;
            }

            columns = Mathf.Max(columns, 1);
            int remainingFields = values.Length % columns;
            int rows = CalcRows(values.Length, columns);
            rows = Mathf.Max(rows, 1);
            int fieldsPerRow = columns < values.Length ? columns : values.Length;

            for (int i = 0; i < rows; i++)
            {
                bool isLastRow = i == rows - 1;
                int fields = isLastRow && remainingFields > 0 ? remainingFields : fieldsPerRow;

                GUIContent[] rowSubLabels = new GUIContent[fields];

                for (int j = 0; j < rowSubLabels.Length; j++)
                {
                    rowSubLabels[j] = subLabels[j + (i * columns)];
                }

                float[] vectorValues = new float[fields];

                for (int k = 0; k < vectorValues.Length; k++)
                {
                    vectorValues[k] = values[k + (i * columns)];
                }

                position.height = EditorGUIUtility.singleLineHeight;

                float width = position.width - (fields - 1) * spacingSubLabel;
                float spacingWidth = width / fields;
                var rect = new Rect(position) { width = spacingWidth };

                float oldLabelWidth = EditorGUIUtility.labelWidth;
                int oldIndentLevel = EditorGUIUnity.indentLevel;
                EditorGUIUnity.indentLevel = 0;

                for (int l = 0; l < fields; l++)
                {
                    int index = l + (i * columns);

                    EditorGUIUtility.labelWidth = CalcSubLabelWidth(subLabels[index], prefixLabelWidth, rect.width);

                    values[index] = EditorGUIUnity.FloatField(rect, subLabels[index], values[index]);

                    rect.x += spacingWidth + spacingSubLabel;
                }

                EditorGUIUtility.labelWidth = oldLabelWidth;
                EditorGUIUnity.indentLevel = oldIndentLevel;

                position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            }
        }

        /// <summary>
        /// Makes a multi-control with text fields for entering multiple integers in the same line.
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the field.</param>
        /// <param name="label">Prefix label to display in front of the field.</param>
        /// <param name="subLabels">Array with labels to show in front of each field.</param>
        /// <param name="values">Array with the values to edit.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        public static void MultiIntField(Rect position, string label, string[] subLabels, int[] values, int columns = 3, bool expandWidth = false)
        {
            MultiIntField(position, EditorGUIUtility.TrTempContent(label), subLabels, values, columns, expandWidth);
        }

        /// <summary>
        /// Makes a multi-control with text fields for entering multiple integers in the same line.
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the field.</param>
        /// <param name="label">Prefix label to display in front of the field.</param>
        /// <param name="subLabels">Array with labels to show in front of each field.</param>
        /// <param name="values">Array with the values to edit.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        public static void MultiIntField(Rect position, GUIContent label, string[] subLabels, int[] values, int columns = 3, bool expandWidth = false)
        {
            GUIContent[] guiSubLabels = new GUIContent[subLabels.Length];

            for (int i = 0; i < subLabels.Length; i++)
            {
                guiSubLabels[i] = EditorGUIUtility.TrTextContent(subLabels[i]);
            }

            MultiIntField(position, label, guiSubLabels, values, columns, expandWidth);
        }

        /// <summary>
        /// Makes a multi-control with text fields for entering multiple integers in the same line.
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the field.</param>
        /// <param name="label">Optional label to display in front of the field.</param>
        /// <param name="subLabels">Array with labels to show in front of each field.</param>
        /// <param name="values">Array with the values to edit.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        public static void MultiIntField(Rect position, GUIContent label, GUIContent[] subLabels, int[] values, int columns = 3, bool expandWidth = false)
        {
            int id = GUIUtility.GetControlID(foldoutHash, FocusType.Keyboard, position);
            int prefixLabelColumns = expandWidth ? 1 : 2;

            position = (Rect)multiFieldPrefixLabelMethod.Invoke(multiFieldPrefixLabel, new object[] { position, id, label, prefixLabelColumns });
            position.height = EditorGUIUtility.singleLineHeight;

            MultiIntField(position, subLabels, values, columns);
        }

        /// <summary>
        /// Makes a multi-control with text fields for entering multiple integers in the same line.
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the field.</param>
        /// <param name="subLabels">Array with labels to show in front of each field.</param>
        /// <param name="values">Array with the values to edit.</param>
        public static void MultiIntField(Rect position, string[] subLabels, int[] values, int columns = 3)
        {
            GUIContent[] guiSubLabels = new GUIContent[subLabels.Length];

            for (int i = 0; i < subLabels.Length; i++)
            {
                guiSubLabels[i] = EditorGUIUtility.TrTextContent(subLabels[i]);
            }

            MultiIntField(position, guiSubLabels, values, columns);
        }

        /// <summary>
        /// Makes a multi-control with text fields for entering multiple integers in the same line.
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the field.</param>
        /// <param name="subLabels">Array with labels to show in front of each field.</param>
        /// <param name="values">Array with the values to edit.</param>
        public static void MultiIntField(Rect position, GUIContent[] subLabels, int[] values, int columns = 3)
        {
            MultiIntFieldInternal(position, subLabels, values, columns);
        }

        internal static void MultiIntFieldInternal(Rect position, GUIContent[] subLabels, int[] values, int columns = 3, float prefixLabelWidth = -1)
        {
            if (subLabels.Length != values.Length)
            {
                if (subLabels.Length < values.Length) 
                    Debug.LogError("CustomVectors MultiFloatField has fewer subLabels than values assigned to it.");
                else 
                    Debug.LogError("CustomVectors MultiFloatField has more subLabels than values assigned to it.");

                return;
            }

            columns = Mathf.Max(columns, 1);
            int remainingFields = values.Length % columns;
            int rows = CalcRows(values.Length, columns);
            rows = Mathf.Max(rows, 1);
            int fieldsPerRow = columns < values.Length ? columns : values.Length;

            for (int i = 0; i < rows; i++)
            {
                bool isLastRow = i == rows - 1;
                int fields = isLastRow && remainingFields > 0 ? remainingFields : fieldsPerRow;

                GUIContent[] rowSubLabels = new GUIContent[fields];

                for (int j = 0; j < rowSubLabels.Length; j++)
                {
                    rowSubLabels[j] = subLabels[j + (i * columns)];
                }

                int[] vectorValues = new int[fields];

                for (int k = 0; k < vectorValues.Length; k++)
                {
                    vectorValues[k] = values[k + (i * columns)];
                }

                position.height = EditorGUIUtility.singleLineHeight;

                float width = position.width - (fields - 1) * spacingSubLabel;
                float spacingWidth = width / fields;
                var rect = new Rect(position) { width = spacingWidth };

                float oldLabelWidth = EditorGUIUtility.labelWidth;
                int oldIndentLevel = EditorGUIUnity.indentLevel;
                EditorGUIUnity.indentLevel = 0;

                for (int l = 0; l < fields; l++)
                {
                    int index = l + (i * columns);

                    EditorGUIUtility.labelWidth = CalcSubLabelWidth(subLabels[index], prefixLabelWidth, rect.width);

                    values[index] = EditorGUIUnity.IntField(rect, subLabels[index], values[index]);

                    rect.x += spacingWidth + spacingSubLabel;
                }

                EditorGUIUtility.labelWidth = oldLabelWidth;
                EditorGUIUnity.indentLevel = oldIndentLevel;

                position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            }
        }
    }

    public sealed partial class EditorGUILayout
    {
        /// <summary>
        /// Make an X and Y field for entering a Vector2.
        /// </summary>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="value">The value to edit.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        /// <param name="options">An optional list of layout options that specify extra layout properties. Any values passed in here will override settings defined by the style.</param>
        /// <returns>The value entered by the user.</returns>
        public static Vector2 Vector2Field(string label, Vector2 value, string xLabel = "X", string yLabel = "Y", bool expandWidth = false, params GUILayoutOption[] options)
        {
            return Vector2Field(EditorGUIUtility.TrTempContent(label), value, xLabel, yLabel, expandWidth, options);
        }

        /// <summary>
        /// Make an X and Y field for entering a Vector2.
        /// </summary>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="value">The value to edit.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        /// <param name="options">An optional list of layout options that specify extra layout properties. Any values passed in here will override settings defined by the style.</param>
        /// <returns>The value entered by the user.</returns>
        public static Vector2 Vector2Field(GUIContent label, Vector2 value, string xLabel = "X", string yLabel = "Y", bool expandWidth = false, params GUILayoutOption[] options)
        {
            float height = EditorGUIUnity.GetPropertyHeight(SerializedPropertyType.Vector2, label);
            var rect = EditorGUILayoutUnity.GetControlRect(true, height, EditorStyles.numberField, options);

            return EditorGUI.Vector2Field(rect, label, value, xLabel, yLabel, expandWidth);
        }

        /// <summary>
        /// Make an X, Y, and Z integer field for entering a Vector2Int.
        /// </summary>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="value">The value to edit.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        /// <param name="options">An optional list of layout options that specify extra layout properties. Any values passed in here will override settings defined by the style.</param>
        /// <returns>The value entered by the user.</returns>
        public static Vector2Int Vector2IntField(string label, Vector2Int value, string xLabel = "X", string yLabel = "Y", bool expandWidth = false, params GUILayoutOption[] options)
        {
            return Vector2IntField(EditorGUIUtility.TrTempContent(label), value, xLabel, yLabel, expandWidth, options);
        }

        /// <summary>
        /// Make an X and Y integer field for entering a Vector2Int.
        /// </summary>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="value">The value to edit.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        /// <param name="options">An optional list of layout options that specify extra layout properties. Any values passed in here will override settings defined by the style.</param>
        /// <returns>The value entered by the user.</returns>
        public static Vector2Int Vector2IntField(GUIContent label, Vector2Int value, string xLabel = "X", string yLabel = "Y", bool expandWidth = false, params GUILayoutOption[] options)
        {
            float height = EditorGUIUnity.GetPropertyHeight(SerializedPropertyType.Vector2Int, label);
            var rect = EditorGUILayoutUnity.GetControlRect(true, height, EditorStyles.numberField, options);

            return EditorGUI.Vector2IntField(rect, label, value, xLabel, yLabel, expandWidth);
        }

        /// <summary>
        /// Make an X, Y, and Z field for entering a Vector3.
        /// </summary>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="value">The value to edit.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="zLabel">Label to display for the Z field.</param>
        /// <param name="options">An optional list of layout options that specify extra layout properties. Any values passed in here will override settings defined by the style.</param>
        /// <returns>The value entered by the user.</returns>
        public static Vector3 Vector3Field(string label, Vector3 value, string xLabel = "X", string yLabel = "Y", string zLabel = "Z", params GUILayoutOption[] options)
        {
            return Vector3Field(EditorGUIUtility.TrTempContent(label), value, xLabel, yLabel, zLabel, options);
        }

        /// <summary>
        /// Make an X, Y, and Z field for entering a Vector3.
        /// </summary>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="value">The value to edit.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="zLabel">Label to display for the Z field.</param>
        /// <param name="options">An optional list of layout options that specify extra layout properties. Any values passed in here will override settings defined by the style.</param>
        /// <returns>The value entered by the user.</returns>
        public static Vector3 Vector3Field(GUIContent label, Vector3 value, string xLabel = "X", string yLabel = "Y", string zLabel = "Z", params GUILayoutOption[] options)
        {
            float height = EditorGUIUnity.GetPropertyHeight(SerializedPropertyType.Vector3, label);
            var rect = EditorGUILayoutUnity.GetControlRect(true, height, EditorStyles.numberField, options);

            return EditorGUI.Vector3Field(rect, label, value, xLabel, yLabel, zLabel);
        }

        /// <summary>
        /// Make an X, Y, and Z integer field for entering a Vector3Int.
        /// </summary>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="value">The value to edit.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="zLabel">Label to display for the Z field.</param>
        /// <param name="options">An optional list of layout options that specify extra layout properties. Any values passed in here will override settings defined by the style.</param>
        /// <returns>The value entered by the user.</returns>
        public static Vector3Int Vector3IntField(string label, Vector3Int value, string xLabel = "X", string yLabel = "Y", string zLabel = "Z", params GUILayoutOption[] options)
        {
            return Vector3IntField(EditorGUIUtility.TrTempContent(label), value, xLabel, yLabel, zLabel, options);
        }

        /// <summary>
        /// Make an X, Y, and Z integer field for entering a Vector3Int.
        /// </summary>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="value">The value to edit.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="zLabel">Label to display for the Z field.</param>
        /// <param name="options">An optional list of layout options that specify extra layout properties. Any values passed in here will override settings defined by the style.</param>
        /// <returns>The value entered by the user.</returns>
        public static Vector3Int Vector3IntField(GUIContent label, Vector3Int value, string xLabel = "X", string yLabel = "Y", string zLabel = "Z", params GUILayoutOption[] options)
        {
            float height = EditorGUIUnity.GetPropertyHeight(SerializedPropertyType.Vector3Int, label);
            var rect = EditorGUILayoutUnity.GetControlRect(true, height, EditorStyles.numberField, options);

            return EditorGUI.Vector3IntField(rect, label, value, xLabel, yLabel, zLabel);
        }

        /// <summary>
        /// Make an X, Y, Z, and W field for entering a Vector4.
        /// </summary>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="value">The value to edit.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="zLabel">Label to display for the Z field.</param>
        /// <param name="wLabel">Label to display for the W field.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        /// <param name="stackFields">Stack the fields in a 2x2 format.</param>
        /// <param name="options">An optional list of layout options that specify extra layout properties. Any values passed in here will override settings defined by the style.</param>
        /// <returns>The value entered by the user.</returns>
        public static Vector4 Vector4Field(string label, Vector4 value, string xLabel = "X", string yLabel = "Y", string zLabel = "Z", string wLabel = "W", bool expandWidth = true, bool stackFields = false, params GUILayoutOption[] options)
        {
            return Vector4Field(EditorGUIUtility.TrTempContent(label), value, xLabel, yLabel, zLabel, wLabel, expandWidth, stackFields, options);
        }

        /// <summary>
        /// Make an X, Y, Z, and W field for entering a Vector4.
        /// </summary>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="value">The value to edit.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="zLabel">Label to display for the Z field.</param>
        /// <param name="wLabel">Label to display for the W field.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        /// <param name="stackFields">Stack the fields in a 2x2 format.</param>
        /// <param name="options">An optional list of layout options that specify extra layout properties. Any values passed in here will override settings defined by the style.</param>
        /// <returns>The value entered by the user.</returns>
        public static Vector4 Vector4Field(GUIContent label, Vector4 value, string xLabel = "X", string yLabel = "Y", string zLabel = "Z", string wLabel = "W", bool expandWidth = true, bool stackFields = false, params GUILayoutOption[] options)
        {
            float height = EditorGUIUnity.GetPropertyHeight(SerializedPropertyType.Vector4, label);

            if (stackFields)
            {
                height += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            }

            var rect = EditorGUILayoutUnity.GetControlRect(true, height, EditorStyles.numberField, options);

            return EditorGUI.Vector4Field(rect, label, value, xLabel, yLabel, zLabel, wLabel, expandWidth, stackFields);
        }

        /// <summary>
        /// Makes a multi-control with text fields for entering multiple floats in the same line.
        /// </summary>
        /// <param name="label">Prefix label to display in front of the field.</param>
        /// <param name="subLabels">Array with labels to show in front of each field.</param>
        /// <param name="values">Array with the values to edit.</param>
        /// <param name="columns">The amount of columns to display per row.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        /// <param name="options">An optional list of layout options that specify extra layout properties. Any values passed in here will override settings defined by the style.</param>
        public static void MultiFloatField(string label, string[] subLabels, float[] values, int columns = 3, bool expandWidth = false, params GUILayoutOption[] options)
        {
            MultiFloatField(EditorGUIUtility.TrTempContent(label), subLabels, values, columns, expandWidth, options);
        }

        /// <summary>
        /// Makes a multi-control with text fields for entering multiple floats in the same line.
        /// </summary>
        /// <param name="label">Prefix label to display in front of the field.</param>
        /// <param name="subLabels">Array with labels to show in front of each field.</param>
        /// <param name="values">Array with the values to edit.</param>
        /// <param name="columns">The amount of columns to display per row.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        /// <param name="options">An optional list of layout options that specify extra layout properties. Any values passed in here will override settings defined by the style.</param>
        public static void MultiFloatField(GUIContent label, string[] subLabels, float[] values, int columns = 3, bool expandWidth = false, params GUILayoutOption[] options)
        {
            columns = Mathf.Max(columns, 1);
            float height = EditorGUIUnity.GetPropertyHeight(SerializedPropertyType.Vector3, label);
            int rows = EditorGUI.CalcRows(values.Length, columns);
            height += (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * (rows - 1);
            var rect = EditorGUILayoutUnity.GetControlRect(true, height, EditorStyles.numberField, options);

            EditorGUI.MultiFloatField(rect, label, subLabels, values, columns, expandWidth);
        }

        /// <summary>
        /// Makes a multi-control with text fields for entering multiple integers in the same line.
        /// </summary>
        /// <param name="label">Prefix label to display in front of the field.</param>
        /// <param name="subLabels">Array with labels to show in front of each field.</param>
        /// <param name="values">Array with the values to edit.</param>
        /// <param name="columns">The amount of columns to display per row.</param>
        /// <param name="options">An optional list of layout options that specify extra layout properties. Any values passed in here will override settings defined by the style.</param>
        public static void MultiIntField(string label, string[] subLabels, int[] values, int columns = 3, bool expandWidth = false, params GUILayoutOption[] options)
        {
            MultiIntField(EditorGUIUtility.TrTempContent(label), subLabels, values, columns, expandWidth, options);
        }

        /// <summary>
        /// Makes a multi-control with text fields for entering multiple integers in the same line.
        /// </summary>
        /// <param name="label">Prefix label to display in front of the field.</param>
        /// <param name="subLabels">Array with labels to show in front of each field.</param>
        /// <param name="values">Array with the values to edit.</param>
        /// <param name="columns">The amount of columns to display per row.</param>
        /// <param name="options">An optional list of layout options that specify extra layout properties. Any values passed in here will override settings defined by the style.</param>
        public static void MultiIntField(GUIContent label, string[] subLabels, int[] values, int columns = 3, bool expandWidth = false, params GUILayoutOption[] options)
        {
            columns = Mathf.Max(columns, 1);
            float height = EditorGUIUnity.GetPropertyHeight(SerializedPropertyType.Vector3, label);
            int rows = EditorGUI.CalcRows(values.Length, columns);
            height += (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * (rows - 1);
            var rect = EditorGUILayoutUnity.GetControlRect(true, height, EditorStyles.numberField, options);

            EditorGUI.MultiIntField(rect, label, subLabels, values, columns, expandWidth);
        }
    }
}
