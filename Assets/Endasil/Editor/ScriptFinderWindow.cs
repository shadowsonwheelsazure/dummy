using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using Component = UnityEngine.Component;
using Object = UnityEngine.Object;

// Created by Jonas ~Endasil~ Stoor https://www.linkedin.com/in/endasil/

namespace Assets.Scripts.Editor
{
    internal class ScriptFinderWindow : EditorWindow
    {

        [MenuItem("Tools/Find scripts in scene %#&f")]
        public static void ShowWindow()
        {
            ScriptFinderWindow window = (ScriptFinderWindow)EditorWindow.GetWindow(typeof(ScriptFinderWindow));
            window.Show();
            window.titleContent = new GUIContent("Scripts and missing components found in scene");
        }

        void OnGUI()
        {
            var scripts = Object.FindObjectsOfType<MonoBehaviour>(true);
            var gameObjectsInScene = FindObjectsOfType<GameObject>(true);
            var gameObjectsWithNullComponent = gameObjectsInScene.Where(x => x.GetComponents<Component>().Any(component => component == null));

            foreach (var component in gameObjectsWithNullComponent.Where(component => GUILayout.Button("GameObject '" + component.gameObject.name + "' has a missing component.", GetButtonStyle())))
            {
                Selection.activeGameObject = component.gameObject;
                EditorGUIUtility.PingObject(component.gameObject);
            }

            foreach (var script in scripts.Where(script => GUILayout.Button("Script '" + script.GetType().Name + "' found on '" + script.name + "'")))
            {
                var gameObject = script.gameObject;
                Selection.activeGameObject = gameObject;
                EditorGUIUtility.PingObject(gameObject);
            }
        }

        private static GUIStyle GetButtonStyle()
        {
            var s = new GUIStyle(GUI.skin.button);
            s.fontStyle = FontStyle.Bold;
            s.normal.textColor = Color.yellow;
            return s;
        }
    }
}
