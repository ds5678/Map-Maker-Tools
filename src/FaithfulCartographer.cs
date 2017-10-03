using Harmony;
using System.Collections.Generic;
using UnityEngine;

namespace MapMakerTools
{
    public class ShowMissingFaithfulCartographerPlaces
    {
        public static void OnLoad()
        {
            uConsole.RegisterCommand("Faithful-Cartographer-Show-Incomplete-Regions", new uConsole.DebugCommand(ShowIncompleteRegions));
            uConsole.RegisterCommand("Faithful-Cartographer-Show-Missing-Places-In-Current-Region", new uConsole.DebugCommand(ShowMissingPlaces));
        }

        private static void ShowIncompleteRegions()
        {
            Dictionary<string, bool> mappedRegions = GameManager.GetAchievementManagerComponent().m_MappedRegions;
            foreach (string eachRegion in mappedRegions.Keys)
            {
                if (!mappedRegions[eachRegion])
                {
                    Debug.Log("Incomplete Region: " + eachRegion);
                }
            }
        }

        private static void ShowMissingPlaces()
        {
            MapDetailManager mapDetailManager = GameManager.GetMapDetailManager();

            int count = 0;
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
