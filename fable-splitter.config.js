module.exports = {
    entry: "src/PM.StyleGuide.fsproj",
    outDir: "out",
    babel: {
        presets: [["@babel/preset-env", { modules: false, "useBuiltIns": "usage", "corejs": 3 }]],
        sourceMaps: false,
    },
    // The `onCompiled` hook (optional) is raised after each compilation
    onCompiled() {
        console.log("Compilation finished!")
    }
}