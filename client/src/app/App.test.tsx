import * as enzyme from "enzyme";
import { shallow } from "enzyme";
import ReactSixteenAdapter from "enzyme-adapter-react-16";
import * as React from "react";

import { App } from "./App";

enzyme.configure({ adapter: new ReactSixteenAdapter() });

it("renders app with proper routes", () => {
  const shallowApp = shallow(<App />);

  const projectsRoute = shallowApp.find("Route[path='/projects']");
  const treeExerciseRoute = shallowApp.find("Route[path='/tree-exercise']");
  const baseRoute = shallowApp.find("Route[path='/']");

  expect(projectsRoute).toHaveLength(1);
  expect(treeExerciseRoute).toHaveLength(1);
  expect(baseRoute).toHaveLength(1);
});

it("renders error prompt", () => {
  const shallowApp = shallow(<App />);

  const errorPrompt = shallowApp.find("Connect(RequestErrorPromptContainer)");
  expect(errorPrompt).toHaveLength(1);
});
