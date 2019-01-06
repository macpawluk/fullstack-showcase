The purpose of this project is to introduce myself and give a sample of my development skills.
This is full stack project implemented in React with Typescript and .NET Core. Application's first two tabs are about myself and my experience, but the last one (Exercise) is for demoing solution for slightly more complex problem.

If you want to check the project in the runtime, it has been deployed to Azure and [can be viewed here](http://mp-fullstack-showcase-ui.azurewebsites.net/){:target="_blank"}.

## Back-end

Back-end application has been developed using .NET Core. The project uses:
* MS SQL Database
* Entity Framework
* Code first migrations
* Xunit
* In-memory database (for integration tests)
* Moq

In order to launch it please use Visual Studio 2017 (it's okay to use Community Edition). First build will automatically restore NuGet packages. 
After this project will be ready to run (DB .mdf files are included in the repository to make it easier to launch).

There are unit and integration tests implemented, which can be started with VS built-in tests runner.


## Front-end
Front-end application has been developed using React. In more details the project uses:
* React
* Typescript
* Redux
* Sass
* Jest
* Puppeteer (for end-to-end tests)

In order to launch it please run (assuming that some of basic prerequisites, like Node.js are installed on the machine):

### `npm i`
### `npm start`

There are unit and end-to-end tests implemented, which can be started with the command:
### `npm test`

Please mind that end-to-end tests require back-end on localhost running and front-end application too (`npm start` run in separate process).
