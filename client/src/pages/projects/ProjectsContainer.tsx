import * as React from "react";
import { IProjectDescriptor, projectDescriptors } from "./data/ProjectsSource";
import { ProjectDescription } from "./ProjectDescriptionComponent";
import "./Projects.scss";

class ProjectsContainer extends React.PureComponent {
  public render(): JSX.Element {
    return (
      <div className="projects-root">
        {this.renderDescriptions(projectDescriptors)}
      </div>
    );
  }

  private renderDescriptions = (
    descriptors: IProjectDescriptor[]
  ): JSX.Element[] => {
    return descriptors.map(desc => (
      <ProjectDescription
        key={desc.id}
        companyName={desc.companyName}
        duration={desc.duration}
        image={desc.image}
        projectBulletItems={desc.projectBulletItems}
        techLabels={desc.techLabels}
      />
    ));
  };
}

export const ProjectsView = ProjectsContainer;
