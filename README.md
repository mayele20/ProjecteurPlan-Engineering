# ProjecteurPlan-Engineering

Moteur universel de calcul et d'implantation de vidéoprojecteurs (Windows, C#/.NET 10).

## Version 0.1 — Fondations mathématiques
- `ProjecteurPlan.Core` : unités SI (mètre, radian), vecteurs/points 3D, plans, rayons, intersection rayon-plan, angle d'incidence.
- `ProjecteurPlan.Core.Tests` : tests xUnit.

Règle : le Core ne dépend ni de WPF, ni de Revit, ni d'appareils. Unités internes = SI ; conversions mm/° uniquement aux frontières (affichage, import/export).

## Commandes
```powershell
dotnet build
dotnet test
```
