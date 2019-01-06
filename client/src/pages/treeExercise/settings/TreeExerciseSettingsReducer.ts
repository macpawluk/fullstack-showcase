import { IRootState } from "../../../interfaces";
import { TREE_EXERCISE_VIEW_LEFT } from "./../TreeExerciseDataActions";
import {
  IChangeRangeTypePayload,
  IChangeRangeValuePayload,
  TREE_EXERCISE_SETTINGS_CHANGE_RANGE_TYPE,
  TREE_EXERCISE_SETTINGS_CHANGE_RANGE_VALUE
} from "./TreeExerciseSettingsActions";
import { TreeExerciseSettingsConstants as Constants } from "./TreeExerciseSettingsConstants";
import { SearchRangeType } from "./TreeExerciseSettingsTypes";

export interface ITreeExerciseSettingsReduxState {
  rangeValue: string;
  rangeType: SearchRangeType;
}

export const treeExerciseSettingsReducer = (
  state: ITreeExerciseSettingsReduxState = initialState,
  action: { type: string; payload: any }
): ITreeExerciseSettingsReduxState => {
  const { type, payload } = action;

  switch (type) {
    case TREE_EXERCISE_SETTINGS_CHANGE_RANGE_VALUE:
      return handleRangeValueChanged(state, payload);

    case TREE_EXERCISE_SETTINGS_CHANGE_RANGE_TYPE:
      return handleRangeTypeChanged(state, payload);

    case TREE_EXERCISE_VIEW_LEFT:
      return initialState;

    default:
      return state;
  }
};

const handleRangeValueChanged = (
  state: ITreeExerciseSettingsReduxState,
  payload: IChangeRangeValuePayload
): ITreeExerciseSettingsReduxState => {
  if (state.rangeValue === payload.range) {
    return state;
  }

  return {
    ...state,
    rangeValue: payload.range
  };
};

const handleRangeTypeChanged = (
  state: ITreeExerciseSettingsReduxState,
  payload: IChangeRangeTypePayload
): ITreeExerciseSettingsReduxState => {
  if (state.rangeType === payload.rangeType) {
    return state;
  }

  return {
    ...state,
    rangeType: payload.rangeType
  };
};

const initialState: ITreeExerciseSettingsReduxState = {
  rangeValue: Constants.RangeValueDefault.toString(),
  rangeType: SearchRangeType.LessOrEqual
};

export const getTreeExerciseSettingsState = (
  state: IRootState
): ITreeExerciseSettingsReduxState => {
  return state.treeExercise.settings;
};

export const getTreeExerciseSettingsRangeValue = (
  state: IRootState
): number => {
  const { rangeValue } = getTreeExerciseSettingsState(state);

  if (isRangeValueValid(rangeValue)) {
    return parseInt(rangeValue, 10);
  }

  return null;
};

export const isRangeValueValid = (rangeValue: string): boolean => {
  if (isNaN(Number(rangeValue))) {
    return false;
  }
  const rangeValueNumber = parseInt(rangeValue, 10);

  return (
    !!rangeValue &&
    Number.isInteger(rangeValueNumber) &&
    rangeValueNumber >= Constants.RangeValueMin &&
    rangeValueNumber <= Constants.RangeValueMax
  );
};
