using System.IO;
using UnityEditor;
using UnityEngine;

namespace UnityToolsLibrary
{
    public class DeletePlayerFiles : Editor
    {
        [MenuItem("Sourav's Tools/Utilities/Delete PlayerPrefs %&d")]
        public static void DeletePrefs()
        {
            if(EditorUtility.DisplayDialog("Delete Player Prefs?", "Are you sure you want to delete the data in PlayerPrefs?", "Yes", "No"))
            {
                PlayerPrefs.DeleteAll();
                Debug.Log("<color=red>PlayerPrefs Data Deleted</color>");
            }
        }
        
        //Validation Method
        [MenuItem("Sourav's Tools/Utilities/Delete Saved Files", true)]
        public static bool CanDeleteSavedFiles()
        {
            //Checks and return whether the game is in play or pause mode, that is we don't want the game to be play or pause mode. This function should only work in edit mode.
            return !(EditorApplication.isPaused | EditorApplication.isPlaying);
        }
        
        //Actual Method
        [MenuItem("Sourav's Tools/Utilities/Delete Saved Files %#d")]
        public static void DeleteSavedFiles()
        {
            if(EditorUtility.DisplayDialog("Delete All Saved Files?", "Are you sure you want to delete all saved files?", "Yes", "No"))
            {
                DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
                dir.Delete(true);
                Debug.Log("All saved files deleted at <color=red>" + Application.persistentDataPath+"</color>");
            }
            
        }
        
    }
}