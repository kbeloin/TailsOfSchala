# TailsOfSchala

In this document, we'll try to collect the best-practices we've picked up to make it easier and more fun to work on this game. Nothing here should be treated as a religion; if following the "rules" gets in your way or cramps your style, don't bother with it!

## Table of Contents

- [Working with Git and Github](#git)
- [Folder structure](#structure)
- [Naming conventions](#naming)
- [Adding assets to the project](#assets)
- [Building scenes](#scripts)
- [Scripts](#scripts)

<a name="git"></a>

## Working with Git & Github

The current stable-ish version of the game is the `master` branch. Don't work on the master branch directly (except in rare cases like conflict fixing and occassional refactors) – instead, make sure your copy of `master` is up to date, and then create your own branch.

### Git branch workflow

1. Before you do anything, make sure to pull (or "sync") the `master` branch.
2. Create your own new branch off master. Give it a name that reflects what it will contain, like `melanie-wheat-sprites`.
3. When you're done working, add all your updates and commit - be sure to add a descriptive commit message.
4. Push your branch. This won't add it to `master` yet, but it does create a checkpoint of your work, and will allow other people to pull your branch and see what you've done.

Once you're ready to merge your work into master, there's a few ways to go about it depending on how comfortable you are with resolving conflicts.

- The simplest way is to create a [Pull Request](https://github.com/SolidGoldStudios/TailsOfSchala) and notify a member of the Game Engine team, and one of us will handle the rest.
- If you create a pull request, and Github tells you that your branch is "able to merge", you can go ahead and complete the merge yourself.
- If there are conflicts, you or a member of the game team will need to pull the branch, merge master into it locally (`git merge master`), and then resolve the conflicts. Then you'll commit, push the branch back up, and complete the merge. You can also do merge from master _before_ your first push, to be sure that there will be no conflicts.

### Resolving conflicts

When you merge two branches together, Git will notify you that there are conflicts if you worked on the same file that someone else worked on simultaneously.

If the conflict is in a script file, yay! You can look at that file and make an informed decision about which conflicting chunk of code to keep, or even manually re-write that section to include pieces from both versions of the code chunk.

However, most of our conflicts will be on non-human-readable files, like `.unity` or `.meta` files. This isn't something you can look at in code and understand easily, most of the time. Therefore, you'll need to make an executive decision about whose version of the file to keep - yours, if you know that you made an important change to that particular file, or the master version, if you know that someone else just added something that should be kept.

In the command line, you can use the following commands:

- `git checkout --theirs filename` to keep the master version.
- `git checkout --ours filename` to keep yours.

Unfortunately, this means that occasionally you will lose your work, or someone else's work will be overwritten by yours. There's no good way around this problem, but you can reduce the chance of it occurring by:

- Working only in small bursts
- Creating new brances often, for specific, limited updates
- Merging often
- **Always** updating your version of `master` before you create a new branch

<a name="structure"></a>

## Folder structure

```
Assets
├── Animation
│
├── Art
│   ├── Materials
│   ├── Palettes
│   ├── Sprites
│
├── Audio
│   ├── Music
│   ├── Sounds
│
├── Code
│   ├── Renderer
│   ├── Scripts
│   │   ├── Managers
│   │   ├── NPC
│   │   ├── Player
│   │   ├── Tools
│   ├── Shaders
│
├── Dialogue
│
├── Fonts
│
├── Level
│   ├── Prefabs
│   ├── Scenes
│   ├── UI
│
├── Plugins
│
├── Video
```

<a name="naming"></a>

## Naming conventions

We're generally following the [Ramen Unity Style Guide](https://github.com/stillwwater/UnityStyleGuide).

### Folders

Unity has some special folders, so [check the list](https://docs.unity3d.com/Manual/SpecialFolders.html) and make sure you don't accidentally re-use one of those!

**No spaces or special characters in file and folder names.** Those make life difficult for folks who work in the command line, and can cause conflicts between Windows and OS X if special characters are handled differently.

**Use PascalCase for folders and scripts** `PascalCase` is like `camelCase`, except the first letter is also capitalized. No spaces, underscores, or dashes.

**Folder names should be as concise as possible**, prefer one or two words. If a directory name is too long, it probably makes sense to split it into sub directories.

**Prefer a deep folder structure over having long asset names.** Instead of `Plants/tree_autumn_birch_tall.png`, aim for `Plants/Trees/Autumn/birch_tall.png`.

**Try to have only one file type per folder.** Use Sprites/Trees, Animation/Trees and not Trees/Sprites, Trees/Animation. That way it's easy to set up root directories for the different software involved, for example, Aseprite would always be set to save to the Sprites directory.

**Use the asset type for the parent directory:** Trees/Jungle, Trees/City not Jungle/Trees, City/Trees. Since it makes it easier to compare similar assets from different art sets to ensure continuity across art sets.

### Files

**Use snake_case for non-code assets like art.** Name files like `tree_small` rather than `small_tree` so that it's easier to group all `tree` objects together.

**Use descriptive suffixes instead of iterative**: `vehicle_truck_damaged`, not `vehicle_truck_01`.

**Use `camelCase` only where necessary.** Use `weapon_miniGun` instead of `weapon_gun_mini`. Avoid this if possible, for example, `vehicles_fighterJet` should be `vehicles_jet_fighter` if you plan to have multiple types of jets.

<a name="assets"></a>

## Adding assets to the project

#### Sprites

- Don't import "flipped" versions of sprites. Sprites can be flipped on both their `x` and `y` axis directly in the inspector.
- If importing an animated version of a previously static sprite, delete the static sprite from the project and replace any references to it with the first frame of the animated spritesheet.
- All non-character sprites should have the `Sprite-Lit-Default` material applied when they are brought into a scene, otherwise they will not interact correctly with the lighting engine. _There are some exceptions to this_
- All character sprites should have `Sprite-Unlit-Default` applied to help them standout from the scene.
  _Note: You may need to click the eye icon to make the `Sprite-Lit-Default` and `Sprite-Unlit-Default` material visible in the material selector panel._

<a name="scenes"></a>

## Building scenes

### Hierarchy

Scenes have a hierarchy, too! It doesn't really matter how you sort items in the scene list, but following a general layout makes it easier to tell at a glance what's included in (or missing from) a scene.

Whe haven't figured out a scene hierchy yet! _Coming soon!_

### Scene-building tips

- If a `Game Object` is being used solely as a container to group objects together that `Game Object` should not have any additional components (e.g. a spriteRenderer) added to it. This helps to keep the hierarchy in the inspector clean.

<a name="scripts"></a>

## Scripts

Scripts should follow the "Single Responsibility" principle: each script should generally do one thing.

### File structure

Stolen from [Sustainable Unity](https://sustainableunity.dev/unity-refactoring-guidelines/).

The basic file structure looks like this, but can vary depending on the class needs. It also has the added benefit of being able to collapse code in most IDEs, like Visual Studio or Rider.

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
