import * as React from "react";
import { connect } from "react-redux";
import { Loader as SemanticLoader } from "semantic-ui-react";

import { IRootState } from "./../../../interfaces";
import "./Loader.scss";
import { getLoaderState } from "./LoaderReducer";

interface ILoaderContainerReduxMergeState {
  active: boolean;
}

class LoaderContainer extends React.PureComponent<
  ILoaderContainerReduxMergeState,
  {}
> {
  public render(): JSX.Element {
    const { active } = this.props;

    if (!active) {
      return null;
    }

    return (
      <div className="loader__container">
        <SemanticLoader active={active} />
      </div>
    );
  }
}

const mapStateToProps = (
  state: IRootState
): ILoaderContainerReduxMergeState => {
  return {
    active: getLoaderState(state).active
  };
};

export const Loader = connect<
  ILoaderContainerReduxMergeState,
  {},
  {},
  IRootState
>(mapStateToProps)(LoaderContainer);
