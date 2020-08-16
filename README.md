# TailsOfSchala

## Working with Git & Github

The current stable-ish version of the game is the `master` branch. Don't work on the master branch directly (except in rare cases like conflict fixing and occassional refactors) – instead, make sure your copy of `master` is up to date, and then create your own branch.

When you're ready, commit your work, push it, and then open a Pull Request on Github. If Github says that your branch is "Able to merge", you can go ahead and do it, or ask someone on the engine team to take a look at it for you.

## Folder structure

```
Assets
├── Animation
├── Art
│   ├── Materials
│   ├── Palettes
│   ├── Sprites
├── Audio
│   ├── Music
│   ├── Sounds
├── Dialogue
├── Fonts

Code
├── Renderer
├── Scripts
│   ├── Managers
│   ├── NPC
│   ├── Player
│   ├── Tools
├── Shaders

Level
├── Prefabs
├── Scenes
├── UI
```

## Naming Conventions

We're generally following the [Ramen Unity Style Guide](https://github.com/stillwwater/UnityStyleGuide).

### Folders

Unity has some special folders, so [check the list](https://docs.unity3d.com/Manual/SpecialFolders.html) and make sure you don't accidentally re-use one of those!

**No spaces or special characters in file and folder names.** Those make life difficult for folks who work in the command line, and can cause conflicts between Windows and OS X if special characters are handled differently.

**Use PascalCase for folders and scripts** `PascalCase` is like `camelCase`, except the first letter is also capitalized. No spaces, underscores, or dashes.

**Folder names should be as concise as possible**, prefer one or two words. If a directory name is too long, it probably makes sense to split it into sub directories.

**Prefer a deep folder structure over having long asset names.** Instead of `Plants/tree_autumn_birch_tall.png`, aim for `Plants/Trees/Autumn/birch_tall.png`.

**Try to have only one file type per folder.** Use Textures/Trees, Models/Trees and not Trees/Textures, Trees/Models. That way its easy to set up root directories for the different software involved, for example, Substance Painter would always be set to save to the Textures directory.

**Use the asset type for the parent directory:** Trees/Jungle, Trees/City not Jungle/Trees, City/Trees. Since it makes it easier to compare similar assets from different art sets to ensure continuity across art sets.

### Files

**Use snake_case for non-code assets like art.** Name files like `tree_small` rather than `small_tree` so that it's easier to group all `tree` objects together.

**Use descriptive suffixes instead of iterative**: vehicle_truck_damaged not vehicle_truck_01.

**Use `camelCase` only where necessary.** Use weapon_miniGun instead of weapon_gun_mini. Avoid this if possible, for example, vehicles_fighterJet should be vehicles_jet_fighter if you plan to have multiple types of jets.

## Art & Animations

## Scripts

Scripts should follow the "Single Responsibility" principle: each script should generally do one thing.

### File structure

```
public class MainMenuScreen : MonoBehaviour
{
		#region Fields

		#endregion

		#region Properties

		#endregion

		#region Unity Lifecycle

		#endregion

		#region Methods

		#endregion
}
```
