using Il2CppMonomiPark.World;
using MelonLoader;
using UnityEngine;

namespace UnlockAllRanchExpansions
{
    internal class Entry : MelonMod
    {
        public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
        {
            if (sceneName != "LoadScene")
                return;

            foreach (var item in Resources.FindObjectsOfTypeAll<AccessDoor>())
            {
                try
                {
                    if (item._model == null || item._model.state == AccessDoor.State.OPEN)
                        continue;

                    item._model.state = AccessDoor.State.OPEN;
                    item.Awake();
                }
                catch (System.Exception e)
                {
                    LoggerInstance.Error($"Failed to unlock {item?.name}", e);
                }
            }
        }
    }
}
