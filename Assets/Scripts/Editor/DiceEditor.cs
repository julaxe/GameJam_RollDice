using Dice;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(DiceController))]
    public class DiceEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {

            // DrawDefaultInspector();
            //
            // DiceController myScript = (DiceController) target;
            // if (GUILayout.Button("Update materials"))
            // {
            //     myScript.UpdateMaterials();
            // }
            // UnityEditor.SceneView.RepaintAll();
        }
    }
}