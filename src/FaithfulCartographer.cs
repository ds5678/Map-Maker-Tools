using Harmony;
using System.Collections.Generic;
using UnityEngine;

namespace MapMakerTools
{
    public class ShowMissingFaithfulCartographerPlaces
    {
        public static void OnLoad()
        {
            uConsole.RegisterCommand("FaithfulCartographer-ShowIncompleteRegions", new uConsole.DebugCommand(ShowIncompleteRegions));
            uConsole.RegisterCommand("FaithfulCartographer-ShowMissingPlacesInCurrentRegion", new uConsole.DebugCommand(ShowMissingPlacesInCurrentRegion));
        }

        private static void ShowIncompleteRegions()
        {
            int count = 0;

            Dictionary<string, bool> mappedRegions = GameManager.GetAchievementManagerComponent().m_MappedRegions;
            foreach (string eachRegion in mappedRegions.Keys)
            {
                if (!mappedRegions[eachRegion])
                {
                    Debug.Log("Incomplete Region: " + eachRegion);
                    count++;
                }
            }

            Debug.Log(count + " incomplete regions.");
        }

        private static void ShowMissingPlacesInCurrentRegion()
        {
            int count = 0;

            MapDetailManager mapDetailManager = GameManager.GetMapDetailManager();
            List<MapDetail> m_MapDetailObjects = (List<MapDetail>)AccessTools.Field(mapDetailManager.GetType(), "m_MapDetailObjects").GetValue(mapDetailManager);
            foreach (MapDetail eachMapDetail in m_MapDetailObjects)
            {
                if (eachMapDetail.m_IconType != MapIcon.MapIconType.DetailEntry && eachMapDetail.gameObject.activeInHierarchy)
                {
                    if (!eachMapDetail.m_IsUnlocked)
                    {
                        Debug.Log("Missing: " + eachMapDetail.m_LocID + ", requiresInteraction = " + eachMapDetail.m_RequiresInteraction + ", location = " + eachMapDetail.transform.position);
                        count++;
                    }
                }
            }

            Debug.Log(count + " missing locations");
        }
    }
}
