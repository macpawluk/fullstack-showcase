import axios from "axios";
import { Dispatch } from "redux";

import { IResponse, IResponseWrapper, IRootState } from "../../interfaces";
import { AppConstants } from "../../shared/AppConstants";
import { IPersonWithContacts } from "./dataModels";
import {
  getTreeExerciseSettingsRangeValue,
  getTreeExerciseSettingsState,
  SearchRangeType
} from "./settings";
import {
  getPersonWithContacts,
  getTreeExerciseState
} from "./TreeExerciseDataReducer";

export const TREE_DATA_FETCH_PERSONS = "@App/TreeExercise/FETCH_PERSONS";
// prettier-ignore
export const TREE_DATA_FETCH_PERSONS_SUCCEED = "@App/TreeExercise/FETCH_PERSONS_FULFILLED";
export const TREE_DATA_SELECT_PERSON = "@App/TreeExercise/SELECT_PERSON";
export const TREE_DATA_FETCH_CONTACTS = "@App/TreeExercise/FETCH_CONTACTS";
// prettier-ignore
export const TREE_DATA_FETCH_CONTACTS_SUCCEED = "@App/TreeExercise/FETCH_CONTACTS_FULFILLED";
export const TREE_EXERCISE_VIEW_LEFT = "@App/TreeExercise/VIEW_LEFT";

export const fetchPersonsAction = () => ({
  type: TREE_DATA_FETCH_PERSONS,
  payload: axios.get(
    `${AppConstants.Api.BaseUrl}${AppConstants.Api.GetAllPersons}`
  )
});

export interface ISelectPersonPayload {
  personId: number;
}
export const selectPersonAction = (payload: ISelectPersonPayload) => {
  return (dispatch: Dispatch, getState: () => IRootState) => {
    dispatch({
      type: TREE_DATA_SELECT_PERSON,
      payload
    });
    fetchContactsAction()(dispatch, getState);
  };
};

export interface IFetchContactsRequest {
  selectedPersonId: number;
  rangeType: SearchRangeType;
  rangeValue: number;
}
export const fetchContactsAction = () => {
  return (dispatch: Dispatch, getState: () => IRootState) => {
    const globalState = getState();
    const { rangeType } = getTreeExerciseSettingsState(globalState);
    const rangeValue = getTreeExerciseSettingsRangeValue(globalState);
    const { selectedPersonId } = getTreeExerciseState(globalState);
    const personWithContacts = getPersonWithContacts(
      globalState,
      selectedPersonId
    );

    if (!selectedPersonId || !rangeValue || personWithContacts) {
      return null;
    }

    return dispatch({
      type: TREE_DATA_FETCH_CONTACTS,
      payload: axios
        .get(
          // prettier-ignore
          `${AppConstants.Api.BaseUrl}${AppConstants.Api.GetPersonContacts}/${selectedPersonId}?searchRange=${rangeValue}&searchRangeType=${rangeType}`
        )
        .then(response => {
          return {
            request: {
              selectedPersonId,
              rangeType,
              rangeValue
            },
            response
          } as IResponseWrapper<
            IFetchContactsRequest,
            IResponse<IPersonWithContacts>
          >;
        })
    });
  };
};

export const treeExerciseViewLeftAction = () => ({
  type: TREE_EXERCISE_VIEW_LEFT,
  payload: {}
});
