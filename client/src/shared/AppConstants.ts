import { isProduction } from "./AppHelpers";

export const AppConstants = {
  Routing: {
    Home: "/",
    Projects: "/projects",
    TreeExercise: "/tree-exercise"
  },
  Api: {
    BaseUrl: isProduction()
      ? "https://mp-fullstack-showcase-api.azurewebsites.net/"
      : "http://localhost:50432/",
    GetAllPersons: "api/persons/get-all",
    GetPersonContacts: "api/persons/get-person-contacts"
  }
};
