import { IAction } from "./../../interfaces";

const requestSuffix = "_PENDING";
const successSuffix = "_FULFILLED";
const failureSuffix = "_REJECTED";

export const isRequestAction = (action: IAction) => {
  return action.type.endsWith(requestSuffix);
};

export const isResponseAction = (action: IAction) => {
  return isRequestSuccessful(action) || isRequestRejected(action);
};

export const isRequestSuccessful = (action: IAction) => {
  return action.type.endsWith(successSuffix);
};

export const isRequestRejected = (action: IAction) => {
  return action.type.endsWith(failureSuffix);
};

export const getRequestActionKey = (action: IAction): string => {
  const key = action.type;
  let suffix = null;

  if (key.endsWith(requestSuffix)) {
    suffix = requestSuffix;
  }
  if (key.endsWith(successSuffix)) {
    suffix = successSuffix;
  }
  if (key.endsWith(failureSuffix)) {
    suffix = failureSuffix;
  }
  if (!suffix) {
    return null;
  }

  return key.substring(0, action.type.length - suffix.length);
};
