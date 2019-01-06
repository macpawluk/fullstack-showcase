import * as React from "react";
import { BrowserRouter as Router, Route } from "react-router-dom";
import "./../../node_modules/semantic-ui-css/semantic.min.css";

import { HomeView } from "./../pages/home";
import { ProjectsView } from "./../pages/projects";
import { TreeExerciseView } from "./../pages/treeExercise";
import { AppConstants } from "./../shared/AppConstants";
import { RequestErrorPrompt } from "./../shared/smartComponents";
import "./App.scss";
import { TopMenu } from "./topMenu/TopMenuComponent";

class AppComponent extends React.Component {
  public render(): JSX.Element {
    return (
      <Router>
        <div>
          <TopMenu />

          <div className="app-content ui bottom attached segment">
            <div className="ui container">
              <Route
                path={AppConstants.Routing.Projects}
                component={ProjectsView}
              />
              <Route
                path={AppConstants.Routing.TreeExercise}
                component={TreeExerciseView}
              />
              <Route
                exact={true}
                path={AppConstants.Routing.Home}
                component={HomeView}
              />
            </div>

            <RequestErrorPrompt>
              <div>Ooops, something went wrong. Try again!</div>
            </RequestErrorPrompt>
          </div>
        </div>
      </Router>
    );
  }
}

export const App = AppComponent;
