# Myanmar Life — Starter Unity project

This repository contains a minimal starter for a Cozy + Deep-sim Myanmar life simulator built for Unity. It includes core C# scripts and sample data to get a small vertical slice running.

Unity version: 2021.3 LTS (recommended)

What is included
- Assets/Scripts/ : core game scripts (TimeManager, Needs, PlayerController, NPCBehavior, SaveSystem)
- Assets/Data/ : sample JSON data (NPC schedules, items)
- README.md : this file
- Android_BUILD.md : Android build & signing guide

Quick start
1. Install Unity 2021.3 LTS (Unity Hub recommended).
2. Create a new 3D project (or open this repository as a Unity project if you add Unity project files).
3. Copy the `Assets` folder into your Unity project's root.
4. In Unity: create a GameObject `TimeManager` and attach `TimeManager.cs`.
5. Create a Plane as ground. Create a Player (Capsule) with `CharacterController`, `PlayerController`, and `NeedsComponent`. Add needs in the inspector: `hunger`, `energy`, `social`.
6. Add Main Camera (child to player or use Cinemachine).
7. Create simple NPC prefabs (Capsule) with `NavMeshAgent`, `NPCBehavior`, and `NeedsComponent`. Assign waypoints (empty GameObjects) and place tagged GameObjects "FoodStand" and "TeaShop" in the scene.
8. Bake NavMesh (Window > AI > Navigation) and press Play.

Notes
- The project includes minimal placeholder code; extend it with data-driven ScriptableObjects or JSON pipelines.
- Use Unicode Myanmar fonts for UI texts.

Next steps (recommended)
- Add a small scene and placeholder models, then commit them to this repo (keep builds small).
- Implement a relationship system and a simple market/economy.
- Add Android build CI using GitHub Actions (optional).

