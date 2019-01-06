import { IRootState } from "./../../../interfaces";
import {
  getRequestActionKey,
  isRequestAction,
  isResponseAction
} from "./../AjaxRequestsHelpers";

export interface ILoaderReduxState {
  active: boolean;
  activeCalls: Map<string, number>;
}

interface IAction {
  type: string;
  payload: any;
}

export const loaderReducer = (
  state: ILoaderReduxState = initialState,
  action: IAction
): ILoaderReduxState => {
  if (isRequestAction(action)) {
    return onRequestAction(state, action);
  }

  if (isResponseAction(action)) {
    return onResponseAction(state, action);
  }

  return state;
};

const onRequestAction = (state: ILoaderReduxState, action: IAction) => {
  const { activeCalls } = state;
  const requestKey = getRequestActionKey(action) as string;

  if (!activeCalls.get(requestKey)) {
    activeCalls.set(requestKey, 0);
  }

  activeCalls.set(requestKey, (activeCalls.get(requestKey) as number) + 1);

  return {
    ...state,
    active: isAnyActiveCall(activeCalls),
    activeCalls
  };
};

const onResponseAction = (state: ILoaderReduxState, action: IAction) => {
  const { activeCalls } = state;
  const requestKey = getRequestActionKey(action) as string;

  if (!activeCalls.get(requestKey)) {
    return state;
  }

  activeCalls.set(requestKey, (activeCalls.get(requestKey) as number) - 1);

  return {
    ...state,
    active: isAnyActiveCall(activeCalls),
    activeCalls
  };
};

const isAnyActiveCall = (activeCalls: Map<string, number>) => {
  return !!Array.from(activeCalls).find(entry => entry[1] > 0);
};

const initialState: ILoaderReduxState = {
  active: false,
  activeCalls: new Map<string, number>()
};

export const getLoaderState = (globalState: IRootState) => {
  return globalState.sharedComponents.loader;
};
