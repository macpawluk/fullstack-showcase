import { IAction, IRootState } from "./../../../interfaces";
import { isRequestRejected, isResponseAction } from "./../AjaxRequestsHelpers";
import { REQUEST_ERROR_PROMPT_CLEAR_ERROR } from "./RequestErrorPromptActions";

export interface IRequestErrorPromptReduxState {
  showError: boolean;
}

export const requestErrorPromptReducer = (
  state: IRequestErrorPromptReduxState = initialState,
  action: IAction
): IRequestErrorPromptReduxState => {
  if (isResponseAction(action)) {
    return onResponseAction(state, action);
  }

  switch (action.type) {
    case REQUEST_ERROR_PROMPT_CLEAR_ERROR:
      return onClearError(state);

    default:
      return state;
  }
};

const onResponseAction = (
  state: IRequestErrorPromptReduxState,
  action: IAction
) => {
  if (isRequestRejected(action) && !state.showError) {
    return {
      ...state,
      showError: true
    };
  }

  return state;
};

const onClearError = (state: IRequestErrorPromptReduxState) => {
  if (!state.showError) {
    return state;
  }

  return {
    ...state,
    showError: false
  };
};

const initialState: IRequestErrorPromptReduxState = {
  showError: false
};

export const getRequestErrorPromptState = (
  globalState: IRootState
): IRequestErrorPromptReduxState => {
  return globalState.sharedComponents.requestErrorPrompt;
};
