# Belix.UI

A .NET UI component library for Blazor.

## Installation

### 1. Add the Base CSS for Belix.UI

Belix.UI ships with a default stylesheet to ensure consistent component styling.
Include this file from the static web assets exposed by the library:

```html
<link
  href="_content/Belix.UI/css/belix-ui.css"
  rel="stylesheet"
/>
```

> This file contains base styles for all Belix.UI components (layout, spacing, typography, etc.).


## Icons

Belix.UI leverages [Google Material Icons](https://fonts.google.com/icons) for all its iconography. You can render these icons via the `<MaterialIcon>` component included in the library.