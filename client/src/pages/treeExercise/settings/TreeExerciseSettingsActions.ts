import { Dispatch } from "redux";
import { IRootState } from "../../../interfaces";
import { fetchContactsAction } from "./../TreeExerciseDataActions";
import { SearchRangeType } from "./TreeExerciseSettingsTypes";

export const TREE_EXERCISE_SETTINGS_CHANGE_RANGE_VALUE =
  "@App/TreeExerciseSettings/CHANGE_RANGE_VALUE";
export const TREE_EXERCISE_SETTINGS_CHANGE_RANGE_TYPE =
  "@App/TreeExerciseSettings/CHANGE_RANGE_TYPE";

export interface IChangeRangeValuePayload {
  range: string;
}
export const changeRangeValue = (payload: IChangeRangeValuePayload) => {
  return (dispatch: Dispatch, getState: () => IRootState) => {
    dispatch({
      type: TREE_EXERCISE_SETTINGS_CHANGE_RANGE_VALUE,
      payload
    });
    fetchContactsAction()(dispatch, getState);
  };
};

export interface IChangeRangeTypePayload {
  rangeType: SearchRangeType;
}
export const changeRangeType = (payload: IChangeRangeTypePayload) => {
  return (dispatch: Dispatch, getState: () => IRootState) => {
    dispatch({
      type: TREE_EXERCISE_SETTINGS_CHANGE_RANGE_TYPE,
      payload
    });
    fetchContactsAction()(dispatch, getState);
  };
};
