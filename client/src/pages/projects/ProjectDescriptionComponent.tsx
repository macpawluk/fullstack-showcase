import * as React from "react";
import {
  Grid,
  Header,
  Icon,
  Image,
  Label,
  List,
  Segment
} from "semantic-ui-react";

interface IProjectDescriptionComponentProps {
  companyName: string;
  duration: string;
  image: any;
  projectBulletItems: string[];
  techLabels: string[];
}

class ProjectDescriptionComponent extends React.PureComponent<
  IProjectDescriptionComponentProps
> {
  public render(): JSX.Element {
    const {
      companyName,
      duration,
      image,
      projectBulletItems,
      techLabels
    } = this.props;

    return (
      <div className="project-item">
        <Header dividing={true}>
          <Segment basic={true}>
            <h3>{companyName}</h3>
            <Label
              tag={true}
              color="orange"
              className="right"
              attached="top right"
            >
              {duration}
            </Label>
          </Segment>
        </Header>

        <Grid columns={2} stackable={true}>
          <Grid.Row>
            <Grid.Column width={3}>
              <Image src={image} bordered={true} />
            </Grid.Column>
            <Grid.Column width={10}>
              {this.renderProjectBulletPoints(projectBulletItems)}
              <div className="tech-labels">
                {this.renderTechItems(techLabels)}
              </div>
            </Grid.Column>
          </Grid.Row>
        </Grid>
      </div>
    );
  }

  private renderProjectBulletPoints = (bulletItems: string[]): JSX.Element => {
    const renderedItems = bulletItems.map(item => (
      <List.Item key={item}>
        <Icon name="triangle right" />
        <List.Content>
          <List.Description>{item}</List.Description>
        </List.Content>
      </List.Item>
    ));

    return <List>{renderedItems}</List>;
  };

  private renderTechItems = (techLabels: string[]): JSX.Element => {
    const renderedItems = techLabels.map(label => (
      <span className="ui image label" key={label}>
        <Icon name="check" />
        {label}
      </span>
    ));

    return <div className="tech-labels">{renderedItems}</div>;
  };
}

export const ProjectDescription = ProjectDescriptionComponent;
