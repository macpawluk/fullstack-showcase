import cx from "classnames";
import * as React from "react";
import { connect } from "react-redux";
import * as Redux from "redux";
import { List, ListItemProps } from "semantic-ui-react";

import { IRootState } from "./../../../interfaces";
import { IPerson } from "./../dataModels";
import { buildContactDescription } from "./../TreeDataHelpers";
import {
  fetchPersonsAction,
  selectPersonAction
} from "./../TreeExerciseDataActions";
import { getTreeExerciseState } from "./../TreeExerciseDataReducer";
import "./PersonsList.scss";

interface IPersonsListContainerProps
  extends IPersonsListReduxMergeState,
    IPersonsListContainerDispatch {}

interface IPersonsListContainerDispatch {
  fetchPersons: () => void;
  selectPerson: (personId: number) => void;
}

interface IPersonsListReduxMergeState {
  persons: IPerson[];
  selectedPersonId?: number;
}

class PersonsListContainer extends React.PureComponent<
  IPersonsListContainerProps,
  {}
> {
  public componentWillMount(): void {
    const { fetchPersons } = this.props;

    fetchPersons();
  }

  public render(): JSX.Element {
    const { persons, selectedPersonId } = this.props;

    const items = persons.map(person => {
      const isSelected = selectedPersonId === person.id;

      return (
        <List.Item
          key={`person_${person.id}`}
          as="a"
          onClick={this.handlePersonItemClicked}
          data-item-id={person.id}
          data-test-person-id={person.id}
          data-test-item="person-list-item"
          className={cx({ active: isSelected })}
        >
          <List.Icon name="user" size="large" verticalAlign="middle" />
          <List.Content>
            <List.Header>{person.firstName}</List.Header>
            <List.Description>
              {buildContactDescription(person.contactsCount)}
            </List.Description>
          </List.Content>

          {isSelected && (
            <List.Icon name="check" size="large" verticalAlign="middle" />
          )}
        </List.Item>
      );
    });

    return (
      <List divided={true} relaxed={true} className="persons__list">
        {items}
      </List>
    );
  }

  private handlePersonItemClicked = (
    args: {},
    source: ListItemProps & { "data-item-id"?: number }
  ) => {
    const { selectPerson } = this.props;
    const selectedPersonId = source["data-item-id"];

    selectPerson(selectedPersonId);
  };
}

const mapStateToProps = (
  state: IRootState,
  ownProps: {}
): IPersonsListReduxMergeState => {
  const viewState = getTreeExerciseState(state);

  return {
    persons: viewState.persons,
    selectedPersonId: viewState.selectedPersonId
  };
};

const mapDispatchToProps = (
  dispatch: Redux.Dispatch
): IPersonsListContainerDispatch =>
  Redux.bindActionCreators(
    {
      fetchPersons: fetchPersonsAction,
      selectPerson: (personId: number) => selectPersonAction({ personId })
    },
    dispatch
  );

export const PersonsListView = connect(
  mapStateToProps,
  mapDispatchToProps
)(PersonsListContainer);
