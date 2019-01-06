import * as React from "react";
import { connect } from "react-redux";

import { IPersonWithContacts } from "../dataModels";
import { IRootState } from "./../../../interfaces";
import {
  getTreeExerciseSettingsRangeValue,
  getTreeExerciseSettingsState,
  SearchRangeType
} from "./../settings";
import {
  buildContactDescription,
  buildNLevelContactDescription
} from "./../TreeDataHelpers";
import {
  getPersonContactsCount,
  getTreeExerciseState
} from "./../TreeExerciseDataReducer";
import { ContactsTreeItemComponent } from "./ContactsTreeItemComponent";

interface IContactsTreeItemContainerProps
  extends IContactsTreeItemContainerReduxMergeState,
    IContactsTreeItemContainerOwnProps {}

interface IContactsTreeItemContainerReduxMergeState {
  contactDescription: string;
  rangeType: SearchRangeType;
}

interface IContactsTreeItemContainerOwnProps {
  person: IPersonWithContacts;
  level: number;
}

class ContactsTreeItemContainer extends React.PureComponent<
  IContactsTreeItemContainerProps
> {
  public render(): JSX.Element {
    const { person, contactDescription } = this.props;

    const hasChildren = person.contacts && person.contacts.length > 0;

    return (
      <ContactsTreeItemComponent
        person={person}
        showDropdownIcon={hasChildren}
        description={contactDescription}
      />
    );
  }
}

const mapStateToProps = (
  state: IRootState,
  ownProps: IContactsTreeItemContainerOwnProps
): IContactsTreeItemContainerReduxMergeState => {
  const rangeType = getTreeExerciseSettingsState(state).rangeType;
  const contactDescription = getContactDescription(state, ownProps);

  return {
    contactDescription,
    rangeType
  };
};

const getContactDescription = (
  state: IRootState,
  ownProps: IContactsTreeItemContainerOwnProps
): string => {
  const { rangeType } = getTreeExerciseSettingsState(state);
  const { selectedPersonId } = getTreeExerciseState(state);

  if (ownProps.level === 0 && rangeType === SearchRangeType.Equal) {
    const contactsCount = getPersonContactsCount(state, selectedPersonId);
    const rangeValue = getTreeExerciseSettingsRangeValue(state);

    return buildNLevelContactDescription(contactsCount, rangeValue);
  } else {
    const contactsCount = getPersonContactsCount(
      state,
      ownProps.person.personId
    );

    return buildContactDescription(contactsCount);
  }
};

export const ContactsTreeItem = connect<
  IContactsTreeItemContainerReduxMergeState,
  {},
  IContactsTreeItemContainerOwnProps,
  IRootState
>(
  mapStateToProps,
  null
)(ContactsTreeItemContainer);
