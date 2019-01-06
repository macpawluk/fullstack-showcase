import * as React from "react";
import { connect } from "react-redux";
import * as Redux from "redux";

import { IRootState } from "./../../interfaces";
import { Loader } from "./../../shared/smartComponents";
import { ContactsTree } from "./contactsTree";
import { IPersonWithContacts } from "./dataModels";
import { PersonsListView } from "./personsList";
import { TreeExerciseSettingsView } from "./settings";
import { treeExerciseViewLeftAction } from "./TreeExerciseDataActions";
import {
  getPersonWithContacts,
  getTreeExerciseState
} from "./TreeExerciseDataReducer";

import "./TreeExercise.scss";

interface ITreeExerciseContainerProps
  extends ITreeExerciseContainerReduxMergeState,
    ITreeExerciseContainerDispatch {}

interface ITreeExerciseContainerReduxMergeState {
  selectedPersonWithContacts?: IPersonWithContacts;
}

interface ITreeExerciseContainerDispatch {
  viewLeft: () => void;
}

export class TreeExerciseContainer extends React.Component<
  ITreeExerciseContainerProps,
  {}
> {
  public componentWillUnmount(): void {
    const { viewLeft } = this.props;
    viewLeft();
  }

  public render(): JSX.Element {
    const { selectedPersonWithContacts } = this.props;

    return (
      <div className="tree-exercise-view-root">
        <TreeExerciseSettingsView />

        <div className="exercise-data">
          <PersonsListView />
          {selectedPersonWithContacts && (
            <ContactsTree rootPerson={selectedPersonWithContacts} />
          )}
          <Loader />
        </div>
      </div>
    );
  }
}

const mapStateToProps = (
  state: IRootState
): ITreeExerciseContainerReduxMergeState => {
  return {
    selectedPersonWithContacts: getPersonWithContacts(
      state,
      getTreeExerciseState(state).selectedPersonId
    )
  };
};

const mapDispatchToProps = (
  dispatch: Redux.Dispatch
): ITreeExerciseContainerDispatch =>
  Redux.bindActionCreators(
    {
      viewLeft: treeExerciseViewLeftAction
    },
    dispatch
  );

export const TreeExerciseView = connect(
  mapStateToProps,
  mapDispatchToProps
)(TreeExerciseContainer);
