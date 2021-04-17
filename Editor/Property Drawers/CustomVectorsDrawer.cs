using UnityEditor;
using UnityEngine;

namespace Dabblesoft.Unity.Editor.CustomVectors
{
    static class CustomVectorUtils
    {
        internal static void ErrorMessage(Rect position, GUIContent label, PropertyAttribute customVector, string compatibleTypes)
        {
            string customVectorTypeName = customVector.GetType().Name;
            string attributeText = "Attribute";
            int attributeIndex = customVectorTypeName.IndexOf(attributeText);
            string customVectorName = customVectorTypeName.Remove(attributeIndex);

            UnityEditor.EditorGUI.LabelField(position, label.text, "Use " + customVectorName + " with " + compatibleTypes + ".");
        }

        internal static GUIContent GetLabel(GUIContent label, string customLabel)
        {
            return customLabel == "" ? label : EditorGUIUtility.TrTextContent(customLabel);
        }
    }

    [CustomPropertyDrawer(typeof(CustomVector2Attribute))]
    class CustomVector2Drawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            CreateCustomVectorField(position, property, label, attribute);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.Vector2 && 
                property.propertyType != SerializedPropertyType.Vector2Int) 
                return base.GetPropertyHeight(property, label);

            int rows = EditorGUIUtility.wideMode ? 1 : 2;
            float height = base.GetPropertyHeight(property, label) * rows;

            return height + EditorGUIUtility.standardVerticalSpacing;
        }

        internal static void CreateCustomVectorField(Rect position, SerializedProperty property, GUIContent label, PropertyAttribute attribute)
        {
            CustomVector2Attribute customVector = (CustomVector2Attribute)attribute;

            label = CustomVectorUtils.GetLabel(label, customVector.label);

            if (property.propertyType == SerializedPropertyType.Vector2)
            {
                property.vector2Value = EditorGUI.Vector2Field(position, label, property.vector2Value,
                    customVector.xLabel, customVector.yLabel, customVector.expandWidth);
            }
            else if (property.propertyType == SerializedPropertyType.Vector2Int)
            {
                property.vector2IntValue = EditorGUI.Vector2IntField(position, label, property.vector2IntValue,
                    customVector.xLabel, customVector.yLabel, customVector.expandWidth);
            }
            else CustomVectorUtils.ErrorMessage(position, label, customVector, "Vector2 or Vector2Int");
        }
    }

    [CustomPropertyDrawer(typeof(CustomVector3Attribute))]
    class CustomVector3Drawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            CreateCustomVectorField(position, property, label, attribute);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.Vector3 && 
                property.propertyType != SerializedPropertyType.Vector3Int) 
                return base.GetPropertyHeight(property, label);

            int rows = EditorGUIUtility.wideMode ? 1 : 2;
            float height = base.GetPropertyHeight(property, label) * rows;

            return height + EditorGUIUtility.standardVerticalSpacing;
        }

        internal static void CreateCustomVectorField(Rect position, SerializedProperty property, GUIContent label, PropertyAttribute attribute)
        {
            CustomVector3Attribute customVector = (CustomVector3Attribute)attribute;

            if (customVector != null)
                label = CustomVectorUtils.GetLabel(label, customVector.label);

            if (property.propertyType == SerializedPropertyType.Vector3)
            {
                property.vector3Value = EditorGUI.Vector3Field(position, label, property.vector3Value,
                    customVector.xLabel, customVector.yLabel, customVector.zLabel);
            }
            else if (property.propertyType == SerializedPropertyType.Vector3Int)
            {
                property.vector3IntValue = EditorGUI.Vector3IntField(position, label, property.vector3IntValue,
                    customVector.xLabel, customVector.yLabel, customVector.zLabel);
            }
            else CustomVectorUtils.ErrorMessage(position, label, customVector, "Vector3 or Vector3Int");
        }
    }

    [CustomPropertyDrawer(typeof(CustomVector4Attribute))]
    class CustomVector4Drawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            CreateCustomVectorField(position, property, label, attribute);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.Vector4) 
                return base.GetPropertyHeight(property, label);

            float rows = EditorGUIUtility.wideMode ? 1 : 2;

            if (property.isExpanded)
            {
                float fieldHeight = base.GetPropertyHeight(property, label) + EditorGUIUtility.standardVerticalSpacing;
                float height = base.GetPropertyHeight(property, label) * rows;

                return height + EditorGUIUtility.standardVerticalSpacing + (fieldHeight * 4);
            }
            else
            {
                float height = base.GetPropertyHeight(property, label) * rows;

                return height + EditorGUIUtility.standardVerticalSpacing;
            }
        }

        internal static void CreateCustomVectorField(Rect position, SerializedProperty property, GUIContent label, PropertyAttribute attribute)
        {
            CustomVector4Attribute customVector = (CustomVector4Attribute)attribute;

            label = CustomVectorUtils.GetLabel(label, customVector.label);

            if (property.propertyType == SerializedPropertyType.Vector4)
            {
                string foldoutLabel = label.text;
                Vector4 v4Value = property.vector4Value;

                float fieldHeight = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                int rows = EditorGUIUtility.wideMode ? 1 : 2;
                float foldoutFieldsHeight = UnityEditor.EditorGUI.GetPropertyHeight(property) - (fieldHeight * rows);

                Rect foldoutPos = position;
                foldoutPos.y -= foldoutFieldsHeight / 2;

                property.isExpanded = UnityEditor.EditorGUI.Foldout(foldoutPos, property.isExpanded, foldoutLabel);

                if (property.isExpanded)
                {
                    GUIContent[] subLabels = new GUIContent[]
                    {
                        EditorGUIUtility.TrTextContent(customVector.xLabel),
                        EditorGUIUtility.TrTextContent(customVector.yLabel),
                        EditorGUIUtility.TrTextContent(customVector.zLabel),
                        EditorGUIUtility.TrTextContent(customVector.wLabel)
                    };

                    float[] values = new float[]
                    {
                        v4Value.x,
                        v4Value.y,
                        v4Value.z,
                        v4Value.w
                    };

                    float spacing = EditorGUIUtility.wideMode ? 0 : EditorGUIUtility.singleLineHeight + 1;
                    position.y += EditorGUIUtility.standardVerticalSpacing + spacing;
                    position.height = EditorGUIUtility.singleLineHeight;

                    using (var check = new UnityEditor.EditorGUI.ChangeCheckScope())
                    {
                        float oldLabelWidth = EditorGUIUtility.labelWidth;
                        int oldIndentLevel = UnityEditor.EditorGUI.indentLevel;
                        UnityEditor.EditorGUI.indentLevel = 1;

                        for (int i = 0; i < values.Length; i++)
                        {
                            position.y += fieldHeight;
                            values[i] = UnityEditor.EditorGUI.FloatField(position, subLabels[i], values[i]);
                        }

                        EditorGUIUtility.labelWidth = oldLabelWidth;
                        UnityEditor.EditorGUI.indentLevel = oldIndentLevel;

                        if (check.changed)
                        {
                            v4Value.x = values[0];
                            v4Value.y = values[1];
                            v4Value.z = values[2];
                            v4Value.w = values[3];
                        }
                    }
                }

                property.vector4Value = v4Value;
            }
            else CustomVectorUtils.ErrorMessage(position, label, customVector, "Vector4");
        }
    }

    [CustomPropertyDrawer(typeof(CustomVector4InlineAttribute))]
    class CustomVector4InlineDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            CreateCustomVectorField(position, property, label, attribute);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.Vector4) 
                return base.GetPropertyHeight(property, label);

            int rows = EditorGUIUtility.wideMode ? 1 : 2;
            float height = base.GetPropertyHeight(property, label) * rows;

            return height + EditorGUIUtility.standardVerticalSpacing;
        }

        internal static void CreateCustomVectorField(Rect position, SerializedProperty property, GUIContent label, PropertyAttribute attribute)
        {
            CustomVector4InlineAttribute customVector = (CustomVector4InlineAttribute)attribute;

            label = CustomVectorUtils.GetLabel(label, customVector.label);

            if (property.propertyType == SerializedPropertyType.Vector4)
            {
                property.vector4Value = EditorGUI.Vector4Field(position, label, property.vector4Value,
                    customVector.xLabel, customVector.yLabel, customVector.zLabel, customVector.wLabel, customVector.expandWidth, false);
            }
            else CustomVectorUtils.ErrorMessage(position, label, customVector, "Vector4");
        }
    }

    [CustomPropertyDrawer(typeof(CustomVector4StackedAttribute))]
    class CustomVector4StackedDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            CreateCustomVectorField(position, property, label, attribute);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.Vector4) 
                return base.GetPropertyHeight(property, label);

            int rows = EditorGUIUtility.wideMode ? 1 : 2;
            float height = base.GetPropertyHeight(property, label) * (rows + 1) + EditorGUIUtility.standardVerticalSpacing;

            return height + EditorGUIUtility.standardVerticalSpacing;
        }

        internal static void CreateCustomVectorField(Rect position, SerializedProperty property, GUIContent label, PropertyAttribute attribute)
        {
            CustomVector4StackedAttribute customVector = (CustomVector4StackedAttribute)attribute;

            label = CustomVectorUtils.GetLabel(label, customVector.label);

            if (property.propertyType == SerializedPropertyType.Vector4)
            {
                property.vector4Value = EditorGUI.Vector4Field(position, label, property.vector4Value,
                    customVector.xLabel, customVector.yLabel, customVector.zLabel, customVector.wLabel, customVector.expandWidth, true);
            }
            else CustomVectorUtils.ErrorMessage(position, label, customVector, "Vector4");
        }
    }
}
