import * as React from "react";
import { connect } from "react-redux";
import * as Redux from "redux";

import { IRootState } from "./../../../interfaces";
import { SlideBanner } from "./../../components";
import { clearErrorAction } from "./RequestErrorPromptActions";
import {
  getRequestErrorPromptState,
  IRequestErrorPromptReduxState
} from "./RequestErrorPromptReducer";

interface IRequestErrorPromptContainerProps
  extends IRequestErrorPromptReduxState,
    IRequestErrorPromptContainerDispatch {}

interface IRequestErrorPromptContainerDispatch {
  clearError: () => void;
}

class RequestErrorPromptContainer extends React.Component<
  IRequestErrorPromptContainerProps,
  {}
> {
  public render(): JSX.Element {
    const { children, showError } = this.props;

    return (
      <SlideBanner
        header="Request error"
        show={showError}
        onBannerClosed={this.props.clearError}
      >
        {children}
      </SlideBanner>
    );
  }
}

const mapStateToProps = (state: IRootState): IRequestErrorPromptReduxState => {
  return getRequestErrorPromptState(state);
};

const mapDispatchToProps = (
  dispatch: Redux.Dispatch
): IRequestErrorPromptContainerDispatch =>
  Redux.bindActionCreators(
    {
      clearError: clearErrorAction
    },
    dispatch
  );

export const RequestErrorPrompt = connect<
  IRequestErrorPromptReduxState,
  IRequestErrorPromptContainerDispatch,
  {},
  IRootState
>(
  mapStateToProps,
  mapDispatchToProps
)(RequestErrorPromptContainer);
