using UnityEditor;
using UnityEngine;

using EditorGUICV = Dabblesoft.Unity.Editor.CustomVectors.EditorGUI;
using EditorGUILayoutCV = Dabblesoft.Unity.Editor.CustomVectors.EditorGUILayout;

[CanEditMultipleObjects]
[CustomEditor(typeof(CustomVectorsCustomEditorExamples))]
public class CustomVectorsCustomEditorExamplesEditor : Editor
{
    SerializedProperty customV2;
    SerializedProperty customV2Layout;
    SerializedProperty customVector2Expanded;

    SerializedProperty customV3;
    SerializedProperty customV3Layout;

    SerializedProperty customV4;
    SerializedProperty customV4Layout;
    SerializedProperty customVector4Expanded;

    SerializedProperty customV4Stacked;
    SerializedProperty customV4StackedLayout;
    SerializedProperty customVector4StackedExpanded;

    SerializedProperty customMulti;
    SerializedProperty customMultiLayout;
    SerializedProperty customMultiExpanded;

    void OnEnable()
    {
        customV2 = serializedObject.FindProperty("customV2");
        customV2Layout = serializedObject.FindProperty("customV2Layout");
        customVector2Expanded = serializedObject.FindProperty("customVector2Expanded");

        customV3 = serializedObject.FindProperty("customV3");
        customV3Layout = serializedObject.FindProperty("customV3Layout");

        customV4 = serializedObject.FindProperty("customV4");
        customV4Layout = serializedObject.FindProperty("customV4Layout");
        customVector4Expanded = serializedObject.FindProperty("customVector4Expanded");

        customV4Stacked = serializedObject.FindProperty("customV4Stacked");
        customV4StackedLayout = serializedObject.FindProperty("customV4StackedLayout");
        customVector4StackedExpanded = serializedObject.FindProperty("customVector4StackedExpanded");

        customMulti = serializedObject.FindProperty("customMulti");
        customMultiLayout = serializedObject.FindProperty("customMultiLayout");
        customMultiExpanded = serializedObject.FindProperty("customMultiExpanded");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // Create a Custom Vector2 or Vector2Int field.
        float v2Height = EditorGUI.GetPropertyHeight(SerializedPropertyType.Vector2, new GUIContent());
        v2Height = EditorGUIUtility.wideMode ? v2Height : v2Height + EditorGUIUtility.singleLineHeight;
        Rect v2Rect = EditorGUILayout.GetControlRect(true, v2Height, EditorStyles.numberField);

        customV2.vector2Value = EditorGUICV.Vector2Field(v2Rect, "CustomVector2", customV2.vector2Value, "xLabel", "yLabel");
        customV2Layout.vector2Value = EditorGUILayoutCV.Vector2Field("CustomVector2Layout", customV2Layout.vector2Value, xLabel: "xLabel");
        customVector2Expanded.vector2Value = EditorGUILayoutCV.Vector2Field("CustomVector2Layout Expanded", customVector2Expanded.vector2Value, xLabel: "xLabel", expandWidth: true);

        // Can also be used with Vector2Int.
        //customV2.vector2IntValue = EditorGUICV.Vector2IntField(v2Rect, "CustomVector2", customV2.vector2IntValue, "xLabel", "yLabel");
        //customV2Layout.vector2IntValue = EditorGUILayoutCV.Vector2IntField("CustomVector2Layout", customV2Layout.vector2IntValue, xLabel: "xLabel");
        //customVector2Expanded.vector2IntValue = EditorGUILayoutCV.Vector2IntField("CustomVector2Layout Expanded", customVector2Expanded.vector2IntValue, xLabel: "xLabel", expandWidth: true);

        EditorGUILayout.Space(20);

        // Create a Custom Vector3 or Vector3Int field.
        float v3Height = EditorGUI.GetPropertyHeight(SerializedPropertyType.Vector3, new GUIContent());
        v3Height = EditorGUIUtility.wideMode ? v3Height : v3Height + EditorGUIUtility.singleLineHeight;
        Rect v3Rect = EditorGUILayout.GetControlRect(true, v3Height, EditorStyles.numberField);

        customV3.vector3Value = EditorGUICV.Vector3Field(v3Rect, "CustomVector3", customV3.vector3Value, "xLabel", "yLabel", "zLabel");
        customV3Layout.vector3Value = EditorGUILayoutCV.Vector3Field("CustomVector3Layout", customV3Layout.vector3Value, xLabel: "xLabel", zLabel: "zLabel");

        // Can also be used with Vector3Int.
        //customV3.vector3IntValue = EditorGUICV.Vector3IntField(v3Rect, "CustomVector3", customV3.vector3IntValue, "xLabel", "yLabel", "zLabel");
        //customV3Layout.vector3IntValue = EditorGUILayoutCV.Vector3IntField("CustomVector3Layout", customV3Layout.vector3IntValue, xLabel: "xLabel", zLabel: "zLabel");

        EditorGUILayout.Space(20);

        // Create a Custom Vector4 field.
        float v4Height = EditorGUI.GetPropertyHeight(SerializedPropertyType.Vector4, new GUIContent());
        v4Height = EditorGUIUtility.wideMode ? v4Height : v4Height + EditorGUIUtility.singleLineHeight;
        Rect v4Rect = EditorGUILayout.GetControlRect(true, v4Height, EditorStyles.numberField);

        customV4.vector4Value = EditorGUICV.Vector4Field(v4Rect, "CustomVector4", customV4.vector4Value, "xLabel", "yLabel", "zLabel", "wLabel", false);
        customV4Layout.vector4Value = EditorGUILayoutCV.Vector4Field("CustomVector4Layout", customV4Layout.vector4Value, xLabel: "xLabel", zLabel: "zLabel", expandWidth: false);
        customVector4Expanded.vector4Value = EditorGUILayoutCV.Vector4Field("CustomVector4Layout Expanded", customVector4Expanded.vector4Value, xLabel: "xLabel", zLabel: "zLabel");

        EditorGUILayout.Space(20);

        // Create a Custom Vector4 field that displays as stacked fields.
        float v4StackedHeight = EditorGUI.GetPropertyHeight(SerializedPropertyType.Vector4, new GUIContent()) * 2;
        v4StackedHeight = EditorGUIUtility.wideMode ? v4StackedHeight : v4StackedHeight + EditorGUIUtility.singleLineHeight;
        Rect v4StackedRect = EditorGUILayout.GetControlRect(true, v4StackedHeight, EditorStyles.numberField);

        customV4Stacked.vector4Value = EditorGUICV.Vector4Field(v4StackedRect, "CustomVector4Stacked", customV4Stacked.vector4Value, "xLabel", "yLabel", "zLabel", "wLabel", false, true);
        customV4StackedLayout.vector4Value = EditorGUILayoutCV.Vector4Field("CustomVector4StackedLayout", customV4StackedLayout.vector4Value, xLabel: "xLabel", zLabel: "zLabel", expandWidth: false, stackFields: true);
        customVector4StackedExpanded.vector4Value = EditorGUILayoutCV.Vector4Field("CustomVector4StackedLayout Expanded", customVector4StackedExpanded.vector4Value, xLabel: "xLabel", zLabel: "zLabel", stackFields: true);

        EditorGUILayout.Space(20);

        // Create a Custom MultiFloat or MultiInt field.
        var subLabels = new string[]
        {
            "label1", "label2", "label3", "label4", "label5",
            "label6", "label7"
        };

        var subLabelsLayout = new string[]
        {
            "label1", "label2", "label3", "label4", "label5",
            "label6", "label7"
        };

        int columns = 5;

        float mfHeight = EditorGUI.GetPropertyHeight(SerializedPropertyType.Vector3, new GUIContent()) * 2;
        mfHeight = EditorGUIUtility.wideMode ? mfHeight : mfHeight + EditorGUIUtility.singleLineHeight;
        Rect mfRect = EditorGUILayout.GetControlRect(true, mfHeight, EditorStyles.numberField);

        var multiValues = new float[customMulti.arraySize];

        for (int i = 0; i < customMulti.arraySize; i++)
        {
            multiValues[i] = customMulti.GetArrayElementAtIndex(i).floatValue;
        }

        EditorGUICV.MultiFloatField(mfRect, "CustomVectors MultiFloat", subLabels, multiValues, columns);

        for (int i = 0; i < multiValues.Length; i++)
        {
            customMulti.GetArrayElementAtIndex(i).floatValue = multiValues[i];
        }

        var multiLayoutValues = new float[customMultiLayout.arraySize];

        for (int i = 0; i < customMultiLayout.arraySize; i++)
        {
            multiLayoutValues[i] = customMultiLayout.GetArrayElementAtIndex(i).floatValue;
        }

        EditorGUILayoutCV.MultiFloatField("CustomVectors MultiFloatLayout", subLabelsLayout, multiLayoutValues, columns);

        for (int i = 0; i < multiLayoutValues.Length; i++)
        {
            customMultiLayout.GetArrayElementAtIndex(i).floatValue = multiLayoutValues[i];
        }

        var multiExpandedValues = new float[customMultiExpanded.arraySize];

        for (int i = 0; i < customMultiExpanded.arraySize; i++)
        {
            multiExpandedValues[i] = customMultiExpanded.GetArrayElementAtIndex(i).floatValue;
        }

        EditorGUILayoutCV.MultiFloatField("CustomVectors MultiFloatLayout Expanded", subLabelsLayout, multiExpandedValues, columns, true);

        for (int i = 0; i < multiExpandedValues.Length; i++)
        {
            customMultiExpanded.GetArrayElementAtIndex(i).floatValue = multiExpandedValues[i];
        }

        // Can also be used with ints.
        /*var multiValues = new int[customMulti.arraySize];

        for (int i = 0; i < customMulti.arraySize; i++)
        {
            multiValues[i] = customMulti.GetArrayElementAtIndex(i).intValue;
        }

        EditorGUICV.MultiIntField(mfRect, "CustomVectors MultiInt", subLabels, multiValues, columns);

        for (int i = 0; i < multiValues.Length; i++)
        {
            customMulti.GetArrayElementAtIndex(i).intValue = multiValues[i];
        }

        var multiLayoutValues = new int[customMultiLayout.arraySize];

        for (int i = 0; i < customMultiLayout.arraySize; i++)
        {
            multiLayoutValues[i] = customMultiLayout.GetArrayElementAtIndex(i).intValue;
        }

        EditorGUILayoutCV.MultiIntField("CustomVectors MultiIntLayout", subLabelsLayout, multiLayoutValues, columns);

        for (int i = 0; i < multiLayoutValues.Length; i++)
        {
            customMultiLayout.GetArrayElementAtIndex(i).intValue = multiLayoutValues[i];
        }

        var multiExpandedValues = new int[customMultiExpanded.arraySize];

        for (int i = 0; i < customMultiExpanded.arraySize; i++)
        {
            multiExpandedValues[i] = customMultiExpanded.GetArrayElementAtIndex(i).intValue;
        }

        EditorGUILayoutCV.MultiIntField("CustomVectors MultiIntLayout Expanded", subLabelsLayout, multiExpandedValues, columns, true);

        for (int i = 0; i < multiExpandedValues.Length; i++)
        {
            customMultiExpanded.GetArrayElementAtIndex(i).intValue = multiExpandedValues[i];
        }*/

        serializedObject.ApplyModifiedProperties();
    }
}

