# Groq Unity API Support Library

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Version](https://img.shields.io/badge/version-1.0.0-green.svg)

## Introduction

This library simplifies the integration of Groq API functionalities into Unity projects, making it easier for developers to utilize Groq's powerful capabilities within the Unity environment. The current focus is on providing streamlined access to Groq's **Chat Completion** functionality, with plans to support additional features in the future.

## Project Goal

The primary aim of this project is to provide a lightweight and efficient API wrapper, enabling developers to easily leverage **Groq's API** for building intelligent, interactive experiences in Unity. Whether you’re developing games, simulations, or AI-powered applications, this library provides the tools you need to get started quickly.

### Current Features

- **Groq Chat Completion**: This feature allows you to integrate AI-driven chat functionality into your Unity projects. Ideal for dialogue systems, NPC interactions, and any scenario requiring natural language processing.
  
### Upcoming Features

We are actively working on expanding the library to support additional Groq API features, including:

- **Streaming Chat Completion**: Real-time chat completion to support dynamic conversational experiences.
- **Audio Translation**: Convert spoken language into another language directly within Unity.
- **Audio Transcription**: Transform speech into text for in-game narration, commands, or dialogue transcription.

## Getting Started

### Prerequisites

Before using this library, make sure you have the following:

- **Unity Version**: Unity 2020.3 or later.
- **Groq API Key**: You will need a valid API key from Groq. You can obtain one by signing up at [Groq API Dashboard](https://groq.com/signup).
- **Groq SDK**: Ensure you have the latest version of the Groq SDK installed. You can download it from [here](https://groq.com/sdk-download).

### Installation

1. Clone the repository to your local environment:

    ```bash
    git clone https://github.com/your-username/groq-unity-api-support.git
    ```

2. In Unity, go to `Assets -> Import Package -> Custom Package`.

3. Select the `.unitypackage` file from the cloned repository.

4. Once imported, configure your API Key in the `Groq Settings` panel found in `Edit -> Project Settings -> Groq Unity Settings`.

### Usage

To get started with Groq's **Chat Completion** in Unity, follow these steps:

1. Import the required namespaces in your Unity script:

   ```csharp
   using GroqUnity;
