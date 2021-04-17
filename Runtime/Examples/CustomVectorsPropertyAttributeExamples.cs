using UnityEngine;

using Dabblesoft.Unity.Editor.CustomVectors;

[ExecuteAlways]
public class CustomVectorsPropertyAttributeExamples : MonoBehaviour
{
    [CustomVector2("CustomVector2 Label", "xLabel", "yLabel")]
    public Vector2 customV2 = Vector2.one;
    //public Vector2Int customV2 = Vector2Int.one; // Can also be used with Vector2Int.

    [CustomVector2(xLabel: "xLabel", expandWidth: true)]
    public Vector2 customVector2Expanded = Vector2.one;
    //public Vector2Int customVector2Expanded = Vector2Int.one; // Can also be used with Vector2Int.

    [Space(20)]

    [CustomVector3("CustomVector3 Label", "xLabel", "yLabel", "zLabel")]
    public Vector3 customV3 = Vector3.one;
    //public Vector3Int customV3 = Vector3Int.one;

    [CustomVector3(xLabel: "xLabel", zLabel: "zLabel")]
    public Vector3 customVector3 = Vector3.one;
    //public Vector3Int customVector3 = Vector3Int.one; // Can also be used with Vector3Int.

    [Space(20)]

    [CustomVector4("CustomVector4 Label", "xLabel", "yLabel", "zLabel", "wLabel")]
    public Vector4 customV4 = Vector4.one;

    [CustomVector4(xLabel: "xLabel", zLabel: "zLabel")]
    public Vector4 customVector4 = Vector4.one;

    [Space(20)]

    [CustomVector4Inline("CustomVector4Inline Label", "xLabel", "yLabel", "zLabel", "wLabel", false)]
    public Vector4 customV4Inline = Vector4.one;

    [CustomVector4Inline(xLabel: "xLabel", zLabel: "zLabel")]
    public Vector4 customVector4InlineExpanded = Vector4.one;

    [Space(20)]

    [CustomVector4Stacked("CustomVector4Stacked Label", "xLabel", "yLabel", "zLabel", "wLabel", false)]
    public Vector4 customV4Stacked = Vector4.one;

    [CustomVector4Stacked(xLabel: "xLabel", zLabel: "zLabel")]
    public Vector4 customVector4StackedExpanded = Vector4.one;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("customV2: " + customV2);
        //Debug.Log("customVector2Expanded: " + customVector2Expanded);

        //Debug.Log("customV3: " + customV3);
        //Debug.Log("customVector3: " + customVector3);

        //Debug.Log("customVector4: " + customVector4);

        //Debug.Log("customV4Inline: " + customV4Inline);
        //Debug.Log("customVector4InlineExpanded: " + customVector4InlineExpanded);

        //Debug.Log("customV4Stacked: " + customV4Stacked);
        //Debug.Log("customVector4StackedExpanded: " + customVector4StackedExpanded);
    }
}
