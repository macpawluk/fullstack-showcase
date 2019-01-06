import * as React from "react";
import { Header, Segment } from "semantic-ui-react";

class SummaryComponent extends React.PureComponent<{}> {
  public render(): JSX.Element {
    return (
      <div>
        <Segment>
          <Header as="h2">Summary</Header>
          <div className="summary-content">
            <p>
              Currently employed as a senior .NET developer at Epam (delegated
              to UBS). During my career I had an opportunity to work in
              different environments: from startups employing two people to big
              enterprises, including banks with thousands of employees.
            </p>
            <p>
              Startup gave me a chance to get familiar with every step of
              development process, starting from convincing a new client, going
              through requirements gathering, software implementation and ending
              with obtaining a final approval.
            </p>
            <p>
              Corporates taught me how to build enterprise class applications
              and how to operate in complex, interdependent environments.
            </p>
          </div>
        </Segment>
        <Segment color="green">Specialities: WPF, .NET Core, React</Segment>
      </div>
    );
  }
}

export const Summary = SummaryComponent;