[ExecuteAlways]
public class CustomVectorsCustomEditorExamples : MonoBehaviour
{
    public Vector2 customV2 = Vector2.one;
    public Vector2 customV2Layout = Vector2.one;
    public Vector2 customVector2Expanded = Vector2.one;

    // Can also be used with Vector2Int.
    //public Vector2Int customV2 = Vector2Int.one;
    //public Vector2Int customV2Layout = Vector2Int.one;
    //public Vector2Int customVector2Expanded = Vector2Int.one;

    public Vector3 customV3 = Vector3.one;
    public Vector3 customV3Layout = Vector3.one;

    // Can also be used with Vector3Int.
    //public Vector3Int customV3 = Vector3Int.one;
    //public Vector3Int customV3Layout = Vector3Int.one;

    public Vector4 customV4 = Vector4.one;
    public Vector4 customV4Layout = Vector4.one;
    public Vector4 customVector4 = Vector4.one;
    public Vector4 customVector4Expanded = Vector4.one;

    public Vector4 customV4Stacked = Vector4.one;
    public Vector4 customV4StackedLayout = Vector4.one;
    public Vector4 customVector4StackedExpanded = Vector4.one;

    public float[] customMulti = new float[] { 1, 2, 3, 4, 5, 6, 7 };
    public float[] customMultiLayout = new float[] { 1, 2, 3, 4, 5, 6, 7 };
    public float[] customMultiExpanded = new float[] { 1, 2, 3, 4, 5, 6, 7 };

    // Can also be used with Int[].
    //public int[] customMulti = new int[] { 1, 2, 3, 4, 5, 6, 7 };
    //public int[] customMultiLayout = new int[] { 1, 2, 3, 4, 5, 6, 7 };
    //public int[] customMultiExpanded = new int[] { 1, 2, 3, 4, 5, 6, 7 };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("customV2: " + customV2);
        //Debug.Log("customV2Layout: " + customV2Layout);
        //Debug.Log("customVector2Expanded: " + customVector2Expanded);

        //Debug.Log("customV3: " + customV3);
        //Debug.Log("customV3Layout: " + customV3Layout);

        //Debug.Log("customVector4: " + customVector4);
        //Debug.Log("customV4Layout: " + customV4Layout);
        //Debug.Log("customVector4Expanded: " + customVector4Expanded);

        //Debug.Log("customV4Stacked: " + customV4Stacked);
        //Debug.Log("customV4StackedLayout: " + customV4StackedLayout);
        //Debug.Log("customVector4StackedExpanded: " + customVector4StackedExpanded);

        //Debug.Log("customMulti: " + customMulti);
        //Debug.Log("customMultiLayout: " + customMultiLayout);
        //Debug.Log("customMultiExpanded: " + customMultiExpanded);
    }
}
