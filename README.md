# OCSelectedItemWpfDemo

In WPF, Item selection changes isn't reflected in View

## Issue
When creating `ISynchronizedView<T, TView>` using `ObservableList<T>.CreateView()`, if type conversion is performed in the `transform`, changes to the selected item in View isn't reflected.

## Demo

[gif]

## Environment
- Visual Studio 2022 17.11.0
- .NET8
- WPF
- ObservableCollections 2.2.0

## Repository

this