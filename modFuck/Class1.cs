using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace modFuck
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class modder : BaseUnityPlugin
    {
        public const string pluginGuid = "firewolf.thecomavicioussisters.modder";
        public const string pluginName = "Fuck you";
        public const string pluginVersion = "0.0.0.0";
        public void Awake() {
            Logger.LogInfo("Hello motherfucker");
        }
        void OnEnable() {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnDisable() {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
        public void Update() {

        }
        public void OnSceneLoaded(Scene scene, LoadSceneMode mode) {

            Logger.LogDebug("NEW SCENE => " + scene.name);
            foreach (GameObject j in scene.GetRootGameObjects())
            {
                recursive(j, 0);
            }
        }
        public void recursive(GameObject data, int level) {
            string text = "Found root: NAME=" + data.name;
            Logger.LogDebug(level + "\t|" + new string(' ', (level != 0 ? level + 1 : 0)) + text );
            for (int i = 0; i < data.transform.childCount; i++)
            {
                Transform child = data.transform.GetChild(i);
                recursive(child.gameObject, level+1);
            }
        }

    }
    
}
