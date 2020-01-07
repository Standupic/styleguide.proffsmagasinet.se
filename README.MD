# Proffsmagasinet Storybook

## Prerequisites

* .NET Core 2.2
* Node.js + NPM

## How to run

```
dotnet tool restore
dotnet paket install
dotnet restore
npm install
npm run storybook
```

## Development

Add stories to `src/PM.StyleGuide.fsproj`. Stories must follow the naming `MyStory.stories.fs`