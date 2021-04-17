using UnityEngine;

namespace Dabblesoft.Unity.Editor.CustomVectors
{
    /// <summary>
    /// Use this PropertyAttribute to customize a Vector2 or Vector2Int field in the Inspector.
    /// </summary>
    public class CustomVector2Attribute : PropertyAttribute
    {
        public string label;

        public string xLabel;
        public string yLabel;

        public bool expandWidth;

        /// <summary>
        /// Use this PropertyAttribute to customize a Vector2 or Vector2Int field in the Inspector.
        /// </summary>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        public CustomVector2Attribute(string label = "", string xLabel = "X", string yLabel = "Y", bool expandWidth = false)
        {
            this.label = string.IsNullOrWhiteSpace(label) ? "" : label;

            this.xLabel = xLabel;
            this.yLabel = yLabel;

            this.expandWidth = expandWidth;
        }
    }

    /// <summary>
    /// Use this PropertyAttribute to customize a Vector3 or Vector3Int field in the Inspector.
    /// </summary>
    public class CustomVector3Attribute : PropertyAttribute
    {
        public string label;

        public string xLabel;
        public string yLabel;
        public string zLabel;

        /// <summary>
        /// Use this PropertyAttribute to customize a Vector3 or Vector3Int field in the Inspector.
        /// </summary>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="zLabel">Label to display for the Z field.</param>
        public CustomVector3Attribute(string label = "", string xLabel = "X", string yLabel = "Y", string zLabel = "Z")
        {
            this.label = string.IsNullOrWhiteSpace(label) ? "" : label;

            this.xLabel = xLabel;
            this.yLabel = yLabel;
            this.zLabel = zLabel;
        }
    }

    /// <summary>
    /// Use this PropertyAttribute to customize a Vector4 field in the Inspector.
    /// </summary>
    public class CustomVector4Attribute : PropertyAttribute
    {
        public string label;

        public string xLabel;
        public string yLabel;
        public string zLabel;
        public string wLabel;

        /// <summary>
        /// Use this PropertyAttribute to customize a Vector4 field in the Inspector.
        /// </summary>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="zLabel">Label to display for the Z field.</param>
        /// <param name="wLabel">Label to display for the W field.</param>
        public CustomVector4Attribute(string label = "", string xLabel = "X", string yLabel = "Y", string zLabel = "Z", string wLabel = "W")
        {
            this.label = string.IsNullOrWhiteSpace(label) ? "" : label;

            this.xLabel = xLabel;
            this.yLabel = yLabel;
            this.zLabel = zLabel;
            this.wLabel = wLabel;
        }
    }

    /// <summary>
    /// Use this PropertyAttribute to customize a Vector4 field in the Inspector.
    /// </summary>
    public class CustomVector4InlineAttribute : CustomVector4Attribute
    {
        public bool expandWidth;

        /// <summary>
        /// Use this PropertyAttribute to customize a Vector4 field in the Inspector.
        /// </summary>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="zLabel">Label to display for the Z field.</param>
        /// <param name="wLabel">Label to display for the W field.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        public CustomVector4InlineAttribute(string label = "", string xLabel = "X", string yLabel = "Y", string zLabel = "Z", string wLabel = "W", bool expandWidth = true)
        {
            this.label = string.IsNullOrWhiteSpace(label) ? "" : label;

            this.xLabel = xLabel;
            this.yLabel = yLabel;
            this.zLabel = zLabel;
            this.wLabel = wLabel;

            this.expandWidth = expandWidth;
        }
    }

    /// <summary>
    /// Use this PropertyAttribute to customize a Vector4 field in the Inspector.
    /// </summary>
    public class CustomVector4StackedAttribute : CustomVector4Attribute
    {
        public bool expandWidth;

        /// <summary>
        /// Use this PropertyAttribute to customize a Vector4 field in the Inspector.
        /// </summary>
        /// <param name="label">Prefix label to display for the field.</param>
        /// <param name="xLabel">Label to display for the X field.</param>
        /// <param name="yLabel">Label to display for the Y field.</param>
        /// <param name="zLabel">Label to display for the Z field.</param>
        /// <param name="wLabel">Label to display for the W field.</param>
        /// <param name="expandWidth">Allows the vector fields to expand horizontally.</param>
        public CustomVector4StackedAttribute(string label = "", string xLabel = "X", string yLabel = "Y", string zLabel = "Z", string wLabel = "W", bool expandWidth = true)
        {
            this.label = string.IsNullOrWhiteSpace(label) ? "" : label;

            this.xLabel = xLabel;
            this.yLabel = yLabel;
            this.zLabel = zLabel;
            this.wLabel = wLabel;

            this.expandWidth = expandWidth;
        }
    }
}
