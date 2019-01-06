import cx from "classnames";
import * as React from "react";
import { Icon, List } from "semantic-ui-react";

import { IPersonWithContacts } from "../dataModels";

interface IContactsTreeItemComponentOwnProps {
  person: IPersonWithContacts;
  showDropdownIcon: boolean;
  description: string;
}

interface IContactsTreeItemComponentState {
  isMouseOver: boolean;
}

export class ContactsTreeItemComponent extends React.PureComponent<
  IContactsTreeItemComponentOwnProps,
  IContactsTreeItemComponentState
> {
  constructor(
    props: IContactsTreeItemComponentOwnProps,
    context: IContactsTreeItemComponentOwnProps
  ) {
    super(props, context);
    this.state = this.getInitialState();
  }

  public render(): JSX.Element {
    const { person, showDropdownIcon, description } = this.props;
    const { isMouseOver } = this.state;

    return (
      <div
        onMouseEnter={this.handleMouseEnter}
        onMouseLeave={this.handleMouseLeave}
      >
        <List.Item
          key={`person_${person.personId}`}
          data-item-id={person.personId}
          className={cx("person__tree-item", { "mouse-over": isMouseOver })}
        >
          <Icon
            name="dropdown"
            className={cx("dropdown__icon", { hidden: !showDropdownIcon })}
          />
          <List.Icon name="user" size="small" className="person__icon" />
          <List.Content>
            <List.Header>
              <strong>{person.firstName}</strong>
            </List.Header>
            <List.Description>{description}</List.Description>
          </List.Content>
        </List.Item>
      </div>
    );
  }

  private handleMouseEnter = () => {
    this.setState({ isMouseOver: true });
  };

  private handleMouseLeave = () => {
    this.setState({ isMouseOver: false });
  };

  private getInitialState = (): IContactsTreeItemComponentState => {
    return { isMouseOver: false };
  };
}
