const core = require('@actions/core');
const github = require('@actions/github');

console.log(github.context.payload);

const octokit = new github.GitHub();