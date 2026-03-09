# 🐔 ChickenSim - Genetic Chicken Breeding Simulator

<div align="center">

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)

*A genetic simulation where chickens breed until they reach your desired population*

*A learning project from back in the day when I was exploring C# and object-oriented programming (2022)*

**[Read in English](#english)** • **[Leer en Español](#español)**

</div>

---

# English

[Features](#-features) • [How It Works](#-how-it-works) • [Installation](#-installation) • [Usage](#-usage)



---

## 🎯 Overview

**ChickenSim** is a genetic breeding simulator. Dionisus and Epistomisya, the primordial chicken parents, spawn generations of offspring until the desired population is reached.

The simulation features:
- 🎲 **Random gender assignment** for each offspring
- 📊 **Generational tracking** with fertility mechanics
- 🎭 **Greek-themed names** randomly selected for fun
- 🔄 **Dynamic parent rotation** based on offspring genetics

## ✨ Features

- **Interactive CLI**: Simple input format (`8f` for 8 females, `5m` for 5 males)
- **Fertility System**: Each pair has limited reproductive capacity
- **Automatic Generation Advancement**: When opposite-gender offspring are born, they become the new breeding pair
- **Real-time Statistics**: Track male and female population counts
- **Mythological Theme**: Greek-inspired names for all chickens

## 🔬 How It Works

### The Breeding Process

1. **Genesis**: Two primordial chickens are created:
   - 🐓 **Dionisus** - Father of all Hens
   - 🐔 **Epistomisya** - Mother of all Hens

2. **Reproduction Cycle**:
   - Each breeding pair produces 2 offspring with random genders
   - Parents have a fertility counter (primordial parents: 3, offspring: 50)
   - Offspring receive random Greek names (Protágoras, Sócrates, Anaxágoras, Aquiles, Ulises, Demócrito, Gorgias, Antonio)

3. **Generational Advancement**:
   - When offspring are of opposite genders, they become the new breeding pair
   - The generation counter increments
   - The cycle continues until the target population is reached

4. **Termination**:
   - Process stops when desired population count is achieved
   - Or when fertility is depleted ("Se acabo lo que se daba")

### Key Mechanics

```
Input: "8f"
├─ Parse: 8 females desired
├─ Create primordial pair
├─ Begin reproduction loop
│  ├─ Generate 2 offspring (random genders)
│  ├─ Decrease fertility
│  ├─ If opposite genders → new breeding pair
│  └─ Check if female count >= 8
└─ Display final statistics
```

## 🚀 Installation

### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later

### Clone & Build

```bash
# Clone the repository
git clone https://github.com/yourusername/gallinas.git
cd gallinas

# Build the project
dotnet build

# Run the simulator
dotnet run
```

## 📖 Usage

### Basic Command

When prompted, enter your desired count followed by gender:

```
==============================================================
8f          # Generate at least 8 females
```

or

```
==============================================================
5m          # Generate at least 5 males
```

### Example Output

```
==============================================================
8f
Dionisus, father of all Hens, has been awakened! (0) 

Epistomisya, mother of all Hens, has been awakened! (0) 

Sócrates has been born; it's a MALE! (0)
Protágoras has been born; it's a FEMALE! (0)
Padres: Dionisus, father of all Hens, and Epistomisya, mother of all Hens, with fertility 2 

Aquiles has been born; it's a MALE! (1)
Demócrito has been born; it's a FEMALE! (1)
Padres: Sócrates and Protágoras with fertility 49 

...

Males: 4 - Females: 8
```

## 🏗️ Architecture

### Core Components

#### `Gallina` Class
- **Static Lists**: Tracks all males and females
- **Properties**: `genero` (gender), `nombre` (name), `fertility`
- **Constructors**:
  - Parameterless: Random gender and name assignment
  - Parameterized: Custom gender and name for primordial chickens
- **Methods**:
  - `isSameGen()`: Checks if two chickens are the same gender
  - `Reproduce()`: Handles breeding logic and generation advancement

#### `Program` Class
- **Static Variables**:
  - `generacionActual`: Current generation counter
  - `padres`: Current breeding pair
  - `newborns`: Latest offspring
  - `fertilityOverride`: Flags when fertility is exhausted
- **Methods**:
  - `Main()`: Input parser and orchestrator
  - `birthProcess()`: Manages reproduction loop

### Enum
```csharp
public enum Genero 
{
    MALE,
    FEMALE
}
```

## 🎲 Probability Theory

- Each offspring has a **50% chance** of being male or female
- Expected generations to target varies based on random outcomes
- Fertility limits create natural population constraints

## 🤔 Edge Cases

- **Minimum input**: Must be at least 2 (program enforces: "Mejor sube el valor, okay?")
- **Fertility depletion**: Stops early with message "Se acabo lo que se daba"
- **Same-gender breeding**: Still produces offspring (simulates parthenogenesis?)

## 🛠️ Technical Details

- **Language**: C# 
- **Framework**: .NET 9.0
- **Architecture**: Console Application
- **Randomization**: `System.Random` for gender and name selection

---

# Español

[Características](#-características) • [Cómo Funciona](#-cómo-funciona) • [Instalación](#-instalación) • [Uso](#-uso)

## 🎯 Descripción General

**ChickenSim** es un simulador de cría genética. Dionisus y Epistomisya, los padres primordiales de las gallinas, generan descendencia hasta alcanzar la población deseada.

La simulación incluye:
- 🎲 **Asignación aleatoria de género** para cada descendiente
- 📊 **Seguimiento generacional** con mecánicas de fertilidad
- 🎭 **Nombres de temática griega** seleccionados aleatoriamente por diversión
- 🔄 **Rotación dinámica de padres** basada en la genética de los descendientes

## ✨ Características

- **CLI Interactiva**: Formato de entrada simple (`8f` para 8 hembras, `5m` para 5 machos)
- **Sistema de Fertilidad**: Cada pareja tiene capacidad reproductiva limitada
- **Avance Automático de Generación**: Cuando nacen crías de géneros opuestos, se convierten en la nueva pareja reproductora
- **Estadísticas en Tiempo Real**: Rastrea conteos de población masculina y femenina
- **Tema Mitológico**: Nombres inspirados en la Grecia antigua para todas las gallinas

## 🔬 Cómo Funciona

### El Proceso de Cría

1. **Génesis**: Se crean dos gallinas primordiales:
   - 🐓 **Dionisus** - Padre de todas las Gallinas
   - 🐔 **Epistomisya** - Madre de todas las Gallinas

2. **Ciclo de Reproducción**:
   - Cada pareja reproductora produce 2 crías con géneros aleatorios
   - Los padres tienen un contador de fertilidad (padres primordiales: 3, descendientes: 50)
   - Las crías reciben nombres griegos aleatorios (Protágoras, Sócrates, Anaxágoras, Aquiles, Ulises, Demócrito, Gorgias, Antonio)

3. **Avance Generacional**:
   - Cuando las crías son de géneros opuestos, se convierten en la nueva pareja reproductora
   - El contador de generación se incrementa
   - El ciclo continúa hasta que se alcanza la población objetivo

4. **Terminación**:
   - El proceso se detiene cuando se logra el conteo de población deseado
   - O cuando la fertilidad se agota ("Se acabo lo que se daba")

### Mecánicas Clave

```
Entrada: "8f"
├─ Analizar: 8 hembras deseadas
├─ Crear pareja primordial
├─ Iniciar ciclo de reproducción
│  ├─ Generar 2 crías (géneros aleatorios)
│  ├─ Disminuir fertilidad
│  ├─ Si géneros opuestos → nueva pareja reproductora
│  └─ Verificar si conteo de hembras >= 8
└─ Mostrar estadísticas finales
```

## 🚀 Instalación

### Prerrequisitos
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) o posterior

### Clonar y Compilar

```bash
# Clonar el repositorio
git clone https://github.com/yourusername/gallinas.git gallinasSim
cd gallinasSim

# Compilar el proyecto
dotnet build

# Ejecutar el simulador
dotnet run
```

## 📖 Uso

### Comando Básico

Cuando se solicite, ingresa el conteo deseado seguido del género:

```
==============================================================
8f          # Generar al menos 8 hembras
```

o

```
==============================================================
5m          # Generar al menos 5 machos
```

### Ejemplo de Salida

```
==============================================================
8f
Dionisus, father of all Hens, has been awakened! (0) 

Epistomisya, mother of all Hens, has been awakened! (0) 

Sócrates has been born; it's a MALE! (0)
Protágoras has been born; it's a FEMALE! (0)
Padres: Dionisus, father of all Hens, and Epistomisya, mother of all Hens, with fertility 2 

Aquiles has been born; it's a MALE! (1)
Demócrito has been born; it's a FEMALE! (1)
Padres: Sócrates and Protágoras with fertility 49 

...

Males: 4 - Females: 8
```

## 🏗️ Arquitectura

### Componentes Principales

#### Clase `Gallina`
- **Listas Estáticas**: Rastrea todos los machos y hembras
- **Propiedades**: `genero`, `nombre`, `fertility` (fertilidad)
- **Constructores**:
  - Sin parámetros: Asignación aleatoria de género y nombre
  - Con parámetros: Género y nombre personalizados para gallinas primordiales
- **Métodos**:
  - `isSameGen()`: Verifica si dos gallinas son del mismo género
  - `Reproduce()`: Maneja la lógica de cría y avance generacional

#### Clase `Program`
- **Variables Estáticas**:
  - `generacionActual`: Contador de generación actual
  - `padres`: Pareja reproductora actual
  - `newborns`: Última descendencia
  - `fertilityOverride`: Indica cuando la fertilidad se ha agotado
- **Métodos**:
  - `Main()`: Analizador de entrada y orquestador
  - `birthProcess()`: Gestiona el ciclo de reproducción

### Enum
```csharp
public enum Genero 
{
    MALE,
    FEMALE
}
```

## 🎲 Teoría de Probabilidad

- Cada cría tiene un **50% de probabilidad** de ser macho o hembra
- Las generaciones esperadas para alcanzar el objetivo varían según resultados aleatorios
- Los límites de fertilidad crean restricciones naturales de población

## 🤔 Casos Especiales

- **Entrada mínima**: Debe ser al menos 2 (el programa indica: "Mejor sube el valor, okay?")
- **Agotamiento de fertilidad**: Se detiene anticipadamente con el mensaje "Se acabo lo que se daba"
- **Cría del mismo género**: Aún produce descendencia (¿simula partenogénesis?)

## 🛠️ Detalles Técnicos

- **Lenguaje**: C# 
- **Framework**: .NET 9.0
- **Arquitectura**: Aplicación de Consola
- **Aleatorización**: `System.Random` para selección de género y nombre