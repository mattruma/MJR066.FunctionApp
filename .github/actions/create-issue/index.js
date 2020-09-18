const core = require('@actions/core');
const github = require('@actions/github');

console.log(github.context.payload);

const octokit = new github.GitHub(core.getInput('token'));

const title = core.getInput('title');
const body = core.getInput('body');
const assignees = core.getInput('assignees');
const labels = core.getInput('labels');

const response = await octokit.issues.create({
    ...github.context.repo,
    title,
    body,
    assignees: assignees ? assignees.split(',') : undefined,
    labels: assignees ? assignees.split(',') : undefined
})

core.setOutput('issue', JSON.stringify(response.data));