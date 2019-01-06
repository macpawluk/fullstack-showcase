// UI Tweaks (nav bar) + reposnive UI (not sure)

import { createSelector } from "reselect";
import { IResponse, IResponseWrapper, IRootState } from "../../interfaces";
import { IPerson, IPersonWithContacts } from "./dataModels";
import {
  TREE_EXERCISE_SETTINGS_CHANGE_RANGE_TYPE,
  TREE_EXERCISE_SETTINGS_CHANGE_RANGE_VALUE
} from "./settings/TreeExerciseSettingsActions";
import {
  IFetchContactsRequest,
  ISelectPersonPayload,
  TREE_DATA_FETCH_CONTACTS_SUCCEED,
  TREE_DATA_FETCH_PERSONS_SUCCEED,
  TREE_DATA_SELECT_PERSON,
  TREE_EXERCISE_VIEW_LEFT
} from "./TreeExerciseDataActions";

export interface ITreeExerciseDataReduxState {
  persons: IPerson[];
  selectedPersonId?: number;
  personsWithContacts: Map<number, IPersonWithContacts>;
}

export const treeExerciseDataReducer = (
  state: ITreeExerciseDataReduxState = initialState,
  action: { type: string; payload: any }
): ITreeExerciseDataReduxState => {
  switch (action.type) {
    case TREE_DATA_FETCH_PERSONS_SUCCEED:
      return onPersonsFetched(state, action.payload);

    case TREE_DATA_SELECT_PERSON:
      return onPersonSelected(state, action.payload);

    case TREE_DATA_FETCH_CONTACTS_SUCCEED:
      return onContactsFetched(state, action.payload);

    case TREE_EXERCISE_SETTINGS_CHANGE_RANGE_TYPE:
    case TREE_EXERCISE_SETTINGS_CHANGE_RANGE_VALUE:
      return onSettingsChanged(state);

    case TREE_EXERCISE_VIEW_LEFT:
      return initialState;

    default:
      return state;
  }
};

const initialState: ITreeExerciseDataReduxState = {
  persons: [],
  selectedPersonId: null,
  personsWithContacts: new Map<number, IPersonWithContacts>()
};

const onPersonsFetched = (
  state: ITreeExerciseDataReduxState,
  payload: IResponse<IPerson[]>
): ITreeExerciseDataReduxState => {
  const items = payload.data;
  sortByName(items);

  return {
    ...state,
    persons: payload.data
  };
};

const onPersonSelected = (
  state: ITreeExerciseDataReduxState,
  payload: ISelectPersonPayload
): ITreeExerciseDataReduxState => {
  if (payload.personId === state.selectedPersonId) {
    return state;
  }

  return {
    ...state,
    selectedPersonId: payload.personId
  };
};

const onContactsFetched = (
  state: ITreeExerciseDataReduxState,
  payload: IResponseWrapper<IFetchContactsRequest, IPersonWithContacts>
): ITreeExerciseDataReduxState => {
  const response = payload.response.data;
  const personsWithContacts = state.personsWithContacts;
  personsWithContacts.set(response.personId, response);

  return {
    ...state
  };
};

const onSettingsChanged = (
  state: ITreeExerciseDataReduxState
): ITreeExerciseDataReduxState => {
  state.personsWithContacts.clear();

  return {
    ...state
  };
};

export const getTreeExerciseState = (
  state: IRootState
): ITreeExerciseDataReduxState => {
  return state.treeExercise.data;
};

export const getPersonContactsCount = (
  state: IRootState,
  personId: number
): number => {
  const personsMap = getPersonsMap(state);
  const person = personsMap.get(personId);

  return person && person.contactsCount ? person.contactsCount : 0;
};

export const getPersonWithContacts = (
  state: IRootState,
  personId: number
): IPersonWithContacts => {
  const { personsWithContacts } = getTreeExerciseState(state);
  return personsWithContacts.get(personId);
};

const getPersonsMap = createSelector(
  (rootState: IRootState) => getTreeExerciseState(rootState).persons,
  (persons: IPerson[]): Map<number, IPerson> => {
    const map = new Map<number, IPerson>();

    if (!persons) {
      return map;
    }

    for (const person of persons) {
      map.set(person.id, person);
    }

    return map;
  }
);

const sortByName = (items: IPerson[]) => {
  if (items) {
    items.sort((item1, item2) => {
      if (!item1.firstName || !item2.firstName) {
        return -1;
      }

      return item1.firstName.localeCompare(item2.firstName);
    });
  }
};
