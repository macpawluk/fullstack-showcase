import * as React from "react";
import { Grid } from "semantic-ui-react";
import "./Home.scss";
import { PhotoCard } from "./PhotoCardComponent";
import { Summary } from "./SummaryComponent";

class HomeComponent extends React.Component<{}, {}> {
  public render(): JSX.Element {
    return (
      <div className="home-view-root">
        <div className="ui grid computer tablet only">
          <Grid columns={2} stackable={true}>
            <Grid.Row>
              <Grid.Column width={10}>
                <Summary />
              </Grid.Column>
              <Grid.Column width={6} className="column-card">
                <PhotoCard />
              </Grid.Column>
            </Grid.Row>
          </Grid>
        </div>

        <div className="ui grid mobile only">
          <PhotoCard />
          <Summary />
        </div>
      </div>
    );
  }
}

export const HomeView = HomeComponent;
