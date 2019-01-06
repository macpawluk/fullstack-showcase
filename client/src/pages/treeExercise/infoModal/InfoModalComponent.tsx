import * as React from "react";
import { Button, Image, Modal } from "semantic-ui-react";

import contactsDiagram from "./../../../images/contacts-diagram.svg";
import {
  saveShowExerciseInfoTime,
  shouldShowExerciseInfo
} from "./../StorageHelper";

interface IInfoModalComponentState {
  showModal: boolean;
}

export class InfoModalComponent extends React.PureComponent<
  {},
  IInfoModalComponentState
> {
  constructor(props: {}, context: {}) {
    super(props, context);

    this.state = this.getInitialState();
  }

  public componentWillMount(): void {
    if (shouldShowExerciseInfo()) {
      this.setState({ showModal: true });
      saveShowExerciseInfoTime();
    }
  }

  public render(): JSX.Element {
    const { showModal } = this.state;

    return (
      <Modal
        trigger={this.renderTriggerButton()}
        defaultOpen={showModal}
        centered={false}
        dimmer="blurring"
        className="info__modal"
      >
        <Modal.Header>Contacts' diagram</Modal.Header>
        <Modal.Content scrolling={true}>
          <Modal.Description>
            <div className="description-text">
              <p>
                This diagram represents connections between people. By choosing
                range value of 1 user says he is interested only in direct
                connections of selected person. Range value of 2 means query
                will return connections of connections etc.
              </p>
              <p>
                Option <strong>Less or equal</strong> means all connections
                below or equal given range will be returned (in tree hierarchy).
                Option <strong>equal</strong> means only contacts from certain
                range will be returned.
              </p>
            </div>
            <Image
              src={contactsDiagram}
              fluid={true}
              className="contacts-diagram__image auto-fit__image"
            />
          </Modal.Description>
        </Modal.Content>
      </Modal>
    );
  }

  private renderTriggerButton = (): JSX.Element => {
    return <Button icon="info circle" className="info__button" />;
  };

  private getInitialState = (): IInfoModalComponentState => {
    return {
      showModal: false
    };
  };
}

export const InfoModal = InfoModalComponent;
