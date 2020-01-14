var CONFIG = {
    babel: {
        presets: [
            ["@babel/preset-env", {
                "modules": false,
                "useBuiltIns": "usage",
                "corejs": 3,
                // This saves around 4KB in minified bundle (not gzipped)
                // "loose": true,
            }]
        ],
    }
};

// Export a function. Accept the base config as the only param.
module.exports = async ({ config, mode }) => {
    // `mode` has a value of 'DEVELOPMENT' or 'PRODUCTION'
    // You can change the configuration based on that.
    // 'PRODUCTION' is used when building the static version of storybook.

    // Make whatever fine-grained changes you need
    config.module.rules = [
        {
            test: /\.fs(x|proj)?$/,
            use: {
                loader: "fable-loader",
                options: {
                    babel: CONFIG.babel
                }
            },
        },
        {
            test: /\.js$/,
            exclude: /node_modules/,
            use: {
                loader: 'babel-loader',
                options: CONFIG.babel
            },
        },
        {
            test: /\.(sass|scss|css)$/,
            use: [
                'style-loader',
                'css-loader',
                { loader: 'postcss-loader', options: { plugins: [ require('autoprefixer')]}},
                { loader: 'sass-loader', options: { implementation: require('sass')}},
            ],
        },
        {
            test: /\.(png|jpg|jpeg|gif|svg|woff|woff2|ttf|eot)(\?.*)?$/,
            use: ["file-loader"]
        }
    ];

    // Return the altered config
    return config;
};
