# Assassin Ninja (Prototype)

A stealth-action 2D platformer prototype built in **Unity 2022.3 LTS**.  
Core gameplay: avoid patrolling enemies, retrieve your sword, and escape through the exit door.

---

## 🎮 Gameplay

- Begin unarmed.
- Enemies **one-shot kill** you on contact → stealth is essential.
- Retrieve your **sword** to fight back:
  - Once armed, you can **one-shot enemies** (but must strike from behind).
- Reach the **exit door** to clear the stage.

---

## 🕹️ Controls

- **A / D keys** → Move left / right  
- **Arrow keys** → Alternative movement  
- **L key** → Attack (only after picking up the sword)

---

## ⚙️ Features

- **Enemy AI** using Unity’s Animator StateMachine + C# Controller:
  - Patrol, detect, chase, attack.
  - Detection via raycast vision.  
  - One-shot mechanic for both player and enemy.  
  - Attack tied to animator state (`bandit_combetIdle`).
- **Patrol flipping** via special `flipper` colliders.
- **Tension-based gameplay**: avoid detection, strike from shadows.

---

## 🛠️ Tech Stack

- Engine: Unity 2022.3.62f1 (LTS)  
- Language: C#  
- Render Pipeline: URP (2D)  
- Platform: Windows, Mac, Linux  

---

## 🚀 Future Improvements

- Expose AI values (sight range, attack range, damage) for tuning.  
- Add patrol patterns (idle, turn, chase, retreat).  
- Add health for player/enemy (optional, balance tweak).  
- Improve enemy telegraphing (animations, VFX).  

---

## 📂 Project Status

This is a **prototype** created to test stealth combat mechanics.  
It is intentionally minimal, focusing on AI behavior and player risk/reward.

---

## 👤 Author

**Rishabh Gohel**  
- Game Developer / Unity Programmer  
- Skills: Unity 2D/3D, Multiplayer (Photon Fusion2, Netcode for GameObjects), Firebase, Play Store publishing  
