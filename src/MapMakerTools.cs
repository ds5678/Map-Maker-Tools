using UnityEngine;

namespace MapMakerTools
{
    class MapMakerTools
    {
        private const float MAX_DISTANCE = 15000;

        public static void OnLoad()
        {
            uConsole.RegisterCommand("MapMaking-HideTrees", new uConsole.DebugCommand(HideTrees));
            uConsole.RegisterCommand("MapMaking-HideGrass", new uConsole.DebugCommand(HideGrass));
            uConsole.RegisterCommand("MapMaking-NoTerrainError", new uConsole.DebugCommand(NoTerrainError));
            uConsole.RegisterCommand("MapMaking-All", new uConsole.DebugCommand(All));
            uConsole.RegisterCommand("MapMaking-ResetAll", new uConsole.DebugCommand(ResetAll));
        }

        private static void HideTrees()
        {
            Terrain[] terrains = Object.FindObjectsOfType<Terrain>();
            foreach (Terrain eachTerrain in terrains)
            {
                eachTerrain.treeDistance = 0;
            }
        }

        private static void HideGrass()
        {
            Terrain[] terrains = Object.FindObjectsOfType<Terrain>();
            foreach (Terrain eachTerrain in terrains)
            {
                eachTerrain.detailObjectDensity = 0;
            }
        }

        private static void NoTerrainError()
        {
            Terrain[] terrains = Object.FindObjectsOfType<Terrain>();
            foreach (Terrain eachTerrain in terrains)
            {
                eachTerrain.heightmapPixelError = 1;
                eachTerrain.basemapDistance = MAX_DISTANCE;
                QualitySettings.lodBias = LodBias.DEFAULT_LODBIAS_PCFANCY;
            }
        }

        private static void All()
        {
            HideTrees();
            HideGrass();
            NoTerrainError();
        }

        private static void ResetAll()
        {
            GameManager.GetQualitySettingsManager().ApplyCurrentQualitySettings();
        }
    }
}
