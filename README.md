# 🎮 Unity FPS Player Controller

![Unity](https://img.shields.io/badge/Unity-2021%2B-000000?style=for-the-badge\&logo=unity\&logoColor=white)
![C#](https://img.shields.io/badge/C%23-Player%20Controller-512BD4?style=for-the-badge\&logo=csharp\&logoColor=white)
![Platform](https://img.shields.io/badge/Platform-Windows%20%7C%20Linux%20%7C%20macOS-blue?style=for-the-badge)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Active-success?style=for-the-badge)

A lightweight and customizable **First-Person Player Controller for Unity**, written in C# and based on Unity's `CharacterController`.

It provides the essential mechanics needed for a simple FPS-style player, including movement, mouse look, sprinting, jumping and gravity.

---

## ✨ Features

* 🎮 First-person movement
* 🖱️ Mouse-controlled camera
* 🏃 Sprinting
* 🦘 Jumping
* 🌍 Gravity
* 🔒 Automatic cursor locking
* 📷 Configurable camera FOV
* ⚡ Runtime movement speed modifiers
* 🚀 Runtime jump-height modifiers
* 🧱 Uses Unity's `CharacterController`
* 🔧 Easy configuration through the Unity Inspector

---

## 🎮 Controls

| Action        | Input        |
| ------------- | ------------ |
| Move Forward  | `W`          |
| Move Backward | `S`          |
| Move Left     | `A`          |
| Move Right    | `D`          |
| Look Around   | `Mouse`      |
| Jump          | `Space`      |
| Sprint        | `Left Shift` |

---

## 📦 Installation

### 1. Add the Script

Copy `Playermovment.cs` into your Unity project:

```text
Assets/
└── Scripts/
    └── Playermovment.cs
```

### 2. Create the Player

Create a GameObject that will act as your player.

Add the following components:

```text
Player
├── CharacterController
├── Playermovment
└── Camera
```

### 3. Assign the Camera

Drag your player's Camera into the **Cam** field of the `Playermovment` component.

### 4. Configure the Controller

Adjust the movement settings inside the Unity Inspector.

Example:

```text
Walk Speed:        4
Sprint Speed:      1.5
Jump Force:        5
Gravity:          -9.81
Camera FOV:        80
Additional Speed:  0
Additional Jump:   0
```

> ⚠️ `Sprint Speed` acts as a multiplier.
> Setting it to `0` means the player will stop while holding `Left Shift`.

---

## ⚙️ Configuration

### Movement

| Property      | Description                   |
| ------------- | ----------------------------- |
| `WalkSpeed`   | Base movement speed           |
| `sprintSpeed` | Sprint speed multiplier       |
| `jumpForce`   | Base jump strength            |
| `gravity`     | Gravity applied to the player |

### Additional Modifiers

The controller contains public modifiers that can be changed during gameplay.

```csharp
Playermovment.instance.additionalSpeed += 2f;
Playermovment.instance.additionalJump += 1f;
```

This can be useful for:

* ⚡ Speed upgrades
* 🦘 Jump upgrades
* 🧪 Power-ups
* 🏆 Progression systems
* 🎁 Temporary buffs

---

## 🖱️ Camera System

Mouse input rotates the player horizontally while the camera rotates vertically.

Vertical rotation is limited to:

```text
-90° → +90°
```

This prevents the camera from rotating beyond the natural first-person viewing range.

---

## 🧩 Requirements

* Unity
* C#
* `CharacterController`
* Unity Legacy Input Manager

The controller currently uses:

```csharp
Input.GetAxis("Horizontal");
Input.GetAxis("Vertical");
Input.GetAxis("Mouse X");
Input.GetAxis("Mouse Y");
```

Make sure the **Legacy Input Manager** is available/enabled in your project.

---

## 📁 Example Hierarchy

```text
Player
│
├── CharacterController
├── Playermovment.cs
│
└── Main Camera
```

The camera should normally be a child of the Player GameObject.

---

## 💻 Usage Example

Other scripts can access the player controller through the static instance:

```csharp
Playermovment.instance.additionalSpeed = 3f;
Playermovment.instance.additionalJump = 2f;
```

For example, a speed pickup could use:

```csharp
private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        Playermovment.instance.additionalSpeed += 2f;
    }
}
```
---

## 📄 License

This project is available under the **MIT License**.

You are free to use, modify and distribute the code in personal and commercial projects according to the terms of the license.

---

## ⭐ Support

If this project helped you, consider giving the repository a **⭐ Star**.

It helps support the project and makes it easier for other Unity developers to discover it.

---

### Made with ❤️ using Unity & C#
