MapMakerTools


This is a mod for **The Long Dark** by Hinterland Studio, Inc.


It adds commands to the [DeveloperConsole](https://github.com/FINDarkside/TLD-Developer-Console) that aid in mapping the terrain.

Additional commands:

* `MapMaking-NoTerrainError` - Produce the most accurate terrain rendering by forcing a very high LOD bias and base map distance, as well as the lowest pixel error. (The LOD bias will affect all objects)
* `MapMaking-NoGrass` - Hide all grass
* `MapMaking-FullGrass` - Set maximum grass density
* `MapMaking-NoTrees` - Hide all trees and bushes, but not rosehips or tree stumps.
* `MapMaking-FullTrees` - Increase tree drawing distance to maximum and never render them as billboards
* `MapMaking-ToggleBloom` - Toggle the "AmplifyBloom" effect on/off
* `MapMaking-ToggleContrast` - Toggle the "ContrastEnhance" effect on/off
* `MapMaking-ToggleVignette` - Toggle the "VignetteAndChromaticAberration" effect on/off
* `MapMaking-NoShadows` - Disable shadows completely
* `MapMaking-ShadowDistance` - Set the shadow draw distance to the given parameter. This is rather experimental, since shadows start to disintegrate rather quickly when raising the draw distance.
* `MapMaking-None` - Do `MapMaking-NoTerrainError` + `MapMaking-NoGrass` + `MapMaking-NoTrees`
* `MapMaking-Full` - Do `MapMaking-NoTerrainError` + `MapMaking-FullGrass` + `MapMaking-FullTrees`
* `MapMaking-Reset` - Revert all settings back to the previously selected quality settings.


None of the settings will be persistent and revert back to the previously selected quality settings when changing scenes or closing the game.