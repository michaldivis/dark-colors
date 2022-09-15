<img src="assets/icon.png?raw=true" width="200">

# Dark Colors

C# color helpers - color blender.

## Nuget

[![Nuget](https://img.shields.io/nuget/v/Divis.DarkColors?label=Divis.DarkColors)](https://www.nuget.org/packages/Divis.DarkColors/)

DarkColors is available using [nuget](https://www.nuget.org/packages/Divis.DarkColors/). To install DarkColors, run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console)

```Powershell
PM> Install-Package Divis.DarkColors
```

## Color blender

Blend multiple colors together with transparency support.

<img src="assets/sample_screenshot.png?raw=true">

### Basic
```csharp
var baseColor = Color.FromArgb(0, 0, 0); //The base color. This one can't be transparent. If it is, the alpha channel will be ignored.

var colorToAdd = Color.FromArgb(125, 55, 13); //A color to add. This one can have transparency.
var colorToAddLayer = new ColorLayer(colorToAdd, 100);

var twoColorsCombined = ColorBlender.Combine(baseColor, colorToAddLayer);
```

### Advanced
```csharp
var baseColor = Color.FromArgb(0, 0, 0); //The base color. This one can't be transparent. If it is, the alpha channel will be ignored.

var colorToAdd = Color.FromArgb(127, 125, 55, 13); //A color to add. This one can have transparency.
var colorToAddLayer = new ColorLayer(colorToAdd, 50); //The color's amount is set to 50% and it's alpha channel is at 50% so in the result, only 25% of this color will be added on top of the base color.

var twoColorsCombined = ColorBlender.Combine(baseColor, colorToAddLayer);

var anotherColorToAdd = Color.FromArgb(255, 13, 79);
var anotherColorToAddLayer = new ColorLayer(anotherColorToAdd, 25);

var threeColorsCombined = ColorBlender.Combine(baseColor, colorToAddLayer, anotherColorToAddLayer);
```
