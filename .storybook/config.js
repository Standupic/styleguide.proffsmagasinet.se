import { configure } from '@storybook/react';

// If using SASS
import '../src/sass/main.sass';

function loadStories() {
    const req = require.context('../src/', true, /\.stories\.(fs|js)$/);
    req.keys().forEach(filename => req(filename));
}

configure(loadStories, module);
