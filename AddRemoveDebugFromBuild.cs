using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace UnityToolsLibrary
{
    public class AddRemoveDebugFromBuild : Editor
    {
        private static List<string> symbols;
        
        [MenuItem("Sourav's Tools/Utilities/Add Log %#l")]
        public static void AddLog()
        {
            GetScriptingSymbols();
            if (!symbols.Contains("LOG"))
            {
                symbols.Add("LOG");
            }
            ResetDefineSymbols();
        }

        [MenuItem("Sourav's Tools/Utilities/Remove Log %l")]
        public static void RemoveLog()
        {
            GetScriptingSymbols();
            
            List<string> newSymbols = new List<string>();
            for (int i = 0; i < symbols.Count; i++)
            {
                if (symbols[i] == "LOG")
                {
                    continue;
                }
                
                newSymbols.Add(symbols[i]);
            }

            symbols = newSymbols;
            ResetDefineSymbols();
        }
        
        private static void GetScriptingSymbols()
        {
            symbols = new List<string>();

            string defines =
                PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);

            symbols = defines.Split(';').ToList();
        }

        private static void ResetDefineSymbols()
        {
            string defineSymbols = "";
            for (int i = 0; i < symbols.Count; i++)
            {
                defineSymbols += symbols[i] + ";";
            }

            PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup,
                defineSymbols);
        }
    }
}