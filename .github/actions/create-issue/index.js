const core = require('@actions/core');
const github = require('@actions/github');
const fs = require('fs');

console.log(github.context.payload);

const changelog = fs.readFileSync('template.md', {
    encoding: "UTF8"
});