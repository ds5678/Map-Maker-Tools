using UnityEngine;

namespace MapMakerTools
{
    class MapMakerTools
    {
        private const float MAX_DISTANCE = 15000;

        public static void OnLoad()
        {
            uConsole.RegisterCommand("MapMaking-FullTrees", new uConsole.DebugCommand(FullTrees));
            uConsole.RegisterCommand("MapMaking-FullGrass", new uConsole.DebugCommand(FullGrass));
            uConsole.RegisterCommand("MapMaking-Full", new uConsole.DebugCommand(Full));

            uConsole.RegisterCommand("MapMaking-NoTrees", new uConsole.DebugCommand(NoTrees));
            uConsole.RegisterCommand("MapMaking-NoGrass", new uConsole.DebugCommand(NoGrass));
            uConsole.RegisterCommand("MapMaking-None", new uConsole.DebugCommand(None));

            uConsole.RegisterCommand("MapMaking-NoTerrainError", new uConsole.DebugCommand(NoTerrainError));

            uConsole.RegisterCommand("MapMaking-ToggleBloom", new uConsole.DebugCommand(ToggleBloom));
            uConsole.RegisterCommand("MapMaking-ToggleContrast", new uConsole.DebugCommand(ToggleContrast));
            uConsole.RegisterCommand("MapMaking-ToggleVignette", new uConsole.DebugCommand(ToggleVignette));

            uConsole.RegisterCommand("MapMaking-ShadowDistance", new uConsole.DebugCommand(ShadowDistance));
            uConsole.RegisterCommand("MapMaking-NoShadows", new uConsole.DebugCommand(NoShadows));

            uConsole.RegisterCommand("MapMaking-Reset", new uConsole.DebugCommand(Reset));
        }

        private static void ShadowDistance()
        {
            if (uConsole.GetNumParameters() != 1)
            {
                Debug.LogError("  Exactly one parameter required.");
                return;
            }

            var distance = uConsole.GetFloat();
            Debug.Log("  Changing shadow distance from " + QualitySettings.shadowDistance + " to " + distance);
            QualitySettings.shadowDistance = distance;
        }

        private static void ToggleBloom()
        {
            GameManager.GetCameraEffects().m_Bloom.active = !GameManager.GetCameraEffects().m_Bloom.active;
            Debug.Log("  Bloom is " + GetEnabledStatus(GameManager.GetCameraEffects().m_Bloom.active));
        }

        private static void ToggleContrast()
        {
            GameManager.GetCameraEffects().ContrastEnhanceEnable(!GameManager.GetCameraEffects().GetContrastEnhanceEnabled());
            Debug.Log("  ContractEnhance is " + GetEnabledStatus(GameManager.GetCameraEffects().GetContrastEnhanceEnabled()));
        }

        private static void ToggleVignette()
        {
            GameManager.GetCameraEffects().Vignette().active = !GameManager.GetCameraEffects().Vignette().active;
            Debug.Log("  Vignette is " + GetEnabledStatus(GameManager.GetCameraEffects().Vignette().active));
        }

        private static void FullTrees()
        {
            Debug.Log("  Setting trees to maximum distance.");

            Terrain[] terrains = Object.FindObjectsOfType<Terrain>();
            foreach (Terrain eachTerrain in terrains)
            {
                eachTerrain.treeDistance = MAX_DISTANCE;
                eachTerrain.treeBillboardDistance = MAX_DISTANCE;
            }
        }

        private static void NoTrees()
        {
            Debug.Log("  Setting trees to invisible.");

            Terrain[] terrains = Object.FindObjectsOfType<Terrain>();
            foreach (Terrain eachTerrain in terrains)
            {
                eachTerrain.treeDistance = 0;
            }
        }

        private static void NoShadows()
        {
            Debug.Log("  Disabling shadows.");
            QualitySettings.shadows = ShadowQuality.Disable;
        }

        private static void FullGrass()
        {
            Debug.Log("  Setting grass to maximum density.");

            Terrain[] terrains = Object.FindObjectsOfType<Terrain>();
            foreach (Terrain eachTerrain in terrains)
            {
                eachTerrain.detailObjectDensity = 1;
            }
        }

        private static void NoGrass()
        {
            Debug.Log("  Setting grass to invisible.");

            Terrain[] terrains = Object.FindObjectsOfType<Terrain>();
            foreach (Terrain eachTerrain in terrains)
            {
                eachTerrain.detailObjectDensity = 0;
            }
        }

        private static void NoTerrainError()
        {
            Debug.Log("  Setting terrain to maximum accuracy.");

            Terrain[] terrains = Object.FindObjectsOfType<Terrain>();
            foreach (Terrain eachTerrain in terrains)
            {
                eachTerrain.heightmapPixelError = 1;
                eachTerrain.basemapDistance = MAX_DISTANCE;
                QualitySettings.lodBias = LodBias.DEFAULT_LODBIAS_PCFANCY;
            }
        }

        private static void None()
        {
            NoTrees();
            NoGrass();
            NoTerrainError();
        }

        private static void Full()
        {
            FullTrees();
            FullGrass();
            NoTerrainError();
        }

        private static void Reset()
        {
            Debug.Log("  Restoring all settings.");
            GameManager.GetQualitySettingsManager().ApplyCurrentQualitySettings();
        }

        private static string GetEnabledStatus(bool enabled)
        {
            return enabled ? "enabled" : "disabled";
        }
    }
}
